using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Xamarin.Forms;


namespace Cranberries.Mobile
{
    public partial class AlbumsPage : ContentPage
    {
        private const string Url = "http://www.linatomus.com/Api/Albums/";
        private HttpClient _client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
        private ObservableCollection<AlbumDto> _albums;

        public AlbumsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            //HttpClientHandler handler = new HttpClientHandler()
            //{
            //    Proxy = new System.Net.IWebProxy()
            //};


            //client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue(username, password);
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");
            
            var content =await _client.GetStringAsync(Url);
            string ds = content;

            var albums = JsonConvert.DeserializeObject<List<AlbumDto>>(content);
            _albums = new ObservableCollection<AlbumDto>(albums);
            AlbumsListView.ItemsSource = _albums;

        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
             //sender
        }

        private void AlbumsListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            AlbumDto album = (AlbumDto)e.SelectedItem;
            Navigation.PushAsync(new LyricsPage(album.Id));
        }
    }

    //public class AlbTest
    //{
    //    public string ImageUrl { get; set; }
    //    public string Name { get; set; }
    //    public string ReleasedDate { get; set; }
    //}
    

}
