using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    /// <summary>
    /// Clase Fachada del ejercicio04, abstrae implementaciones de las clases Biblioteca y Libro
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
        /// <param name="pBiblioteca">Biblioteca a la que se le quiere agregar el libro</param>
        public bool AgregarABiblioteca(Libro pLibro, Biblioteca pBiblioteca)
        {
            return pBiblioteca.AgregarLibro(pLibro);
        }

        /// <summary>
        /// Permite quitar un libro de una biblioteca
        /// </summary>
        /// <param name="pTitulo">Titulo de libro que se quiere quitar</param>
        /// <param name="pBiblioteca">Biblioteca de la cual se quiere quitar el libro</param>
        /// <returns>Devuelve un booleano que indica si se pudo quitar el libro o no</returns>
        public bool QuitarDeBiblioteca(string pTitulo, Biblioteca pBiblioteca)
        {
            return pBiblioteca.QuitarLibro(pTitulo);
        }

        /// <summary>
        /// Permite mostrar la informacion de un libro de la biblioteca
        /// </summary>
        /// <param name="pTitulo">Titulo libro que se quiere mostrar</param>
        /// <param name="pBiblioteca">Biblioteca donde se encuentra el libro que se quiere mostrar</param>
        /// <returns>Devuelve la instancia de Libro que se corresponde con el Titulo, o null si no se encuentra el libro</returns>
        public Libro InformacionDeLibro(string pTitulo, Biblioteca pBiblioteca)
        {
            return pBiblioteca.BuscarLibro(pTitulo);
        }

        public int PrestamoDeLibro(string pTitulo, Biblioteca pBiblioteca)
        {
            return pBiblioteca.PrestarLibro(pTitulo);
        }

        public int DevolucionDeLibro(string pTitulo, Biblioteca pBiblioteca)
        {
            return pBiblioteca.DevolverLibro(pTitulo);
        }

    }
}
