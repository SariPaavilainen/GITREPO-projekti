using RataDigiTraffic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RataDigiTraffic;

namespace DigiTrafficTester
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(Console.LargestWindowWidth - 40, Console.LargestWindowHeight - 15);

            intro.Alku();
            Console.WriteLine("Tervetuloa Junajuttuun! Olen konduktööri Pekka.");
            Console.WriteLine("##############################################");
           

            string response = "k";
            do
            {   intro.PekkaImg();
                Console.WriteLine("Mitä haluat tehdä?\n 1) Etsiä seuraavat junat tietylle reitille\n 2) Hakea junan tiedot junan numerolla\n Info) Saada lisätietoa sovelluksesta");
                string vastaus = Console.ReadLine();
                if (vastaus == "1") {
                    Console.Clear();
                    intro.PekkaImg(); SeuraavaJuna.KerroSeuraavatJunat(); }
                if (vastaus == "2")
                {
                    Console.Clear();
                    intro.PekkaImg();
                    Console.WriteLine("Anna junan numero");
                    string junaSyöte = Console.ReadLine();
                    Console.WriteLine(Junanumerolla.EtsiJuna(junaSyöte));
                }
                if (vastaus.ToLower().Contains("i"))
                {
                    Console.Clear();
                    intro.PekkaImg();
                    Console.WriteLine("##############################\n\n" +
                        "JUNAJUTTU INFO\n"+
                        "Junajuttu on sovellus, jossa konduktööri Pekka etsii tietoa junien aikatauluista\n"+
                        "käyttäjän antamilla tiedoilla. Junajuttu-sovelluksen kehittämistyössä on panostettu\n"+
                        "erityisesti käyttäjäystävällisyyteen. Junajuttu on kehitetty kesäkuussa 2018\n"+
                        "Academy Finlandin C#.NET Accelerated Learning -koulutusohjelman miniprojektina,\n"+
                        "ja sen ovat kehittäneet Hanna-Mari Lapp (@hmlapp), Sari Paavilainen (@SariPaavilainen),\n"+
                        "Olli Piilonen (@ollipiilonen) ja Tatu Vahteri (@tatuvahteri).\n\n"+
                        "##############################");
                }
                else { continue; }
                Console.WriteLine("Haluatko tehdä uuden haun? (k/e)");
                response = Console.ReadLine();
                Console.Clear();
            } while (response == "k");
            intro.PekkaImg();
            Console.WriteLine("Kiitos kun kävit Junajutussa! Hyvää matkaa!");
            intro.Alku();
         

          
            //Koodasivat: Tatu ja Hanna-Mari
           //Tähän asti!

        }

        private static void tulostaJunatVälillä(string lähtöasema, string kohdeasema)
        {
            RataDigiTraffic.APIUtil rata = new RataDigiTraffic.APIUtil();

            List<Juna> junat = rata.JunatVälillä(lähtöasema, kohdeasema);
            string s =  string.Join(", ", junat.Select(j => j.trainNumber + " " + j.trainType));
            Console.WriteLine($"Junat {lähtöasema} ==> {kohdeasema}: " + s);
        }

        private static void tulostaAsemat(string asema)
        {
            List<Liikennepaikka> paikat;
            RataDigiTraffic.APIUtil rata = new RataDigiTraffic.APIUtil();
            paikat = rata.Liikennepaikat();
            foreach (var item in paikat.Where(p => p.type == "STATION"))
            {
                if (item.stationName.StartsWith(asema))
                {
                    Console.WriteLine(item.stationName + " - " + item.stationShortCode);
                }
            }
        }
     //   //Koodasivat: Sari ja Tatu
     //public static string EtsiAsema( List<Liikennepaikka> lista, string nimi)
     //   {
     //       foreach (var item in lista)
     //       {
     //           if (item.stationName == nimi) { return item.stationShortCode;}
     //           else { continue; }
     //       }
     //       return "Asemaa ei löydy!";
     //   }


        // Tatu ja H-M koodasivat --> siirretty omaan classiin
        //public static string EtsiJuna(int junanNumero) // Tässä haetaan junan numeron avulla junan tyyppi --> siirretty omaksi luokaksi Junanumerolla.cs
        //{
        //    RataDigiTraffic.APIUtil rata = new RataDigiTraffic.APIUtil();
        //    List<Juna> junat = rata.JunaNumerolla(junanNumero);
        //    foreach (var item in junat)
        //    {
        //        if (item.trainNumber == junanNumero) //{ return item.trainType; }
               
        //            foreach(var rivi in item.timeTableRows)
        //            {
        //                Console.WriteLine(rivi.stationShortCode + " " + rivi.type + " " + rivi.scheduledTime.ToLocalTime());  // Muokattu koodia niin, että hakee aseman lyhenteen, pysähdyksen tyypin ja lokalisoidun ajan näille.   
        //            }
                
                
        //    }
            
        //    return "";
        
        //}
         // tähän asti  

        private static void printUsage()
        {
            Console.WriteLine();
            Console.WriteLine("Ohje:");
            Console.WriteLine("DigiTrafficTester -a[semat] <asemanAlkukirjain>");
            Console.WriteLine("tai");
            Console.WriteLine("DigiTrafficTester -j[unat] alkuasemaLyhenne loppuasemaLyhenne");
            Console.WriteLine();
        }


    }
}
