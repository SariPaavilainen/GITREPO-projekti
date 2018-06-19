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
            AsemaLyhenteet lyh = new AsemaLyhenteet();
            lyh.TekeeLyhenteet();
            string nimi = "Virtanen";
            string expected = null;
            string actual = Asema.EtsiAsema(lyh.TekeeLyhenteet(), nimi);
            Assert.AreEqual(expected, actual, "Ei ole kaupunki!");
        }

        [TestMethod()]
        public void YlimääräisetMerkit()
        {
            AsemaLyhenteet lyh = new AsemaLyhenteet();
            lyh.TekeeLyhenteet();
            string nimi = "..hElsInki???";
            string expected = "HKI";
            string actual = Asema.EtsiAsema(lyh.TekeeLyhenteet(), nimi);
            Assert.AreEqual(expected, actual, "Ylimääräisiä merkkejä alussa ja lopussa!");
        }
        [TestMethod()]
        public void NumeroitaNimessä()
        {
            AsemaLyhenteet lyh = new AsemaLyhenteet();
            lyh.TekeeLyhenteet();
            string nimi = "123123hElsInki";
            string expected = "HKI";
            string actual = Asema.EtsiAsema(lyh.TekeeLyhenteet(), nimi);
            Assert.AreEqual(expected, actual, "Ylimääräisiä merkkejä alussa ja lopussa!");
        }

        //[TestMethod()]
        //public void SmashTheKeyboardTest()
        //{
        //    AsemaLyhenteet lyh = new AsemaLyhenteet();
        //    lyh.TekeeLyhenteet();
        //    string koodi;
        //    List<string> vaihtoehdot;
        //    string nimi = "heskilni";
        //    string expected = "Helsinki";
        //    Asema.SmashTheKeyboard(lyh.TekeeLyhenteet(), nimi, out koodi, out vaihtoehdot);
        //    string actual = vaihtoehdot;
        //    Assert.AreEqual(expected, actual, "Smash the keyboard ei toimi!");
        //}

        [TestMethod()]
        public void EtsiAsemaNumeroInput()
        {
            AsemaLyhenteet lyh = new AsemaLyhenteet();
            lyh.TekeeLyhenteet();
            string nimi = "45";
            string expected = null;
            string actual = Asema.EtsiAsema(lyh.TekeeLyhenteet(), nimi);
            Assert.AreEqual(expected, actual, "Tyhjää inputtia ei osata käsitellä!");
        }

        //[TestMethod()]
        //public void SmashTheKeyboardNumeroInput()
        //{
        //    AsemaLyhenteet lyh = new AsemaLyhenteet();
        //    lyh.TekeeLyhenteet();
        //    string koodi;
        //    List<string> vaihtoehdot;
        //    string nimi = "45";
        //    string expected = null;
        //    Asema.SmashTheKeyboard(lyh.TekeeLyhenteet(), nimi, out koodi, out vaihtoehdot);
        //    string actual = koodi;
        //    Assert.AreEqual(expected, actual, "Tyhjää inputtia ei osata käsitellä!");
        //}


    }
}