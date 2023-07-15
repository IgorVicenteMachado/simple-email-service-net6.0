namespace etmai.aspnet6.email.Extentions
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Production",
                    builder =>
                        builder
                        .WithOrigins("https://www.etmai.com.br/")
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            return services;
        }
        public static IApplicationBuilder UseCorsConfiguration(this IApplicationBuilder app)
        {
            app.UseCors("Production");
            app.UseHsts();
            return app;
        }
    } 
}
