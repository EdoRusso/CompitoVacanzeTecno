using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EsTecnoVacanze
{
    class CPersone
    {
        public class CGestione
        {
            private List<CPersona> lista;

            public CGestione(List<CPersona> lista)
            {
                this.lista = lista;
            }

            public List<CPersona> getList()
            {
                return lista;
            }

            public void Agg(CPersona A)
            {
                lista.Add(A);
            }

            public CPersona GetElemento(int pos)
            {
                return lista.ElementAt(pos);
            }

            public string getAllCSV()
            {
                string tmp = "";
                for (int i = 0; i < lista.Count; i++)
                {
                    tmp += lista.ElementAt(i).ToString() + "\n";
                }
                return tmp;
            }

        }
    }
}
