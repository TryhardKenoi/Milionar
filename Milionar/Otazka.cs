using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionar
{
    class Otazka
    {
        /*
         * 0-9 = nejmensi a nejvetsi stupen
         */
        public int stupen = 0;
        public string otazka;
        public string[] odpovedi = new string[4];
        public int spravnaOdpoved;

        public Otazka(int stupen, string otazka, string[] odpovedi, int spravnaOdpoved)
        {
            this.stupen = stupen;
            this.otazka = otazka;
            this.odpovedi = odpovedi;
            this.spravnaOdpoved = spravnaOdpoved;
        }
    }
}