using Newtonsoft.Json;
using RataDigiTraffic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RataDigiTraffic
{
    public class APIUtil

    {
        public List<Liikennepaikka> Liikennepaikat()
        {
            //            //Mitä tässä tapahtuu?? :D Lista muodostuu siitä, että metadata/stations -data luetaan response-muuttujaan ja siitä edelleen
            //            //responseStringiin ja jsoniin; 
            string json = "";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync($"https://rata.digitraffic.fi/api/v1/metadata/stations").Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                json = responseString;
            }
            List<Liikennepaikka> res;
            res = JsonConvert.DeserializeObject<List<Liikennepaikka>>(json);
            return res;
            // ja kaivaa jsonista Liikennepaikka-datan list-liikennepaikka-tyyppiseksi listaksi
        }

        public List<Juna> JunatVälillä(string mistä, string minne)
        {
//            //Sama juttu paitsi että Juna-tyyppinen lista kahden aseman välillä 
            string json = "";
            string url = $"https://rata.digitraffic.fi/api/v1/schedules?departure_station={mistä}&arrival_station={minne}";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(url).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                json = responseString;
            }
            List<Juna> res;
            res = JsonConvert.DeserializeObject<List<Juna>>(json);
            return res;
        }

        public List<Kulkutietoviesti> LiikennepaikanJunat(string paikka )
        {
            // Sama juttu kuin yllä, mutta tietyn parametrina annettavan paikan kautta kulkevat junat tänään
            string json = "";
            string url = $"https://rata.digitraffic.fi/api/v1/train-tracking?station={paikka}&departure_date={DateTime.Today.ToString("yyyy-MM-dd")}";

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(url).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                json = responseString;
            }
            List<Kulkutietoviesti> res;
            res = JsonConvert.DeserializeObject<List<Kulkutietoviesti>>(json);
            return res;
        }
    }





}
