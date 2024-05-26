using Microsoft.EntityFrameworkCore;
using VinDecoderSalvageApi.DatabaseContext;
using VinDecoderSalvageApi.Interface;
using VinDecoderSalvageApi.Services;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddTransient<IVerificationService, TelesignVerificationService>();
builder.Services.AddTransient<IVinDecoderService, VinDecoderService>();
// Use mock services for testing
builder.Services.AddSingleton<IVerificationService, MockVerificationService>();
builder.Services.AddSingleton<IVinDecoderService, MockVinDecoderService>();


// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configure Kestrel server endpoints if necessary
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5010); // HTTP port
    options.ListenLocalhost(7286, listenOptions => listenOptions.UseHttps()); // HTTPS port
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
