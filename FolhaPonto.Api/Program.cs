using FolhaPonto.Domain.Interfaces;
using FolhaPonto.Domain.Services;
using FolhaPonto.Infra.Contexto;
using FolhaPonto.Infra.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nome da Sua API", Version = "v1" });

    // Configuração da autorização (Bearer Token)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    }
                                },
                                Array.Empty<string>()
                            }
                        });
});

builder.Services.AddDbContext<AppDbContext>();

//services
builder.Services.AddTransient<IUsersServices, UsersService>();
builder.Services.AddTransient<ICollaboratorsService, CollaboratorsService>();
builder.Services.AddTransient<ITimeTrackersService, TimeTrackersService>();
builder.Services.AddTransient<ITasksService, TasksService>();
builder.Services.AddTransient<IProjectsService, ProjectsService>();

//Repositorys
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<ICollaboratorsRepository, CollaboratorsRepository>();
builder.Services.AddTransient<ITimeTrackersRepository, TimeTrackersRepository>();
builder.Services.AddTransient<ITasksRepository, TasksRepository>();
builder.Services.AddTransient<IProjectsRepository, ProjectsRepository>();

var config = builder.Configuration;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
   options.TokenValidationParameters = new TokenValidationParameters
   {
       ValidateIssuer = true,
       ValidateAudience = true,
       ValidateLifetime = true,
       ValidateIssuerSigningKey = true,
       ValidIssuer = config["Jwt:Issuer"],
       ValidAudience = config["Jwt:Audience"],
       IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(config["Jwt:Key"]))
   };
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
