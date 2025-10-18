using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automata
{
    public class ProcesarColumnas
    {
        public int ObtenerColumnaPorSimbolo(DataGridView dgv, char simbolo)
        {
            //Busca en cada columna que el HeaderText sea exactamente el símbolo
            for (int i = 1; i < dgv.Columns.Count; i++) // omitir columna "Estado"
            {
                if (dgv.Columns[i].HeaderText == simbolo.ToString())
                    return i;
            }

            //Si no coincide con ningún carácter personalizado, verifica el grupo
            string grupo = IngresoCaracteres.caracterGrupo?.ToLower() ?? "";
            if (grupo == "digitos")
            {
                if (char.IsDigit(simbolo))
                    return dgv.Columns.Count - 2; // penúltima columna antes de FDC
            }
            else if (grupo == "vocales")
            {
                if ("aeiouAEIOU".IndexOf(simbolo) >= 0)
                    return dgv.Columns.Count - 2;
            }
            else if (grupo == "letras")
            {
                if (char.IsLetter(simbolo))
                    return dgv.Columns.Count - 2;
            }

            return -1;
        }
    }
    
}
