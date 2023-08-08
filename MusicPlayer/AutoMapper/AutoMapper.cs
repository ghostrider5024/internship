using AutoMapper;
using MusicPlayer.Models;
using MusicPlayer.Models.ResponseModels;

namespace MusicPlayer.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            MapSong();
        }

        private void MapSong()
        {
            CreateMap<Song, SongResponse>()
             //.ForMember(dest => dest.Artists, opt => opt.MapFrom(src => src.SongArtists.Select(sc => sc.ArtistId)))
             //.ForMember(dest => dest.Playlists, opt => opt.MapFrom(src => src.SongPlaylists.Select(sc => sc.PlaylistId)))
             .ReverseMap();

        }
    }
}
