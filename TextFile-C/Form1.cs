using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFile_C
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Student> listStudent = new List<Student>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.code = int.Parse(txtCode.Text);
            student.name = txtName.Text;
            student.DOB = dtpDOB.Value;
            listStudent.Add(student);

            showStudents();
        }

        private void showStudents()
        {
            lbStudent.Items.Clear();
            foreach (Student student in listStudent)
            {
                lbStudent.Items.Add(student);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Application.StartupPath + "\\database.txt";
                bool check = FileFactory.saveFile(listStudent, path);
                if (check)
                    MessageBox.Show("Save successed!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\database.txt";
            if (System.IO.File.Exists(path))
            { 
                listStudent = FileFactory.readFile(path);
                showStudents();
            }
        }
    }
}
