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
    public partial class class2 : Form
    {
        DataRow dr;
     public class2()
        {
            InitializeComponent();
            getProgram();

        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-81NQEVVL\\KUSHAL1;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=123456");
       string  status;  
        private void getProgram()
        {
            // Assuming you have a SqlConnection named "connection" established somewhere

            SqlCommand cmd = new SqlCommand("select * from program", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
           // dr = dt.NewRow();
            //dr.ItemArray = new object[]{  0, "--select program--" };
            //dt.Rows.InsertAt(dr, 0);            
            comboBox1.DisplayMember = "program_name";
            comboBox1.ValueMember = "pid";

            comboBox1.DataSource = dt;

        }
        private void getfaculty(int p_id)
        {
            // Assuming you have a SqlConnection named "connection" established somewhere

            SqlCommand cmd = new SqlCommand("select * from faculty2 where pid=@f_id", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.Parameters.AddWithValue("@f_id", p_id);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox2.DisplayMember = "f_name";
            comboBox2.ValueMember = "f_id";

            comboBox2.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-81NQEVVL\\KUSHAL1;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=123456"))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("sp_insertclass1", con);
                        cmd.CommandType = CommandType.StoredProcedure;  

                        cmd.Parameters.AddWithValue("@c_id", int.Parse(textBox2.Text));
                        cmd.Parameters.AddWithValue("@p_name", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@f_name", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@c_name", textBox1.Text);
                        cmd.Parameters.AddWithValue("@f_id", textBox3.Text);




                        // Set the value of status based on the checkbox selection
                        string status = checkBox1.Checked ? "Active" : "Inactive";
                        cmd.Parameters.AddWithValue("@status", status);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully saved");
                        binddata();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    binddata();
                }
            }

            }

            void binddata()
        {
            SqlCommand cmd = new SqlCommand("exec spsaveclass  ", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

        }

            private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {
             status="Active";
            }

            private void checkBox2_CheckedChanged(object sender, EventArgs e)
            {
            status = "inactive";
            }

            private void class2_Load(object sender, EventArgs e)
            {
                binddata();
            }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.ToString()!=null)
            {
                int p_id = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                getfaculty(p_id);
            }
         
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
