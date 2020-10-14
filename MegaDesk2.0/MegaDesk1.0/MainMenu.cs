using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MegaDesk1._0
{
    public partial class MainMenu : Form
    {

        //Public Variable of some kind list/arraylist/dictionary whatever. (Probably List)
        private static List<DeskQuote> quotes = new List<DeskQuote>();
        private string quotesFile = @"quotes.json";

        public MainMenu()
        {
            InitializeComponent();
            

            //Load in Rush Order Pricing
            DeskQuote.GetRushOrder();

            //Load JSon
            if (File.Exists(quotesFile))
            {
                string json = File.ReadAllText(quotesFile);
                List<DeskQuote> deser = JsonConvert.DeserializeObject<List<DeskQuote>>(json);
                //Error checking maybe?
                quotes = deser;
            }
        }

        public static List<DeskQuote> GetQuotes()
        {
            return quotes;
        }

        private void addQuoteButton_Click(object sender, EventArgs e)
        {
            AddQuote quote = new AddQuote();
            quote.Tag = this;
            quote.Show(this);
            Hide();
        }

        private void viewQuotesButton_Click(object sender, EventArgs e)
        {
            ViewAllQuotes quotes = new ViewAllQuotes();
            quotes.Tag = this;
            quotes.Show(this);
            Hide();
        }

        private void searchQuotes_Click(object sender, EventArgs e)
        {
            SearchQuotes squotes = new SearchQuotes();
            squotes.Tag = this;
            squotes.Show(this);
            Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {         
            Close();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            JsonSerializer serializer = new JsonSerializer();
            string json = JsonConvert.SerializeObject(quotes);
            Console.WriteLine(json);
            System.IO.File.WriteAllText(quotesFile, json);
        }
    }
}
