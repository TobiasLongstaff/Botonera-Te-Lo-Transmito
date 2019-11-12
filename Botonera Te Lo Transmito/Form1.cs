using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
using WMPLib;
using System.IO;

namespace Botonera_Te_Lo_Transmito
{
    public partial class Botonera : Form
    {

        public Botonera()
        {
            InitializeComponent();
        }


        int i, o, p, q, w = 0;
        string linea, linea2, linea3, linea4, linea5 = null;
        string VNBoton = "";
        string ruta = Application.StartupPath + @"\Imagenes\xdefecto.gif";
        string Boton1 = Application.StartupPath + @"\Sonidos\1.mp3";

        WindowsMediaPlayer sonido;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int Iparam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ActualizarDatosDelTrack();
            TiempoAudio.Value = (int)Reproductor.Ctlcontrols.currentPosition;
            Volumen.Value = Reproductor.settings.volume;
        }

        public void ActualizarDatosDelTrack()
        {

            if (Reproductor.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                TiempoAudio.Maximum = (int)Reproductor.Ctlcontrols.currentItem.duration;
                timer1.Start();
            }
            else if (Reproductor.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                timer1.Stop();
                TiempoAudio.Value = 0;
            }
        }

        private void Reproductor_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            ActualizarDatosDelTrack();
        }

        private void Volumen_ValueChanged(object sender, decimal value)
        {
            Reproductor.settings.volume = Volumen.Value;

            if (Reproductor.settings.volume < 50)
            {
                img0.Visible = false;
                img100.Visible = false;
                img50.Visible = true;
            }
            if (Reproductor.settings.volume > 50)
            {
                img0.Visible = false;
                img100.Visible = true;
                img50.Visible = false;
            }
            if (Reproductor.settings.volume == 0)
            {
                img0.Visible = true;
                img100.Visible = false;
                img50.Visible = false;
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            //string F = "";
            //string[] lineas = { VNBoton, F, ruta };
            //using (StreamWriter outputfile = new StreamWriter(@"C:\Users\tobiL\source\repos\Botonera Te Lo Transmito\Botonera Te Lo Transmito\pb.txt"))
            //{
            //    foreach (string linea in lineas)
            //    {
            //        outputfile.WriteLine(linea);
            //    }
            //}
            Application.Exit();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Cerrar_MouseMove(object sender, MouseEventArgs e)
        {
            Cerrar.BackColor = Color.Red;
        }

        private void Cerrar_MouseLeave(object sender, EventArgs e)
        {
            Cerrar.BackColor = Color.Transparent;
        }

        private void Minimizar_MouseLeave(object sender, EventArgs e)
        {
            Minimizar.BackColor = Color.Transparent;
        }

        private void Minimizar_MouseMove(object sender, MouseEventArgs e)
        {
            Minimizar.BackColor = Color.DimGray;
        }

        private void TiempoAudio_MouseMove(object sender, MouseEventArgs e)
        {
            TiempoAudio.TickColor = Color.Green;
            TiempoAudio.TrackLineSelectedColor = Color.Green;
        }

        private void TiempoAudio_MouseLeave(object sender, EventArgs e)
        {
            TiempoAudio.TickColor = Color.Silver;
            TiempoAudio.TrackLineSelectedColor = Color.Silver;
        }

        private void Volumen_MouseLeave(object sender, EventArgs e)
        {
            Volumen.TickColor = Color.Silver;
            Volumen.TrackLineSelectedColor = Color.Silver;
        }

        private void Volumen_MouseMove(object sender, MouseEventArgs e)
        {
            Volumen.TickColor = Color.Green;
            Volumen.TrackLineSelectedColor = Color.Green;
        }

        private void Botonera_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);
            timer2.Enabled = true;
            textBox3.Text = contador.ToString();
            StreamReader archivo = File.OpenText(@"C:\Users\tobiL\source\repos\Botonera Te Lo Transmito\Botonera Te Lo Transmito\pb.txt");

            while (!archivo.EndOfStream)
            {
                //Leer la 1ra línea:
                linea = archivo.ReadLine();
                if (++i == 1) break;

                linea2 = archivo.ReadLine();
                if (++o == 2) break;

                linea3 = archivo.ReadLine();
                if (++p == 3) break;

                linea4 = archivo.ReadLine();
                if (++q == 4) break;

                linea5 = archivo.ReadLine();
                if (++w == 5) break;
            }
            archivo.Dispose();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            Reproductor.Ctlcontrols.stop();
        }

        #region

        private void ReproducirBoton(string Boton)
        {
            try
            {
                sonido = new WindowsMediaPlayer();
                Reproductor.URL = @""+Boton;
                sonido.controls.play();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void Boton1_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\1.mp3");
        }

        private void Boton2_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\2.mp3");
        }

        private void Boton3_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\3.mp3");
        }

        private void Boton4_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\4.mp3");
        }

        private void Boton5_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\5.mp3");
        }

        private void Boton6_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\6.mp3");
        }

        private void Boton7_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\7.mp3");
        }

        private void Boton8_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\8.mp3");
        }

        private void Boton9_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\9.mp3");
        }

        private void Boton10_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\10.mp3");
        }

        private void Boton11_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\11.mp3");
        }

        private void Boton12_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\12.mp3");
        }

        private void Boton13_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\13.mp3");
        }

        private void Boton14_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\14.mp3");
        }

        private void Boton15_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\15.mp3");
        }

        private void Boton16_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\16.mp3");
        }

        private void Boton17_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\17.mp3");
        }

        private void Boton18_Click(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\29.mp3");
        }

        private void Boton19_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\30.mp3");
        }

        private void Boton20_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\31.mp3");
        }

        private void Boton21_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\32.mp3");
        }

        private void Boton22_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\33.mp3");
        }

        private void Boton23_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\34.mp3");
        }

        private void Boton24_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\35.mp3");
        }

        private void Boton29_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\39.mp3");
        }

        private void Boton31_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\41.mp3");
        }

        private void Boton34_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\44.mp3");
        }

        private void Boton35_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\45.mp3");
        }

        private void Boton36_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\46.mp3");
        }

        private void Boton37_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\47.mp3");
        }

        private void Boton40_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\51.mp3");
        }

        private void Boton41_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\52.mp3");
        }

        private void Boton42_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\53.mp3");
        }

        private void Boton43_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\54.mp3");
        }

        private void Boton44_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\55.mp3");
        }

        private void Boton45_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\56.mp3");
        }

        private void Boton46_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\57.mp3");
        }

        private void Boton47_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\58.mp3");
        }

        private void Boton48_Click_1(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\59.mp3");
        }

        private void Boton49_Click(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\60.mp3");
        }

        private void Boton50_Click(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\61.mp3");
        }

        private void Boton51_Click(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\62.mp3");
        }

        private void Boton52_Click(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\63.mp3");
        }

        private void Boton56_Click(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\64.mp3");
        }

        private void Boton53_Click(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\65.mp3");
        }

        private void Boton54_Click(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\66.mp3");
        }

        private void Boton55_Click(object sender, EventArgs e)
        {
            ReproducirBoton(Application.StartupPath + @"\Sonidos\67.mp3");
        }

        #endregion

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            EditarBoton formulario = new EditarBoton(/*imagenBoton, MostrarBoton, ruta, CI*/);
            formulario.Visible = true;
        }

        string CI;
        int contador;
        private void timer2_Tick(object sender, EventArgs e)
        {
            textBox1.Text = contador.ToString();
            contador++;
            if (contador == 3)
            {
                contador = 0;
            }
            //LTimer.Text = MostrarBoton.ToString();
            if (textBox1.Text == "1")
            {
                StreamReader archivo = File.OpenText(@"C:\Users\tobiL\source\repos\Botonera Te Lo Transmito\Botonera Te Lo Transmito\pb.txt");

                while (!archivo.EndOfStream)
                {
                    //Leer la 1ra línea:
                    linea = archivo.ReadLine();
                    if (++i == 1) break;

                    linea2 = archivo.ReadLine();
                    if (++o == 2) break;

                    linea3 = archivo.ReadLine();
                    if (++p == 3) break;

                    linea4 = archivo.ReadLine();
                    if (++q == 4) break;

                    linea5 = archivo.ReadLine();
                    if (++w == 5) break;

                }
                archivo.Dispose();
                textBox3.Text = linea;
                textBox4.Text = linea2;
                textBox5.Text = linea3;
                textBox6.Text = linea4;

                #region

                //label7.Text = ruta;
                if (linea == BotonCortinas1.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonCortinas1.Visible = false;

                    }
                    else
                    {
                        BotonCortinas1.Visible = true;
                        Boton1 = linea4;
                        if (linea3 == "")
                        {
                            this.BotonCortinas1.Load(ruta);                            

                        }
                        if (linea3 != "")
                        {
                            this.BotonCortinas1.Load(linea3);
                        }
                    }
                }
                if (linea == BotonCortinas2.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonCortinas2.Visible = false;
                    }
                    else
                    {
                        BotonCortinas2.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonCortinas2.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonCortinas2.Load(linea3);
                        }
                    }
                }
                if (linea == BotonCortinas3.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonCortinas3.Visible = false;
                    }
                    else
                    {
                        BotonCortinas3.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonCortinas3.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonCortinas3.Load(linea3);
                        }
                    }
                }
                if (linea == BotonCortinas4.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonCortinas4.Visible = false;
                    }
                    else
                    {
                        BotonCortinas4.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonCortinas4.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonCortinas4.Load(linea3);
                        }
                    }
                }
                if (linea == BotonCortinas5.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonCortinas5.Visible = false;
                    }
                    else
                    {
                        BotonCortinas5.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonCortinas5.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonCortinas5.Load(linea3);
                        }
                    }
                }
                if (linea == BotonCortinas6.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonCortinas6.Visible = false;
                    }
                    else
                    {
                        BotonCortinas6.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonCortinas6.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonCortinas6.Load(linea3);
                        }
                    }
                }
                if (linea == BotonCortinas7.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonCortinas7.Visible = false;
                    }
                    else
                    {
                        BotonCortinas7.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonCortinas7.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonCortinas7.Load(linea3);
                        }
                    }
                }
                if (linea == BotonCortinas8.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonCortinas8.Visible = false;
                    }
                    else
                    {
                        BotonCortinas8.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonCortinas8.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonCortinas8.Load(linea3);
                        }
                    }
                }
                if (linea == BotonCortinas9.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonCortinas9.Visible = false;
                    }
                    else
                    {
                        BotonCortinas9.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonCortinas9.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonCortinas9.Load(linea3);
                        }
                    }
                }
                if (linea == BotonCortinas10.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonCortinas10.Visible = false;
                    }
                    else
                    {
                        BotonCortinas10.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonCortinas10.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonCortinas10.Load(linea3);
                        }
                    }
                }
                if (linea == BotonCortinas11.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonCortinas11.Visible = false;
                    }
                    else
                    {
                        BotonCortinas11.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonCortinas11.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonCortinas11.Load(linea3);
                        }
                    }
                }
                if (linea == BotonCortinas12.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonCortinas12.Visible = false;
                    }
                    else
                    {
                        BotonCortinas12.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonCortinas12.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonCortinas12.Load(linea3);
                        }
                    }
                }
                if (linea == BotonCortinas13.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonCortinas13.Visible = false;
                    }
                    else
                    {
                        BotonCortinas13.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonCortinas13.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonCortinas13.Load(linea3);
                        }
                    }
                }
                //
                //Boton saludos
                //
                if (linea == BotonSaludos1.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSaludos1.Visible = false;
                    }
                    else
                    {
                        BotonSaludos1.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSaludos1.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSaludos1.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSaludos2.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSaludos2.Visible = false;
                    }
                    else
                    {
                        BotonSaludos2.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSaludos2.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSaludos2.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSaludos3.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSaludos3.Visible = false;
                    }
                    else
                    {
                        BotonSaludos3.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSaludos3.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSaludos3.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSaludos4.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSaludos4.Visible = false;
                    }
                    else
                    {
                        BotonSaludos4.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSaludos4.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSaludos4.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSaludos5.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSaludos5.Visible = false;
                    }
                    else
                    {
                        BotonSaludos5.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSaludos5.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSaludos5.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSaludos6.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSaludos6.Visible = false;
                    }
                    else
                    {
                        BotonSaludos6.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSaludos6.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSaludos6.Load(linea3);
                        }
                    }
                }
                //
                // Boton Musica
                //
                if (linea == BotonMusica1.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonMusica1.Visible = false;
                    }
                    else
                    {
                        BotonMusica1.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonMusica1.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonMusica1.Load(linea3);
                        }
                    }
                }
                if (linea == BotonMusica2.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonMusica2.Visible = false;
                    }
                    else
                    {
                        BotonMusica2.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonMusica2.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonMusica2.Load(linea3);
                        }
                    }
                }
                if (linea == BotonMusica3.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonMusica3.Visible = false;
                    }
                    else
                    {
                        BotonMusica3.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonMusica3.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonMusica3.Load(linea3);
                        }
                    }
                }
                if (linea == BotonMusica4.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonMusica4.Visible = false;
                    }
                    else
                    {
                        BotonMusica4.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonMusica4.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonMusica4.Load(linea3);
                        }
                    }
                }
                if (linea == BotonMusica5.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonMusica5.Visible = false;
                    }
                    else
                    {
                        BotonMusica5.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonMusica5.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonMusica5.Load(linea3);
                        }
                    }
                }
                if (linea == BotonMusica6.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonMusica6.Visible = false;
                    }
                    else
                    {
                        BotonMusica6.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonMusica6.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonMusica6.Load(linea3);
                        }
                    }
                }
                //
                // Sonidos
                //
                if (linea == BotonSonidos1.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos1.Visible = false;
                    }
                    else
                    {
                        BotonSonidos1.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos1.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos1.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos2.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos2.Visible = false;
                    }
                    else
                    {
                        BotonSonidos2.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos2.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos2.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos3.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos3.Visible = false;
                    }
                    else
                    {
                        BotonSonidos3.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos3.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos3.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos4.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos4.Visible = false;
                    }
                    else
                    {
                        BotonSonidos4.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos4.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos4.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos5.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos5.Visible = false;
                    }
                    else
                    {
                        BotonSonidos5.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos5.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos5.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos6.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos6.Visible = false;
                    }
                    else
                    {
                        BotonSonidos6.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos6.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos6.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos7.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos7.Visible = false;
                    }
                    else
                    {
                        BotonSonidos7.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos7.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos7.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos8.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos8.Visible = false;
                    }
                    else
                    {
                        BotonSonidos8.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos8.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos8.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos9.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos9.Visible = false;
                    }
                    else
                    {
                        BotonSonidos9.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos9.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos9.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos10.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos10.Visible = false;
                    }
                    else
                    {
                        BotonSonidos10.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos10.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos10.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos11.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos11.Visible = false;
                    }
                    else
                    {
                        BotonSonidos11.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos11.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos11.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos12.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos12.Visible = false;
                    }
                    else
                    {
                        BotonSonidos12.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos12.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos12.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos13.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos13.Visible = false;
                    }
                    else
                    {
                        BotonSonidos13.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos13.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos13.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos14.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos14.Visible = false;
                    }
                    else
                    {
                        BotonSonidos14.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos14.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos14.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos15.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos15.Visible = false;
                    }
                    else
                    {
                        BotonSonidos15.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos15.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos15.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos16.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos16.Visible = false;
                    }
                    else
                    {
                        BotonSonidos16.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos16.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos16.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos17.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos17.Visible = false;
                    }
                    else
                    {
                        BotonSonidos17.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos17.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos17.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos18.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos18.Visible = false;
                    }
                    else
                    {
                        BotonSonidos18.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos18.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos18.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos19.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos19.Visible = false;
                    }
                    else
                    {
                        BotonSonidos19.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos19.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos19.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos20.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos20.Visible = false;
                    }
                    else
                    {
                        BotonSonidos20.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos20.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos20.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos21.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos21.Visible = false;
                    }
                    else
                    {
                        BotonSonidos21.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos21.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos21.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos22.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos22.Visible = false;
                    }
                    else
                    {
                        BotonSonidos22.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos22.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos22.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos23.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos23.Visible = false;
                    }
                    else
                    {
                        BotonSonidos23.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos23.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos23.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos24.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos24.Visible = false;
                    }
                    else
                    {
                        BotonSonidos24.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos24.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos24.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos25.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos25.Visible = false;
                    }
                    else
                    {
                        BotonSonidos25.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos25.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos25.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos26.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos26.Visible = false;
                    }
                    else
                    {
                        BotonSonidos26.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos26.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos26.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos27.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos27.Visible = false;
                    }
                    else
                    {
                        BotonSonidos27.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos27.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos27.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos28.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos28.Visible = false;
                    }
                    else
                    {
                        BotonSonidos28.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos28.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos28.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos29.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos29.Visible = false;
                    }
                    else
                    {
                        BotonSonidos29.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos29.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos29.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos30.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos30.Visible = false;
                    }
                    else
                    {
                        BotonSonidos30.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos30.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos30.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos31.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos31.Visible = false;
                    }
                    else
                    {
                        BotonSonidos31.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos31.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos31.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos32.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos32.Visible = false;
                    }
                    else
                    {
                        BotonSonidos32.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos32.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos32.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos33.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos33.Visible = false;
                    }
                    else
                    {
                        BotonSonidos33.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos33.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos33.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos34.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos34.Visible = false;
                    }
                    else
                    {
                        BotonSonidos34.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos34.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos34.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos35.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos35.Visible = false;
                    }
                    else
                    {
                        BotonSonidos35.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos35.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos35.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos36.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos36.Visible = false;
                    }
                    else
                    {
                        BotonSonidos36.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos36.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos36.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos37.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos37.Visible = false;
                    }
                    else
                    {
                        BotonSonidos37.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos37.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos37.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos38.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos38.Visible = false;
                    }
                    else
                    {
                        BotonSonidos38.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos38.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos38.Load(linea3);
                        }
                    }
                }
                if (linea == BotonSonidos39.Name)
                {
                    if (linea2 == "0")
                    {
                        BotonSonidos39.Visible = false;
                    }
                    else
                    {
                        BotonSonidos39.Visible = true;
                        if (linea3 == "")
                        {
                            this.BotonSonidos39.Load(ruta);

                        }
                        if (linea3 != "")
                        {
                            this.BotonSonidos39.Load(linea3);
                        }
                    }
                }
                #endregion
                //label6.Text = imagenBoton;
            }
        }
    }
}
