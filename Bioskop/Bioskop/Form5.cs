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
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DZAJA-PC;Initial Catalog=Bioskop;Integrated Security=True");
        public Form5()
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

        private void Form5_Load(object sender, EventArgs e)
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
            string sifra = textBox1.Text;
            SqlCommand cmd = con.CreateCommand();
            SqlDataReader dataReader = null;
            cmd.CommandType = CommandType.Text;
            StringBuilder builder;
            if (sifra.Length > 0)
            {
                // cmd.CommandText = "DELETE FROM  WHERE Sifra = '" + sifra + "' ";
                cmd.CommandText = "SELECT * FROM Film WHERE id = '" + sifra + "'";
                builder = new StringBuilder();

                //try

                /*cmd.CommandText = "IF EXISTS(SELECT * FROM  WHERE Sifra = '" + sifra + "') DELETE FROM  WHERE Sifra = '" + sifra + "' ";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                MessageBox.Show("Uspesno ste ob");*/
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
                    cmd.CommandText = "DELETE FROM Film WHERE id = '" + sifra + "' ";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                    MessageBox.Show("Uspesno ste obrisali film");

                }
                else MessageBox.Show("Ne postoji film sa trazenom sifrom");


                ResetText();
                dataReader.Close();
                con.Close();



                /*catch 
                {
                     MessageBox.Show("Ne postoji sa ovom sifrom!");
                }*/
            }
            else
            {
                MessageBox.Show("Morate uneti sifru filma koji zelite da izbrisete");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 openForm = new Form2();
            openForm.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 openForm = new Form1();
            openForm.Show();
            Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
