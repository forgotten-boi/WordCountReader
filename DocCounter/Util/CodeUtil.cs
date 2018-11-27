using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Office.Interop.Word;

using Application = Microsoft.Office.Interop.Word.Application;
using iTextSharp.text.pdf.parser;
using System.IO.MemoryMappedFiles;

namespace DocCounter.Util
{
    public static class CodeUtil
    {
        //string strDocumentText;
        //string strUniqueWords;
        //string strSingleWord = "";
        //long lngTotalWordsCount = 0;
        //long lngUniqueWordsCount = 0;
        //List<string> lstAllWords { get; set; }
        //List<string> lstUniqueWords { get; set; }
        //List<string> lstFinalResults { get; set; }
        //string lblAllWord = string.Empty;
        //string lblUniqWord = string.Empty;
        ////string strFilePath;
        ////long i;
        //Application fileApp;
        //Regex RegexObj;
        //int SingleWordSearchCount;
        //public void WordCounter(List<string> fileNames)
        //{
        //    foreach (String strFilePath in fileNames)
        //    {


        //        try
        //        {
        //            // First reset controls


                  

        //            long lngSystemWordCount = 0;

        //            // Read all the words into a string
        //            string strDocumentText = "";


        //            if (System.IO.Path.GetExtension(strFilePath).Equals(".pdf", StringComparison.CurrentCultureIgnoreCase))
        //            {
        //                //string InputFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Input.pdf");

        //                //Get all the text
        //                string[] TextArrays = ExtractAllTextFromPdf(strFilePath).ToArray();
        //                //Count the words
        //                //int I = GetWordCountFromString(T);
        //                lngSystemWordCount = TextArrays.Length;

        //                for (int i = 0; i < lngSystemWordCount; i++)
        //                {
        //                    strSingleWord = TextArrays[i];

        //                    if (!string.IsNullOrEmpty(strSingleWord) && strSingleWord.Replace(" ", "") != "")
        //                    {
        //                        lstAllWords.Add(strSingleWord);
        //                        strDocumentText = strDocumentText + " " + strSingleWord;
        //                        lngTotalWordsCount = lngTotalWordsCount + 1;
        //                    }
        //                }

        //            }
        //            if (System.IO.Path.GetExtension(strFilePath).Equals(".txt", StringComparison.CurrentCultureIgnoreCase) || System.IO.Path.GetExtension(strFilePath).Equals(".srt", StringComparison.CurrentCultureIgnoreCase))
        //            {
        //                string[] TextArrays = ExtractAllTextWordsFromText(strFilePath);
        //                //Count the words
        //                //int I = GetWordCountFromString(T);
        //                lngSystemWordCount = TextArrays.Length;

        //                for (int i = 0; i < lngSystemWordCount; i++)
        //                {
        //                    strSingleWord = TextArrays[i];

        //                    if (!string.IsNullOrEmpty(strSingleWord) && strSingleWord.Replace(" ", "") != "")
        //                    {
        //                        lstAllWords.Add(strSingleWord);
        //                        strDocumentText = strDocumentText + " " + strSingleWord;
        //                        lngTotalWordsCount = lngTotalWordsCount + 1;
        //                    }
        //                }
        //            }
        //            //doc or docx or microsoft product
        //            if (System.IO.Path.GetExtension(strFilePath).Equals(".doc", StringComparison.CurrentCultureIgnoreCase) || System.IO.Path.GetExtension(strFilePath).Equals(".docx", StringComparison.CurrentCultureIgnoreCase))
        //            {

        //                // Open the chosen document  
        //                fileApp = new Application();
        //                Document doc = fileApp.Documents.Open(strFilePath);
        //                lngSystemWordCount = doc.Words.Count;

        //                //lngTotalWordsCount = 0;

        //                for (int i = 0; i < lngSystemWordCount; i++)
        //                {
        //                    strSingleWord = doc.Words[i].Text;

        //                    if (!string.IsNullOrEmpty(strSingleWord) && strSingleWord.Replace(" ", "") != "")
        //                    {
        //                        lstAllWords.Add(strSingleWord);
        //                        strDocumentText = strDocumentText + " " + strSingleWord;
        //                        lngTotalWordsCount = lngTotalWordsCount + 1;
        //                    }
        //                }

        //                // Quit the file processing application
        //                fileApp.Quit();
        //            }
        //            // Count total number of words and display them in the first tab
        //            lblAllWord = "All words (" + lngTotalWordsCount + ")";

        //            // Now count the number of unique words
        //            var distinctWordsArray = strDocumentText.Split(' ').Distinct().ToArray();

        //            strUniqueWords = "";
        //            //lngUniqueWordsCount = 0;

        //            for (int i = 0; i < (distinctWordsArray.Length); i++)
        //            {
        //                strSingleWord = distinctWordsArray[i];

        //                if (strSingleWord.Replace(" ", "") != "")
        //                {
        //                    lstUniqueWords.Add(strSingleWord);
        //                    strUniqueWords = strUniqueWords + " " + strSingleWord;
        //                    lngUniqueWordsCount = lngUniqueWordsCount + 1;
        //                }
        //            }

        //            lblUniqWord = "Unique words only (" + lngUniqueWordsCount + ")";

        //            // Now get number of occurrences of each word in the whole file
        //            for (int i = 0; i < (distinctWordsArray.Length); i++)
        //            {
        //                strSingleWord = distinctWordsArray[i];

        //                if (strSingleWord != "")
        //                {
        //                    RegexObj = new Regex(strSingleWord);
        //                    SingleWordSearchCount = RegexObj.Matches(strDocumentText).Count;

        //                    if (SingleWordSearchCount > 0)
        //                        lstFinalResults.Add(strSingleWord + " - " + SingleWordSearchCount);
        //                }
        //            }
        //        }
        //        catch (ArgumentException ex)
        //        {
        //            Console.Write(ex.Message);
        //        }

               
        //    }
        //}
        public static List<string> ExtractAllTextFromPdf(string inputFile)
        {
            //Sanity checks
            if (string.IsNullOrEmpty(inputFile))
                throw new ArgumentNullException("inputFile");
            if (!System.IO.File.Exists(inputFile))
                throw new System.IO.FileNotFoundException("Cannot find inputFile", inputFile);
            try
            {

         
            //Create a stream reader (not necessary but I like to control locks and permissions)
            using (FileStream SR = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                //Create a reader to read the PDF
                iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(SR);

                //Create a buffer to store text
                var Buf = new List<string>();

                //Use the PdfTextExtractor to get all of the text on a page-by-page basis
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    var text = PdfTextExtractor.GetTextFromPage(reader, i);
                    if(text!=null)
                        Buf.Add(text);
                }

                return Buf;
            }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static string[] ExtractAllTextWordsFromText(string inputFile)
        {
            string[] lineWords = { };
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
