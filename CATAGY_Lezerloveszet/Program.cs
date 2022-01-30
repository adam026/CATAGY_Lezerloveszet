using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATAGY_Lezerloveszet
{
    internal class Program
    {
        static List<JatekosLovese> lovesek = new List<JatekosLovese>();
        static Dictionary<string,int> jatekosokSzerint = new Dictionary<string, int>();
        static Dictionary<string, double> atlagpontszamokSzerint = new Dictionary<string, double>();

        static void Main(string[] args)
        {
            Beolvas();
            F05();
            F07();
            F09();
            F10();
            F11();
            F12();
            F13();
        }

        private static void F13()
        {
            var nyertes = atlagpontszamokSzerint.OrderBy(x => x.Value).Last();
            Console.WriteLine($"13. Feladat: A játék nyertese: {nyertes.Key}");
        }

        private static void F12()
        {
            Console.WriteLine("12. Feladat: Átlagpontszámok: ");
            foreach (var jatekos in jatekosokSzerint)
            {
                var atlagPontszam = lovesek.Where(x => x.Nev == jatekos.Key).Average(y => y.Pontszam);
                Console.WriteLine($"\t{jatekos.Key} - {atlagPontszam}");
                if (!atlagpontszamokSzerint.ContainsKey(jatekos.Key))
                {
                    atlagpontszamokSzerint.Add(jatekos.Key, atlagPontszam);
                }
                else
                {
                    atlagpontszamokSzerint[jatekos.Key] += atlagPontszam;
                }
            }
        }

        private static void F11()
        {
            Console.WriteLine($"11. Feladat: Lövések száma: ");
            foreach (var jatekos in jatekosokSzerint)
            {
                Console.WriteLine($"\t{jatekos.Key} - {jatekos.Value} db");
            }
        }

        private static void F10()
        {
            for (int i = 1; i < lovesek.Count; i++) //Mivel a konstruktor miatt benne van a forrásállomány első sora is a listában!
            {
                if (!jatekosokSzerint.ContainsKey(lovesek[i].Nev))
                {
                    jatekosokSzerint.Add(lovesek[i].Nev, 1);
                }
                else
                {
                    jatekosokSzerint[lovesek[i].Nev] += 1;
                }
            }
            Console.WriteLine($"10. Feladat: Játékosok száma: {jatekosokSzerint.Keys.Count}");
        }

        private static void F09()
        {
            var nullaPontosLovesek = lovesek.Where(x => x.Pontszam == 0).Count();
            Console.WriteLine($"9. Feladat: Nulla pontos lövések száma: {nullaPontosLovesek - 1} db"); 
            //Mivel a forrásállomány első sorát is számolja a konstruktor miatt
        }

        private static void F07()
        {
            var legpontosabb = lovesek.OrderBy(x => x.Tavolsag).First();
            var hely = lovesek.IndexOf(legpontosabb);
            Console.WriteLine($"7. Feladat: Legpontosabb lövés: \n\t{hely}. {legpontosabb.Nev} x={legpontosabb.LovesX}; y={legpontosabb.LovesY}; távolság: {legpontosabb.Tavolsag}");
        }

        private static void F05()
        {
            Console.WriteLine($"5. Feladat: Lövések száma: {lovesek.Count} db");
        }

        private static void Beolvas()
        {
            using (var sr = new StreamReader(@"..\..\RES\lovesek.txt", Encoding.UTF8))
            {
                var szamlalo = 1;

                while (!sr.EndOfStream)
                {
                    lovesek.Add(new JatekosLovese(sr.ReadLine(), szamlalo));
                    szamlalo++;
                }

            }
        }
    }
}
