using BookReviewManager.Application.FluentValidation.UserValidation;
using BookReviewManager.Application.IServiceReport;
using BookReviewManager.Domain.IRepositories;
using BookReviewManager.Domain.IServices;
using BookReviewManager.Infrastructure.DataContext;
using BookReviewManager.Infrastructure.Repositories;
using BookReviewManager.Infrastructure.Service;
using FastReport.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookReviewManager.Extensions.Dependencies
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {

            //Configuration Controllers
            services.AddControllers()
                .AddJsonOptions(op =>
                {
                    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());// mostra no Schemas do swagger os valores do enum
                    op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                })
                .AddNewtonsoftJson(op => op.SerializerSettings.Converters.Add(new StringEnumConverter()));

            //DbContext
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BookManagerContext>(opt =>
                            opt.UseSqlServer(connectionString));
            services.AddDbContext<BookManagerContextIdentity>(
                opt => opt.UseSqlServer(connectionString));

            //FastReport
            services.AddFastReport();
            FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

            //Injections Dependency
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAssessmentRepository, AssessmentsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenerateDataTableReport, GenerateDataTableReport>();

            services.Configure<KeyGoogloBooks>(configuration.GetSection("KeyGoogleBooksApi"));
            services.AddSingleton<string>(configuration["KeyGoogleBooksApi:KeyApi"]);
            services.AddScoped<IGoogleBookApi, GoogleBookApi>();

            //Fluent Validation
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateUserValidation>();

            //CQRS Injection
            var myHandlers = AppDomain.CurrentDomain.Load("BookReviewManager.Application");
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(myHandlers));

            return services;
        }
    }
}
