using System;
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
    public partial class SearchQuotes : Form
    {
        public SearchQuotes()
        {
            InitializeComponent();
        }

        private void SearchQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu main = (MainMenu)Tag;
            main.Show();
            Hide();
        }

        private void btnSearchQuotes_Click(object sender, EventArgs e)
        {
            //Send the information to be searched
            dataGridSearchQuotes.DataSource = DeskQuote.getQuotesMaterial(searchQuoteMaterialDropdown.Text);
        }
    }
}
