using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    class Libro
    {
        private string iTitulo;
        private string iAutor;
        private string iEditorial;
        private int iAnio;

        public string Titulo
        {
            get { return this.iTitulo; }
            private set {this.iTitulo = value;}
        }

        public string Autor
        {
            get { return this.iAutor; }
            private set { this.iAutor = value; }
        }

        public string Editorial
        {
            get { return this.iEditorial; }
            private set { this.iEditorial = value; }
        }

        public int Anio
        {
            get { return this.iAnio; }
            private set { this.iAnio = value; }
        }

        public Libro(string pTitulo, string pAutor, string pEditorial, int pAnio)
        {
            Titulo = pTitulo;
            Autor = pAutor;
            Editorial = pEditorial;
            Anio = pAnio;
        } 

    }
}
