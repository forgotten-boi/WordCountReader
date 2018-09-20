using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Office.Interop.Word;

using Application = Microsoft.Office.Interop.Word.Application;

namespace WordCountApp
{
    public partial class WordCounter : Form
    {
        public WordCounter()
        {
            InitializeComponent();
            this.OpenFileDialog1.Filter =
        "Document (*.doc;*.docx;*.pdf, *.csv)|*.doc;*.docx;*.pdf,*.csv|" +
        "All files (*.*)|*.*";

            // Allow the user to select multiple images.
            this.OpenFileDialog1.Multiselect = true;
            this.OpenFileDialog1.Title = "My Image Browser";
        }

        private void btnCountWords_Click(System.Object sender, System.EventArgs e)
        {
            //DialogResult dr = this.OpenFileDialog1.ShowDialog();
            //if (dr == System.Windows.Forms.DialogResult.OK)
            //{
            //    // Read the files
            //    foreach (String file in openFileDialog1.FileNames)
            //    {
                    string strDocumentText;
                string strUniqueWords;
                string strSingleWord = "";
                long lngTotalWordsCount;
                long lngUniqueWordsCount;
                string strFilePath;
                //long i;
                Application fileApp;
                Regex RegexObj;
                int SingleWordSearchCount;

                try
                {
                // First reset controls


                    TabPage1.Text = "All words";
                    TabPage2.Text = "Unique words only";

                    // Now check if the selected file exists
                    strFilePath = "";

                    if (txtFilePath.Text == "")
                    {
                        DialogResult result = OpenFileDialog1.ShowDialog();
                        strFilePath = OpenFileDialog1.FileName;

                        if (strFilePath != "" & strFilePath != "OpenFileDialog1")
                            txtFilePath.Text = strFilePath;
                        else
                        {
                       MessageBox.Show("You need to choose a file!","File Selection Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    if (File.Exists(strFilePath) == false)
                    {
                        MessageBox.Show("Selected file no longer exists! Please double-check the path and try again.",  "File Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    // Reset controls
                    this.Cursor = Cursors.WaitCursor;
                    lstAllWords.Cursor = Cursors.WaitCursor;
                    lstUniqueWords.Cursor = Cursors.WaitCursor;
                    lstFinalResults.Cursor = Cursors.WaitCursor;
                    btnCountWords.Enabled = false;
                    txtFilePath.Cursor = Cursors.WaitCursor;

                    // Open the chosen document  
                    fileApp = new Application();
                    Document doc = fileApp.Documents.Open(strFilePath);
                    long lngSystemWordCount = doc.Words.Count;

                    // Read all the words into a string
                    strDocumentText = "";
                    lngTotalWordsCount = 0;

                    for ( int i = 1; i <= lngSystemWordCount; i++)
                    {
                        strSingleWord = doc.Words[i].Text;

                        if (strSingleWord.Replace(" ", "") != "")
                        {
                            lstAllWords.Items.Add(strSingleWord);
                            strDocumentText = strDocumentText + " " + strSingleWord;
                            lngTotalWordsCount = lngTotalWordsCount + 1;
                        }
                    }

                    // Quit the file processing application
                    fileApp.Quit();

                    // Count total number of words and display them in the first tab
                    TabPage1.Text = "All words (" + lngTotalWordsCount + ")";

                    // Now count the number of unique words
                    var distinctWordsArray = strDocumentText.Split(' ').Distinct().ToArray();

                    strUniqueWords = "";
                    lngUniqueWordsCount = 0;

                    for (int i = 0; i < (distinctWordsArray.Length); i++)
                    {
                        strSingleWord = distinctWordsArray[i];

                        if (strSingleWord.Replace(" ", "") != "")
                        {
                            lstUniqueWords.Items.Add(strSingleWord);
                            strUniqueWords = strUniqueWords + " " + strSingleWord;
                            lngUniqueWordsCount = lngUniqueWordsCount + 1;
                        }
                    }

                    TabPage2.Text = "Unique words only (" + lngUniqueWordsCount + ")";

                    // Now get number of occurrences of each word in the whole file
                    for (int i = 0; i < (distinctWordsArray.Length); i++)
                    {
                        strSingleWord = distinctWordsArray[i];

                        if (strSingleWord != "")
                        {
                            RegexObj = new Regex(strSingleWord);
                            SingleWordSearchCount = RegexObj.Matches(strDocumentText).Count;

                            if (SingleWordSearchCount > 0)
                                lstFinalResults.Items.Add(strSingleWord + " - " + SingleWordSearchCount);
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                }

                finally
                {
                    // Reset controls
                    this.Cursor = Cursors.Default;
                    lstAllWords.Cursor = Cursors.Default;
                    lstUniqueWords.Cursor = Cursors.Default;
                    lstFinalResults.Cursor = Cursors.Default;
                    btnCountWords.Enabled = true;
                    txtFilePath.Cursor = Cursors.WaitCursor;

                    // Reset memory objects
                    RegexObj = null;
                    fileApp = null/* TODO Change to default(_) if this is not a reference type */;

                    MessageBox.Show("Done. See the 'Final Results' tab!","", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

      
    }

    }

