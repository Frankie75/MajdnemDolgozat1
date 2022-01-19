using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajdnemDolgozat1
{
    internal class Jatek
    {
        public int Megjelenes { get; set; }
        public string Cim { get; set; }
        public string Mufaj { get; set; }
        public string Kiado { get; set; }
        public string Platform { get; set; }

        public Jatek(string sor)
        {
            var darabok = sor.Split(';');
            Megjelenes = int.Parse(darabok[0]);
            Cim = darabok[1];
            Mufaj = darabok[2];
            Kiado = darabok[3];
            Platform = darabok[4];
        }
    }
}
