using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_IFTS29_Grupo12
{
    internal class Biblioteca
    {
        private List<Libro> libros;

        // TP: Atributo de lista de lectores registrados
        private List<Lector> lectores;

        public Biblioteca()
        {
            this.libros = new List<Libro>();

            //TP: Crear lista de lectores con el constructor
            this.lectores = new List<Lector>();
        }

        private Libro buscarLibro(string titulo)
        {
            Libro libroBuscado = null;
            int i = 0;
            while (i < libros.Count && !libros[i].getTitulo().Equals(titulo))
                i++;
            if (i != libros.Count)
                libroBuscado = libros[i];
            return libroBuscado;
        }

        public bool agregarLibro(string titulo, string autor, string editorial)
        {
            bool resultado = false;
            Libro libro;
            libro = buscarLibro(titulo);
            if (libro == null)
            {
                libro = new Libro(titulo, autor, editorial);
                libros.Add(libro);
                resultado = true;
            }
            return resultado;
        }

        public void listarLibros()
        {
            foreach (var libro in libros)
                Console.WriteLine(libro);
        }

        public bool eliminarLibro(string titulo)
        {
            bool resultado = false;
            Libro libro;
            libro = buscarLibro(titulo);
            if (libro != null)
            {
                libros.Remove(libro);
                resultado = true;
            }
            return resultado;
        }


        // Tp: Buscar si lector ya esta registrado, por DNI que es unico
        private Lector buscarLector(string dni)
        {
            Lector lector = null;
            int i = 0;

            // TP: Iterar para buscar al lector en la lista de lectores existentes
            while (i < lectores.Count && !lectores[i].getDni().Equals(dni))
                i++;
            if (i != lectores.Count)
                lector = lectores[i];
            return lector;
        }

        //TP: Registrar al lector
        public bool altaLector(string nombre, string dni)
        {
            bool resultado = false;

            // Crear lector si no existe, notificar si si
            Lector lector;
            lector = buscarLector(dni);
            if (lector == null)
            {
                lector = new Lector(nombre, dni);
                lectores.Add(lector);
                resultado = true;
            }
            else
            {

            }
            return resultado;
        }

        // Tp: Metodo para prestar libros a lector

        public string prestarLibro(string titulo, string dni)
        {

            //El orden seria: Buscar que el lector existe (presumimos menos lectores que libros) y que no tenga el tope, luego buscar el libro, luego añadir a lector, y borrar.

            Lector lector = buscarLector(dni);

            if (lector != null)
            {
                if (lector.getLibrosEnPrestamo().Count < 3)
                {
                    Libro libro = buscarLibro(titulo);
                    if (libro != null)
                    {
                        lector.agregarLibro(libro);
                        libros.Remove(libro);
                        return "PRESTAMO EXITOSO";
                    }
                    else
                    {
                        return "LIBRO INEXISTENTE";
                    }
                }
                else
                {
                    return "TOPE DE PRESTAMO ALCANZADO";
                }
            }
            else
            {
                return "LECTOR INEXISTENTE";
            }

        }
    }
}