using TP1.Data;
using Microsoft.EntityFrameworkCore;
using TP1.Services;
using TP1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Ajouter le DbContext à l'injection de dépendances
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// Service Injection
builder.Services.AddScoped<IEvenementService, EvenementService>();
builder.Services.AddScoped<IEvenementParticipantService, EvenementParticipantService>();
// Repository Injection
builder.Services.AddScoped<IEvenementRepository, EvenementRepository>();
builder.Services.AddScoped<IEvenementParticipantRepository, EvenementParticipantRepository>();
builder.Services.AddScoped<IIntervenantRepository, IntervenantRepository>();
builder.Services.AddScoped<ILieuRepository, LieuRepository>();
builder.Services.AddScoped<INotationRepository, NotationRepository>();
builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();
builder.Services.AddScoped<ISalleRepository, SalleRepository>();
builder.Services.AddScoped<ISessionIntervenantRepository, SessionIntervenantRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();


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
