using ArmazingXStock.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // a aplicação está sendo criada com base nos argumentos passados para o programa. O método CreateBuilder é responsável por configurar a aplicação, incluindo serviços, configuração e logging.

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); 

builder.Services.AddSwaggerGen();// Adiciona o serviço Swagger para geração de documentação da API.

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ArmazingXStockContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // Adiciona o middleware Swagger para gerar a documentação da API em tempo de execução.
    app.UseSwagger();

    // Adiciona o middleware Swagger UI para fornecer uma interface web interativa para explorar a documentação da API.
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
