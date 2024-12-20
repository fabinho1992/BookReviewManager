using BookReviewManager.Application.FluentValidation.UserValidation;
using BookReviewManager.Application.IServiceReport;
using BookReviewManager.Domain.IRepositories;
using BookReviewManager.Domain.IServices;
using BookReviewManager.Domain.IServices.Autentication;
using BookReviewManager.Infrastructure.DataContext;
using BookReviewManager.Infrastructure.IdentityToken;
using BookReviewManager.Infrastructure.Repositories;
using BookReviewManager.Infrastructure.Service;
using BookReviewManager.Infrastructure.Service.Identity;
using FastReport.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

            //Identity
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<BookManagerContextIdentity>()
                .AddDefaultTokenProviders();

            //Jwt Token
            var secretKey = configuration["Jwt:SecretKey"] ?? throw new ArgumentException("Invalid secret Key ..");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // desafio de solicitar o token
            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true; // salvar o token
                opt.RequireHttpsMetadata = true; // se é preciso https para transmitir o token , em produçao é true
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidAudience = configuration["Jwt:ValidAudience"],
                    ValidIssuer = configuration["Jwt:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

                };
            });

            //Politicas que serão usadas para acessar os endpoints
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("Admin", policy => policy.RequireRole("Admin"));

                //opt.AddPolicy("SuperAdmin", policy => policy.RequireClaim("id", "fabio"));

                opt.AddPolicy("User", policy => policy.RequireRole("User"));


            }
            );

            //FastReport
            services.AddFastReport();
            FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

            //Injections Dependency
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAssessmentRepository, AssessmentsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenerateDataTableReport, GenerateDataTableReport>();
            services.AddScoped<ICreateUser, CreateUser>();
            services.AddScoped<ICreateRole, CreateRole>();
            services.AddScoped<ILoginUser, LoginUser>();
            services.AddScoped<IAddRole, AddRole>();
            services.AddScoped<ITokenService, TokenService>();

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

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3001")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            return services;
        }
    }
}
