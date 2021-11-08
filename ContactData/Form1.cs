using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var MyContact = new FirstDBEntities().Contacts;

            //displays Persons in list
            foreach (var item in MyContact)
            {
                listBox1.Items.Add(item);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Will be abel to click the listbox items
            ListBox Persons = sender as ListBox;
            Contact selectedPerson = Persons.SelectedItem as Contact;

            IdLabel.Text = $"Id: {selectedPerson.Id}";
            PhoneNumber.Text = $"PhoneNumber: {selectedPerson.PhoneNumber}";
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Button Add = sender as Button;

            using (var context = new FirstDBEntities())
            {
                var firsname = new Contact { FirstName = textBox1.Text,
                    LastName = textBox2.Text,
                    PhoneNumber = int.Parse(textBox3.Text)};
                context.Contacts.Add(firsname);
                context.SaveChanges();
            }


        }

    }
    public partial class Contact
    {
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

}
