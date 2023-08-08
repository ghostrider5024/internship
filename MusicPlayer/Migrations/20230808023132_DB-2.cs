using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicPlayer.Migrations
{
    public partial class DB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongArtists_Artists_ArtistId",
                table: "SongArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_SongArtists_Songs_SongId",
                table: "SongArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_SongPlaylists_Playlists_PlaylistId",
                table: "SongPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_SongPlaylists_Songs_SongId",
                table: "SongPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongPlaylists",
                table: "SongPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongArtists",
                table: "SongArtists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Playlists",
                table: "Playlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artists",
                table: "Artists");

            migrationBuilder.RenameTable(
                name: "Songs",
                newName: "Song");

            migrationBuilder.RenameTable(
                name: "SongPlaylists",
                newName: "SongPlaylist");

            migrationBuilder.RenameTable(
                name: "SongArtists",
                newName: "SongArtist");

            migrationBuilder.RenameTable(
                name: "Playlists",
                newName: "Playlist");

            migrationBuilder.RenameTable(
                name: "Artists",
                newName: "Artist");

            migrationBuilder.RenameIndex(
                name: "IX_SongPlaylists_PlaylistId",
                table: "SongPlaylist",
                newName: "IX_SongPlaylist_PlaylistId");

            migrationBuilder.RenameIndex(
                name: "IX_SongArtists_ArtistId",
                table: "SongArtist",
                newName: "IX_SongArtist_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Song",
                table: "Song",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongPlaylist",
                table: "SongPlaylist",
                columns: new[] { "SongId", "PlaylistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongArtist",
                table: "SongArtist",
                columns: new[] { "SongId", "ArtistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playlist",
                table: "Playlist",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artist",
                table: "Artist",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtist_Artist_ArtistId",
                table: "SongArtist",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtist_Song_SongId",
                table: "SongArtist",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongPlaylist_Playlist_PlaylistId",
                table: "SongPlaylist",
                column: "PlaylistId",
                principalTable: "Playlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongPlaylist_Song_SongId",
                table: "SongPlaylist",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongArtist_Artist_ArtistId",
                table: "SongArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_SongArtist_Song_SongId",
                table: "SongArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_SongPlaylist_Playlist_PlaylistId",
                table: "SongPlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_SongPlaylist_Song_SongId",
                table: "SongPlaylist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongPlaylist",
                table: "SongPlaylist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongArtist",
                table: "SongArtist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Song",
                table: "Song");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Playlist",
                table: "Playlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artist",
                table: "Artist");

            migrationBuilder.RenameTable(
                name: "SongPlaylist",
                newName: "SongPlaylists");

            migrationBuilder.RenameTable(
                name: "SongArtist",
                newName: "SongArtists");

            migrationBuilder.RenameTable(
                name: "Song",
                newName: "Songs");

            migrationBuilder.RenameTable(
                name: "Playlist",
                newName: "Playlists");

            migrationBuilder.RenameTable(
                name: "Artist",
                newName: "Artists");

            migrationBuilder.RenameIndex(
                name: "IX_SongPlaylist_PlaylistId",
                table: "SongPlaylists",
                newName: "IX_SongPlaylists_PlaylistId");

            migrationBuilder.RenameIndex(
                name: "IX_SongArtist_ArtistId",
                table: "SongArtists",
                newName: "IX_SongArtists_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongPlaylists",
                table: "SongPlaylists",
                columns: new[] { "SongId", "PlaylistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongArtists",
                table: "SongArtists",
                columns: new[] { "SongId", "ArtistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playlists",
                table: "Playlists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artists",
                table: "Artists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtists_Artists_ArtistId",
                table: "SongArtists",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtists_Songs_SongId",
                table: "SongArtists",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongPlaylists_Playlists_PlaylistId",
                table: "SongPlaylists",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongPlaylists_Songs_SongId",
                table: "SongPlaylists",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
