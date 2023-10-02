using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace final_student1
{
    public partial class program2 : Form
    {
        public program2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-81NQEVVL\\KUSHAL1;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=123456");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EXEC InsertProgram @pid, @program_name", con);

            // Replace "textBox3.Text", "textBox2.Text", and "comboBox1.Text" with actual values

            cmd.Parameters.AddWithValue("@pid", int.Parse(textBox2.Text));

            cmd.Parameters.AddWithValue("@program_name", comboBox1.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully saved");
            binddata(); // Assuming this function is used to bind data to some UI element


        }
        void binddata()
        {
            SqlCommand cmd = new SqlCommand("exec SaveProgram ", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void program2_Load(object sender, EventArgs e)
        {
            binddata();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}

  
