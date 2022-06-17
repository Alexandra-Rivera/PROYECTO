using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_BINAES
{
    public partial class frmInicio : Form
    {
        private int tiempo; //variable de conteo de valores
        public frmInicio()
        {
            InitializeComponent();

        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void panelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempo++;
            label1.Text = tiempo.ToString();

            if (label1.Text == "200")
            {
                picImagenes.ImageLocation = Application.StartupPath + "\\RECURSOS\\BIBLIOTECA2.jpg";
            }

            if (label1.Text == "400")
            {
                picImagenes.ImageLocation = Application.StartupPath + "\\RECURSOS\\BIBLIOTECA3.jpg";
            }

            if (label1.Text == "600")
            {
                picImagenes.ImageLocation = Application.StartupPath + "\\RECURSOS\\BIBLIOTECA4.jpg";
            }

            if (label1.Text == "800")
            {
                picImagenes.ImageLocation = Application.StartupPath + "\\RECURSOS\\BIBLIOTECA5.jpg";
            }

            if (label1.Text == "1000")
            {
                picImagenes.ImageLocation = Application.StartupPath + "\\RECURSOS\\BIBLIOTECA6.jpg";
            }

            if (label1.Text == "1200")
            {
                timer1.Enabled=false;
                picImagenes.ImageLocation = Application.StartupPath + "\\RECURSOS\\BIBLIOTECA7.jpg";
                tiempo = 0;
                label1.Text = "0";
                timer1.Start();

            }

        }


    }
}
