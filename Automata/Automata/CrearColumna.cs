using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automata
{
    public class CrearColumna
    {
        public DataGridViewComboBoxColumn CrearColumnaCombo(string encabezado)
        {
            //Formato para las celdas
            DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn();
            comboColumn.HeaderText = encabezado;
            comboColumn.FlatStyle = FlatStyle.Flat;
            comboColumn.DropDownWidth = 100;
            comboColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            comboColumn.DisplayStyleForCurrentCellOnly = true;
            comboColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

            // Opciones disponibles (q0 a q6)
            for (int i = 0; i < 7; i++)
            {
                comboColumn.Items.Add($"q{i}");
            }
            //Opcion de Error
            comboColumn.Items.Add("Error");

            return comboColumn;
        }

        public DataGridViewComboBoxColumn CrearColumnaFDC(string FDC)
        {
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = FDC;
            comboBoxColumn.FlatStyle = FlatStyle.Flat;
            comboBoxColumn.DropDownWidth = 100;
            comboBoxColumn.Name = "FDC";
            comboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            comboBoxColumn.DisplayStyleForCurrentCellOnly = true;
            comboBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

            comboBoxColumn.Items.Add("Error");
            comboBoxColumn.Items.Add("Aceptar");

            return comboBoxColumn;
        }

        
    }
}
