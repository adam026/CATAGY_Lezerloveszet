using System;

namespace CATAGY_Lezerloveszet
{
    class JatekosLovese
    {
        static float CeltablaX { get; set; }
        static float CeltablaY { get; set; }
        public string Nev { get; set; }
        public int Loves { get; set; }
        public float LovesX { get; set; }
        public float LovesY { get; set; }
        public double Tavolsag => TKiszamol(LovesX, LovesY);
        public double Pontszam => PontszamKiszamol(Tavolsag);

        public JatekosLovese(string sor, int szamlalo)
        {
            if (szamlalo == 1)
            {
                var buffer = sor.Split(';');
                CeltablaX = float.Parse(buffer[0]);
                CeltablaY = float.Parse(buffer[1]);
            }
            else
            {
                var buff = sor.Split(';');
                Nev = buff[0];
                LovesX = float.Parse(buff[1]);
                LovesY = float.Parse(buff[2]);
                Loves = szamlalo - 1;
            }
            
        }

        private double TKiszamol(float kx, float ky)
        {
            var dx = CeltablaX - kx;
            var dy = CeltablaY - ky;
            return (Math.Sqrt((dx * dx) + (dy * dy)));
        }

        private double PontszamKiszamol(double tavolsag)
        {
            var eredmeny = 10 - tavolsag;
            if (eredmeny <= 0)
            {
                return 0;
            }
            else
            {
                return eredmeny;
            }
        }



    }
}
