using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DigiTrafficTester
{
    public class intro
    {
        public static void Alku()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

           

            Console.WriteLine("\n"+

           "                   _ -====-__-======-__-========-_____-============-__        \t\n"+
           "                 _(                                                  _)       \t\n"+
           "              OO(                                                   _)_       \t\n"+
           "            0    (_                  JUNAJUTTU 2018                   _)      \t\n"+
           "          o0       (_                                                _)       \t\n"+
           "        o            '=-___-===-_____-========-___________-===-dwb-='         \t\n"+
           "      .o                                     _________                        \t\n"+
           "     .   ______             ______________  |         |       _____           \t\n"+
           "   _()_ || __ || ________   |            |  |_________|   __ ||___|| __       \t\n"+
           "  (BNSF 1995  |  |      |   |            | __Y______00 | | _         _ |      \t\n"+
           " / -OO----OO'' = 'OO--OO'=  'OO--------OO'='OO-------OO'='OO-------OO'= P     \t\n"+
           "##############################################################################\t\n"+
           "\n");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.TrainWhistle__2_);
            player.Play();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PekkaImg()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._91926__tim_kahn__ding);
            player.Play();

            Console.WriteLine("\n" +
              "\n" +

        @"        _.---._             " + Environment.NewLine +
        @"     .-'       '-.          " + Environment.NewLine +
        @"      \ _. _ ._ /           " + Environment.NewLine +
        @"       /..___..\            " + Environment.NewLine +
        @"       ;-.___.-;            " + Environment.NewLine +
        @"      (| e ) e |)     .;.   " + Environment.NewLine +
        @"       \  /_   /      ||||  " + Environment.NewLine +
        @"       _\__-__/_    (\|'-|  " + Environment.NewLine +
        @"     /` / \V/ \ `\   \ )/   " + Environment.NewLine +
        @"    /   \  Y  /   \  /=/    " + Environment.NewLine +
        @"   /  |  \ | /     \/ /     " + Environment.NewLine +
        @"  /  /|   `|'   |\   /      " + Environment.NewLine +
        @"  \  \|    |.   | \_/       " + Environment.NewLine +
        @"   \ /\    |.   |      jgs  " + Environment.NewLine+"\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
      

    }
}
