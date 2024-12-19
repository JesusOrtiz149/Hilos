using System;
using System.Threading;
using System.Windows.Forms;

namespace Hilos
{
    public partial class Form2 : Form
    {
        Thread t1, t2, t3, t4;
        readonly object lockObject = new object();
        int contador1 = 1, contador2 = 1, contador3 = 1, contador4 = 1;

        public Form2()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            t1 = new Thread(() => Contar(label1, ref contador1));
            t1.Start();

            t2 = new Thread(() => Contar(label2, ref contador2));
            t2.Start();

            t3 = new Thread(() => Contar(label3, ref contador3));
            t3.Start();

            t4 = new Thread(() => Contar(label4, ref contador4));
            t4.Start();
        }

        public void Contar(Label label, ref int contador)
        {
            while (true)
            {
                Thread.Sleep(1000);

                lock (lockObject)
                {
                    if (contador > 10)
                        break;

                    UpdateLabelSafe(label, contador.ToString());
                    contador++;
                }
            }
        }

        private void UpdateLabelSafe(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new Action(() => label.Text = text));
            }
            else
            {
                label.Text = text;
            }
        }
    }
}
