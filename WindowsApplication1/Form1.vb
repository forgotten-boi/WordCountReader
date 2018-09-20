Option Explicit On

Imports System.Text.RegularExpressions
Imports System.IO
Imports Microsoft.Office.Interop.Word

Public Class Form1

    Private Sub btnCountWords_Click(sender As System.Object, e As System.EventArgs) Handles btnCountWords.Click
        Dim strDocumentText As String
        Dim strUniqueWords As String
        Dim strSingleWord As String = ""
        Dim lngTotalWordsCount As Long
        Dim lngUniqueWordsCount As Long
        Dim strFilePath As String
        Dim i As Long
        Dim fileApp As Application
        Dim RegexObj
        Dim SingleWordSearchCount

        Try
            'First reset controls
            TabControl1.TabPages.Item(0).Text = "All words"
            TabControl1.TabPages.Item(1).Text = "Unique words only"

            'Now check if the selected file exists
            strFilePath = ""

            If txtFilePath.Text = "" Then
                Dim result As DialogResult = OpenFileDialog1.ShowDialog()
                strFilePath = OpenFileDialog1.FileName

                If strFilePath <> "" And strFilePath <> "OpenFileDialog1" Then
                    txtFilePath.Text = strFilePath
                Else
                    MsgBox("You need to choose a file!", vbExclamation, "File Selection Error")
                    Exit Sub
                End If
            End If

            If File.Exists(strFilePath) = False Then
                MsgBox("Selected file no longer exists! Please double-check the path and try again.", vbExclamation, "File Selection Error")
                Exit Sub
            End If

            'Reset controls
            Me.Cursor = Cursors.WaitCursor
            lstAllWords.Cursor = Cursors.WaitCursor
            lstUniqueWords.Cursor = Cursors.WaitCursor
            lstFinalResults.Cursor = Cursors.WaitCursor
            btnCountWords.Enabled = False
            txtFilePath.Cursor = Cursors.WaitCursor

            'Open the chosen document  
            fileApp = New Application
            Dim doc As Document = fileApp.Documents.Open(strFilePath)
            Dim lngSystemWordCount As Long = doc.Words.Count

            'Read all the words into a string
            strDocumentText = ""
            lngTotalWordsCount = 0

            For i = 1 To lngSystemWordCount
                strSingleWord = doc.Words(i).Text

                If Replace(strSingleWord, " ", "") <> "" Then
                    lstAllWords.Items.Add(strSingleWord)
                    strDocumentText = strDocumentText & " " & strSingleWord
                    lngTotalWordsCount = lngTotalWordsCount + 1
                End If
            Next

            'Quit the file processing application
            fileApp.Quit()

            'Count total number of words and display them in the first tab
            TabControl1.TabPages.Item(0).Text = "All words (" & lngTotalWordsCount & ")"

            'Now count the number of unique words
            Dim distinctWordsArray = strDocumentText.Split(" ").Distinct().ToArray

            strUniqueWords = ""
            lngUniqueWordsCount = 0

            For i = 0 To UBound(distinctWordsArray)
                strSingleWord = distinctWordsArray(i)

                If Replace(strSingleWord, " ", "") <> "" Then
                    lstUniqueWords.Items.Add(strSingleWord)
                    strUniqueWords = strUniqueWords & " " & strSingleWord
                    lngUniqueWordsCount = lngUniqueWordsCount + 1
                End If
            Next

            TabControl1.TabPages.Item(1).Text = "Unique words only (" & lngUniqueWordsCount & ")"

            'Now get number of occurrences of each word in the whole file
            For i = 0 To UBound(distinctWordsArray)
                strSingleWord = distinctWordsArray(i)

                If strSingleWord <> "" Then
                    RegexObj = New Regex(strSingleWord)
                    SingleWordSearchCount = RegexObj.Matches(strDocumentText)

                    If SingleWordSearchCount.count > 0 Then
                        lstFinalResults.Items.Add(strSingleWord & " - " & SingleWordSearchCount.count)
                    End If
                End If
            Next

        Catch ex As ArgumentException

        Finally
            'Reset controls
            Me.Cursor = Cursors.Default
            lstAllWords.Cursor = Cursors.Default
            lstUniqueWords.Cursor = Cursors.Default
            lstFinalResults.Cursor = Cursors.Default
            btnCountWords.Enabled = True
            txtFilePath.Cursor = Cursors.WaitCursor

            'Reset memory objects
            RegexObj = Nothing
            fileApp = Nothing

            MsgBox("Done. See the 'Final Results' tab!", vbInformation, "")
        End Try

    End Sub

End Class
