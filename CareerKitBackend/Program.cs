using Betalgo.Ranul.OpenAI.Extensions;
using CareerKitBackend.Main.AIService.Service;
using CareerKitBackend.Main.APITrackerService.Service;
using CareerKitBackend.Main.CoverLetterService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddOpenAIService(); // Loads from config (e.g., appsettings or Render env vars)
builder.Services.AddScoped<OpenAIService>();
builder.Services.AddScoped<CoverLetterService>();
builder.Services.AddSingleton<TrackerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
