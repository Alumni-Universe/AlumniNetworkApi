using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Owin.Security.Keycloak;
using Microsoft.Extensions.Configuration;
using PathString = Microsoft.Owin.PathString;

[assembly: OwinStartup(typeof(AlumniNetworkApi.Startup))]

namespace AlumniNetworkApi
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            AppConfiguration = builder.Build();
        }

        public void Configuration(IAppBuilder app)
        {
            // Configure cookie authentication for local sign-in
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login"),
                LogoutPath = new PathString("/Account/Logout")
            });

            // Configure Keycloak authentication
            app.UseKeycloakAuthentication(new KeycloakAuthenticationOptions
            {
                Realm = AppConfiguration["Keycloak:Realm"],
                ClientId = AppConfiguration["Keycloak:ClientId"],
                ClientSecret = AppConfiguration["Keycloak:ClientSecret"],
                KeycloakUrl = AppConfiguration["Keycloak:Url"],
                AuthenticationType = "Keycloak",
                SignInAsAuthenticationType = "ApplicationCookie"
            });

            // Configure CORS (if needed)
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }
}
