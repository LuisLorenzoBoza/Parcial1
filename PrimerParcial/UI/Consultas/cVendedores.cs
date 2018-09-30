using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace PrimerParcial.UI.Consultas
{
    public partial class cVendedores : Form
    {
        public cVendedores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en True
            Expression<Func<Vendedores, bool>> filtro = x => true;

            int id;
            switch (comboBoxFiltro.SelectedIndex)
            {
                case 0://ID
                    id = Convert.ToInt32(textBoxCriterio.Text);
                    filtro = x => x.VendedorId == id;
                    break;
                case 1://Nombres
                    filtro = x => x.Nombres.Contains(textBoxCriterio.Text);
                    break;
                case 2://Sueldo
                    filtro = x => x.Sueldo.Equals(textBoxCriterio.Text);
                    break;
                case 3://PorcientoRetencion
                    filtro = x => x.PorcientoRetencion.Equals(textBoxCriterio.Text);
                    break;
                case 4://Retencion
                    filtro = x => x.Retencion.Equals(textBoxCriterio.Text);
                    break;
                case 5://Fecha
                    filtro = x => x.Fecha.Equals(textBoxCriterio.Text);
                    break;
            }

            dataGridArticulos.DataSource = BLL.VendedoresBLL.GetList(filtro);
        }

        private void cVendedores_Load(object sender, EventArgs e)
        {

        }
    }
}

