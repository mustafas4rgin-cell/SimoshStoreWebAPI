using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using SimoshStore;
using SimoshStoreAPI;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessService(this IServiceCollection services)
    {

        services.AddHttpContextAccessor();

        var validatorAssemblies = ValidatorAssemblyProvider.GetValidatorAssemblies();
        foreach (var assemblyType in validatorAssemblies)
        {
            services.AddValidatorsFromAssemblyContaining(assemblyType);
        }

        ServiceRegistrationProvider.RegisterServices(services);

        return services;
    }
}
