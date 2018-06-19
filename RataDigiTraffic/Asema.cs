using RataDigiTraffic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RataDigiTraffic
{
    public class Asema
    {


        //Koodasivat Sari ja Tatu, muokkasivat Sari ja Olli
        public static string EtsiAsema(List<Liikennepaikka> lista, string nimi)
        {

            char[] charsToTrim = { ' ', ',', '.', '1', '2', '3', '4', '5', '6', '7', '8', '9', '?', '!', '@', '\'' };
            nimi = nimi.Trim(charsToTrim);
            if (nimi.Length == 0) { return null; }
            else
            {
                string alkukirjain = nimi.Substring(0, 1).ToUpper();
                string loppunimi = nimi.Substring(1, (nimi.Length - 1)).ToLower();
                nimi = alkukirjain + loppunimi;
                foreach (var item in lista)
                {
                    if (item.stationName == nimi) { return item.stationShortCode; }
                    else { continue; }
                }

                return null; 
            }
          
        }

        //Koodasivat Sari ja Olli
        public static void SmashTheKeyboard(List<Liikennepaikka> lista, string typo, out string koodi, out List<string> vaihtoehdot)
        {
            List<string> samanlaiset = new List<string>();
            foreach (var item in lista)
            {
                char[] charsToTrim = { ' ', ',', '.', '1', '2', '3', '4', '5', '6', '7', '8', '9', '?', '!', '@', '\'' };
                typo = typo.Trim(charsToTrim);
                if (typo.Length == 0)
                {
                    koodi =  "Asemaa ei löydy!";
                    vaihtoehdot = null;
                }
                else
                {
                    string alkukirjain = typo.Substring(0, 1).ToUpper();
                    string loppunimi = typo.Substring(1, (typo.Length - 1)).ToLower();
                    typo = alkukirjain + loppunimi;
                    string nimi = item.stationName;
                   

                    if (nimi.Substring(0, 1) == typo.Substring(0, 1) && nimi.Substring(nimi.Length - 1, 1) == typo.Substring(typo.Length - 1, 1))

                    {
                        samanlaiset.Add(nimi);
                    }
                    else
                    {
                        continue;
                    }
                    
                }
                
            }
            koodi = null;
            vaihtoehdot = samanlaiset;
        }
        // Koodasivat Olli ja Sari
        public static void Konduktööri(out string lähtöAsema, out string kohdeAsema)
        {
            Console.WriteLine("Tervetuloa Junajuttuun!");
         
                annalähtöasema:
                Console.WriteLine("Anna lähtöasema:");
                string lähtö = Console.ReadLine();
                AsemaLyhenteet pekka = new AsemaLyhenteet();
                lähtöAsema = Asema.EtsiAsema(lista: pekka.TekeeLyhenteet(), nimi: lähtö);
                 string vastaus;
                 List<string> vaihtoehdot;
                if (lähtöAsema == null)
                {
                   SmashTheKeyboard(pekka.TekeeLyhenteet(), lähtö, out vastaus, out vaihtoehdot);

                      if (vastaus == "Asemaa ei löydy!")
                     {
                             Console.WriteLine("Asemaa ei löydy!");
                            goto annalähtöasema;
                        }
                foreach (var uusiLähtö in vaihtoehdot)
                {

                
                    Console.WriteLine("Tarkoititko " + uusiLähtö + "? (k/e)");
                    var response = Console.ReadLine().Substring(0,1).ToLower();
                    switch (response)
                    {
                        case "k":
                            
                                lähtöAsema = Asema.EtsiAsema(lista: pekka.TekeeLyhenteet(), nimi: uusiLähtö);
                                break;

                        case "e":
                            break;

                        default:
                            Console.WriteLine("Anna vastaus (k/e)");
                            response = Console.ReadLine().Substring(0, 1).ToString();
                            break;
                    }
                    if (lähtöAsema != null) { break; }
                  
                    
                }
                if (lähtöAsema == null)
                {
                    Console.WriteLine("Asemaa ei löydy!");
                    goto annalähtöasema;
                }
            }
                annakohdeasema:
                Console.WriteLine("Anna asema, jonne haluat matkustaa asemalta " + lähtöAsema + ": ");
                string kohde = Console.ReadLine();
            
            kohdeAsema = Asema.EtsiAsema(lista: pekka.TekeeLyhenteet(), nimi: kohde);
            if (kohdeAsema == null)
            {
                SmashTheKeyboard(pekka.TekeeLyhenteet(), kohde, out vastaus, out vaihtoehdot);
                if (vastaus == "Asemaa ei löydy!")
                {
                    Console.WriteLine("Asemaa ei löydy!");
                    goto annakohdeasema;
                }
                foreach (var uusiKohde in vaihtoehdot)
                {


                    Console.WriteLine("Tarkoititko " + uusiKohde + "? (k/e)");
                    var response = Console.ReadLine();
                    switch (response)
                    {
                        case "k":

                            kohdeAsema = Asema.EtsiAsema(lista: pekka.TekeeLyhenteet(), nimi: uusiKohde);
                            break;

                        case "e":
                            break;

                        default:
                            Console.WriteLine("Anna vastaus (k/e)");
                            response = Console.ReadLine().Substring(0, 1).ToString();
                            break;
                    }
                    if (kohdeAsema != null) { break; }


                }
                if (kohdeAsema == null)
                {
                    Console.WriteLine("Asemaa ei löydy!");
                    goto annakohdeasema;
                }
            }

            
         
           
           

        }
       

    }
}
