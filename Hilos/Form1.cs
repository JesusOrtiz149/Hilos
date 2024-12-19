using System.Diagnostics.Eventing.Reader;

namespace Hilos
{
    public partial class Form1 : Form
    {
        Thread p1, p2, p3, p4;
        byte r, g, b,rg;
        bool b1, b2, b3, b4;
        int contadorP1, contadorP2, contadorP3, contadorP4;

        private readonly object lockObject = new object();

       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
            b1 = false;
            b2 = false;
            b3 = false;
            b4 = false;
        }

        
        private void Hilo1()
        {
            while (true)
            {
                CambiarColor(pictureBox1, ref contadorP1, Color.FromArgb(255, 80, 100));
                if (contadorP1 >= 6) break;
            }
            p2 = new Thread(Hilo2);
            p2.Start();
        }

        private void Hilo2()
        {
            while (true)
            {
                CambiarColor(pictureBox2, ref contadorP2, Color.FromArgb(100, 255, 80));
                if (contadorP2 >= 6) break;
            }
            p3 = new Thread(Hilo3);
            p3.Start();
        }

        private void Hilo3()
        {
            while (true)
            {
                CambiarColor(pictureBox3, ref contadorP3, Color.FromArgb(100, 80, 255));
                if (contadorP3 >= 6) break;
            }
            p4 = new Thread(Hilo4);
            p4.Start();
        }

        private void Hilo4()
        {
            while (true)
            {
                CambiarColor(pictureBox4, ref contadorP4, Color.FromArgb(255, 255, 80));
                if (contadorP4 >= 6) break;
            }
            ReiniciarCiclo();
        }

        private void CambiarColor(PictureBox pictureBox, ref int contador, Color baseColor)
        {
            int intensidad = 0;
            bool incrementando = true;

            while (true)
            {
                Thread.Sleep(10);

                if (incrementando)
                {
                    intensidad++;
                    if (intensidad >= 255)
                    {
                        incrementando = false;
                        contador++;
                    }
                }
                else
                {
                    intensidad--;
                    if (intensidad <= 0)
                    {
                        incrementando = true;
                        contador++;
                    }
                }

                lock (lockObject)
                {
                    pictureBox.Invoke((MethodInvoker)(() =>
                        pictureBox.BackColor = Color.FromArgb(
                            baseColor.R == 255 ? intensidad : baseColor.R,
                            baseColor.G == 255 ? intensidad : baseColor.G,
                            baseColor.B == 255 ? intensidad : baseColor.B)));
                }

                if (contador >= 6) break;
            }
        }

        private void ReiniciarCiclo()
        {
            contadorP1 = contadorP2 = contadorP3 = contadorP4 = 0;
            p1 = new Thread(Hilo1);
            p1.Start();
        }

      
        private void btnIniciar_Click(object sender, EventArgs e)
        {

            p1 = new Thread(new ThreadStart(Hilo1));
            p1.Start();
            

           
        }
     }

}     


