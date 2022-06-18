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
        private int tiempo = -1; //variable de conteo de valores
        private int numImagen = 0;
        private int tiempo2 = 50;


        public frmInicio()
        {
            InitializeComponent();

        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            timer1.Start();
            //timer2.Start();
        }

        //CERRAR
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //MAXIMIZAR
        private void btnMaximizar_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        //RESTAURAR
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        //MINIMIZAR
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }


        //IMAGENES CENTRALES
        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempo++;
            label1.Text = tiempo.ToString() +"/"+ numImagen.ToString();



            if ((tiempo+100)%100==0)
            {
               
                if (numImagen<7)
                {
                    numImagen++;
                }
                else
                {
                    numImagen = 1;
                }
                this.CheckBot(numImagen);

            }


        }


        // CHECAR POSICION
        private void CheckBot(int posicion)
        {
            radImagen1.Checked = posicion == 1;
            radImagen2.Checked = posicion == 2;
            radImagen3.Checked = posicion == 3;
            radImagen4.Checked = posicion == 4;
            radImagen5.Checked = posicion == 5;
            radImagen6.Checked = posicion == 6;
            radImagen7.Checked = posicion == 7;

        }

        //  BOTONES CHECK
        private void radImagen1_CheckedChanged(object sender, EventArgs e)
        {
            picImagenes.ImageLocation = Application.StartupPath + "\\RECURSOS\\BIBLIOTECA1.jpg";
            numImagen = 1;
            tiempo = 0;
        }

        private void radImagen2_CheckedChanged(object sender, EventArgs e)
        {
            picImagenes.ImageLocation = Application.StartupPath + "\\RECURSOS\\BIBLIOTECA2.jpg";
            numImagen = 2;
            tiempo = 0;
        }

        private void radImagen3_CheckedChanged(object sender, EventArgs e)
        {
            picImagenes.ImageLocation = Application.StartupPath + "\\RECURSOS\\BIBLIOTECA3.jpg";
            numImagen = 3;
            tiempo = 0;
        }

        private void radImagen4_CheckedChanged(object sender, EventArgs e)
        {
            picImagenes.ImageLocation = Application.StartupPath + "\\RECURSOS\\BIBLIOTECA4.jpg";
            numImagen = 4;
            tiempo = 0;
        }

        private void radImagen5_CheckedChanged(object sender, EventArgs e)
        {
            picImagenes.ImageLocation = Application.StartupPath + "\\RECURSOS\\BIBLIOTECA5.jpg";
            numImagen = 5;
            tiempo = 0;
        }

        private void radImagen6_CheckedChanged(object sender, EventArgs e)
        {
            picImagenes.ImageLocation = Application.StartupPath + "\\RECURSOS\\BIBLIOTECA6.jpg";
            numImagen = 6;
            tiempo = 0;
        }

        private void radImagen7_CheckedChanged(object sender, EventArgs e)
        {
            picImagenes.ImageLocation = Application.StartupPath + "\\RECURSOS\\BIBLIOTECA7.jpg";
            numImagen = 7;
            tiempo = 0;
        }

        private void iNICIODESESIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();  //(para quitar el primer frm y que solo se vea el segundo)
            frmInicioDeSesion frm = new frmInicioDeSesion();
            frm.Show();


        }




        //PUBLICIDAD
        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    tiempo2++;
        //    label2.Text = tiempo2.ToString();

        //    if (label2.Text == "200")
        //    {
        //        picPublicidad.ImageLocation = Application.StartupPath + "\\IMAGENES\\1.png";
        //    }

        //    if (label2.Text == "400")
        //    {
        //        picPublicidad.ImageLocation = Application.StartupPath + "\\IMAGENES\\2.png";
        //    }

        //    if (label2.Text == "600")
        //    {
        //        picPublicidad.ImageLocation = Application.StartupPath + "\\IMAGENES\\3.png";
        //    }

        //    if (label2.Text == "800")
        //    {
        //        timer2.Enabled = false;
        //        picPublicidad.ImageLocation = Application.StartupPath + "\\IMAGENES\\4.png";
        //        tiempo2 = 0;
        //        label2.Text = "0";
        //        timer2.Start();


        //    }

        //}





    }
}
