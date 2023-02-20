using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lottosorsolas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> random = new List<int>();

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<string> list = new List<string>();
            int r;
            bool volte = false;
            for (int i = 0; i < 5; i++)
            {
                r = rnd.Next(1, 90);
                for (int j = 0; j < random.Count; j++)
                {
                    if (random[j] == r && volte != true)
                    {
                        volte = true;
                        continue;
                    }
                }
                if (volte == false)
                {
                    random.Add(r);
                    volte = false;
                }
            }

            panel1.Controls.Clear();
            int size = 45;
            int num = 1;
            for (int i = 1; i < 7; i++)
            {
                for (int j = 1; j < 16; j++)
                {
                    Button Btn = new Button();
                    Btn.SetBounds(j * size, i * size, size, size);
                    Btn.Name = $"{i};{j}";
                    Btn.Text = $"{num++}";
                    Btn.BackColor = Color.LightGray;
                    Btn.FlatStyle = FlatStyle.Flat;
                    Btn.FlatAppearance.BorderSize = 0;
                    Btn.Click += (o, oe) =>
                    {
                        Button bt = (Button)o;
                        if (bt.BackColor == Color.Red)
                        {
                            bt.BackColor = Color.LightGray;
                            label2.Text = Regex.Replace(label2.Text, $"{bt.Text}, ", "");
                            
                        }
                        else if (bt.BackColor == Color.LightGray)
                        {
                            bt.BackColor = Color.Red;
                            label2.Text += $"{bt.Text}, ";
                        }
                    };
                    panel1.Controls.Add(Btn);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string final = Regex.Replace(label2.Text, "Megjátszott ->", "");
            final = Regex.Replace(final, " ", "");
            string[] tomb = final.Split(',');
            for (int i = 0; i < 5; i++)
            {
                label1.Text += $"{random[i]}, ";
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < tomb.Length; j++)
                {
                    if (tomb[j] == random[i].ToString())
                    {
                        label3.Text += $"{tomb[j]}, ";
                    }
                }
            }
            if (label3.Text == "Találat ->")
            {
                label3.Text = "Találat -> Nincs találat";
            }
        }
    }
}
