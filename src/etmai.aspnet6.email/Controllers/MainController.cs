using etmai.aspnet6.email.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace etmai.aspnet6.email.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotification _notificador;

        protected MainController(INotification notificador)
        {
            _notificador = notificador;
        }

        protected ActionResult CustomResponse(object obj = null)
        {
            if(obj != null && obj.GetType() == typeof(ModelStateDictionary))
            {
                ModelStateDictionary modelstate = (ModelStateDictionary)obj;
                var erros = modelstate.Values.SelectMany(e => e.Errors);
                foreach (var erro in erros)
                {
                    var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                    _notificador.Handle(erroMsg);
                }
            }

            if (!_notificador.HasAnyNotification())
            {
                return Ok(new
                {
                    success = true,
                    data = obj
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificador.GetNotifications()
            });
        }

        protected void AddNotification(string errormsg) => _notificador.Handle(errormsg);
    }
}
