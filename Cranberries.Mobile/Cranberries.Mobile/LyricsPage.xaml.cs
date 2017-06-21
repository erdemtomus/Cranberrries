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
    public partial class LyricsPage : ContentPage
    {
        public LyricsPage()
        {
            InitializeComponent();
        }

        private const string Url = "http://www.linatomus.com/Api/Albums/";
        private const string SongsUrl = "http://www.linatomus.com/Api/Songs/";
        private HttpClient _client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
        public ObservableCollection<SongDto> _songs;
        private List<AlbumDto> albums = null;

        protected override async void OnAppearing()
        {
            var songsList = await _client.GetStringAsync(SongsUrl);
            var songs = JsonConvert.DeserializeObject<List<SongDto>>(songsList);
            _songs = new ObservableCollection<SongDto>(songs);

        }


        public async Task GetSongs()
        {
            var songsList = await _client.GetStringAsync(SongsUrl);
            var songs = JsonConvert.DeserializeObject<List<SongDto>>(songsList);
            _songs = new ObservableCollection<SongDto>(songs);
            
        }
        
        public LyricsPage(int albumId)
        {
            //DisplayAlert("Pass Ettik","Albüm Id" + albumId,"iptal");
            InitializeComponent();
            //AlbumDto alb = albums.FirstOrDefault(t => t.Id == albumId);

            var task = Task.Run(async () =>
            {
                await GetSongs();
            });

            while(task.Status != TaskStatus.RanToCompletion)
            {
                //do nothing
            }

            //List<SongDto> res = _songs.Where(t => t.AlbumId == albumId).ToList();
            //ObservableCollection<SongDto> _res = new ObservableCollection<SongDto>(res);
            //SongsListView.ItemsSource = _res;
            var res = _songs.Where(t => t.AlbumId == albumId).ToList();
            SongsListView.ItemsSource = res;

            
            
            try
            {
                this.Title = res[0].Album.Name;
            }
            catch (Exception)
            {
            }




        }

        private void SongsListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SongDto song = (SongDto)e.SelectedItem;
            Navigation.PushAsync(new LyricsDetailPage(song.Id));
            //DisplayAlert("sarkı listesi","Şarkı seçildi","iptal");
        }
    }
}
