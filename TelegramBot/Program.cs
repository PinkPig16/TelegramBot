using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using TelegramParse.Data;
using TelegramParse.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<TelegramBotClientOptions>(builder.Configuration.GetSection("TelegramBotOptions"));
builder.Services.AddSingleton<TelegramBotClient>(provider =>
{ 
    var options = provider.GetRequiredService<IOptions<TelegramBotClientOptions>>().Value;
    return new SetWebhook(options);
});
builder.Services.AddDbContext<ApplicationDB>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddSingleton<TelegramBot>();
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
