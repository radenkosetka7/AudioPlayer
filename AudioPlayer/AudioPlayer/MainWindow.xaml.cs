using Microsoft.Win32;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace AudioPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        Dictionary<string, TimeSpan> mapSongs = new Dictionary<string, TimeSpan>();
        private  string[] files;
        private TimeSpan duration;
        private static int num = 0;
        private TimeSpan s;
        private RoutedEventArgs ex = new RoutedEventArgs();
        private bool isClikedFirstTime = true;
        private static int ticker=0;
        private bool repeat = true;
        private static List<string>  songs = new List<string>();
        
        public MainWindow()
        {
            InitializeComponent();
            btnPlay.Visibility = Visibility.Visible;
            btnPause.Visibility = Visibility.Hidden;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        public void btnFile_Click(object sender, RoutedEventArgs e)
        {

                    OpenFileDialog fileDialog = new OpenFileDialog();
                    fileDialog.Filter = "MP3 files (*.mp3)|*.mp3|MP4 files (*.mp4)|*.mp4";
                    fileDialog.Multiselect = true;
                    if (fileDialog.ShowDialog() == true)
                    {
                    files = fileDialog.FileNames;

                    }
            if (files!=null)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    if (songs.Contains(files[i]))
                    {
                        continue;
                    }
                    else
                    {
                        songs.Add(files[i]);
                    }
                }
                for (int i = 0; i < files.Length; i++)
                {
                    Mp3FileReader reader = new Mp3FileReader(files[i]);
                    duration = reader.TotalTime;

                    if (mapSongs.ContainsKey(files[i]))
                    {
                        continue;
                    }

                    else
                    {
                        mapSongs.Add(files[i], duration);

                    }
                    string[] linija = files[i].Split("\\");
                    if (num < 10)
                    {
                        Songs.Items.Add("0" + $"{ ++num}" + "\t" + linija[linija.Length - 1]);
                    }
                    else
                    {
                        Songs.Items.Add($"{ ++num}" + "\t" + linija[linija.Length - 1]);

                    }
                }
            }
            if(songs.Count>0)
            {
                btnStop.IsEnabled = true;
                btnPlay.IsEnabled = true;
                btnPause.IsEnabled = true;
                btnPRewind.IsEnabled = true;
                btnPNext.IsEnabled = true;
                btnRepeat.IsEnabled = true;
            }
        }

        void timerTick(object sender, EventArgs e)
        {
            lblCurrenttime.Content = string.Format("{0}:{1:00}", mediaPlayer.Position.Minutes, mediaPlayer.Position.Seconds);
            TimerSlider.Value = mediaPlayer.Position.TotalMilliseconds;
            if ((int)TimerSlider.Value >= (int)TimerSlider.Maximum)
            {
                if (repeat)
                {
                    TimerSlider.Value = 0;
                    btnPNext_Click(sender, ex);
                }
                else
                {
                    mediaPlayer.Position = TimeSpan.Zero;
                    mediaPlayer.Play();
                }
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (Songs.SelectedItem != null)
            {
                if(isClikedFirstTime)
                {
                    isClikedFirstTime = false;
                    for (int i = 0; i < songs.Count; i++)
                    {
                        string parts = (string)Songs.SelectedItem;
                        string[] par = parts.Split("\t");
                        if (songs[i].EndsWith(par[1]))
                        {
                            mediaPlayer.Open(new Uri(songs[i]));
                            lblCurrenttime.Content = 0.0;
                            TimerSlider.Minimum = 0.0;
                            lblSongname.Text = par[1];
                            foreach (KeyValuePair<string, TimeSpan> dic in mapSongs)
                            {
                                if (dic.Key.Contains(par[1]))
                                {
                                    s = dic.Value;
                                    break;
                                }
                            }
                            lblMusiclength.Content = string.Format("{0}:{1:00}", s.Minutes, s.Seconds);
                            TimerSlider.Maximum = s.TotalMilliseconds;
                            break;
                        }
                    }
                }
                mediaPlayer.Play();
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Tick += new EventHandler(timerTick);
                timer.Start();
                btnPlay.Visibility = Visibility.Hidden;
                btnPause.Visibility = Visibility.Visible;

            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            btnPlay.Visibility = Visibility.Visible;
            btnPause.Visibility = Visibility.Hidden;
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
            btnPlay.Visibility = Visibility.Visible;
            btnPause.Visibility = Visibility.Hidden;
        }

        private void Songs_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string song = (string)Songs.SelectedValue;
            string[] parts = song.Split("\t");
            for (int i = 0; i < songs.Count; i++)
            {
                if (songs[i].EndsWith(parts[1]))
                {
                    mediaPlayer.Open(new Uri(songs[i]));
                    lblCurrenttime.Content = 0.0;
                    TimerSlider.Minimum = 0.0;
                    string[] items = ((string)Songs.SelectedItem).Split("\t");
                    lblSongname.Text = items[1];
                    foreach(KeyValuePair<string,TimeSpan> dic in mapSongs)
                    {
                        if(dic.Key.Contains(items[1]))
                        {
                            s = dic.Value;
                            break;
                        }
                    }
                    lblMusiclength.Content = string.Format("{0}:{1:00}", s.Minutes, s.Seconds);
                    TimerSlider.Maximum = s.TotalMilliseconds;
                    btnPlay_Click(sender, e);
                    break;
                }
            }
        }

        private void TimerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int sliderValue = (int)TimerSlider.Value;
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, sliderValue);
            if (this.TimerSlider.IsMouseOver)
            {
                mediaPlayer.Position = ts;
            }
        }

        private void btnPNext_Click(object sender, RoutedEventArgs e)
        {
            int x = Songs.SelectedIndex;
            Songs.SelectedIndex = Songs.SelectedIndex + 1;
            int y = Songs.SelectedIndex;
            if (Songs.SelectedIndex >= (Songs.Items.Count) || x == y)
            {
                Songs.SelectedIndex = 0;
            }
            string song = (string)Songs.SelectedItem;
            string[] parts = song.Split("\t");
            for (int i = 0; i < songs.Count; i++)
            {
                if (songs[i].EndsWith(parts[1]))
                {
                    mediaPlayer.Open(new Uri(songs[i]));
                    lblCurrenttime.Content = 0.0;
                    TimerSlider.Minimum = 0.0;
                    string[] items = ((string)Songs.SelectedItem).Split("\t");
                    lblSongname.Text = items[1];
                    foreach (KeyValuePair<string, TimeSpan> dic in mapSongs)
                    {
                        if (dic.Key.Contains(items[1]))
                        {
                            s = dic.Value;
                            break;
                        }
                    }
                    lblMusiclength.Content = string.Format("{0}:{1:00}", s.Minutes, s.Seconds);
                    TimerSlider.Maximum = s.TotalMilliseconds;
                    btnPlay_Click(sender, e);
                    break;
                }
            }
        }

        private void btnPRewind_Click(object sender, RoutedEventArgs e)
        {

            Songs.SelectedIndex = Songs.SelectedIndex - 1;
            if (Songs.SelectedIndex < 0)
            {
                Songs.SelectedIndex = Songs.Items.Count - 1;
            }
            string song = (string)Songs.SelectedItem;
            string[] parts = song.Split("\t");
            for (int i = 0; i < songs.Count; i++)
            {
                if (songs[i].EndsWith(parts[1]))
                {
                    mediaPlayer.Open(new Uri(songs[i]));
                    lblCurrenttime.Content = 0.0;
                    TimerSlider.Minimum = 0.0;
                    string[] items = ((string)Songs.SelectedItem).Split("\t");
                    lblSongname.Text = items[1];
                    foreach (KeyValuePair<string, TimeSpan> dic in mapSongs)
                    {
                        if (dic.Key.Contains(items[1]))
                        {
                            s = dic.Value;
                            break;
                        }
                    }
                    lblMusiclength.Content = string.Format("{0}:{1:00}", s.Minutes, s.Seconds);
                    TimerSlider.Maximum = s.TotalMilliseconds;
                    btnPlay_Click(sender, e);
                    break;
                }
            }
        }

        private void lblSongname_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Songs.SelectedItem != null)
            {
                string name = (string)Songs.SelectedItem;
                string[] parts = name.Split("\t");
                lblSongname.ToolTip = parts[1];
            }
        }

        private void btnRepeat_Click(object sender, RoutedEventArgs e)
        {

            ticker++;
            if (ticker%2==0)
            {
                repeat = true;
                btnRepeat.ToolTip = "Repeat Turn On";
            }
            else if(ticker%2!=0)
            {
                repeat = false;
                btnRepeat.ToolTip = "Repeat Turn Off";
            }
        }
    }
}
