using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automata
{
    public partial class CadenaEntrada : Form
    {
        public CadenaEntrada()
        {
            InitializeComponent();
        }

        CrearColumna CreadorCeldas=new CrearColumna();
        Grupo Grupo=new Grupo();

        public int ObtenerColumnaPorSimbolo(char simbolo)
        {
            // 1) Buscar columna cuyo HeaderText sea exactamente el símbolo (ej. columna "a", "b" o "2")
            for (int i = 1; i < dataGridView1.Columns.Count - 1; i++) // saltamos "Estado" y "FDC"
            {
                string header = dataGridView1.Columns[i].HeaderText;
                if (!string.IsNullOrEmpty(header) && header.Length == 1 && header[0] == simbolo)
                    return i;
            }

            // 2) Si no se encontró, verificar si el símbolo es válido según el grupo y entonces
            //    devolver la columna que representa al grupo (ej. columna cuyo HeaderText == IngresoCaracteres.caracterGrupo)
            string grupo = IngresoCaracteres.caracterGrupo ?? "";
            if (!string.IsNullOrEmpty(grupo) && EsSimboloValido(simbolo))
            {
                for (int i = 1; i < dataGridView1.Columns.Count - 1; i++)
                {
                    if (string.Equals(dataGridView1.Columns[i].HeaderText, grupo, StringComparison.OrdinalIgnoreCase))
                        return i;
                }
            }

            // 3) No se encontró ninguna columna aplicable
            return -1;
        }

        //codigo para el evento de carga de la vista
        private void CadenaEntrada_Load(object sender, EventArgs e)
        {
            //limpieza de cualquier dato residual
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            //columna estado
            dataGridView1.Columns.Add("Estado", "Estado");

            //agregar columnas en base a los caracteres ingresados y grupo seleccionado
            dataGridView1.Columns.Add(CreadorCeldas.CrearColumnaCombo(IngresoCaracteres.caracter1));
            dataGridView1.Columns.Add(CreadorCeldas.CrearColumnaCombo(IngresoCaracteres.caracter2));
            dataGridView1.Columns.Add(CreadorCeldas.CrearColumnaCombo(IngresoCaracteres.caracter3));
            dataGridView1.Columns.Add(CreadorCeldas.CrearColumnaCombo(IngresoCaracteres.caracter4));
            if (!string.IsNullOrEmpty(IngresoCaracteres.caracterGrupo))
            {
                dataGridView1.Columns.Add(CreadorCeldas.CrearColumnaCombo(IngresoCaracteres.caracterGrupo));
            }

            // Columna FDC
            dataGridView1.Columns.Add(CreadorCeldas.CrearColumnaFDC("FDC"));

            //agregar las 7 filas para los 7 estados
            for (int i = 0; i < 7; i++)
            {
                dataGridView1.Rows.Add($"q{i}");
            }

            //ajustar tabla para autoajuste de las celdas, visibilidad de los encabezados y solo lectura
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // Bloquear columna Estado
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.Columns[0].ReadOnly = true;

            //Establecer todas las celdas en error para facilidad de uso
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                foreach (DataGridViewCell celda in fila.Cells)
                {
                    if (celda is DataGridViewComboBoxCell comboCelda)
                    {
                        comboCelda.Value = "Error";
                    }
                }
            }
        }

        private bool EsSimboloValido(char simbolo)
        {
            string grupo = IngresoCaracteres.caracterGrupo?.ToLower() ?? "";

            bool perteneceAlGrupo = false;

            // Verificar si el símbolo pertenece al grupo
            if (grupo == "dígitos" || grupo == "digitos")
                perteneceAlGrupo = char.IsDigit(simbolo);

            else if (grupo == "vocales")
                perteneceAlGrupo = "aeiouAEIOU".IndexOf(simbolo) >= 0;

            else if (grupo == "alfabeto")
                perteneceAlGrupo = char.IsLetter(simbolo);

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

            // Aceptar si pertenece al grupo o a los personalizados
            return perteneceAlGrupo || perteneceACaracterPersonalizado;
        }

        //comportamiento de boton validar
        private async void btnValidar_Click(object sender, EventArgs e)
        {
            string cadena = txtCadena.Text.Trim();
            if (string.IsNullOrEmpty(cadena))
            {
                MessageBox.Show("Ingresa una cadena para comprobar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string estadoActual = "q0";

            // Reiniciar colores previos
            foreach (DataGridViewRow fila in dataGridView1.Rows)
                fila.DefaultCellStyle.BackColor = Color.White;

            //paso a paso
            foreach (char simbolo in cadena)
            {
                if (!EsSimboloValido(simbolo))
                {
                    MessageBox.Show($"El símbolo '{simbolo}' no pertenece al grupo seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int colIndex = ObtenerColumnaPorSimbolo(simbolo);
                if (colIndex == -1)
                {
                    MessageBox.Show($"El símbolo '{simbolo}' no coincide con ningún carácter definido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int rowIndex = int.Parse(estadoActual.Substring(1));
                var celda = dataGridView1.Rows[rowIndex].Cells[colIndex] as DataGridViewComboBoxCell;
                string nuevoEstado = celda.Value?.ToString();

                if (string.IsNullOrEmpty(nuevoEstado) || nuevoEstado == "Error")
                {
                    dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                    MessageBox.Show($"La cadena no fue aceptada en el estado {estadoActual} por el símbolo '{simbolo}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Resaltar celda actual
                dataGridView1.ClearSelection();
                dataGridView1.Rows[rowIndex].Cells[colIndex].Selected = true;
                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightBlue;

                await Task.Delay(400); // pausa para visualizar el paso
                txtSalida.Text=simbolo.ToString();

                estadoActual = nuevoEstado;
            }

            // Verificar estado final
            string resultadoFDC = dataGridView1.Rows[int.Parse(estadoActual.Substring(1))]
                .Cells["FDC"].Value?.ToString() ?? "Error";

            if (resultadoFDC == "Aceptar")
            {
                dataGridView1.Rows[int.Parse(estadoActual.Substring(1))].DefaultCellStyle.BackColor = Color.LightGreen;
                MessageBox.Show($"Cadena ACEPTADA en {estadoActual}.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView1.Rows[int.Parse(estadoActual.Substring(1))].DefaultCellStyle.BackColor = Color.LightCoral;
                MessageBox.Show($"Cadena RECHAZADA en {estadoActual}.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnComprobar_Click(object sender, EventArgs e)
        {
            int cont = 0;
            
            // Verificar que todas las transiciones estén definidas
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 1; i < dataGridView1.Columns.Count - 1; i++)
                {
                    var cell = row.Cells[i] as DataGridViewComboBoxCell;
                    if (cell.Value == null)
                    {
                        cont = 1;
                    }
                }
            }
            if(cont==1){ 
                MessageBox.Show("Falta definir una transición","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("La tabla de trancisiones es valida","Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpia colores
            foreach (DataGridViewRow fila in dataGridView1.Rows)
                fila.DefaultCellStyle.BackColor = Color.White;

            // Limpia cadena
            txtCadena.Text = "";

            // Limpia selección en la tabla
            dataGridView1.ClearSelection();

            MessageBox.Show("Simulación reiniciada correctamente.", "Limpieza", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        

        //codigo para retorno a la vista anterior
        private void CadenaEntrada_FormClosing(object sender, FormClosingEventArgs e)
        {
            IngresoCaracteres cambio = new IngresoCaracteres();
            cambio.Show();
        }

        
    }
}
