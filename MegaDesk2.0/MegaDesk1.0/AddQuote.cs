using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk1._0
{
    public partial class AddQuote : Form
    {
        private static int[] DAYS = new int[] { 14, 3, 5, 7 };
        private DeskQuote deskQuote;

        public AddQuote()
        {
            InitializeComponent();

            //Set our limits/values
            materialComboBox.DataSource = Enum.GetValues(typeof(DeskMaterial));

            daysComboBox.DataSource = DAYS;

            //Set Labels

            depthLabel.Text = "Desk Depth: (" + Desk.GetMinDepth() + "\"-" + Desk.GetMaxDepth() + "\")";
            widthLabel.Text = "Desk Width: (" + Desk.GetMinWdith() + "\"-" + Desk.GetMaxWidth() + "\")";
            drawLabel.Text = "Number of Drawers: (" + Desk.GetMinDrawers() + "-" + Desk.GetMaxDrawers() + ")";
        }

        private bool checkValid()
        {
            errorLabel.Text = "";
            materialComboBox.BackColor = Color.White;
            daysComboBox.BackColor = Color.White;
            nameTextBox.BackColor = Color.White;
            depthNum.BackColor = Color.White;
            widthNum.BackColor = Color.White;

            if (materialComboBox.SelectedIndex == -1)
            {

                errorLabel.Text = "Must Select a Material.";
                materialComboBox.BackColor = Color.Red;
                return false;
            }

            if (daysComboBox.SelectedIndex == -1)
            {
                errorLabel.Text = "Must Select a number of days.";
                daysComboBox.BackColor = Color.Red;
                return false;
            }

            if (nameTextBox.Text == "")
            {
                errorLabel.Text = "Name cannot be empty.";
                nameTextBox.BackColor = Color.Red;
                return false;
            }

            if (depthNum.Text == "")
            {
                errorLabel.Text = "Depth cannot be empty.";
                depthNum.BackColor = Color.Red;
                return false;
            }

            if (widthNum.Text == "")
            {
                errorLabel.Text = "Width cannot be empty.";
                widthNum.BackColor = Color.Red;
                return false;
            }

            if (drawersNum.Text == "")
            {
                errorLabel.Text = "Drawers cannot be empty.";
                drawersNum.BackColor = Color.Red;
                return false;
            }

            return true;
        }

        private void AddQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu main = (MainMenu)Tag;
            main.Show();
            Hide();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (checkValid())
            {                
                try
                {
                    DeskMaterial material;
                    Enum.TryParse<DeskMaterial>(materialComboBox.SelectedValue.ToString(), out material);
                    deskQuote = new DeskQuote(nameTextBox.Text, int.Parse(widthNum.Text), int.Parse(depthNum.Text), int.Parse(drawersNum.Text), material, (int)daysComboBox.SelectedItem);
                    MainMenu.GetQuotes().Add(deskQuote);
                    DisplayQuote quote = new DisplayQuote(deskQuote);
                    quote.Tag = this;
                    quote.Show(this);
                    Hide();
                }
                catch (Exception exe)
                {
                    errorLabel.Text = exe.Message;
                }
            }
        }


        //Prevent anything but numbers from being entered.
        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {                
                e.Handled = true;
            }
        }

        private void depthNum_TextChanged(object sender, EventArgs e)
        {

            int temp;
            if (int.TryParse(depthNum.Text, out temp)) 
            { 
                if (temp < Desk.GetMinDepth())
                {
                    depthNum.BackColor = Color.Red;
                    errorLabel.Text = "Depth below minimum allowance.";
                }
                else if (temp > Desk.GetMaxDepth())
                {
                    depthNum.BackColor = Color.Red;
                    errorLabel.Text = "Depth above maximum allowance.";
                }
                else
                {
                    depthNum.BackColor = Color.White;
                    errorLabel.Text = "";
                }
            }
        }

        private void widthNum_TextChanged(object sender, EventArgs e)
        {
            int temp;
            if (int.TryParse(widthNum.Text, out temp))
            {
                if (temp < Desk.GetMinWdith())
                {
                    widthNum.BackColor = Color.Red;
                    errorLabel.Text = "*Width below minimum allowance.";
                }
                else if (temp > Desk.GetMaxWidth())
                {
                    widthNum.BackColor = Color.Red;
                    errorLabel.Text = "*Width above maximum allowance.";
                }
                else
                {
                    widthNum.BackColor = Color.White;
                    errorLabel.Text = "";
                }
            }
        }

        private void drawersNum_TextChanged(object sender, EventArgs e)
        {
            int temp;
            if (int.TryParse(drawersNum.Text, out temp))
            {
                if (temp < Desk.GetMinDrawers())
                {
                    drawersNum.BackColor = Color.Red;
                    errorLabel.Text = "*Drawers count below minimum.";
                }
                else if (temp > Desk.GetMaxDrawers())
                {
                    drawersNum.BackColor = Color.Red;
                    errorLabel.Text = "*Drawers count above maximum.";
                }
                else
                {
                    drawersNum.BackColor = Color.White;
                    errorLabel.Text = "";
                }
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "")
            {
                errorLabel.Text = "";
                nameTextBox.BackColor = Color.White;
            }
            else
            {
                errorLabel.Text = "Name cannot be empty.";
                nameTextBox.BackColor = Color.Red;
            }
        }
    }
}
