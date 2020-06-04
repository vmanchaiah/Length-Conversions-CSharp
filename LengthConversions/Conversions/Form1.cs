using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conversions
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

            cboConversions.Items.Add(conversionTable[0, 0]);
            cboConversions.Items.Add(conversionTable[1, 0]);
            cboConversions.Items.Add(conversionTable[2, 0]);
            cboConversions.Items.Add(conversionTable[3, 0]);
            cboConversions.Items.Add(conversionTable[4, 0]);
            cboConversions.Items.Add(conversionTable[5, 0]);

            cboConversions.SelectedIndex = 0;

        }

        string[,] conversionTable = {
            {"Miles to kilometers", "Miles", "Kilometers", "1.6093"},
            {"Kilometers to miles", "Kilometers", "Miles", "0.6214"},
            {"Feet to meters", "Feet", "Meters", "0.3048"},
            {"Meters to feet", "Meters", "Feet", "3.2808"},
            {"Inches to centimeters", "Inches", "Centimeters", "2.54"},
            {"Centimeters to inches", "Centimeters", "Inches", "0.3937"}
        };

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;

        }

        public bool IsDecimal(TextBox textBox, string name)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(name + " must be a decimal number.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        private void cboConversions_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            lblToLength.Text = (conversionTable[cboConversions.SelectedIndex, 2]);
            lblFromLength.Text = (conversionTable[cboConversions.SelectedIndex, 1]);


            lblCalculatedLength.Text = "";

            txtLength.Focus();
        }

        public bool IsValidData()
        {
            return

                IsPresent(txtLength, "Length") &&
                IsDecimal(txtLength, "Length");

        }

        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            if (IsValidData() == true)
            {
                lblCalculatedLength.Text = ((int.Parse(txtLength.Text) * decimal.Parse((conversionTable[cboConversions.SelectedIndex, 3]))).ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}