using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DonacionSangre
{
    class Paciente
    {
        private string nombre;
        private string apellido;
        private int dni;
        private string telefono;
        private string mail;
        private string direccion;
        private string grupoSanguineo;

        public Paciente(string nombre, string apellido, int dni, string telefono, string mail, string direccion, string grupoSanguineo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.dni = dni;
            this.telefono = telefono;
            this.mail = mail;
            this.grupoSanguineo = grupoSanguineo;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Dni { get => dni; set => dni = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string GrupoSanguineo { get => grupoSanguineo; set => grupoSanguineo = value; }
    }
}
