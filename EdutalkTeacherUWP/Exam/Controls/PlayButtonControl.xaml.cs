using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EdutalkTeacherUWP.Exam.Controls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayButtonControl : UserControl
    {
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(string), typeof(PlayButtonControl), new PropertyMetadata(null));

        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }
        public static readonly DependencyProperty IsPlayProperty = DependencyProperty.Register("IsPlay", typeof(bool), typeof(PlayButtonControl), new PropertyMetadata(null));

        public bool IsPlay
        {
            get => (bool)GetValue(IsPlayProperty);
            set => SetValue(IsPlayProperty, value);
        }

        bool isPlaying { set; get; }
        MediaPlayer player;
        public PlayButtonControl()
        {
            this.InitializeComponent();
          
            player.MediaEnded += Player_MediaEnded;
        }

        private void Player_MediaEnded(MediaPlayer sender, object args)
        {
            isPlaying = false;
            SwitchButton();
        }


        async Task SwitchButton()
        {
            await Task.WhenAll(isPlaying == true ? RotateButton() : RotateBackButton(), FadeButton());

            PlayButton.Fade(0, 250);
            BitmapImage bitmapImage = new BitmapImage();
            Uri uri = isPlaying == true ? new Uri("ic_pause_solid") : new Uri("ic_play_solid");
            bitmapImage.UriSource = uri;
            PlayButton.Source = bitmapImage;
            FadeBackButton();
        }

        async Task RotateButton()
        {
            PlayButton.Rotate(360, 250);
        }

        async Task RotateBackButton()
        {
            PlayButton.Rotate(0, 250);
        }
        async Task FadeButton()
        {
            PlayButton.Fade(0, 250);
        }
        async Task FadeBackButton()
        {
            PlayButton.Fade(1, 250);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isPlaying == false)
                {
                    if (!string.IsNullOrEmpty(Source))
                    {
                        try
                        {
                            var uri = new Uri(Source);
                            player = new MediaPlayer();
                            player.Source = MediaSource.CreateFromUri(uri);
                            player.Play();
                            isPlaying = true;
                        }
                        catch (Exception ex)
                        {
                            isPlaying = false;
                        }
                    }
                }
                else
                {
                    isPlaying = false;
                    player.Pause();
                }
            }
            catch (Exception exception)
            {
                isPlaying = false;
            }
            await SwitchButton();
        }
    }
}
