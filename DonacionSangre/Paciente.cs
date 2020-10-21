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

        public Paciente()
        {

        }

        private void setDni(int dni)
        {
            this.dni = dni;
        }

        private int getDni()
        {
            return this.dni;
        }

        private void setNombre(string nom)
        {
            this.nombre = nom;
        }

        private string getNombre()
        {
            return this.nombre;
        }

        private void setApellido(string ape)
        {
            this.apellido= ape;
        }

        private string getApellido()
        {
            return this.apellido;
        }

        private void setTelefono(string tel)
        {
            this.telefono = tel;
        }

        private string getTelefono()
        {
            return this.telefono;
        }

        private void setMail(string mail)
        {
            this.mail = mail;
        }

        private string getMail()
        {
            return this.mail;
        }

        private void setDireccion(string dir)
        {
            this.direccion = dir;
        }

        private string getDireccion()
        {
            return this.direccion;
        }

        private void setGrupoSanguineo(string gs)
        {
            this.grupoSanguineo = gs;
        }

        private string getGrupoSanguineo()
        {
            return this.grupoSanguineo;
        }

    }
}
