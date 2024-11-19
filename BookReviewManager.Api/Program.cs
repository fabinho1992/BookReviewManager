

using BookReviewManager.Api.ErrosMiddleware;
using BookReviewManager.Extensions.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDependencyInjection(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(ErroMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();


app.UseFastReport();

app.MapControllers();

app.Run();
