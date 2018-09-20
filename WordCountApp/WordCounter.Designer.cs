namespace WordCountApp
{
    partial class WordCounter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.lstAllWords = new System.Windows.Forms.ListBox();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.lstUniqueWords = new System.Windows.Forms.ListBox();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.lstFinalResults = new System.Windows.Forms.ListBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnCountWords = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.TabPage3);
            this.TabControl1.Location = new System.Drawing.Point(1, 69);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(801, 345);
            this.TabControl1.TabIndex = 9;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.lstAllWords);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(793, 319);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "All words";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // lstAllWords
            // 
            this.lstAllWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstAllWords.FormattingEnabled = true;
            this.lstAllWords.Location = new System.Drawing.Point(6, 9);
            this.lstAllWords.Name = "lstAllWords";
            this.lstAllWords.ScrollAlwaysVisible = true;
            this.lstAllWords.Size = new System.Drawing.Size(781, 301);
            this.lstAllWords.TabIndex = 0;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.lstUniqueWords);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(793, 319);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Unique words only";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // lstUniqueWords
            // 
            this.lstUniqueWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstUniqueWords.FormattingEnabled = true;
            this.lstUniqueWords.Location = new System.Drawing.Point(6, 9);
            this.lstUniqueWords.Name = "lstUniqueWords";
            this.lstUniqueWords.ScrollAlwaysVisible = true;
            this.lstUniqueWords.Size = new System.Drawing.Size(781, 301);
            this.lstUniqueWords.TabIndex = 1;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.lstFinalResults);
            this.TabPage3.Location = new System.Drawing.Point(4, 22);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Size = new System.Drawing.Size(793, 319);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "Final results";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // lstFinalResults
            // 
            this.lstFinalResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstFinalResults.FormattingEnabled = true;
            this.lstFinalResults.Location = new System.Drawing.Point(6, 9);
            this.lstFinalResults.Name = "lstFinalResults";
            this.lstFinalResults.ScrollAlwaysVisible = true;
            this.lstFinalResults.Size = new System.Drawing.Size(781, 301);
            this.lstFinalResults.TabIndex = 2;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(-2, 27);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(50, 13);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "File path:";
            // 
            // btnCountWords
            // 
            this.btnCountWords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCountWords.Location = new System.Drawing.Point(671, 43);
            this.btnCountWords.Name = "btnCountWords";
            this.btnCountWords.Size = new System.Drawing.Size(131, 23);
            this.btnCountWords.TabIndex = 7;
            this.btnCountWords.Text = "Count unique words";
            this.btnCountWords.UseVisualStyleBackColor = true;
            this.btnCountWords.Click += new System.EventHandler(this.btnCountWords_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(1, 43);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(664, 20);
            this.txtFilePath.TabIndex = 6;
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(1, 419);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(797, 16);
            this.ProgressBar1.TabIndex = 10;
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            this.OpenFileDialog1.Multiselect = true;
            // 
            // WordCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnCountWords);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.ProgressBar1);
            this.Name = "WordCounter";
            this.Text = "Form1";
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.ListBox lstAllWords;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.ListBox lstUniqueWords;
        internal System.Windows.Forms.TabPage TabPage3;
        internal System.Windows.Forms.ListBox lstFinalResults;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnCountWords;
        internal System.Windows.Forms.TextBox txtFilePath;
        internal System.Windows.Forms.ProgressBar ProgressBar1;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
    }
}

