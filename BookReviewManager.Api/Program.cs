

using BookReviewManager.Api.ErrosMiddleware;
using BookReviewManager.Extensions.Dependencies;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDependencyInjection(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {


    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "V1",
        Title = "Book review Manager",
        Description = "API that allows you to manage the creation and evaluation of books",
        Contact = new OpenApiContact
        {
            Name = "Fabio dos Santos",
            Email = "f.santosdev1992@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/f%C3%A1bio-dos-santos-518612275/")
        }

    });



    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
       {
          new OpenApiSecurityScheme
          {
              Reference = new OpenApiReference
               {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
               }
           },
               new string[] {}
       }
    });

    //incluindo comentario XML
    //nome:
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors();


app.UseMiddleware(typeof(ErroMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();


app.UseFastReport();

app.MapControllers();

app.Run();
