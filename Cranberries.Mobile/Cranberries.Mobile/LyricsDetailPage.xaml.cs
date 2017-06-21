using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Cranberries.Mobile
{
    public partial class LyricsDetailPage : ContentPage
    {
        public LyricsDetailPage()
        {
            InitializeComponent();
        }

        private const string Url = "http://www.linatomus.com/Api/Albums/";
        private const string SongsUrl = "http://www.linatomus.com/Api/Songs/";
        private HttpClient _client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
        public ObservableCollection<SongDto> _songs;
        private List<AlbumDto> albums = null;


        public async Task GetSongs()
        {
            var songsList = await _client.GetStringAsync(SongsUrl);
            var songs = JsonConvert.DeserializeObject<List<SongDto>>(songsList);
            _songs = new ObservableCollection<SongDto>(songs);

        }

        public LyricsDetailPage(int songId)
        {
            //DisplayAlert("Pass Ettik","Albüm Id" + albumId,"iptal");
            InitializeComponent();
            //AlbumDto alb = albums.FirstOrDefault(t => t.Id == albumId);

            var task = Task.Run(async () =>
            {
                await GetSongs();
            });

            while (task.Status != TaskStatus.RanToCompletion)
            {
                //do nothing
            }

            //List<SongDto> res = _songs.Where(t => t.AlbumId == albumId).ToList();
            //ObservableCollection<SongDto> _res = new ObservableCollection<SongDto>(res);
            //SongsListView.ItemsSource = _res;
            SongDto selectedSong = _songs.First(t => t.Id == songId);

            //lyricsStack.BindingContext = selectedSong;

            string htmlText = "<html><head></head><body>" + selectedSong.Lyrics.ToString().Replace(@"\", string.Empty) + "</body></html>";
            //var browser = new WebView();
            HTMLSrc.Html = htmlText;
            //var html = new HtmlWebViewSource
            //{
            //    Html = htmlText
            //};

            WebViewLyrics.Source = HTMLSrc;

            LyricsName.Text = selectedSong.Album.Name;
            //browser.Source = html;
            //LyricsWebView.Source = html;


            try
            {
                this.Title = selectedSong.Name;
            }
            catch (Exception)
            {
            }



        }
    }
}
