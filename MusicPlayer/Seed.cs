using MusicPlayer.Data;
using System.Diagnostics.Metrics;

namespace MusicPlayer
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
           
        }
    }
}
