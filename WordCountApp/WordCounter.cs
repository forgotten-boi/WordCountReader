﻿using System;
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
using iTextSharp.text.pdf.parser;
using System.IO.MemoryMappedFiles;
using System.Diagnostics;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace WordCountApp
{
    public partial class WordCounter : Form
    {
        public WordCounter()
        {
            InitializeComponent();
        //    this.OpenFileDialog1.Filter =
        //"Document (*.doc;*.docx;*.pdf, *.csv)|*.doc;*.docx;*.pdf,*.csv|" +
        //"All files (*.*)|*.*";

            // Allow the user to select multiple images.
            this.OpenFileDialog1.Multiselect = true;
            this.OpenFileDialog1.Title = "My Image Browser";
        }

        private void btnCountWords_Click(System.Object sender, System.EventArgs e)
        {
            DialogResult dr = this.OpenFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                OpenFileDialog1.FileNames.ToList().ForEach(p=>
                    {
                        txtFilePath.Text += p + ", ";
                });

                string strDocumentText;
                string strUniqueWords;
                string strSingleWord = "";
                long lngTotalWordsCount = 0;
                long lngUniqueWordsCount = 0;
                //string strFilePath;
                //long i;
                Application fileApp;
                Regex RegexObj;
                int SingleWordSearchCount;

                // Read the files
                foreach (String strFilePath in OpenFileDialog1.FileNames)
                {


                    try
                    {
                        // First reset controls


                        TabPage1.Text = "All words";
                        TabPage2.Text = "Unique words only";

                        // Now check if the selected file exists
                        //strFilePath = "";

                        if (txtFilePath.Text == "")
                        {
                            //DialogResult result = OpenFileDialog1.ShowDialog();
                            //strFilePath = OpenFileDialog1.FileName;

                            //if (strFilePath != "" & strFilePath != "OpenFileDialog1")
                            //    txtFilePath.Text = strFilePath;
                            //else
                            //{
                            MessageBox.Show("You need to choose a file!", "File Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                            //}
                        }

                        if (File.Exists(strFilePath) == false)
                        {
                            MessageBox.Show("Selected file no longer exists! Please double-check the path and try again.", "File Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        // Reset controls
                        this.Cursor = Cursors.WaitCursor;
                        lstAllWords.Cursor = Cursors.WaitCursor;
                        lstUniqueWords.Cursor = Cursors.WaitCursor;
                        lstFinalResults.Cursor = Cursors.WaitCursor;
                        btnCountWords.Enabled = false;
                        txtFilePath.Cursor = Cursors.WaitCursor;

                        long lngSystemWordCount = 0;

                        // Read all the words into a string
                        strDocumentText = "";


                        if (System.IO.Path.GetExtension(strFilePath).Equals(".pdf", StringComparison.CurrentCultureIgnoreCase))
                        {
                            //string InputFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Input.pdf");

                            //Get all the text
                            string[] TextArrays = ExtractAllTextFromPdf(strFilePath);
                            //Count the words
                            //int I = GetWordCountFromString(T);

                            Stopwatch sw = new Stopwatch();

                            sw.Start();

                            lngSystemWordCount = TextArrays.Length;

                            lstAllWords.Items.AddRange(TextArrays);
                            strDocumentText = string.Join(" ", TextArrays);
                            sw.Stop();

                            Stopwatch sw1 = new Stopwatch();


                        

                            //for (int i = 0; i < lngSystemWordCount; i++)
                            //{
                            //    strSingleWord = TextArrays[i];
                             

                            //    if (!string.IsNullOrEmpty(strSingleWord) && strSingleWord.Replace(" ", "") != "")
                            //    {
                            //        lstAllWords.Items.Add(strSingleWord);
                            //        strDocumentText = strDocumentText + " " + strSingleWord;
                            //        lngTotalWordsCount = lngTotalWordsCount + 1;
                            //    }
                            //}

                        }
                        if (System.IO.Path.GetExtension(strFilePath).Equals(".txt", StringComparison.CurrentCultureIgnoreCase) || System.IO.Path.GetExtension(strFilePath).Equals(".srt", StringComparison.CurrentCultureIgnoreCase))
                        {
                            string[] TextArrays = ExtractAllTextWordsFromText(strFilePath);
                            //Count the words
                            //int I = GetWordCountFromString(T);
                            lngSystemWordCount += TextArrays.Length;

                            lstAllWords.Items.AddRange(TextArrays);
                            strDocumentText += string.Join(" ", TextArrays);

                            //for (int i = 0; i < lngSystemWordCount; i++)
                            //{
                            //    strSingleWord = TextArrays[i];

                            //    if (!string.IsNullOrEmpty(strSingleWord) && strSingleWord.Replace(" ", "") != "")
                            //    {
                            //        lstAllWords.Items.Add(strSingleWord);
                            //        strDocumentText = strDocumentText + " " + strSingleWord;
                            //        lngTotalWordsCount = lngTotalWordsCount + 1;
                            //    }
                            //}
                        }
                        //doc or docx or microsoft product
                        if (System.IO.Path.GetExtension(strFilePath).Equals(".doc", StringComparison.CurrentCultureIgnoreCase) || System.IO.Path.GetExtension(strFilePath).Equals(".docx",StringComparison.CurrentCultureIgnoreCase))
                        {

                            // Open the chosen document  
                            fileApp = new Application();




                            Document doc = fileApp.Documents.Open(strFilePath);

                            //foreach (Paragraph objParagraph in doc.Paragraphs)
                            //{

                            //    lstAllWords.Items.AddRange(objParagraph.Range.Text.Split(' '));
                                
                            //}

                            var TextArrays = doc.Content.Text.Split(' ');


                            strDocumentText += string.Join(" ", TextArrays);
                            lstAllWords.Items.AddRange(TextArrays);
                            lngSystemWordCount += doc.Words.Count;

                            
                            





                            //lngTotalWordsCount = 0;

                            //for (int i = 1; i <= lngSystemWordCount; i++)
                            //{
                            //    strSingleWord = doc.Words[i].Text;

                            //    if (!string.IsNullOrEmpty(strSingleWord) && strSingleWord.Replace(" ", "") != "")
                            //    {
                            //        lstAllWords.Items.Add(strSingleWord);
                            //        strDocumentText = strDocumentText + " " + strSingleWord;
                            //        lngTotalWordsCount = lngTotalWordsCount + 1;
                            //    }
                            //}

                            // Quit the file processing application
                            fileApp.Quit();
                        }
                        // Count total number of words and display them in the first tab


                        TabPage1.Text = "All words (" + lngTotalWordsCount + ")";

                        // Now count the number of unique words

                        var totalWordArray = strDocumentText.Split(' ');

                        var distinctWordsArray = totalWordArray.Distinct().ToArray();

                        strUniqueWords = "";
                        //lngUniqueWordsCount = 0;

                        lstUniqueWords.Items.AddRange(distinctWordsArray);
                        strUniqueWords += string.Join(" ", strSingleWord);
                     
                        lngUniqueWordsCount = distinctWordsArray.Length;




                        //for (int i = 0; i < (distinctWordsArray.Length); i++)
                        //{
                        //    strSingleWord = distinctWordsArray[i];

                        //    if (strSingleWord.Replace(" ", "") != "")
                        //    {
                        //        lstUniqueWords.Items.Add(strSingleWord);
                        //        strUniqueWords = strUniqueWords + " " + strSingleWord;
                        //        lngUniqueWordsCount = lngUniqueWordsCount + 1;
                        //    }
                        //}

                        TabPage2.Text = "Unique words only (" + lngUniqueWordsCount + ")";

                        // Now get number of occurrences of each word in the whole file

                        //var uniqueWOrdsList = new List<string>();

                        Func<string, int> textCount = delegate(string text)
                        {
                            int countText = 0;
                            countText = distinctWordsArray.Where(p => p.Equals(text)).ToArray().Length;
                            return countText;
                        };

                        var uniqueWOrdsList = distinctWordsArray.ToList().GroupBy(p => p).Select(p=> new Pair{ Key = p.Key, Value = textCount(p.Key.ToString()).ToString() });

                        Func<Pair, string> textData = delegate (Pair pair)
                        {
                            int countText = 0;
                            countText = totalWordArray.Where(p => p.ToString().Equals(pair.Key)).ToArray().Length;
                            return pair.Key + "-" + countText;
                        };

                        uniqueWOrdsList.ToList().ForEach(p =>
                        {
                            lstFinalResults.Items.Add(textData(p));
                        });

                       



                        //for (int i = 0; i < (distinctWordsArray.Length); i++)
                        //{
                        //    strSingleWord = distinctWordsArray[i];

                        //    if (strSingleWord != "")
                        //    {
                        //        RegexObj = new Regex(strSingleWord);
                        //        SingleWordSearchCount = RegexObj.Matches(strDocumentText).Count;

                        //        if (SingleWordSearchCount > 0)
                        //            lstFinalResults.Items.Add(strSingleWord + " - " + SingleWordSearchCount);
                        //    }
                        //}
                    }
                    catch (ArgumentException ex)
                    {
                        Console.Write(ex.Message);
                        
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

                        MessageBox.Show("File: " + strFilePath + " is completed." , "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                MessageBox.Show("Done. See the 'Final Results' tab!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }
        public class Pair
        {
            public string Key { get; set; }
            public string Value { get; set; }
            public int ID { get; set; }
        }
        public static string[] ExtractAllTextFromPdf(string inputFile)
        {
            //Sanity checks
            if (string.IsNullOrEmpty(inputFile))
                throw new ArgumentNullException("inputFile");
            if (!System.IO.File.Exists(inputFile))
                throw new System.IO.FileNotFoundException("Cannot find inputFile", inputFile);

            //Create a stream reader (not necessary but I like to control locks and permissions)
            using (FileStream SR = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                //Create a reader to read the PDF
                iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(SR);

                //Create a buffer to store text
                var Buf = new  StringBuilder();

                //Use the PdfTextExtractor to get all of the text on a page-by-page basis
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    Buf.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }

                return Buf.ToString().Split(' ');
            }
        }

        public static string[] ExtractAllTextWordsFromText(string inputFile)
        {
            string[] lineWords= { };
            using (var mappedFile1 = MemoryMappedFile.CreateFromFile(inputFile))
            {
                using (Stream mmStream = mappedFile1.CreateViewStream())
                {
                    using (StreamReader sr = new StreamReader(mmStream, ASCIIEncoding.ASCII))
                    {
                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();
                            lineWords = line.Split(' ');
                           
                        }
                    }
                }
            }
            return lineWords;
        }

        public static int GetWordCountFromString(string text)
        {
            //Sanity check
            if (string.IsNullOrEmpty(text))
                return 0;

            //Count the words
            return System.Text.RegularExpressions.Regex.Matches(text, "\\S+").Count;
        }
    }

    }

