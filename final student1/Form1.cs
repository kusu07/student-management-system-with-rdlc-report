using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace final_student1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            getProgram();
         
       
           
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-81NQEVVL\\KUSHAL1;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=123456");
        string status;

        private void getProgram()
        {
            // Assuming you have a SqlConnection named "connection" established somewhere

            SqlCommand cmd = new SqlCommand("select * from program", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
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

        private void getclass(string  f_id)
        {
            // Assuming you have a SqlConnection named "connection" established somewhere

            SqlCommand cmd = new SqlCommand("select * from classtab1 where f_id=@c_id", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.Parameters.AddWithValue("@c_id", f_id);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox3.DisplayMember = "c_name";
            comboBox3.ValueMember = "c_id";
            comboBox3.DataSource = dt;
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                try
                {
                    using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-81NQEVVL\\KUSHAL1;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=123456"))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("sp_student", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                        cmd.Parameters.AddWithValue("@name", (textBox2.Text));
                        cmd.Parameters.AddWithValue("@address", (textBox3.Text));

                        cmd.Parameters.AddWithValue("@p_name", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@f_name", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@c_name", comboBox3.Text);

                        // Set the value of status based on the checkbox selection
                        string status = checkBox1.Checked ? "Running" : "Passout";
                        cmd.Parameters.AddWithValue("@status", status);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully saved");
                        Binddata();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    Binddata();


                }
            }
        }
        void Binddata()
        {
            SqlCommand cmd = new SqlCommand("exec savestudent", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            Binddata();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.ToString() != null)
            {
                int p_id = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                getfaculty(p_id);
            }
        }

        private void comboBox2_SelectedIndexChanged_3(object sender, EventArgs e)
        {

            if (comboBox2.SelectedValue.ToString() != null)
            {
                string  f_id = comboBox2.SelectedValue.ToString();
                getclass(f_id);
            }
        }
        }
    }

       


   
 


  