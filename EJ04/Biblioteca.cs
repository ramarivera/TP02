using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    /// <summary>
    /// Reprenseta una biblioteca
    /// </summary>
    class Biblioteca
    {
        /// <summary>
        /// Reprensenta un libro de la biblioteca
        /// </summary>
        private Libro iLibro;

        /// <summary>
        /// Arreglo de elementos de la clase Libro, de longitud 5
        /// </summary>
        private Libro[] libros= new Libro[5];

        /// <summary>
        /// Propiedad Libro, solo lectura
        /// </summary>
        public Libro Libro
        {
            get { return this.iLibro; }
            private set { this.iLibro = value; }
        }

        /// <summary>
        /// Verifica si los espacios de la biblioteca estan llenos de libros
        /// </summary>
        /// <returns>Devuelve un booleano que es verdadero si la biblioteca esta llena de libros</returns>
        public bool BibliotecaLlena()
        {
            bool llena=true;
            int i = 0;
            while ((llena = false) && !(i < 5))
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
                Console.ReadKey();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Agrega un libro a la biblioteca siempre que haya lugar para este
        /// </summary>
        /// <param name="pLibro">Libro que se quiere agregar a la biblioteca</param>
        public void AgregarLibro(Libro pLibro)
        {
            int i =0;
            bool cargado = false;
            if (BibliotecaLlena() == false)
            {
                while ((cargado == false) && (i < 5))
                {
                    if (libros[i] == null)
                    {
                        libros[i] = pLibro;
                        cargado = true;
                    }
                    i++;
                }
            }
        }

        /// <summary>
        /// Retira un libro de la biblioteca
        /// </summary>
        /// <param name="pTitulo">Titulo del libro que se quiere retirar de la biblioteca</param>
        /// <returns>Devuelve un booleano que informa si el libro pudo ser borrado o no</returns>
        public bool QuitarLibro(string pTitulo)
        {
            int i = 0;
            bool borrado = false;
            while ((i < 5) && (borrado == false))
            {
                if ((libros[i]!=null) && (pTitulo == libros[i].Titulo)) 
                {
                    libros[i] = null;
                    borrado = true;
                }
                i++;
            }
            return borrado;
        }
/*
        public Libro MostrarLibro(string titulo)
        {
            int i = 0;
            bool encontrado = false;
            while ((encontrado == false) || (i < 5))
            {
                if (titulo == libros[i].Titulo)
                {
                    return libros[i];
                    encontrado = true;
                }
                i++;
            }
            if (encontrado == false)
            {
                return null;
            }
        }
 */
    }
}
