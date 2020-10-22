using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DonacionSangre
{
    public class Donante
    {
        private int dni;
        private string nombre;
        private string apellido;
        private string fechaNacimiento;
        private int telefono;
        private string mail;
        private string direccion;
        private string grupoSanguineo;
        
        public Donante(int dni, string nombre, string apellido, string fechaNacimiento, int telefono, string mail, string direccion, string grupoSanguineo)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
            this.telefono = telefono;
            this.mail = mail;
            this.direccion = direccion;
            this.grupoSanguineo = grupoSanguineo;
        }

        public int Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string GrupoSanguineo { get => grupoSanguineo; set => grupoSanguineo = value; }


    }
    
}
