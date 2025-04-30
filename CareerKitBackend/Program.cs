using Betalgo.Ranul.OpenAI.Extensions;
using CareerKitBackend.Main.AIService.Service;
using CareerKitBackend.Main.APITrackerService.Service;
using CareerKitBackend.Main.CoverLetterService.Service;
using CareerKitBackend.Main.InterviewService.Service;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// External services
builder.Services.AddOpenAIService(); // Loads from config (e.g., appsettings or Render env vars)

// Internal services (Scoped)
builder.Services.AddScoped<OpenAIService>();
builder.Services.AddScoped<CoverLetterService>();
builder.Services.AddScoped<InterviewService>();

// Internal services (Singleton)
builder.Services.AddSingleton<TrackerService>();

// CORS
builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy =>
	{
		policy
			.WithOrigins("http://127.0.0.1:5500") // frontend local origins
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(); // Enable CORS before routing

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
