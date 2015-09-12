using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    /// <summary>
    /// Representa un libro
    /// </summary>
    class Libro
    {
        /// <summary>
        /// Representa el titulo del libro
        /// </summary>
        private string iTitulo;
        /// <summary>
        /// Representa el autor del libro
        /// </summary>
        private string iAutor;
        /// <summary>
        /// Representa la editorial del libro
        /// </summary>
        private string iEditorial;
        /// <summary>
        /// Representa el año de publicion del libro
        /// </summary>
        private int iAño;

        /// <summary>
        /// Representa si el libro se encuentra prestado o no
        /// </summary>
        private bool iPrestado;

        /// <summary>
        /// Propiedad Titulo, solo lectura
        /// </summary>
        public string Titulo
        {
            get { return this.iTitulo; }
            private set {this.iTitulo = value;}
        }

        /// <summary>
        /// Propiedad Autor, solo lectura
        /// </summary>
        public string Autor
        {
            get { return this.iAutor; }
            private set { this.iAutor = value; }
        }

        /// <summary>
        /// Propiedad Editorial, solo lectura
        /// </summary>
        public string Editorial
        {
            get { return this.iEditorial; }
            private set { this.iEditorial = value; }
        }

        /// <summary>
        /// Propiedad Año, solo lectura
        /// </summary>
        public int Año
        {
            get { return this.iAño; }
            private set { this.iAño = value; }
        }

        public bool Prestado
        {
            get { return this.iPrestado; }
            set { this.iPrestado = value; }
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="pTitulo">Titulo del libro</param>
        /// <param name="pAutor">Autor del libro</param>
        /// <param name="pEditorial">Editorial del libro</param>
        /// <param name="pAño">Año de publicacion del libro</param>
        public Libro(string pTitulo, string pAutor, string pEditorial, int pAño)
        {
            Titulo = pTitulo;
            Autor = pAutor;
            Editorial = pEditorial;
            Año = pAño;
            Prestado = false;
        }

        public void Prestar()
        {
            this.Prestado = true;
        }

        public void Devolver()
        {
            this.Prestado = false;
        }
    }
}
