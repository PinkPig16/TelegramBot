using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using Telegram.Bot;
using TelegramParse.Data;
using TelegramParse.Entity.Mapping;
using TelegramParse.Interfaces;
using TelegramParse.Parse;
using TelegramParse.Repository;
using TelegramParse.Service;
using TelegramParse.TelegramOperation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.Configure<TelegramConfigModel>(builder.Configuration.GetSection("TelegramBot"));
builder.Services.AddScoped<ICommands,StartCommand>();
builder.Services.AddScoped<CommandsRegistry>();
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
builder.Services.AddScoped<IMessage,MessageOperation>();
builder.Services.AddSingleton<ILoggerError,ConsoleLogger>();
builder.Services.AddHostedService<TelegramBotClientService>();
builder.Services.AddScoped<Run>();
builder.Services.AddSingleton<TelegramBotClientService>();
builder.Services.AddSingleton<HtmlWeb>();
/*builder.Services.AddSingleton<TelegramBotClientService>();

// Register the TelegramBotClient as a singleton using the factory
builder.Services.AddSingleton<TelegramBotClient>(provider =>
    provider.GetRequiredService<TelegramBotClientService>().CreateClient());
*/
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddDbContext<ApplicationDB>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
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
