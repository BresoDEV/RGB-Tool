using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public static int r = 0;
        public static int g = 0;
        public static int b = 0;
        public static int fim = 255;
        public static int inicio = 0;
        public static bool passo1 = true;
        public static bool passo2 = false;
        public static bool passo3 = false;
        public static bool passo4 = false;
        public static int vel = 1;//multiplos de 5 somente


        public static void rgb(int velocidade)
        {

            if (passo1)
            {
                if (r != 255) { r = r + vel; }
                if (r == 255 && g != 255) { g = g + vel; }
                if (r == 255 && g == 255 && b != 255) { b = b + vel; }
                if (r == 255 && g == 255 && b == 255) { passo1 = false; passo2 = true; }
            }

            if (passo2)
            {
                if (r != 0) { r = r - vel; }
                if (r == 0 && g != 0) { g = g - vel; }
                if (r == 0 && g == 0 && b != 0) { b = b - vel; }
                if (r == 0 && g == 0 && b == 0) { passo2 = false; passo3 = true; }
            }

            if (passo3)
            {
                if (g != 255) { g = g + vel; }
                if (g == 255) { g = g - vel; passo3 = false; passo4 = true; }
            }
            if (passo4)
            {
                if (g != 0 && b != 255 && r != 255) { g = g - vel; b = b + vel; r = r + vel; }
                if (r != 0 && g == 0 && b != 0) { r = r - vel; b = b - vel; }
                if (r == 0 && g == 0 && b == 0) { passo4 = false; passo3 = false; passo2 = false; passo1 = true; }
            } 
        }


        private static String HexConverter(int r, int g, int b)
        {
            return "#" + r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "Lento")
            {
                vel = 1;
                timer1.Enabled = true;
            }
            else if (comboBox1.Text == "Normal")
            {
                vel = 5;
                timer1.Enabled = true;
            }
            else if (comboBox1.Text == "Rapido")
            {
                vel = 15;
                timer1.Enabled = true;
            }
            else if (comboBox1.Text == "Velocidade da troca de cores")
            {
                MessageBox.Show("Escolha uma velocidade para as cores");
            }
            else
            {
                MessageBox.Show("Escolha uma velocidade valida");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {



            if (r == 255 && g == 1 && b == 0)//vermelho
                checkBox1.Checked = true;
            if (r == 0 && g == 254 && b == 0)//verde
                checkBox2.Checked = true;
            if (r == 0 && g == 1 && b == 255)//azul
                checkBox3.Checked = true;
            if (r == 1 && g == 255 && b == 255)//cyano
                checkBox4.Checked = true;
            if (r == 255 && g == 255 && b == 1)//amarelo
                checkBox5.Checked = true;
            if (r == 190 && g == 0 && b == 190)//roxo
                checkBox6.Checked = true;
            if (r == 0 && g == 0 && b == 0)//preto
                checkBox7.Checked = true;
            if (r == 255 && g == 255 && b == 254)//branco
                checkBox8.Checked = true;



            rgb(vel);
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(255, r, g, b);
            label1.Text = "Cor atual: " + Convert.ToString(r) + ", " + Convert.ToString(g) + ", " + Convert.ToString(b);
            label2.Text = "Cor Hex: " + HexConverter(r, g, b);



        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
