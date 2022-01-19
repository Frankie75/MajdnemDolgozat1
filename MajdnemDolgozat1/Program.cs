using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// kezdes : 16:19

namespace MajdnemDolgozat1
{
    internal class Program
 
    {
        static List<Jatek> Jatekok = new List<Jatek>();
        static void Main(string[] args)
        {
            Feladat02();
            Feladat03();
            Feladat04();
            Feladat05();
            Feladat06();
            Feladat07();
            Feladat09();
            Feladat10();

            Console.ReadKey();
        }

        private static void Feladat10()
        {
            float OsszesenMegjelent = 0;
            float MegjelentPCn = 0;
            foreach (var item in Jatekok)
            {
                if (item.Kiado== "Electronic Arts") OsszesenMegjelent++;
                if (item.Kiado== "Electronic Arts" & item.Platform.Contains("PC")) MegjelentPCn++;

            }
            Console.WriteLine("10. feladat:");
            Console.WriteLine($"\tAz Electronic Arts jatekainak {(MegjelentPCn/OsszesenMegjelent)*100} %-a jelent meg PC-n");

        }

        private static void Feladat09()
        {
            List<string> list = new List<string>(); 
            Console.WriteLine("9. feladat:");
            Console.Write("\tIrja be egy platform nevet :");
            string BekertPlatformNeve = Console.ReadLine();
            Console.WriteLine("\tEzen a platformon a kovetkezo jatekok erhetoek el peldaul:");
            foreach (var item in Jatekok)
            {
                if (item.Platform.Contains(BekertPlatformNeve)) list.Add(item.Cim);
            }

            int sorszam = 1;
            foreach (var item in list)
            {
                Console.WriteLine($"{sorszam}. {item}");
                sorszam++;  
            }

        }

        private static void Feladat07()
        {
            Dictionary<string,int> LegtobbJatek = new Dictionary<string,int>();

            foreach (var item in Jatekok)
            {
                if (LegtobbJatek.ContainsKey(item.Kiado))
                {
                    LegtobbJatek[item.Kiado]++;

                }
                else
                {
                    LegtobbJatek.Add(item.Kiado, 1);
                }
            }

            string nev = LegtobbJatek.OrderBy(x => x.Value).Last().Key;
            int darab = LegtobbJatek.OrderBy(x => x.Value).Last().Value;

            Console.WriteLine("7. feladat:");
            Console.WriteLine($"\tA legtobb jatekkal szereplo kiado: {nev} ({darab} jatek)");

        }

        private static void Feladat06()
        {
            Dictionary<int, string> NESJatekok = new Dictionary<int, string>();
            //key:megjelenes, value: cim
            foreach (var item in Jatekok)
            {
                if (item.Platform.Contains("NES") & !NESJatekok.ContainsKey(item.Megjelenes))
                {
                    NESJatekok.Add(item.Megjelenes, item.Cim);
                }
            }

            string nev = NESJatekok.OrderBy(x => x.Key).First().Value;
            int megjelenesEve = NESJatekok.OrderBy(y => y.Key).First().Key;

            Console.WriteLine("6. feladat:");
            Console.WriteLine($"Az utolso NES jatek a {nev}, megjelenesei eve: {megjelenesEve}");
        }

        private static void Feladat05()
        {
          
            Dictionary<int, int> SikeresEvek = new Dictionary<int, int>();
            // key: ev, value: darab
            List<int> SikeresEvekListaja = new List<int>();

            foreach (var item in Jatekok)
            {
                if (SikeresEvek.ContainsKey(item.Megjelenes))
                {
                    SikeresEvek[item.Megjelenes]++;
                }
                else
                {
                    SikeresEvek.Add(item.Megjelenes, 1);
                }
            }
            foreach (var item in SikeresEvek)
            {
                if (item.Value >= 7) SikeresEvekListaja.Add(item.Key);
            }

            Console.WriteLine("5. feladat:");
            Console.WriteLine("Igazan sikeres evek:");
            Console.Write("\t");

           
            foreach (var item in SikeresEvekListaja)
            {
                Console.Write($"{item} ");
            }

        }

        private static void Feladat04()
        {
            int PCJatekIs = 0;
            foreach (var item in Jatekok)
            {
                if(item.Platform.Contains("PC")) PCJatekIs++;
            }
            Console.WriteLine("4. feladat:");
            Console.WriteLine($"\t{PCJatekIs} db. jatek jelent meg eloszor PC  re (is)");
        }

        private static void Feladat03()
        {
            Console.WriteLine("3. feladat:");
            Console.WriteLine($"\tOsszsesen: {Jatekok.Count} jatek szerepel a listaban");

        }

        private static void Feladat02()
        {
            using (var sr = new StreamReader(@"..\\..\\Resources\games.txt", Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    Jatekok.Add(new Jatek(sr.ReadLine()));
                }
            }

        }
    }
}
