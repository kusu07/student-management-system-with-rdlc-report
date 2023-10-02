using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_student1
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1info = new Form1();
            form1info.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            program2 program2info = new program2();
            program2info.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            faculty2 faculty2info = new faculty2();
            faculty2info.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            class2 class2info = new class2();
            class2info.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            student_report student_Reportinfo = new student_report();
            student_Reportinfo.Show();
        }

     

      

        private void button6_Click(object sender, EventArgs e)
        {
            classrdlc1 classrdlc1info = new classrdlc1();
            classrdlc1info.Show();
        }
    }
}
