using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    class Facade
    {
        public Libro CargarLibro(string pTitulo, string pAutor, string pEditorial, int pAnio)
        {
            return new Libro(pTitulo, pAutor, pEditorial, pAnio);
        }
    }
}
