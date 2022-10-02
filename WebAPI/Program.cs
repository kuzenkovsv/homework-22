using Microsoft.AspNetCore.Mvc.Formatters;
using PhoneBookEntitiesLib;
using PhoneBookContextLib;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using WebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PhoneBooksContext>();

//builder.Services.AddControllers();

builder.Services.AddControllers().AddXmlDataContractSerializerFormatters().AddXmlSerializerFormatters();

//builder.Services.AddControllers(options =>
//{
//    WriteLine("Default output formatters:");
//    foreach (IOutputFormatter formatter in options.OutputFormatters)
//    {
//        OutputFormatter? mediaFormatter = formatter as OutputFormatter;
//        if (mediaFormatter == null)
//        {
//            WriteLine($"{formatter.GetType().Name}");
//        }
//        else
//        {
//            WriteLine("{ 0}, Media types: { 1}", arg0: mediaFormatter.GetType().Name,
//                arg1: string.Join(", ", mediaFormatter.SupportedMediaTypes));
//        }
//    }
//}).AddXmlDataContractSerializerFormatters().AddXmlSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Регистрация репозитория контактов и телефонных книжек
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
