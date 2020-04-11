[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("YouStation.Platform.Infrastructure.UnitTests")]

namespace YouStation.Platform.Infrastructure.Extensions
{
    using Cryptography;
    using Domain.Cryptography;
    using Microsoft.Extensions.DependencyInjection;

    public static class StartupExtensions
    {
        private static IServiceCollection AddCryptography(this IServiceCollection services)
        {
            services.AddScoped<ISaltShakerProvider, SaltShakerProvider>();
            services.AddScoped<ICryptoProvider, RsaCryptoProvider>();
            services.AddScoped<IX509CertificateFactory, X509CertificateFactory>();

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddCryptography();

            return services;
        }
    }
}
