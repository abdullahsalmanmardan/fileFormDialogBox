using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        bool flag=false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.Visible=false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            flag=!flag;
            if(flag)
            {
                panel2.Visible= true;
            }  
            else
            {
                panel2.Visible= false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            string allText = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MANAR.|*txt";
            if(openFileDialog.ShowDialog() == DialogResult.OK )
            {
                if(openFileDialog.FilterIndex==1)
                {
                    StreamReader sw= new StreamReader(openFileDialog.FileName);
                  //  MessageBox.Show(openFileDialog.FileName);
                    
                    while(!sw.EndOfStream)
                    {
                        string line=sw.ReadLine();
                        allText+= line+'\n';
                    }
                    MessageBox.Show(allText);
                    List<Employee> employees = new List<Employee>();
                    string[] allLines = allText.Split('\n');
                    MessageBox.Show(allLines.Length.ToString());
                    string[] firstLine = allLines[0].Split(' ');
                   // MessageBox.Show(firstLine[0]+ firstLine[0]+firstLine[0]);
                   for(int i=1; i<allLines.Length-1; i++) 
                   {
                        string[] singleData = allLines[i].Split(' ');
                       
                            Employee e1 = new Employee
                            {
                                Id = int.Parse(singleData[0]),
                                Name = singleData[1],
                                email = singleData[2]
                            };
                            employees.Add(e1);
                   }

                   foreach(Employee e2 in employees)
                    {
                        MessageBox.Show(e2.Name);
                        MessageBox.Show(e2.Id.ToString());
                        MessageBox.Show(e2.email);
                    }

                }
            }
        }
    }
}
