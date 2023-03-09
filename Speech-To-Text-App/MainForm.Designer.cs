namespace SpeechToTextApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.run_button = new System.Windows.Forms.Button();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fileLocationText = new System.Windows.Forms.TextBox();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.regionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // run_button
            // 
            this.run_button.Location = new System.Drawing.Point(479, 196);
            this.run_button.Name = "run_button";
            this.run_button.Size = new System.Drawing.Size(279, 86);
            this.run_button.TabIndex = 0;
            this.run_button.Text = "Run";
            this.run_button.UseVisualStyleBackColor = true;
            this.run_button.Click += new System.EventHandler(this.run_button_Click);
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(107, 196);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(305, 86);
            this.selectFileButton.TabIndex = 1;
            this.selectFileButton.Text = "Select File";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "File Directory:";
            // 
            // fileLocationText
            // 
            this.fileLocationText.Font = new System.Drawing.Font("Segoe UI", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileLocationText.Location = new System.Drawing.Point(244, 124);
            this.fileLocationText.Name = "fileLocationText";
            this.fileLocationText.ReadOnly = true;
            this.fileLocationText.Size = new System.Drawing.Size(632, 51);
            this.fileLocationText.TabIndex = 3;
            this.fileLocationText.Text = "C:\\";
            // 
            // keyTextBox
            // 
            this.keyTextBox.Font = new System.Drawing.Font("Segoe UI", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.keyTextBox.Location = new System.Drawing.Point(32, 58);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.PasswordChar = '*';
            this.keyTextBox.Size = new System.Drawing.Size(643, 51);
            this.keyTextBox.TabIndex = 4;
            // 
            // regionTextBox
            // 
            this.regionTextBox.Font = new System.Drawing.Font("Segoe UI", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.regionTextBox.Location = new System.Drawing.Point(715, 58);
            this.regionTextBox.Name = "regionTextBox";
            this.regionTextBox.Size = new System.Drawing.Size(175, 51);
            this.regionTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(699, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 46);
            this.label2.TabIndex = 6;
            this.label2.Text = "Region";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(22, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(435, 46);
            this.label3.TabIndex = 7;
            this.label3.Text = "Azure Cognitive Service Key";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 307);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.regionTextBox);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.fileLocationText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.run_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Speech-To-Text Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button run_button;
        private Button selectFileButton;
        private Label label1;
        private TextBox fileLocationText;
        private TextBox keyTextBox;
        private TextBox regionTextBox;
        private Label label2;
        private Label label3;
    }
}