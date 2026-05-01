//TP

using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_IFTS29_Grupo8
{
    internal class Lector
    {
        // TP: Parametros
        private string nombre;
        private string dni;
        private List<Libro> librosEnPrestamo;

        //TP: Constructor
        public Lector(string nombre, string dni)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.librosEnPrestamo = new List<Libro> ();
        }

        // TP: Metodos para leer

        public string getNombre()
        {
            return nombre;
        }
        
        public string getDni()
        {
            return dni;
        }

        public List<Libro> getLibrosEnPrestamo()
        {
            return librosEnPrestamo;
        }

        public int getCantidadPrestamos()
        {
            return librosEnPrestamo.Count;
        }


        // TP: Metodos para operar con los libros

        public void agregarLibro(Libro libro)
        {
            librosEnPrestamo.Add(libro);
        }

        public void devolverLibro(Libro libro)
        {
            librosEnPrestamo.Remove(libro);
        }


        // Info del objeto
        public override string ToString()
        {
            return "Nombre: " + nombre + " DNI: " + dni + " Prestamos: " + librosEnPrestamo.Count;
        }

    }
}
