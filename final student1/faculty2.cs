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
namespace final_student1
{
    public partial class faculty2 : Form
    {
        public faculty2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-81NQEVVL\\KUSHAL1;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=123456");
        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EXEC insertfaculty @f_id, @p_name,@f_name,@pid", con);



                cmd.Parameters.AddWithValue("@f_id",(textBox1.Text));

                cmd.Parameters.AddWithValue("@p_name", comboBox1.Text);

                cmd.Parameters.AddWithValue("@f_name", textBox2.Text);

                cmd.Parameters.AddWithValue("@pid", textBox3.Text);






                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Successfully saved");
                binddata();


            }
        }
            void binddata()
            {
                SqlCommand cmd = new SqlCommand("exec Savefaculty", con);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        private void faculty2_Load_3(object sender, EventArgs e)
        {
            binddata();
        }

        private void Cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }

      
}