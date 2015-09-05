using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
    class Motor
    {
        private int iLitrosAceite;
        private int iCv;

        public int LitrosAceite
        {
            get { return this.iLitrosAceite; }
            private set { this.iLitrosAceite = value; }
        }

        public int CV
        {
            get { return this.iCv; }
            private set { this.iCv = value; }
        }

        public Motor(int pCv)
        {
            LitrosAceite = 0;
            CV = pCv;
        }

        public void AgregarLitrosAceite(int pLitrosDeAceite)
        {
            LitrosAceite = pLitrosDeAceite;
        }


    }
}
