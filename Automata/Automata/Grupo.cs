using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata
{
    public class Grupo
    {

        public static bool EsSimboloValido(char simbolo)
        {
            //se pasan los datos del listbox a minusculas
            string grupo = IngresoCaracteres.caracterGrupo?.ToLower() ?? "";

            //se inicializa la varible de control
            bool perteneceAlGrupo = false;

            // Verificar si el símbolo pertenece al grupo
            if (grupo == "digitos")
            {
                perteneceAlGrupo = char.IsDigit(simbolo);
            }

            else if (grupo == "vocales")
            {
                perteneceAlGrupo = "aeiouAEIOU".IndexOf(simbolo) >= 0;
            }

            else if (grupo == "letras")
            {
                perteneceAlGrupo = char.IsLetter(simbolo);
            }

            // Verificar si el símbolo pertenece a los caracteres personalizados
            bool perteneceACaracterPersonalizado = false;

            if (!string.IsNullOrEmpty(IngresoCaracteres.caracter1) && IngresoCaracteres.caracter1.Length > 0)
                perteneceACaracterPersonalizado |= char.ToLower(simbolo) == char.ToLower(IngresoCaracteres.caracter1[0]);

            if (!string.IsNullOrEmpty(IngresoCaracteres.caracter2) && IngresoCaracteres.caracter2.Length > 0)
                perteneceACaracterPersonalizado |= char.ToLower(simbolo) == char.ToLower(IngresoCaracteres.caracter2[0]);

            if (!string.IsNullOrEmpty(IngresoCaracteres.caracter3) && IngresoCaracteres.caracter3.Length > 0)
                perteneceACaracterPersonalizado |= char.ToLower(simbolo) == char.ToLower(IngresoCaracteres.caracter3[0]);

            if (!string.IsNullOrEmpty(IngresoCaracteres.caracter4) && IngresoCaracteres.caracter4.Length > 0)
                perteneceACaracterPersonalizado |= char.ToLower(simbolo) == char.ToLower(IngresoCaracteres.caracter4[0]);

            // Acepta si pertenece al grupo o a los personalizados
            return perteneceAlGrupo || perteneceACaracterPersonalizado;
        }
    }
}
