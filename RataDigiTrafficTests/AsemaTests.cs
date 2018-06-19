using Microsoft.VisualStudio.TestTools.UnitTesting;
using RataDigiTraffic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RataDigiTraffic.Model;

namespace RataDigiTraffic.Tests
{
    //Testasivat Sari ja Olli
    [TestClass()]
    public class AsemaTests
    {

        [TestMethod()]
        public void IsotJaPienetKirjaimetTest()
        {
            AsemaLyhenteet lyh = new AsemaLyhenteet();
            lyh.TekeeLyhenteet();
            string nimi = "heLsiNkI";
            string expected = "HKI";
            string actual = Asema.EtsiAsema(lyh.TekeeLyhenteet(), nimi);
            Assert.AreEqual(expected, actual, "Isot ja pienet kirjaimet pielessä!");
        }

        [TestMethod()]
        public void OlematonKaupunginNimi()
        {
            Liikennepaikka l1 = new Liikennepaikka("Helsinki", "HKI");
            List<Liikennepaikka> Lyhenteet = new List<Liikennepaikka>();
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Tampere", "TPE");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Turku", "TKU");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Lahti", "LH");
            Lyhenteet.Add(l1);
            string nimi = "Virtanen";
            string expected = "Asemaa ei löydy!";
            string actual = Asema.EtsiAsema(Lyhenteet, nimi);
            Assert.AreEqual(expected, actual, "Ei ole kaupunki!");
        }

        [TestMethod()]
        public void YlimääräisetMerkit()
        {
            Liikennepaikka l1 = new Liikennepaikka("Helsinki", "HKI");
            List<Liikennepaikka> Lyhenteet = new List<Liikennepaikka>();
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Tampere", "TPE");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Turku", "TKU");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Lahti", "LH");
            Lyhenteet.Add(l1);
            string nimi = "..hElsInki???";
            string expected = "HKI";
            string actual = Asema.EtsiAsema(Lyhenteet, nimi);
            Assert.AreEqual(expected, actual, "Ylimääräisiä merkkejä alussa ja lopussa!");
        }
        [TestMethod()]
        public void NumeroitaNimessä()
        {
            Liikennepaikka l1 = new Liikennepaikka("Helsinki", "HKI");
            List<Liikennepaikka> Lyhenteet = new List<Liikennepaikka>();
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Tampere", "TPE");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Turku", "TKU");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Lahti", "LH");
            Lyhenteet.Add(l1);
            string nimi = "123123hElsInki";
            string expected = "HKI";
            string actual = Asema.EtsiAsema(Lyhenteet, nimi);
            Assert.AreEqual(expected, actual, "Ylimääräisiä merkkejä alussa ja lopussa!");
        }

        [TestMethod()]
        public void SmashTheKeyboardTest()
        {
            Liikennepaikka l1 = new Liikennepaikka("Helsinki", "HKI");
            List<Liikennepaikka> Lyhenteet = new List<Liikennepaikka>();
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Tampere", "TPE");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Turku", "TKU");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Lahti", "LH");
            Lyhenteet.Add(l1);
            string nimi = "heskilni";
            string expected = "Tarkoititko Helsinki?";
            string actual = Asema.SmashTheKeyboard(Lyhenteet, nimi);
            Assert.AreEqual(expected, actual, "Smash the keyboard ei toimi!");
        }

        [TestMethod()]
        public void EtsiAsemaTest()
        {
            Liikennepaikka l1 = new Liikennepaikka("Helsinki", "HKI");
            List<Liikennepaikka> Lyhenteet = new List<Liikennepaikka>();
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Tampere", "TPE");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Turku", "TKU");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Lahti", "LH");
            Lyhenteet.Add(l1);
            string nimi = "heskilni";
            string expected = "Tarkoititko Helsinki?";
            string actual = Asema.EtsiAsema(Lyhenteet, nimi);
            Assert.AreEqual(expected, actual, "Smash the keyboard ei toimi!");
        }
    }
}