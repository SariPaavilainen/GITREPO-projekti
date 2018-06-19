using RataDigiTraffic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RataDigiTraffic;

namespace RataDigiTraffic // Koodannut H-M ja Tatu
{
    public class Junanumerolla
    {
        public static bool EtsiJuna(string junanNumero) // Tässä haetaan junan numeron avulla junan tyyppi
        {
            char[] charsToTrim = { ' ', ',', '.','?', '!', '@', 'I', 'i', 'C', 'c', 'P', 'p','H', 'h', 'S', 's'  }; // Tässä trimmataan syötteestä pois typot.
            junanNumero = junanNumero.Trim(charsToTrim);
            bool testi = int.TryParse(junanNumero, out int oikeanro); // Testataan onko syöte int-muotoinen
            if (testi == false)
            {
                Console.WriteLine("Et syöttänyt numeroa!");
            }
            if(junanNumero.ToString().Length>6 || oikeanro==0) // Rajoitetaan merkkien määrä viiteen ja erisuureksi kuin nolla
            {
                Console.WriteLine("Junan numero voi olla välillä 1-99999"); // Rajataan junannumero välille 1-99999
                    return false;
            }
            RataDigiTraffic.APIUtil rata = new RataDigiTraffic.APIUtil();
            List<Juna> junat = rata.JunaNumerolla(oikeanro);
            foreach (var item in junat)
                if (item.trainNumber == oikeanro) //{ return item.trainType; }
                {
                    foreach (var rivi in item.timeTableRows)
                    {
                        Console.WriteLine(rivi.stationShortCode + " " + rivi.type + " " + rivi.scheduledTime.ToLocalTime());  // Muokattu koodia niin, että hakee aseman lyhenteen, pysähdyksen tyypin ja lokalisoidun ajan näille.   
                    }
                return true;
                }
            Console.WriteLine("Syöttämääsi junaa ei löydy, tarkista antamasi numero");
            return false;
        }
    }
}                   // tähän asti
