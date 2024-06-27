using Bot.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var botToken = "7263798544:AAFdzx8K35pJ86meX2J-FwPlI2eMfUmzsR8";
builder.Services.AddSingleton<BotService>(provider =>
{
    var logger = provider.GetRequiredService<ILogger<BotService>>();
    return new BotService(botToken, logger);
});
builder.Services.AddHostedService<BotBackgroundService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
