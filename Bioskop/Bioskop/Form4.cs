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
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DZAJA-PC;Initial Catalog=Bioskop;Integrated Security=True");
        public Form4()
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
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
            string sifra = textBox1.Text;
            string datum = textBox2.Text;
            string vreme = textBox3.Text;
            string smesta = textBox4.Text;
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            SqlDataReader dataReader = null;
            StringBuilder builder;
            if (sifra.Length > 0 && datum.Length > 0 && vreme.Length > 0 && smesta.Length > 0)
            {
                cmd.CommandText = "SELECT * FROM Film WHERE id = '" + sifra + "'";
                builder = new StringBuilder();
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    builder.Append("Sifra: " + dataReader.GetValue(0));

                }

                cmd.Dispose();
                con.Close();
                string output = builder.ToString();
                if (output.Length > 0)
                {
                    con.Open();
                    cmd.CommandText = "UPDATE Film set datum_odrzavanja = '" + datum + "' , vreme = '" + vreme + "' where id = '" + sifra + "'";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                    MessageBox.Show("Uspesno ste azurirali podatke o filmu");

                }
                else MessageBox.Show("Ne postoji film sa trazenom sifrom");


                ResetText();
                dataReader.Close();
                con.Close();



            }
            else
            {
                MessageBox.Show("Morate uneti sve trazene parametre");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 openForm = new Form2();
            openForm.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 openForm = new Form1();
            openForm.Show();
            Visible = false;
        }
    }
}
