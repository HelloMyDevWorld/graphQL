using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mCarMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            SampleRest();
        }


        void InitRestService()
        {
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000; 
        }

        public async void SampleRest()
        {
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            string url = @"http://89.66.175.59:5000/api/graphql/";
            var uri = new Uri(string.Format(url, string.Empty));

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Query", "query { hero {  id name  } }")
            });

            try
            {
                var response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    GraphQL.Text = result.ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }


    }
}
