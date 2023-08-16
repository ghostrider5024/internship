using AutoMapper;
using MusicPlayer.Models;
using MusicPlayer.Models.RequestModels;
using MusicPlayer.Models.ResponseModels;

namespace MusicPlayer.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            MapSong();
            MapArtist();
            MapSongArtist();
            MapPlaylist();
            MapSongPlaylist();
            MapUser();
        }

        private void MapSong()
        {
            CreateMap<Song, SongResponse>()
             //.ForMember(dest => dest.Artists, opt => opt.MapFrom(src => src.SongArtists.Select(sc => sc.ArtistId)))
             //.ForMember(dest => dest.Playlists, opt => opt.MapFrom(src => src.SongPlaylists.Select(sc => sc.PlaylistId)))
             .ReverseMap();

        }

        private void MapArtist()
        {
            CreateMap<Artist, ArtistResponse>().ReverseMap();
        }

        private void MapSongArtist()
        {
            CreateMap<SongArtist, SongArtistResponse>().ReverseMap();
        } 
        
        private void MapPlaylist()
        {
            CreateMap<Playlist, PlaylistResponse>().ReverseMap();
        }

        private void MapSongPlaylist()
        {
            CreateMap<SongPlaylist, SongPlaylistResponse>().ReverseMap();
        }
        private void MapUser()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, LoginRequest>().ReverseMap();
            CreateMap<User, UserRequest>().ReverseMap();
        }

    }
}
