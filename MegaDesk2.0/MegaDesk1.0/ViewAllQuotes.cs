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
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes()
        {
            InitializeComponent();

            List<DeskQuote> quotes = MainMenu.GetQuotes();

            DataTable table = BasicTable();

            foreach (DeskQuote quote in quotes)
            {                
                table.Rows.Add(CreateRow(quote, table));
            }

            dataGridView.DataSource = table;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AllowUserToAddRows = false;
        }

        private void ViewAllQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu main = (MainMenu)Tag;
            main.Show();
            Hide();
        }

        public static DataTable BasicTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("Customer Name", typeof(string)));
            table.Columns.Add(new DataColumn("Quote Amount", typeof(decimal)));
            table.Columns.Add(new DataColumn("Date of Completition", typeof(DateTime)));
            table.Columns.Add(new DataColumn("Production Days", typeof(int)));
            table.Columns.Add(new DataColumn("Desk", typeof(Desk)));

            return table;
        }

        public static DataRow CreateRow(DeskQuote quote, DataTable table)
        {            
            DataRow row = table.NewRow();
            row["Customer Name"] = quote.GetCustomerName();
            row["Quote Amount"] = quote.GetQuoteAmount();
            row["Date of Completition"] = quote.GetCompletionDate();
            row["Production Days"] = quote.GetProductionDays();
            row["Desk"] = quote.GetDesk();
            return row;
        }

        private void ViewAllQuotes_Load(object sender, EventArgs e)
        {

        }
    }
}
