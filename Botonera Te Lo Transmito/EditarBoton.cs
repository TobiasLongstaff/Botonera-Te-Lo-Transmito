using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace Botonera_Te_Lo_Transmito
{
    public partial class EditarBoton : Form
    {
        Computer mycomputer = new Computer(); 

        public EditarBoton(/*string imagenBoton, int MostrarBoton, string ruta, string CI*/)
        {
            InitializeComponent();
            //this.imagenBoton = imagenBoton;
            //this.MostrarBoton = MostrarBoton;
            //this.ruta = ruta;
            //this.CI = CI;
        }

        int MostrarBoton, VBoton;
        string SonidosRuta, VNBoton, AudioRuta, CI, ruta, imagenBoton;
        bool CambiarAudio = false;

        private void EditarBoton_Load(object sender, EventArgs e)
        {
            Bunifu.Framework.Lib.Elipse.Apply(BotonAA, 5);
            Bunifu.Framework.Lib.Elipse.Apply(BotonAI, 5);
            Bunifu.Framework.Lib.Elipse.Apply(BotonGuardar, 5);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                string Dir = openFileDialog2.FileName;
                Bitmap Picture = new Bitmap(Dir);
                BotonVista.Image = (Image)Picture;
                ruta = openFileDialog2.FileName;
                textBoxE1.Text = ruta;
            }
        }

        private void BotonAA_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos los archivos (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AudioRuta = openFileDialog1.FileName;
                textBox1.Text = AudioRuta;
                textBoxE1.Text = SonidosRuta;
                CambiarAudio = true;
            }
        }

        private void BotonGuardar_Click(object sender, EventArgs e)
        {

            if (Dropdown.selectedIndex == 0 )
            {
                if (Dropdown2.selectedIndex == 0)
                {
                    if (Dropdown3.selectedIndex == 0)
                    {
                        MessageBox.Show("Coloque el boton");
                    }
                    else
                    {
                        VBoton = Dropdown3.selectedIndex;
                        if (Dropdown3.selectedIndex == VBoton)
                        {
                            VNBoton = "BotonSonidos" + VBoton;
                            MostrarBoton = 0;

                            if (Switch.Value == false)
                            {
                                MostrarBoton = 0;
                            }
                            else
                            {
                                MostrarBoton = 1;
                            }
                            if (AudioRuta != "")
                            {
                                textBox1.Text = AudioRuta;
                            }
                            string[] lineas = { VNBoton, MostrarBoton.ToString(), ruta, AudioRuta};
                            using (StreamWriter outputfile = new StreamWriter(@"C:\Users\tobiL\source\repos\Botonera Te Lo Transmito\Botonera Te Lo Transmito\pb.txt"))
                            {
                                foreach (string linea in lineas)
                                {
                                    outputfile.WriteLine(linea);
                                }
                            }
                            MessageBox.Show("Guardado");
                        }
                    }
                }
                else
                {
                    VBoton = Dropdown2.selectedIndex;
                    if (Dropdown2.selectedIndex == VBoton)
                    {
                        if (VBoton <= 6)
                        {
                            VNBoton = "BotonSaludos" + VBoton;
                        }
                        if (VBoton >= 7)
                        {
                            VBoton = VBoton - 6;
                            VNBoton = "BotonMusica" + VBoton;
                        }
                        MostrarBoton = 0;

                        if (Switch.Value == false)
                        {
                            MostrarBoton = 0;
                        }
                        else
                        {
                            MostrarBoton = 1;
                        }
                        if (AudioRuta != "")
                        {
                            textBox1.Text = AudioRuta;
                        }
                        string[] lineas = { VNBoton, MostrarBoton.ToString(), ruta, AudioRuta};
                        using (StreamWriter outputfile = new StreamWriter(@"C:\Users\tobiL\source\repos\Botonera Te Lo Transmito\Botonera Te Lo Transmito\pb.txt"))
                        {
                            foreach (string linea in lineas)
                            {
                                outputfile.WriteLine(linea);
                            }
                        }
                        MessageBox.Show("Guardado");
                    }
                }
            }
            else
            {
                VBoton = Dropdown.selectedIndex;
                if (Dropdown.selectedIndex == VBoton)
                {
                    VNBoton = "BotonCortinas" + VBoton;
                    MostrarBoton = 0;

                    if (Switch.Value == false)
                    {
                        MostrarBoton = 0;             
                    }
                    else
                    {
                        MostrarBoton = 1;
                    }
                    if (AudioRuta != "")
                    {
                        textBox1.Text = AudioRuta;
                    }
                    string[] lineas = { VNBoton, MostrarBoton.ToString(),ruta ,AudioRuta};
                    using (StreamWriter outputfile = new StreamWriter(@"C:\Users\tobiL\source\repos\Botonera Te Lo Transmito\Botonera Te Lo Transmito\pb.txt"))
                    {
                        foreach (string linea in lineas)
                        {
                            outputfile.WriteLine(linea);
                        }
                    }
                    if (CambiarAudio == true)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Imagen Guardada");
                    }

                }
            }
        }

        private void Cerrar_MouseLeave(object sender, EventArgs e)
        {
            Cerrar.BackColor = Color.Transparent;
        }

        private void Cerrar_MouseMove(object sender, MouseEventArgs e)
        {
            Cerrar.BackColor = Color.Red;
        }

        private void Minimizar_MouseMove(object sender, MouseEventArgs e)
        {
            Minimizar.BackColor = Color.DimGray;
        }

        private void Minimizar_MouseLeave(object sender, EventArgs e)
        {
            Minimizar.BackColor = Color.Transparent;
        }
        private void Cerrar_Click(object sender, EventArgs e)
        {
            EditarBoton formulario = new EditarBoton(/*imagenBoton, MostrarBoton, ruta,CI*/);
            formulario.Visible = false;
            Visible = false;
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
