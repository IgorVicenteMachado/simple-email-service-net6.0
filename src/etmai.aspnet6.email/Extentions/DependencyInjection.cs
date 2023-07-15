using etmai.aspnet6.email.Services;

namespace etmai.aspnet6.email.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection LoadDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<INotification, Notification>();
            return services;
        }
        public static void LoadSecretsValues(this WebApplicationBuilder builder)
        {
            SecretsValues.smtpPassword = builder.Configuration.GetValue<string>("smtpPassword");
            SecretsValues.smtpUser = builder.Configuration.GetValue<string>("smtpUser");
            SecretsValues.emailTo = builder.Configuration.GetValue<string>("emailTo");
        }
    }
}
