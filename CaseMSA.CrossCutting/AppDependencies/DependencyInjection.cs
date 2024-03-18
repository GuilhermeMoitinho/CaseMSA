using CaseMSA.Application.Validators;
using CaseMSA.Domain.Interfaces;
using CaseMSA.Infrastructure.Context;
using CaseMSA.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CaseMSA.CrossCutting.AppDependencies
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(
                           this IServiceCollection services)                                                                        
        {
            var connection = "MSA_connect";

            services.AddDbContext<AppDbcontext>
                                 (op => op.UseInMemoryDatabase(connection));

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            var myhandlers = AppDomain.CurrentDomain.Load("CaseMSA.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));



            services.AddFluentValidationAutoValidation()
                        .AddFluentValidationClientsideAdapters();
            
            services.AddValidatorsFromAssemblyContaining<CreateMemberCommandValidator>();


        }
    }
}
