using Backend.Models;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;
//using MySql.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var connectionString = builder.Configuration.GetConnectionString("defaultconnection");

builder.Services.AddDbContext<ClientDBContext>(opts => opts.UseMySql(connectionString,
    MySqlServerVersion.LatestSupportedServerVersion));

builder.Services.AddDbContext<LoanRequestDBContext>(opts => opts.UseMySql(connectionString,
    MySqlServerVersion.LatestSupportedServerVersion));

builder.Services.AddDbContext<LoanDBContext>(opts => opts.UseMySql(connectionString,
    MySqlServerVersion.LatestSupportedServerVersion));

builder.Services.AddDbContext<PaymentDBContext>(opts => opts.UseMySql(connectionString,
    MySqlServerVersion.LatestSupportedServerVersion));

builder.Services.AddScoped<IClientRepo, ClientRepo>();
builder.Services.AddScoped<ILoanRequestRepo, LoanRequestRepo>();
builder.Services.AddScoped<ILoanRepo, LoanRepo>();
builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();
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

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
