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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace final_student1
{
    public partial class classrdlc1 : Form
    {
        DataRow dr;
   
        public classrdlc1()
        {
            InitializeComponent();
            getfaculty();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-81NQEVVL\\KUSHAL1;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=123456");
        private void getfaculty()
        {
            // Assuming you have a SqlConnection named "connection" established somewhere

            SqlCommand cmd = new SqlCommand("select * from faculty2 ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sda.Fill(dt);
           dr = dt.NewRow();
           dr.ItemArray = new object[] { 0, "--select faculty--" };
          dt.Rows.InsertAt(dr, 0);
                  
            
            comboBox1.DisplayMember = "f_name";
           comboBox1.ValueMember = "f_id";

            comboBox1.DataSource = dt;
        }

         private void getclass(string f_id)
        {
        // Assuming you have a SqlConnection named "connection" established somewhere

        SqlCommand cmd = new SqlCommand("select * from classtab1 where f_id=@c_id", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.SelectCommand.Parameters.AddWithValue("@c_id", f_id);
        DataTable dt = new DataTable();
        sda.Fill(dt);
          // dr = dt.NewRow();
            //dr.ItemArray = new object[] { 0, "-select class-" };
           // dt.Rows.InsertAt(dr, 0);
        comboBox2.DisplayMember = "c_name";
       comboBox2.ValueMember = "c_id";
        comboBox2.DataSource = dt;
    }

        private void classrdlc1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet3.classtab1' table. You can move, or remove it, as needed.
            this.classtab1TableAdapter.Fill(this.projectDataSet3.classtab1);

            this.reportViewer1.RefreshReport();
        }

            

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.ToString() != null)
            {
                string f_id = comboBox1.SelectedValue.ToString();
                getclass(f_id);
            }
    }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem !=null)
            {
                this.classtab1TableAdapter.FillByBoth(this.projectDataSet3.classtab1, comboBox1.Text, comboBox2.Text.ToString());
                this.reportViewer1.RefreshReport();
            }
        }

        private void button2_Click(object sender, EventArgs e)  
        {
            // TODO: This line of code loads data into the 'projectDataSet3.classtab1' table. You can move, or remove it, as needed.
            this.classtab1TableAdapter.Fill(this.projectDataSet3.classtab1);

            this.reportViewer1.RefreshReport();
          
           

        }
    }
}
   