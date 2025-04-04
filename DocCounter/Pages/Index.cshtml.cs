﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;

using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Office.Interop.Word;

using Application = Microsoft.Office.Interop.Word.Application;
using iTextSharp.text.pdf.parser;
using System.IO.MemoryMappedFiles;
using DocCounter.Util;
using System;
using System.Linq;

namespace DocCounter.Pages
{
    public class IndexModel : PageModel
    {
        private IHostingEnvironment _hostingEnvironment;

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


        List<string> lstAllWords = new List<string>();
        List<string> lstUniqueWords = new List<string>();
        List<string> lstFinalResults = new List<string>();
        string lblAllWord = string.Empty;
        string lblUniqWord = string.Empty;


        public IndexModel(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public void OnGet()
        {
        }
        [RequestSizeLimit(100_000_000)]
        public ActionResult OnPostUpload(List<IFormFile> files)
        {
            if(files != null && files.Count > 0)
            {
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = System.IO.Path.Combine(webRootPath, folderName);
                if(!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                foreach (IFormFile item in files)
                {
                    if (item.Length > 0)
                    {
                        string fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                        string fullPath = System.IO.Path.Combine(newPath, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            item.CopyTo(stream);
                        }

                        WordCounter(fullPath);
                    }
                }
                lstAllWords.ForEach(p => p = p.Replace(" ", ""));
                lstFinalResults.ForEach(p => p = p.Replace(" ", ""));
                lstUniqueWords.ForEach(p => p = p.Replace(" ", ""));
               

                var wordCount = new WordList()
                {
                    AllWordsList = lstAllWords.FindAll(p=> !p.Equals(" ") && !p.Equals("")),
                    FinalResultsList = lstFinalResults.FindAll(p => !p.Equals(" ") && !p.Equals("")),
                    UniqueWordsList = lstUniqueWords.FindAll(p => !p.Equals(" ") && !p.Equals("")),
                    IsSuccess = true,
                    Message = "Success"
                };
                //return this.Content("Success" + "lstAllWords:" + lstAllWords.Count + @"\r\n");
                return new JsonResult(wordCount);
            }
            return new JsonResult(new WordList
            {
                IsSuccess = false,
                Message = "Failed"
            });
        }

        public void WordCounter(string strFilePath)
        {
            
                try
                {
                    // First reset controls
                    
                    long lngSystemWordCount = 0;

                    // Read all the words into a string
                    string strDocumentText = "";


                    if (System.IO.Path.GetExtension(strFilePath).Equals(".pdf", StringComparison.CurrentCultureIgnoreCase))
                    {
                        //string InputFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Input.pdf");

                        //Get all the text
                        string[] TextArrays = CodeUtil.ExtractAllTextFromPdf(strFilePath).ToArray();
                        //Count the words
                        //int I = GetWordCountFromString(T);
                        lngSystemWordCount = TextArrays.Length;

                        for (int i = 0; i < lngSystemWordCount; i++)
                        {
                            strSingleWord = TextArrays[i].Replace(@"\t"," ")
                                                .Replace(@"\n"," ").Replace(@"\s"," ").Replace(@"\r"," ");

                            if (!string.IsNullOrEmpty(strSingleWord) && strSingleWord.Replace(" ", "") != "")
                            {
                                lstAllWords.AddRange(strSingleWord.Replace("\n","").Split(" ").ToList());
                                strDocumentText = strDocumentText + " " + strSingleWord;
                                lngTotalWordsCount = lngTotalWordsCount + 1;
                            }
                        }

                    }
                    if (System.IO.Path.GetExtension(strFilePath).Equals(".txt", StringComparison.CurrentCultureIgnoreCase) || System.IO.Path.GetExtension(strFilePath).Equals(".srt", StringComparison.CurrentCultureIgnoreCase))
                    {
                        string[] TextArrays = CodeUtil.ExtractAllTextWordsFromText(strFilePath);
                        //Count the words
                        //int I = GetWordCountFromString(T);
                        lngSystemWordCount = TextArrays.Length;

                        for (int i = 0; i < lngSystemWordCount; i++)
                        {
                          
                            strSingleWord = TextArrays[i].Replace(@"\t", " ")
                                                   .Replace(@"\n", " ").Replace(@"\s", " ").Replace(@"\r", " ");

                            if (!string.IsNullOrEmpty(strSingleWord) && strSingleWord.Replace(" ", "") != "")
                            {
                                lstAllWords.AddRange(strSingleWord.Replace("\n", "").Split(" ").ToList());
                                strDocumentText = strDocumentText + " " + strSingleWord;
                                lngTotalWordsCount = lngTotalWordsCount + 1;
                            }
                        }
                    }
                    //doc or docx or microsoft product
                    if (System.IO.Path.GetExtension(strFilePath).Equals(".doc", StringComparison.CurrentCultureIgnoreCase) || System.IO.Path.GetExtension(strFilePath).Equals(".docx", StringComparison.CurrentCultureIgnoreCase))
                    {

                        // Open the chosen document  
                        fileApp = new Application();
                        Document doc = fileApp.Documents.Open(strFilePath);
                        lngSystemWordCount = doc.Words.Count;

                        //lngTotalWordsCount = 0;

                        for (int i = 0; i < lngSystemWordCount; i++)
                        {
                            strSingleWord = doc.Words[i+1].Text.Replace(@"\t", " ")
                                               .Replace(@"\n", " ").Replace(@"\s", " ").Replace(@"\r", " ");


                        if (!string.IsNullOrEmpty(strSingleWord) && strSingleWord.Replace(" ", "") != "")
                            {
                                lstAllWords.AddRange(strSingleWord.Replace("\n", "").Split(" ").ToList());
                                strDocumentText = strDocumentText + " " + strSingleWord;
                                lngTotalWordsCount = lngTotalWordsCount + 1;
                            }
                        }

                        // Quit the file processing application
                        fileApp.Quit();
                    }
                    // Count total number of words and display them in the first tab
                    lblAllWord = "All words (" + lngTotalWordsCount + ")";

                    // Now count the number of unique words
                    var distinctWordsArray = strDocumentText.Split(' ').Distinct().ToArray();

                    strUniqueWords = "";
                    //lngUniqueWordsCount = 0;

                    for (int i = 0; i < (distinctWordsArray.Length); i++)
                    {
                        strSingleWord = distinctWordsArray[i];

                        if (strSingleWord.Replace(" ", "") != "")
                        {
                            lstUniqueWords.AddRange(strSingleWord.Replace("\n", "").Split(" ").ToList()); 
                            strUniqueWords = strUniqueWords + " " + strSingleWord;
                            lngUniqueWordsCount = lngUniqueWordsCount + 1;
                        }
                    }

                    lblUniqWord = "Unique words only (" + lngUniqueWordsCount + ")";

                    // Now get number of occurrences of each word in the whole file
                    for (int i = 0; i < (distinctWordsArray.Length); i++)
                    {
                        strSingleWord = distinctWordsArray[i];

                        if (strSingleWord != "")
                        {
                            RegexObj = new Regex(strSingleWord);
                            SingleWordSearchCount = RegexObj.Matches(strDocumentText).Count;

                            if (SingleWordSearchCount > 0)
                                lstFinalResults.Add(strSingleWord + " - " + SingleWordSearchCount);
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.Write(ex.Message);
                }


            //}
        }
    }

    public class WordList
    {
        public WordList()
        {
            this.AllWordsList = new List<string>(); 
            this.UniqueWordsList = new List<string>(); 
            this.FinalResultsList = new List<string>(); 
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<string> AllWordsList { get; set; }
        public List<string> UniqueWordsList { get; set; }
        public List<string> FinalResultsList { get; set; }
      
    }

}
