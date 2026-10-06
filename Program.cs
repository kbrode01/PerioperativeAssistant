using Microsoft.EntityFrameworkCore;
using PerioperativeAssistant.Data;
using PerioperativeAssistant.Services;
using PerioperativeAssistant.Ingestion.Synthetic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// === Azure SQL Connection with Retry Logic ===
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }));
builder.Services.AddScoped<SurgicalScheduleIngestionService>();
builder.Services.AddScoped<SyntheticScheduleCsvAdapter>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("openapi", new()
    {
        Title = "Perioperative Assistant",
        Description = "API for perioperative resource forecasting and operational planning."
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()|| app.Environment.IsProduction())
{
    app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		options.SwaggerEndpoint(
			"/swagger/openapi/swagger.json",
			"Perioperative Assistant");
	});
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();