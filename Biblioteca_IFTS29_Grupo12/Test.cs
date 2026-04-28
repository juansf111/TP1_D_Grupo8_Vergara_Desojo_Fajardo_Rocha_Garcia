using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_IFTS29_Grupo12
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            cargarLibros(10, biblioteca);
            cargarLibros(2, biblioteca);
            biblioteca.listarLibros();
            biblioteca.eliminarLibro("Libro5");
            biblioteca.listarLibros();

            // TP: Agregar casos de prueba para lo que acabamos de crear

            // Crear Lector
            bool pude = biblioteca.altaLector("Juan", "95627");
            if (pude)
                Console.WriteLine("Lector registrado correctamente.");
            else
                Console.WriteLine("Lector ya existe.");
            // Lector inexistente
            Console.WriteLine(biblioteca.prestarLibro("Libro7", "9999"));
            //Libro inexistente
            Console.WriteLine(biblioteca.prestarLibro("Libro999", "95627"));

            //Prestar 3 libros validos a usuario existente
            Console.WriteLine(biblioteca.prestarLibro("Libro1", "95627"));
            Console.WriteLine(biblioteca.prestarLibro("Libro2", "95627"));
            Console.WriteLine(biblioteca.prestarLibro("Libro3", "95627"));

            // Limite superado
            Console.WriteLine(biblioteca.prestarLibro("Libro4", "95627"));
        }

        static void cargarLibros(int cantidad, Biblioteca biblioteca)
        {
            bool pude;
            for (int i = 1; i <= cantidad; i++)
            {
                pude = biblioteca.agregarLibro("Libro" + i, "Autor" + i, "Editorial" + i);
                if (pude)
                    Console.WriteLine("Libro" + i + " agregado correctamente.");
                else
                    Console.WriteLine("Libro" + i + " Ya existe en la biblioteca.");
            }
        }
    }
}