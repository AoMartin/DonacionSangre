using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DonacionSangre
{
    public enum GrupoSangre
    {
        A, B, AB, Cero
    }
    class Sangre
    {    
        
        private int litros;
        private GrupoSangre grupoSanguineo;
        private bool factorRH = false;  // True + False -

        public Sangre(int litros, GrupoSangre grupoSanguineo, bool factorRH)
        {
            this.litros = litros;
            this.grupoSanguineo = grupoSanguineo;
            this.factorRH = factorRH;
        }

        public int Litros { get => litros; set => litros = value; }
        public GrupoSangre GrupoSanguineo { get => grupoSanguineo; set => grupoSanguineo = value; }
        public bool FactorRH { get => factorRH; set => factorRH = value; }
    }
}
