using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bioskop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sifra;
            sifra = textBox1.Text;
            if (sifra.Length < 0)
            {
                MessageBox.Show("Morate uneti sifru!");
                ResetText();
            }


            else if (sifra == "admin")
            {

                Form2 openForm = new Form2();
                openForm.Show();
                Visible = false;
            }
            else
            {
                MessageBox.Show("Pogresna sifra!");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 openForm = new Form6();
            openForm.Show();
            Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
