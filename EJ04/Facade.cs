using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    /// <summary>
    /// /// Clase Fachada del ejercicio04, abstrae implementaciones de las clases Biblioteca y Libro
    /// </summary>
    class Facade
    {
        /// <summary>
        /// Permite cargar los datos de un nuevo libro
        /// </summary>
        /// <param name="pTitulo">Titulo del libro</param>
        /// <param name="pAutor">Autor del libro</param>
        /// <param name="pEditorial">Editorial del libro</param>
        /// <param name="pAnio">Año de publicacion del libro</param>
        /// <returns>Devuelve el Libro que se ha creado</returns>
        public Libro CargarLibro(string pTitulo, string pAutor, string pEditorial, int pAnio)
        {
            return new Libro(pTitulo, pAutor, pEditorial, pAnio);
        }

        /// <summary>
        /// Permite agregar el libro cargado a la biblioteca
        /// </summary>
        /// <param name="pLibro">Libro que se quiere agregar</param>
        /// <param name="biblioteca">Biblioteca a la que se le quiere agregar el libro</param>
        public void AgregarABiblioteca(Libro pLibro, Biblioteca biblioteca)
        {
            biblioteca.AgregarLibro(pLibro);
        }

        /// <summary>
        /// Permite quitar un libro de una biblioteca
        /// </summary>
        /// <param name="titulo">Titulo de libro que se quiere quitar</param>
        /// <param name="biblioteca">Biblioteca de la cual se quiere quitar el libro</param>
        /// <returns>Devuelve un booleano que indica si se pudo quitar el libro o no</returns>
        public bool QuitarDeBiblioteca(string titulo, Biblioteca biblioteca)
        {
           return biblioteca.QuitarLibro(titulo);
        }

    }
}
