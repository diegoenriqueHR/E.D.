using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto2PRESTAMO
{
    internal class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Gestión de Biblioteca");
                Console.WriteLine("1. Registrar un nuevo libro");
                Console.WriteLine("2. Mostrar lista de libros registrados");
                Console.WriteLine("3. Registrar un préstamo de libro");
                Console.WriteLine("4. Registrar la devolución de un libro");
                Console.WriteLine("5. Mostrar lista de préstamos");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Registro de libro");
                            Console.WriteLine("------------------------------\n");
                            Console.Write("Título del libro: ");
                            string titulo = Console.ReadLine();
                            Console.Write("Autor: ");
                            string autor = Console.ReadLine();
                            Console.Write("Año de Publicación: ");
                            if (int.TryParse(Console.ReadLine(), out int añoPublicacion))
                            {
                                int codigoAleatorio = random.Next(1000, 10000);
                                biblioteca.AgregarLibro(titulo, autor, añoPublicacion);
                            }
                            else
                            {
                                Console.WriteLine("Año de publicación no válido.");
                            }
                            Console.WriteLine("------------------------------\n");
                            Console.ReadKey();
                            break;
                        case 2:
                            biblioteca.MostrarLibros();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Registro Prestamo de libro");
                            Console.WriteLine("---------------------------");
                            Console.WriteLine();
                            Console.Write("Persona que realiza el préstamo: ");
                            string personaPrestamo = Console.ReadLine();
                            Console.Write("Título del libro a prestar: ");
                            string tituloPrestamo = Console.ReadLine();
                            biblioteca.RegistrarPrestamo(personaPrestamo, tituloPrestamo);
                            Console.WriteLine();
                            Console.WriteLine("---------------------------");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            Console.Write("Título del libro a devolver: ");
                            string tituloDevolucion = Console.ReadLine();
                            biblioteca.RegistrarDevolucion(tituloDevolucion);
                            break;
                        case 5:
                            biblioteca.MostrarPrestamos();
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Intente de nuevo.");
                }
            }
        }
    }
}
internal class Biblioteca
{
    private List<Libro> libros = new List<Libro>();
    private List<Prestamo> prestamos = new List<Prestamo>();
    private Random random = new Random();

    public void AgregarLibro(string titulo, string autor, int añoPublicacion)
    {
        int codigoAleatorio = random.Next(1000, 10000);
        libros.Add(new Libro(codigoAleatorio, titulo, autor, añoPublicacion));
        Console.WriteLine("Libro registrado con éxito.");
    }

    public void MostrarLibros()
    {
        Console.WriteLine("Lista de libros registrados:");
        foreach (var libro in libros)
        {
            Console.WriteLine($"Código: {libro.Codigo}, Título: {libro.Titulo}, Autor: {libro.Autor}, Año de Publicación: {libro.AñoPublicacion}");
        }
        Console.ReadKey();
    }

    public void RegistrarPrestamo(string persona, string tituloLibro)
    {
        // Implementa la lógica para registrar un préstamo
    }

    public void RegistrarDevolucion(string tituloLibro)
    {
        // Implementa la lógica para registrar una devolución
    }

    public void MostrarPrestamos()
    {
        // Implementa la lógica para mostrar la lista de préstamos
    }
}

internal class Libro
{
    public int Codigo { get; }
    public string Titulo { get; }
    public string Autor { get; }
    public int AñoPublicacion { get; }

    public Libro(int codigo, string titulo, string autor, int añoPublicacion)
    {
        Codigo = codigo;
        Titulo = titulo;
        Autor = autor;
        AñoPublicacion = añoPublicacion;
    }
}

internal class Prestamo
{
    public string Persona { get; }
    public string TituloLibro { get; }
    public DateTime FechaPrestamo { get; }

    public Prestamo(string persona, string tituloLibro)
    {
        Persona = persona;
        TituloLibro = tituloLibro;
        FechaPrestamo = DateTime.Now;
    }
}

