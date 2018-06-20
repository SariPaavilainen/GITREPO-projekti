using RataDigiTraffic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RataDigiTraffic;
using System.Threading;

namespace RataDigiTraffic // Koodannut H-M ja Tatu
{
    public class Junanumerolla
    {
        public static string EtsiJuna(string junanNumero) // Tässä haetaan junan numeron avulla junan tyyppi
        { 
            char[] charsToTrim = { ' ', ',', '.','?', '!', '@', 'I', 'i', 'C', 'c', 'P', 'p','H', 'h', 'S', 's'  }; // Tässä trimmataan syötteestä pois typot.

            junanNumero = junanNumero.Trim(charsToTrim);

            bool testi = int.TryParse(junanNumero, out int oikeanro); // Testataan onko syöte int-muotoinen

            if (testi == false)
            {
                return "Et syöttänyt numeroa!";
                //return false; // Poistettu, kun muutettu metodi string-muotoon
            }

            if(junanNumero.ToString().Length>5 || oikeanro==0) // Rajoitetaan merkkien määrä viiteen ja erisuureksi kuin nolla
            {
                return "Junan numero voi olla välillä 1-99999"; // Rajataan junannumero välille 1-99999
                //return false;

            }

            Console.Clear();
            
            string odotusTeksti = "Haetaan tietoa, odota hetki...";
            
            //for(int i=0;i<=5;i++) // Vilkkuvan odotustekstin toteutus
            //{
            //    Console.WriteLine(odotusTeksti);
            //    Thread.Sleep(1000);
            //    Console.Clear();
            //    Thread.Sleep(1000);
            //}
            RataDigiTraffic.APIUtil rata = new RataDigiTraffic.APIUtil(); //junan tietojen haku API:lta
            //List<Juna> junat = rata.JunaNumerolla(oikeanro);
            Task<List<Juna>> hakutaski = new Task<List<Juna>>(() => rata.JunaNumerolla(oikeanro));
            hakutaski.Start();
            Console.Write(odotusTeksti);
            while (!hakutaski.IsCompleted )
            {
                                         // Odotus-teksti vilkkuu samaan aikaan kun haku tapahtuu
                Console.Write(".");     // Muutettu niin, että pisteet lisääntyvät odotus-tekstissä samaan aikaan kun haku tapahtuu
                Thread.Sleep(2000);
                //Console.Clear();
                //Thread.Sleep(1000);
            }
            List<Juna> junat = hakutaski.Result;

            foreach (var item in junat)
                if (item.trainNumber == oikeanro) //{ return item.trainType; }
                {
                    string junanKulku = "";
                    if (item.runningCurrently == true)
                        junanKulku = "Juna on liikkeellä";
                    if (item.runningCurrently == false)
                        junanKulku = "Juna ei ole liikenteessä";
                    Console.WriteLine("\n\n" + item.trainType + item.trainNumber + " " + item.departureDate.ToString("dd.MM.yyyy") + " " + junanKulku);
                    
                    Console.WriteLine("\n\nAseman lyhenne" + "\t" + "" + "\t" + "KLO"+ "\t\t" + "Arvioitu aika" + "\t" + "Toteutunut aika");
                    foreach (var rivi in item.timeTableRows)
                    {
                        string pysähdyksenTyyppi = "";
                        if (rivi.type.Contains("ARRIVAL"))
                            pysähdyksenTyyppi = "tulo";
                        if (rivi.type.Contains("DEPARTURE"))
                            pysähdyksenTyyppi = "lähtö";
                        if (rivi.commercialStop == true) 
                        Console.WriteLine(rivi.stationShortCode + "\t\t" + pysähdyksenTyyppi + "\t" + rivi.scheduledTime.ToLocalTime().ToString("HH:mm") + "\t\t" + (rivi.liveEstimateTime  > default(DateTime ) ? rivi.liveEstimateTime .ToLocalTime().ToString("HH:mm"):"") 
                            + "\t\t" + (rivi.actualTime > default(DateTime) ? rivi.actualTime.ToLocalTime().ToString("HH:mm") : ""));  // Muokattu koodia niin, että hakee aseman lyhenteen, pysähdyksen tyypin ja lokalisoidun ajan näille.   
                    }
                    return "";
                }
            return "Syöttämääsi junaa ei löydy, tarkista antamasi numero";
            //return false;
        }
    }
    }
                 // tähän asti
