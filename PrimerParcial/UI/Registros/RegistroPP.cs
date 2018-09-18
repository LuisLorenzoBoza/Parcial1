using PrimerParcial.BLL;
using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerParcial.UI.Registros
{
    public partial class RegistroPP : Form
    {
        public RegistroPP()
        {
            InitializeComponent();
        }


        public void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            NombrestextBox.Text = string.Empty;
            SueldonumericUpDown.Value = 0;
            PorcientoRetencionnumericUpDown.Value = 0;
            RetencionnumericUpDown.Value = 0;
        }

        private Vendedores LlenaClase()
        {
            Vendedores vendedor = new Vendedores();
            vendedor.VendedorId = Convert.ToInt32(IDnumericUpDown.Value);
            vendedor.Nombres = NombrestextBox.Text;
            vendedor.Sueldo = Convert.ToInt32(SueldonumericUpDown.Value);
            vendedor.PorcientoRetencion = Convert.ToInt32(PorcientoRetencionnumericUpDown.Value);
            vendedor.Retencion = Convert.ToInt32(RetencionnumericUpDown.Value);
            return vendedor;
        }


        private void LlenaCampo(Vendedores vendedor)
        {
            IDnumericUpDown.Value = vendedor.VendedorId;
            NombrestextBox.Text = vendedor.Nombres;
            SueldonumericUpDown.Value = vendedor.Sueldo;
            PorcientoRetencionnumericUpDown.Value = vendedor.PorcientoRetencion;
            RetencionnumericUpDown.Value = vendedor.Retencion;

        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Vendedores vendedor = VendedoresBLL.Buscar((int)IDnumericUpDown.Value);

            return (vendedor != null);
        }



        private bool Validar(int validar)
        {
            bool paso = false;
            if (validar == 1 && IDnumericUpDown.Value == 0)
            {
                errorProvider.SetError(IDnumericUpDown, "Ingrese el ID");
                paso = true;
            }
            if (validar == 2 && NombrestextBox.Text == String.Empty)
            {
                errorProvider.SetError(NombrestextBox, "Digite el nombre y apellido");
                paso = true;
            }
            if (validar == 2 && SueldonumericUpDown.Value == 0)
            {
                errorProvider.SetError(SueldonumericUpDown, "Ingrese su Sueldo");
                paso = true;
            }
            if (validar == 2 && PorcientoRetencionnumericUpDown.Value == 0)
            {
                errorProvider.SetError(PorcientoRetencionnumericUpDown, "Ingrese % de retencion");
                paso = true;
            }
            if (validar == 2 && RetencionnumericUpDown.Value == 0)
            {
                errorProvider.SetError(RetencionnumericUpDown, "Ingrese retencion");
                paso = true;
            }
            return paso;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int id;
            Vendedores vendedor = new Vendedores();
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            vendedor = VendedoresBLL.Buscar(id);

            if (vendedor != null)
            {
                MessageBox.Show("Vendedor Encontrado");
                LlenaCampo(vendedor);
            }
            else
            {
                MessageBox.Show("Vendedor no Encontado");
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
        }





        private void button3_Click(object sender, EventArgs e)
        {
            Vendedores vendedor;
            bool paso = false;

            if (Validar(2))
            {
                MessageBox.Show("LLenar los campos ");
                return;
            }

            vendedor = LlenaClase();
            Limpiar();

            if (IDnumericUpDown.Value == 0)
                paso = VendedoresBLL.Guardar(vendedor);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar, no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = BLL.VendedoresBLL.Modificar(vendedor);
            }

            if (paso)
                MessageBox.Show("Guardado!", "Con Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingresar el ID");
                return;
            }

            int id = Convert.ToInt32(IDnumericUpDown.Value);

            if (BLL.VendedoresBLL.Eliminar(id))
                MessageBox.Show("Eliminado!", "Con Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }


        private void RetencionnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (PorcientoRetencionnumericUpDown.Value != 0)
                PorcientoRetencionnumericUpDown.Value = PorcientoRetencionnumericUpDown.Value / 100;
        }
    }
}
