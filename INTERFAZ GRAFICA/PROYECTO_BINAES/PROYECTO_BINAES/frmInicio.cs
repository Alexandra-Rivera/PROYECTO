using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; //pa mover la pestania

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
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMenssage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


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

        //LINK INICIO DE SESION
        private void iNICIODESESIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();  //(para quitar el primer frm y que solo se vea el segundo)
            frmInicioDeSesion frm = new frmInicioDeSesion();
            frm.Show();


        }

        //LINK NOSOTROS
        private void nOSOTROSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNosotros frm = new frmNosotros();
            frm.Show();
        }

        //MOVER LA PESTANIA
        private void panelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMenssage(this.Handle, 0x112, 0xf012, 0);
        }


        
        


    }
}
