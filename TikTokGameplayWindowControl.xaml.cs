using Microsoft.Web.WebView2.Core;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace TikTokGameplayVS
{
    /// <summary>
    /// Interaction logic for TikTokGameplayWindowControl.
    /// </summary>
    public partial class TikTokGameplayWindowControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TikTokGameplayWindowControl"/> class.
        /// </summary>
        public TikTokGameplayWindowControl()
        {
            this.InitializeComponent();
            this.InitializeAsync();
            // set up binding
            this.DataContext = this;
            this.VideoLink = "about:blank";
            this.RandomVideo();

            var myBinding = new Binding("VideoLink")
            {
                Source = this,
                Mode = BindingMode.OneWay
            };
        }

        private async void InitializeAsync()
        {
            var env = await CoreWebView2Environment.CreateAsync(null, "C:\\temp");
            webView.EnsureCoreWebView2Async(env);
        }

        public string VideoLink { get; set; }

        public void RandomVideo()
        {
            Random random = new Random();
            string[] videos = { "iYgYfHb8gbQ", "hs7Z0JUgDeA", "Tqne5J7XdPA", "nNGQ7kMhGuQ", "Pt5_GSKIWQM", "SLXi3EKV8Bw", "n_Dv4JMiwK8" };

            // select a random video
            string video = videos[random.Next(0, videos.Length)];

            // set the video link
            this.VideoLink = "https://yewtu.be/latest_version?id=" + video + "&amp;itag=22#t=100";
        }
    }
}