using MusicPlayer;
using MusicPlayer.Data;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using MusicPlayer.Controllers;
using MusicPlayer.Repositories;
using MusicPlayer.Services;

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
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();

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

    services.AddAutoMapper(typeof(Program).Assembly);
}