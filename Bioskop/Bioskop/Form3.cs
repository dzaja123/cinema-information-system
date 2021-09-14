using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bioskop
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DZAJA-PC;Initial Catalog=Bioskop;Integrated Security=True");

        public Form3()
        {
            InitializeComponent();
            ReallyCenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string naziv = textBox2.Text;
            string uloge = textBox3.Text;
            string datum = textBox4.Text;
            string vreme = textBox5.Text;
            string smesta = textBox4.Text;


            if (naziv.Length > 0 && uloge.Length > 0 && datum.Length > 0 && vreme.Length > 0 && smesta.Length > 0)
            {
                try
                {
                    con.Open();
                    String query = "INSERT INTO Film(imeFilma , datum_odrzavanja, vreme, uloge, mesta ) VALUES ('" + naziv + "', '" + datum + "', '" + vreme + "', '" + uloge + "', '" + smesta + "' )";
                    SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Uspesno ste dodali film u bazu!");
                }
                catch
                {
                    MessageBox.Show("Doslo je do greske. Pokusajte ponovo i proverite format unosa podataka. ID filma mora da bude jedinstven");

                }
            }
            else
            {
                MessageBox.Show("Morate popuniti sva polja!");
            }
        }
        protected void ReallyCenterToScreen()
        {
            Screen screen = Screen.FromControl(this);

            Rectangle workingArea = screen.WorkingArea;
            this.Location = new Point()
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - this.Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - this.Height) / 2)
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 openForm = new Form1();
            openForm.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 openForm = new Form2();
            openForm.Show();
            Visible = false;

        }
    }
}

