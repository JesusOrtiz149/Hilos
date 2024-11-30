namespace Hilos
{
    public partial class Form1 : Form
    {
        Thread p1, p2, p3, p4;
        byte r, g, b,rg;
        bool b1, b2, b3, b4;
        int contadorP1, contadorP2, contadorP3, contadorP4;
        bool detener = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // r = 0; 
            // g = 255; 
            // contadorP1 = 0;
            b1 = false;
            b2 = false;
            b3 = false;
            b4 = false;
        }

        private void Hilo1()
        {
            r = 0;

            
                while (contadorP1<=6)
                {
                    Thread.Sleep(10);
                    if (r >= 0 && r <= 255 && b1 == false)
                    {
                        r++;
                        if (r == 255)
                        {
                            
                            contadorP1++; b1 = true;
                        }
                    }
                    if (r >= 0 && r <= 255 && b1 == true)
                    {
                        r--;
                        if (r == 0)
                        {
                            
                            contadorP1++; b1 = false;
                        }
                    }
                    pictureBox1.BackColor = Color.FromArgb(r, 80, 100);
                }
            
            

        }
        private void Hilo2()
        {
            g = 0;
            while (true)
            {
                Thread.Sleep(10);
                if (g >= 0 && g <= 255 && b2 == false)
                {
                    g++;
                    if (g == 255)
                        b2 = true;
                }
                if (g >= 0 && g <= 255 && b2 == true)
                {
                    g--;
                    if (g == 0)
                        b2 = false;
                }
                pictureBox2.BackColor = Color.FromArgb(100, g, 80);
            }
        }
        private void Hilo3()
        {
            b = 0;
            while (true)
            {
                Thread.Sleep(10);
                if (b >= 0 && b <= 255 && b3 == false)
                {
                    b++;
                    if (b == 255)
                        b3 = true;
                }
                if (b >= 0 && b <= 255 && b3 == true)
                {
                    b--;
                    if (b == 0)
                        b3 = false;
                }
                pictureBox3.BackColor = Color.FromArgb(100, 80,b);
            }
        }
        private void Hilo4()
        {
            rg = 0;
            while (true)
            {
                Thread.Sleep(10);
                if (rg>= 0 && rg <= 255 && b4 == false)
                {
                    rg++;
                    if (rg == 255)
                        b4 = true;
                }
                if (rg >= 0 && rg <= 255 && b4 == true)
                {
                    rg--;
                    if (rg == 0)
                        b4 = false;
                }
                pictureBox4.BackColor = Color.FromArgb(rg, 80, 100);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            p1 = new Thread(new ThreadStart(Hilo1));
            p2 = new Thread(new ThreadStart(Hilo2));
            p3 = new Thread(new ThreadStart(Hilo3));
            p4 = new Thread(new ThreadStart(Hilo4));
            p1.Start();
            p2.Start();
            p3.Start();
            p4.Start();




            //p2.Start();

        }     
    }
}
