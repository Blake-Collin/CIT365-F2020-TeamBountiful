using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MegaDesk1._0
{
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes()
        {
            InitializeComponent();

            //different option
            using (StreamReader file = File.OpenText("quotes.txt"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject oj = (JObject)JToken.ReadFrom(reader);
            }
            var quotes = JsonConvert.DeserializeObject("quotes.txt");
            DataGridView.DataSource = quotes;
            //another option

            DataTable dt = (DataTable)JsonConvert.DeserializeObject("quotes.txt");
            var list = new BindingList<DeskQuote>(DeskQuote.dataQuotes);
            DataGridView.DataSource = list;
        }

        private void ViewAllQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu main = (MainMenu)Tag;
            main.Show();
            Hide();
        }

        private void ViewAllQuotes_Load(object sender, EventArgs e)
        {

        }
    }
}
