using etmai.aspnet6.email.Models.ViewModels;
using etmai.aspnet6.email.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace etmai.aspnet6.email.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : MainController
    {
        private readonly IEmailService _emailService;
        private readonly IMemoryCache _cache;
        
        public EmailController(IEmailService emailService, IMemoryCache cache, INotification notificador)
            : base(notificador)
        {
            _emailService = emailService;
            _cache = cache;
        }


        [HttpPost]
        public async Task<IActionResult> SendAsync([FromBody] DuvidaViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (_cache.TryGetValue(viewModel.Email, out DuvidaViewModel vm))
            {
                var elapsedTime = viewModel.Date - vm.Date;
                if (elapsedTime.Minutes <= 5)
                {
                    AddNotification("Você enviou uma mensagem recentemente! Aguarde alguns minutos e tente novamente.");
                    return CustomResponse();
                }
            }

            _cache.Set(viewModel.Email, viewModel);

            _emailService.SendEmail(viewModel.Email, viewModel.Mensagem);

            return CustomResponse("Email enviado com sucesso!");
        }
    }
}
