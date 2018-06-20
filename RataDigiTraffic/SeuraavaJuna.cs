using RataDigiTraffic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace RataDigiTraffic
{
    public class SeuraavaJuna
    {
        public static void KerroSeuraavatJunat()
        {
            string lähtöasema;
            string kohdeasema;
            Asema.Konduktööri(out lähtöasema, out kohdeasema);
            Console.WriteLine("Valittu matka: "+lähtöasema+ " - "+kohdeasema);
            List<Juna> junat;
            string lähtöformat = "dd.MM klo HH.mm";
            string saapumisformat = "klo HH.mm";

            RataDigiTraffic.APIUtil rata = new RataDigiTraffic.APIUtil();
            try
            {
                junat = rata.JunatVälillä(lähtöasema, kohdeasema);

                int counter = 1;
                foreach (var item in junat)
                {
                    StringBuilder tulostus = new StringBuilder(counter + ". Juna " + item.trainType + " " + item.trainNumber + " lähtee asemalta " + lähtöasema + " ");
                    List<RataDigiTraffic.Model.Aikataulurivi> aikataulut = item.timeTableRows;


                    foreach (var rivi in aikataulut)
                    {

                        if (rivi.stationShortCode == lähtöasema && rivi.type.Contains("DEPARTURE"))
                        {


                            tulostus.Append(rivi.scheduledTime.ToLocalTime().ToString(lähtöformat) + " ja saapuu asemalle " + kohdeasema + " ");
                            break;


                        }

                    }
                    foreach (var rivi in aikataulut)
                    {
                        if (rivi.stationShortCode == kohdeasema && rivi.type.Contains("ARRIVAL"))
                        {
                            tulostus.Append(rivi.scheduledTime.ToLocalTime().ToString(saapumisformat));
                            break;
                        }
                    }

                    Console.WriteLine(tulostus);
                    counter++;
                    if (counter == 6) { break; }
                }
            }
            catch (Newtonsoft.Json.JsonSerializationException)
            {

                Console.WriteLine("Antamallesi yhteysvälille ei löydy suoraa junayhteyttä!");
                return;
            }


        }
        
    }
}
