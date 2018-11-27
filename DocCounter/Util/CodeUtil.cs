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
