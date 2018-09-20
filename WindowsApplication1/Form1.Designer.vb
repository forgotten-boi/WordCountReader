<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.btnCountWords = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lstAllWords = New System.Windows.Forms.ListBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lstUniqueWords = New System.Windows.Forms.ListBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lstFinalResults = New System.Windows.Forms.ListBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(25, 37)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(664, 20)
        Me.txtFilePath.TabIndex = 0
        '
        'btnCountWords
        '
        Me.btnCountWords.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCountWords.Location = New System.Drawing.Point(695, 37)
        Me.btnCountWords.Name = "btnCountWords"
        Me.btnCountWords.Size = New System.Drawing.Size(131, 23)
        Me.btnCountWords.TabIndex = 1
        Me.btnCountWords.Text = "Count unique words"
        Me.btnCountWords.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "File path:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(25, 63)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(801, 345)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lstAllWords)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(793, 319)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "All words"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lstAllWords
        '
        Me.lstAllWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstAllWords.FormattingEnabled = True
        Me.lstAllWords.Location = New System.Drawing.Point(6, 9)
        Me.lstAllWords.Name = "lstAllWords"
        Me.lstAllWords.ScrollAlwaysVisible = True
        Me.lstAllWords.Size = New System.Drawing.Size(781, 301)
        Me.lstAllWords.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lstUniqueWords)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(793, 319)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Unique words only"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lstUniqueWords
        '
        Me.lstUniqueWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstUniqueWords.FormattingEnabled = True
        Me.lstUniqueWords.Location = New System.Drawing.Point(6, 9)
        Me.lstUniqueWords.Name = "lstUniqueWords"
        Me.lstUniqueWords.ScrollAlwaysVisible = True
        Me.lstUniqueWords.Size = New System.Drawing.Size(781, 301)
        Me.lstUniqueWords.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lstFinalResults)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(793, 319)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Final results"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lstFinalResults
        '
        Me.lstFinalResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstFinalResults.FormattingEnabled = True
        Me.lstFinalResults.Location = New System.Drawing.Point(6, 9)
        Me.lstFinalResults.Name = "lstFinalResults"
        Me.lstFinalResults.ScrollAlwaysVisible = True
        Me.lstFinalResults.Size = New System.Drawing.Size(781, 301)
        Me.lstFinalResults.TabIndex = 2
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(25, 413)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(797, 16)
        Me.ProgressBar1.TabIndex = 5
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 441)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCountWords)
        Me.Controls.Add(Me.txtFilePath)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Count unique words in a text document"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents btnCountWords As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lstAllWords As System.Windows.Forms.ListBox
    Friend WithEvents lstUniqueWords As System.Windows.Forms.ListBox
    Friend WithEvents lstFinalResults As System.Windows.Forms.ListBox

End Class
