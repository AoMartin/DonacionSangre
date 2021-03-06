﻿using System;
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
        private int telefono;
        private string mail;
        private string direccion;
        private Sangre tipoSangre;

        public Paciente(string nombre, string apellido, int dni, int telefono, string mail, string direccion, Sangre tipoSangre)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.dni = dni;
            this.telefono = telefono;
            this.mail = mail;
            this.tipoSangre = tipoSangre;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Dni { get => dni; set => dni = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public Sangre TipoSangre { get => tipoSangre; set => tipoSangre = value; }
    }
}
