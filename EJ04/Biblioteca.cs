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
            while ((llena) && (i < 5))
            {                
                if(libros[i]==null)
                {
                    llena =false;
                }
                i++;
            }
            return llena;
        }

        /// <summary>
        /// Agrega un libro a la biblioteca siempre que haya lugar para este
        /// </summary>
        /// <param name="pLibro">Libro que se quiere agregar a la biblioteca</param>
        public bool AgregarLibro(Libro pLibro)
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
            return cargado;
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

        /// <summary>
        /// Obtiene la instancia del libro que se corresponde con el titulo ingresado
        /// </summary>
        /// <param name="pTitulo">Titulo del libro que se quiere conocer la informacion</param>
        /// <returns>Devuelve la instancia del libro solicitado, o null si no pudo encontrarlo</returns>
        public Libro BuscarLibro(string pTitulo)
        {
            int i = 0;
            Libro libro = null;
            bool encontrado = false;
            while ((i < 5) && (encontrado == false))
            {
                if ((libros[i] != null) && (pTitulo == libros[i].Titulo))
                {
                    libro = libros[i];
                    encontrado = true;
                }
                i++;
            }
            return libro;
        }

        /// <summary>
        /// Realiza el prestado de un libro
        /// </summary>
        /// <param name="pTitulo">Titulo del libro a prestar</param>
        /// <returns>Devuelve un numero entero: 0 si no pudo encontrar el libro; -1 si el libro ya se encuentra prestado; 1 si el libro se prestado correctamente</returns>
        public int PrestarLibro(string pTitulo)
        {
            Libro libro = this.BuscarLibro(pTitulo);
            if (libro == null)
            {
                return 0;
            }
            else if (libro.Prestado)
            {
                return -1;
            }
            else
            {
                libro.Prestar();
                return 1;
            }

        }

        /// <summary>
        /// Realiza la devolucion de un libro
        /// </summary>
        /// <param name="pTitulo">Titulo de libro a devolver</param>
        /// <returnsDevuelve un numero entero: 0 si no pudo encontrar el libro; -1 si el libro no esta prestado prestado; 1 si el libro se devolvio correctamente></returns>
        public int DevolverLibro(string pTitulo)
        {
            Libro libro = this.BuscarLibro(pTitulo);
            if (libro == null)
            {
                return 0;
            }
            else if (libro.Prestado)
            {
                libro.Devolver();
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
