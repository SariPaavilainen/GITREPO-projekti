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
            //Ei käytetä komentoriviparametrejä vaan kysytään käyttäjältä, siten voidaan myös loopata tarvittaessa uusiin kysymyksiin
            //if (args.Length == 0)
            //{
            //    printUsage();
            //    return;
            //}
            //if (args[0].ToLower().StartsWith("-a"))
            //{
            //    string asema = "";
            //    if (args.Length > 1)
            //    {
            //        asema = args[1];
            //    }
            //    tulostaAsemat(asema);
            //    return;    
            //}
            //if (args[0].ToLower().StartsWith("-j"))
            //{
            //    string lähtöasema;
            //    string kohdeasema;
            //    if (args.Length < 3)
            //    {
            //        printUsage();
            //        return;
            //    }
            //    lähtöasema = args[1];
            //    kohdeasema = args[2];
            //    tulostaJunatVälillä(lähtöasema, kohdeasema);
            //}


            string lähtöAsema;
            string kohdeAsema;
            Asema.Konduktööri(out lähtöAsema, out kohdeAsema);

            Console.WriteLine("Valittu matka " + lähtöAsema + " - " + kohdeAsema); //Tähän asti!
            tulostaJunatVälillä(lähtöAsema, kohdeAsema);
            //Koodasivat: Tatu ja Hanna-Mari
            Console.WriteLine("Annan junan numero");
            int junaSyöte = int.Parse(Console.ReadLine());
            Console.WriteLine(EtsiJuna(junaSyöte));//Tähän asti!

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


        // Tatu ja H-M koodasivat
        public static string EtsiJuna(int junanNumero) // Tässä haetaan junan numeron avulla junan tyyppi
        {
            RataDigiTraffic.APIUtil rata = new RataDigiTraffic.APIUtil();
            List<Juna> junat = rata.JunaNumerolla(junanNumero);
            foreach (var item in junat)
            {
                if (item.trainNumber == junanNumero) //{ return item.trainType; }
               
                    foreach(var rivi in item.timeTableRows)
                    {
                        Console.WriteLine(rivi.stationShortCode + " " + rivi.type + " " + rivi.scheduledTime.ToLocalTime());  // Muokattu koodia niin, että hakee aseman lyhenteen, pysähdyksen tyypin ja lokalisoidun ajan näille.   
                    }
                
                
            }
            
            return "";
        
        }
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
