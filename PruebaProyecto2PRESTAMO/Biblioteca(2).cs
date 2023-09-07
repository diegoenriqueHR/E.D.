using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PruebaProyecto2PRESTAMO
{
    internal class Biblioteca
    {
        public libro PrimerLibro { get; set; }
        public prestamo PrimerPrestamo { get; set; }
        private Random random = new Random();

        public void AgregarLibro(string titulo, string autor, int añoPublicacion)
        {
            int codigoAleatorio = random.Next(1000, 10000);

            // Verificar si el código ya existe y, si es así, generar uno nuevo único
            while (LibroConCodigoExiste(codigoAleatorio))
            {
                codigoAleatorio = random.Next(1000, 10000);
            }

            libro nuevoLibro = new libro
            {
                Codigo = codigoAleatorio,
                Titulo = titulo,
                Autor = autor,
                AñoPublicacion = añoPublicacion,
                Disponible = true
            };

            nuevoLibro.Siguiente = PrimerLibro;
            PrimerLibro = nuevoLibro;
            Console.WriteLine("\n===========================");
            Console.WriteLine("Libro registrado con éxito.");
            Console.WriteLine("===========================\n");
        }

        // Método para verificar si un libro con el código dado ya existe
        private bool LibroConCodigoExiste(int codigo)
        {
            libro actual = PrimerLibro;
            while (actual != null)
            {
                if (actual.Codigo == codigo)
                {
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }
        public void MostrarLibros()
        {
            Console.Clear();
            Console.WriteLine("Lista de Libros Registrados:");
            Console.WriteLine("------------------------------\n");
            libro actual = PrimerLibro;
            while (actual != null)
            {
                Console.WriteLine("==============================");
                Console.WriteLine("Código: {0}", actual.Codigo);
                Console.WriteLine("Título: {0}\nAutor: {1}\nAño de Publicación: {2}", (actual.Titulo), (actual.Autor), (actual.AñoPublicacion));
                actual = actual.Siguiente;
                Console.WriteLine("==============================\n");
            }
            Console.WriteLine("\n------------------------------");
            Console.ReadKey();
            Console.Clear();
        }
        private libro BuscarLibroPorTitulo(string titulo)
        {
            libro actual = PrimerLibro;
            while (actual != null)
            {
                if (actual.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    return actual;
                }
                actual = actual.Siguiente;
            }
            return null;
        }
        private prestamo BuscarPrestamoPorLibro(libro libro)
        {
            prestamo actual = PrimerPrestamo;
            while (actual != null)
            {
                if (actual.LibroPrestado == libro)
                {
                    return actual;
                }
                actual = actual.Siguiente;
            }
            return null;
        }

        public void RegistrarPrestamo(string persona, string tituloLibro)
        {
            libro libroPrestado = BuscarLibroPorTitulo(tituloLibro);

            if (libroPrestado != null && libroPrestado.Disponible)
            {
                prestamo nuevoPrestamo = new prestamo
                {
                    Persona = persona,
                    FechaPrestamo = DateTime.Now,
                    LibroPrestado = libroPrestado
                };

                nuevoPrestamo.Siguiente = PrimerPrestamo;
                PrimerPrestamo = nuevoPrestamo;

                libroPrestado.Disponible = false;
                Console.WriteLine("\n");
                Console.WriteLine("==============================");
                Console.WriteLine("Préstamo registrado con éxito.");
                Console.WriteLine("==============================");
            }
            else
            {
                Console.WriteLine("\n");
                Console.WriteLine("==============================");
                Console.WriteLine("El libro no está disponible para préstamo o no se encontró.");
                Console.WriteLine("==============================");
            }
        }

        public void RegistrarDevolucion(string tituloLibro)
        {
            libro libroDevuelto = BuscarLibroPorTitulo(tituloLibro);

            if (libroDevuelto != null && !libroDevuelto.Disponible)
            {
                prestamo prestamo = BuscarPrestamoPorLibro(libroDevuelto);

                if (prestamo != null)
                {
                    libroDevuelto.Disponible = true;

                    Console.WriteLine("Devolución registrada con éxito.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("El libro no se puede devolver o no se encontró.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void MostrarPrestamos()
        {
            Console.Clear();
            Console.WriteLine("Lista de Préstamos Registrados:");
            Console.WriteLine("---------------------------------");
            prestamo actual = PrimerPrestamo;
            while (actual != null)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine();
                Console.WriteLine("Persona: {0}\n Título del libro prestado: {1}\n Fecha de Préstamo: {2}", (actual.Persona), (actual.LibroPrestado.Titulo), (actual.FechaPrestamo));
                actual = actual.Siguiente;
                Console.WriteLine();
                Console.WriteLine("=====================================");
            }
            Console.ReadKey();
        }
    }
}
