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
using CSVLib;

namespace CSVExample
{
    public partial class CSVEXample : Form
    {
        public CSVEXample()
        {
            InitializeComponent();
        }

        private string fileLocation = @"personalinfo.cvs";

        private void saveButton_Click(object sender, EventArgs e)
        {
            FileStream aFileStream = new FileStream(fileLocation,FileMode.Open);
            CsvFileReader aCsvFileReaderr = new CsvFileReader(aFileStream);
            List<string> personalRecod = new List<string>();

            while (aCsvFileReaderr.ReadRow(personalRecod))
            {
                if (contactNumberTextBox.Text == personalRecod[0])
                {
                    MessageBox.Show("this name doesn't exist!");
                    aFileStream.Close();
                    return;
                }
               

            }



            CsvFileWriter aWriter = new CsvFileWriter(aFileStream);

            personalRecod.Add(nameTextBox.Text);
            personalRecod.Add(emailTextBox.Text);
            personalRecod.Add(contactNumberTextBox.Text);
            personalRecod.Add(homeContactTextBox.Text);
            personalRecod.Add(homeAddressTextBox.Text);
            aWriter.WriteRow(personalRecod);
            aFileStream.Close();
            
            






        }
    }
}
