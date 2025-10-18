using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Automata
{
    public partial class IngresoCaracteres : Form
    {
        public static string caracter1;
        public static string caracter2;
        public static string caracter3;
        public static string caracter4;
        public static string caracterGrupo;

        public IngresoCaracteres()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            caracter1=txtChar1.Text;
            caracter2=txtChar2.Text;
            caracter3=txtChar3.Text;
            caracter4=txtChar4.Text;
            caracterGrupo = lstGrupo.Text;

            if (string.IsNullOrEmpty(txtChar1.Text)|| string.IsNullOrEmpty(txtChar2.Text)|| string.IsNullOrEmpty(txtChar3.Text)|| string.IsNullOrEmpty(txtChar4.Text)||lstGrupo.SelectedIndex==-1)
            {
                MessageBox.Show("Debe ingresar los 4 caracteres y seleccionar el grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (caracter1 == caracter2 || caracter1 == caracter3 || caracter1 == caracter4 || caracter2 == caracter3 || caracter2 == caracter4 || caracter3 == caracter4)
            {
                MessageBox.Show("Los Caracteres no se pueden repetir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.Hide();
                CadenaEntrada Cambio=new CadenaEntrada();
                Cambio.Show();
            }
        }

        //Evento para caja de texto 1
        private void txtChar1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar)) // Validacion de a-Z o 0-9
            {
                e.Handled = true; // No permite que el carácter sea escrito
            }
            else if (e.KeyChar == (char)Keys.Back) // Permite borrar el texto
            {
                e.Handled = false;
            }
            else if (txtChar1.Text.Length >= 1)
            {
                e.Handled = true; // Permite el carácter especial
            }
        }

        //Evento para la caja de texto 2
        private void txtChar2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar)) // Validacion de a-Z o 0-9
            {
                e.Handled = true; // No permite que el carácter sea escrito
            }
            else if (e.KeyChar == (char)Keys.Back) // Permite borrar el texto
            {
                e.Handled = false;
            }
            else if (txtChar2.Text.Length >= 1)
            {
                e.Handled = true; // Permite el carácter especial
            }
        }

        private void txtChar3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar)) // Validacion de a-Z o 0-9
            {
                e.Handled = true; // No permite que el carácter sea escrito
            }
            else if (e.KeyChar == (char)Keys.Back) // Permite borrar el texto
            {
                e.Handled = false;
            }
            else if (txtChar3.Text.Length >= 1)
            {
                e.Handled = true; // Permite el carácter especial
            }
        }

        private void txtChar4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar)) // Validacion de a-Z o 0-9
            {
                e.Handled = true; // No permite que el carácter sea escrito
            }
            else if (e.KeyChar == (char)Keys.Back) // Permite borrar el texto
            {
                e.Handled = false;
            }
            else if (txtChar4.Text.Length >= 1)
            {
                e.Handled = true; // Permite el carácter especial
            }
        }

        private void IngresoCaracteres_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
