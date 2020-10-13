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



namespace MegaDesk1._0
{
    public partial class MainMenu : Form
    {

        //Public Variable of some kind list/arraylist/dictionary whatever. (Probably List)
        private static List<DeskQuote> quotes = new List<DeskQuote>();

        public MainMenu()
        {
            InitializeComponent();
            //Load JSon
            var quotesFile = @"quotes.json";
            List<DeskQuote> deskQuotes = new List<DeskQuote>();

            // read existing quotes
            if ( File.Exists(quotesFile))
            {
                using (StreamReader reader = new StreamReader(quotesFile))
                {
                    // load quotes
                    string quotes = reader.ReadToEnd();

                    if (quotes.Length >0)
                    {
                        // deserialize
                        deskQuotes = JsonConvert.DeserializeObject<List<DeskQuote>>(quotes);
                    }

                    // add a quote
                    deskQuotes.Add(deskQuote);
                }

                // save
                SaveQuotes(deskQuotes);
            }
            else
            {
                // create new quote list
                deskQuotes = new List<DeskQuote> { deskQuote };

                SaveQuotes(deskQuotes);
            }

            
            //*****
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
            //Save JSON
           

            //********
            Close();
        }
    }
}
