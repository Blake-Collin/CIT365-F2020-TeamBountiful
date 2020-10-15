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
            searchQuoteMaterialDropdown.DataSource = Enum.GetValues(typeof(DeskMaterial));
        }

        private void SearchQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu main = (MainMenu)Tag;
            main.Show();
            Hide();
        }

        private void btnSearchQuotes_Click(object sender, EventArgs e)
        {
            DeskMaterial material;
            Enum.TryParse<DeskMaterial>(searchQuoteMaterialDropdown.SelectedValue.ToString(), out material);

            DataTable table = ViewAllQuotes.BasicTable();

            foreach(DeskQuote quote in MainMenu.GetQuotes())
            {
                if(quote.GetDesk().GetDeskMaterial() == material)
                {                    
                    table.Rows.Add(ViewAllQuotes.CreateRow(quote, table));
                }
            }

            dataGridSearchQuotes.DataSource = table;
            dataGridSearchQuotes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;            
            dataGridSearchQuotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
    }
}
