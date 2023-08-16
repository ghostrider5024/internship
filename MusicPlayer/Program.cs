using MusicPlayer;
using MusicPlayer.Data;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using MusicPlayer.Controllers;
using MusicPlayer.Repositories;
using MusicPlayer.Services;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver =
        new DefaultContractResolver();
    options.SerializerSettings.ReferenceLoopHandling =
        ReferenceLoopHandling.Ignore;
});
// Add services to the container.
builder.Services.AddTransient<Seed>();
//Add DI
AddDI(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "bearer token",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    opt.OperationFilter<SecurityRequirementsOperationFilter>();
});
//builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddDbContext<DataContext>();

#region Authentication and Authorization
builder.Services.AddAuthentication(op =>
{
    op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(op =>
{
    op.SaveToken = true;
    op.RequireHttpsMetadata = false;
    op.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:ValidAudience"],
        ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecureKey"]))
    };
});


// Authorization
//builder.Services.AddAuthorization(op =>
//{
//    op.AddPolicy("DepartmentPolicy", policy => policy.RequireClaim("department"));
//});
builder.Services.AddAuthorization();


#endregion Authentication and Authorization

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }

}

void AddDI(IServiceCollection services)
{
    #region Song
    services.AddScoped<SongRepository>();
    services.AddScoped<ISongService, SongService>();
    #endregion

    #region Artist
    services.AddScoped<ArtistRepository>();
    services.AddScoped<IArtistService, ArtistService>();
    #endregion

    #region SongArtist
    services.AddScoped<SongArtistRepository>();
    services.AddScoped<ISongArtistService, SongArtistService>();
    #endregion

    #region Playlist
    services.AddScoped<PlaylistRepository>();
    services.AddScoped<IPlaylistService, PlaylistService>();
    #endregion

    #region User
    services.AddScoped<UserRepository>();
    services.AddScoped<IUserService, UserService>();
    #endregion

    services.AddAutoMapper(typeof(Program).Assembly);
}