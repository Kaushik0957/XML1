using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xml
{

    public partial class Form1 : Form
    {
        public static List<Employee> LoadEmployees(string xmltext)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmltext);

            List<Employee> employees = new List<Employee>();

            foreach (XmlNode node in doc.DocumentElement)
            {
                string name = node.Attributes[0].Value;
                int age = int.Parse(node["Age"].InnerText);
                bool programmer = bool.Parse(node["Programmer"].InnerText);
                Employee employee = new Employee(name, age, programmer);
                employees.Add(employee);
            }

            return employees;
        }

        public Form1()
        {
            InitializeComponent();
            List<Employee> employees = LoadEmployees("xmltext.xml");
            foreach (Employee employee in employees)
            {
                listBox1.Items.Add(employee); 
            }
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            { 
            propertyGrid1.SelectedObject = listBox1.SelectedItem;
            }
        }
    }
}
