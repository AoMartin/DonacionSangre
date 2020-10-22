using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DonacionSangre
{
    class Sangre
    {
        private int litros;
        private string grupoSanguineo;

        public int Litros { get => litros; set => litros = value; }
        public string GrupoSanguineo { get => grupoSanguineo; set => grupoSanguineo = value; }
    }
}
