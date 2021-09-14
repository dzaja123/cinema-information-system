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
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DZAJA-PC;Initial Catalog=Bioskop;Integrated Security=True");

        public Form6()
        {

            InitializeComponent();
            ReallyCenterToScreen();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Film";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void Form6_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataReader dataReader = null;
            //SqlCommand command;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string sifra = textBox1.Text;
            StringBuilder builder;
            if (sifra.Length > 0)
            {
                cmd.CommandText = "SELECT * FROM Film WHERE id = '" + sifra + "'";
                builder = new StringBuilder();
                try
                {
                    dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        builder.Append("Sifra: " + dataReader.GetValue(0) + "\nNaziv: " + dataReader.GetValue(1) + "\nDatum: " + dataReader.GetValue(2) + "\nVreme: " + dataReader.GetValue(3) + "\nUloge: " + dataReader.GetValue(4) + "\nSlobodna mesta: " + dataReader.GetValue(5));
                        builder.Append("\n---------------");
                    }

                    cmd.Dispose();
                    string output = builder.ToString();
                    if (output.Length > 0) MessageBox.Show(builder.ToString());
                    else MessageBox.Show("Ne postoji film sa trazenom sifrom!");

                    ResetText();
                    dataReader.Close();
                    con.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    MessageBox.Show("Doslo je do greske!");
                }

            }
            else
            {
                MessageBox.Show("Morate uneti sifru!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataReader dataReader = null;
            //SqlCommand command;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string naziv = textBox2.Text;
            StringBuilder builder;
            if (naziv.Length > 0)
            {
                cmd.CommandText = "SELECT * FROM Film WHERE imeFilma = '" + naziv + "'";
                builder = new StringBuilder();
                try
                {
                    dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        builder.Append("Sifra: " + dataReader.GetValue(0) + "\nNaziv: " + dataReader.GetValue(1) + "\nDatum: " + dataReader.GetValue(2) + "\nVreme: " + dataReader.GetValue(3) + "\nUloge: " + dataReader.GetValue(4) + "\nSlobodna mesta: " + dataReader.GetValue(5));
                        builder.Append("\n---------------");
                    }

                    cmd.Dispose();
                    string output = builder.ToString();
                    if (output.Length > 0) MessageBox.Show(builder.ToString());
                    else MessageBox.Show("Ne postoji film sa trazenim naslovom");

                    ResetText();
                    dataReader.Close();
                    con.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    MessageBox.Show("Doslo je do greske");
                }

            }
            else
            {
                MessageBox.Show("Morate uneti naziv filma");
            }
        } 

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 openForm = new Form1();
            openForm.Show();
            Visible = false;

        }
    }
}
