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

            RataDigiTraffic.APIUtil rata = new RataDigiTraffic.APIUtil();
            List<Juna> junat = rata.JunatVälillä(lähtöasema, kohdeasema);
            DateTime tänään = DateTime.Now.ToLocalTime();
            int counter = 1;
            foreach (var item in junat)
            {
                StringBuilder tulostus = new StringBuilder(counter + ". Juna " + item.trainType + " " + item.trainNumber + " lähtee asemalta " + lähtöasema + " ");
                List<RataDigiTraffic.Model.Aikataulurivi> aikataulut = item.timeTableRows;

                foreach (var rivi in aikataulut)
                    {

                        if (rivi.stationShortCode == lähtöasema && rivi.type.Contains("DEPARTURE"))
                        {


                            tulostus.Append(rivi.scheduledTime.ToLocalTime()+" ja saapuu asemalle "+kohdeasema+" ");


                        }
               
                    }
                foreach (var rivi in aikataulut)
                {
                    if (rivi.stationShortCode == kohdeasema && rivi.type.Contains("ARRIVAL"))
                    {
                        tulostus.Append(rivi.scheduledTime.ToLocalTime());
                    }
                }

                Console.WriteLine(tulostus);
                counter++;
                if (counter == 6) { break; }
            }


        }
        
    }
}
