using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata
{
    public class Grupo
    {
        public bool EsSimboloValido(char simbolo)
        {
            string grupo = IngresoCaracteres.caracterGrupo?.ToLower() ?? "";

            if (grupo == "dígitos" || grupo == "digitos")
                return char.IsDigit(simbolo);

            if (grupo == "vocales")
                return "aeiouAEIOU".Contains(simbolo);

            if (grupo == "letras")
                return char.IsLetter(simbolo);

            // Si no hay grupo, solo acepta los 4 caracteres definidos
            return simbolo == IngresoCaracteres.caracter1[0] ||
                   simbolo == IngresoCaracteres.caracter2[0] ||
                   simbolo == IngresoCaracteres.caracter3[0] ||
                   simbolo == IngresoCaracteres.caracter4[0];
        }
    }
}
