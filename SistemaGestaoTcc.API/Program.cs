using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SistemaGestaoTcc.Application.Commands.Convites.EnviarConvite;
using SistemaGestaoTcc.Application.Commands.Courses.CreateCourse;
using SistemaGestaoTcc.Application.Commands.ProjectComment.CreateComment;
using SistemaGestaoTcc.Application.Commands.Projects.CreateProject;
using SistemaGestaoTcc.Application.Commands.Users.CreateUser;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;
using SistemaGestaoTcc.Infrastructure.Authentication;
using SistemaGestaoTcc.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddControllers();

//ADICIONANDO CORS PARA PODER SER CONSUMINDO NO FRONT-END
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemaGestaoTcc.API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header usando o esquema Bearer."
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
            new string[] {}
        }
    });
});

//CONNECTION STRING
var connection = builder.Configuration.GetConnectionString("SistemaTcc");
builder.Services.AddDbContext<SistemaTccContext>(p => p.UseSqlServer(connection));


//mediator injecao de dependencia
builder.Services.AddMediatR(typeof(CreateProjectCommand));
builder.Services.AddMediatR(typeof(CreateUserCommand));
builder.Services.AddMediatR(typeof(CreateCourseCommand));
builder.Services.AddMediatR(typeof(CreateCommentCommand));
builder.Services.AddMediatR(typeof(EnviarConviteCommand));

//repositorios injecao de dependencia
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProjectCommentRepository, ProjectCommentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IConviteRepository, ConviteRepository>();
builder.Services.AddScoped<IUsuarioProjetoRepository, UsuarioProjetoRepository>();
builder.Services.AddScoped<INotaRepository, NotaRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProjetoArquivoRepository, ProjetoArquivoRepository>();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//APLICANDO POLITICA CORS
app.UseCors();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

