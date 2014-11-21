using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows.Forms;

namespace real_robot_battle
{
    public class Sound
    {
        SoundPlayer player = null;
        
        public Sound()
        {
        }

        ~Sound()
        {
            StopSound();
        }

        public void Play(string fileName)
        {
            if (player != null)
            {
                StopSound();
            }
            player = new SoundPlayer(fileName);
            try
            {
                player.Play();
            }
            catch
            {
                MessageBox.Show("音声ファイル:" + fileName + "が見つかりません");
            }
        }

        private void StopSound()
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }
    }
}
