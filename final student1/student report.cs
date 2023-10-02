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
    public partial class student_report : Form
    {
        public student_report()
        {
            InitializeComponent();
        }

        private void student_report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet.studenttab' table. You can move, or remove it, as needed.
            this.studenttabTableAdapter.Fill(this.projectDataSet.studenttab);

            this.reportViewer1.RefreshReport();
        }
    }
}
