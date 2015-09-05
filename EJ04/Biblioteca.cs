using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    class Biblioteca
    {
        private Libro iLibro;

        private Libro[] libros= new Libro[5];

        public Libro Libro
        {
            get { return this.iLibro; }
            private set { this.iLibro = value; }
        }


        public bool BibliotecaLlena()
        {
            bool llena=true;
            int i = 0;
            while ((llena != false) || i < 5)
            {                
                if(libros[i]==null)
                {
                    llena =false;
                }
                i++;
            }
            if (llena)
            {
                Console.WriteLine("La biblioteca esta llena");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AgregarLibro(Libro libro)
        {
            int i =0;
            if (BibliotecaLlena() == false)
            {
                while (i < 5)
                {
                    if (libros[i] == null)
                    {
                        libros[i] = libro;
                    }
                }
            }
        }

        public void QuitarLibro(string titulo)
        {
            int i = 0;
            bool borrado = false;
            while ((borrado == false) || (i<5))
            {
                if (titulo == libros[i].Titulo)
                {
                    libros[i] = null;
                    Console.WriteLine("Libro borrado correctamente");
                    Console.ReadKey();
                }
                i++;
            }
            if (borrado == false)
            {
                Console.WriteLine("No se encontre el libro");
                Console.ReadKey();
            }
        }
    }
}
