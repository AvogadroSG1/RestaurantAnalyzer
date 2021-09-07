using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace RestaurantAnalyzer
{
    public class GoogleSearcher
    {
        public GoogleSearcher()
        {

        }

        public async Task Search()
        {
            StringBuilder bufferForHtml = new StringBuilder();
            byte[] encodedBytes = new byte[8192];
            var basePlaceAPI = @"https://maps.googleapis.com/maps/api/place/textsearch/json";
            var textSearch = "?query=restaurants in Hagerstown MD";
            var apiAddition = "&key=";
            GoogleTextSearchResponse? results = null;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(string.Concat(basePlaceAPI,textSearch, apiAddition));
                var things = await response.Content.ReadAsStringAsync();

                results = JsonSerializer.Deserialize<GoogleTextSearchResponse>(things);
            }

            if(results == null)
            {

            }
        }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Viewport
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
        public Viewport viewport { get; set; }
    }

    public class OpeningHours
    {
        public bool open_now { get; set; }
    }

    public class Photo
    {
        public int height { get; set; }
        public List<string> html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }

    public class PlusCode
    {
        public string compound_code { get; set; }
        public string global_code { get; set; }
    }

    public class Result
    {
        public string business_status { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string icon_background_color { get; set; }
        public string icon_mask_base_uri { get; set; }
        public string name { get; set; }
        public OpeningHours opening_hours { get; set; }
        public List<Photo> photos { get; set; }
        public string place_id { get; set; }
        public PlusCode plus_code { get; set; }
        public double rating { get; set; }
        public string reference { get; set; }
        public List<string> types { get; set; }
        public int user_ratings_total { get; set; }
    }

    public class GoogleTextSearchResponse
    {
        public List<object>? html_attributions { get; set; }
        public List<Result>? results { get; set; }
        public string? status { get; set; }
    }


}
