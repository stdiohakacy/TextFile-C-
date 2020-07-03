using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFile_C
{
    public class FileFactory
    {
        public static bool saveFile(List<Student> listStudent, string path) {
            try
            {
                StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
                foreach (Student student in listStudent)
                {
                    string line = student.code + ";" + student.name + ";" + student.DOB.ToString("dd/MM/yyyy");
                    sw.WriteLine(line);
                }
                sw.Close();
                return true;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public static List<Student> readFile(string path)
        {
            List<Student> listStudent = new List<Student>();
            try
            {
                StreamReader sr = new StreamReader(path, Encoding.UTF8);
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] arr = line.Split(';');
                    if (arr.Length == 3)
                    {
                        Student student = new Student();
                        student.code = int.Parse(arr[0]);
                        student.name = arr[1];
                        student.DOB = DateTime.Parse(arr[2]);

                        listStudent.Add(student);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listStudent;
        }
    }
}
