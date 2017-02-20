using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_39
{
    public class MediaPlayer
    {
        private const int MaxLength = 1000;
        private string[] songsLeft;
        private string[] songsPlayed;
        private int counterLeft;
        private int counterPlayed;
        private Random random;

        public MediaPlayer()
        {
            this.songsLeft = new string[MaxLength];
            this.songsPlayed = new string[MaxLength];
            this.counterLeft = 0;
            this.counterPlayed = 0;
            this.CurrentSong = null;
            this.random = new Random();
        }

        public bool Repeat { get; set; }

        public string CurrentSong { get; private set; }

        public void AddSong(string song)
        {
            this.songsLeft[this.counterLeft++] = song;
        }

        public void NextSong()
        {
            if (this.CurrentSong == null && this.counterLeft + this.counterPlayed == 0)
            {
                return;
            }

            if (this.CurrentSong != null && this.counterLeft == 0)
            {
                if (this.Repeat && this.counterPlayed > 0)
                {
                    this.Reload();
                    string buffer = this.CurrentSong;
                    this.CurrentSong = this.TakeSong();
                    this.AddSong(buffer);
                }
                else 
                {
                    this.MarkSongAsPlayed(this.CurrentSong);
                    this.CurrentSong = null;

                    if (this.Repeat)
                    {
                        this.Reload();
                    }
                }

                return;
            }

            if (this.CurrentSong != null)
            {
                this.MarkSongAsPlayed(this.CurrentSong);
            }

            this.CurrentSong = this.TakeSong();
        }

        public void Reload()
        {
            for (int i = 0; i < this.counterPlayed; i++)
            {
                this.AddSong(this.songsPlayed[i]);
            }

            this.counterPlayed = 0;
        }

        private string TakeSong()
        {
            if (this.counterLeft == 0)
            {
                return null;
            }

            int index = this.random.Next(0, this.counterLeft);
            string result = this.songsLeft[index];

            this.songsLeft[index] = this.songsLeft[--this.counterLeft];

            return result;
        }

        private void MarkSongAsPlayed(string song)
        {
            this.songsPlayed[this.counterPlayed++] = song;
        }
    }
}
