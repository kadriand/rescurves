namespace Rescurves.View.Secondary
{
    partial class AddinPreferencesWindow
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.settingsBox = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.columnCellsTB = new System.Windows.Forms.TextBox();
            this.columnCellsLabel = new System.Windows.Forms.Label();
            this.settingsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsBox
            // 
            this.settingsBox.Controls.Add(this.saveButton);
            this.settingsBox.Controls.Add(this.columnCellsTB);
            this.settingsBox.Controls.Add(this.columnCellsLabel);
            this.settingsBox.Location = new System.Drawing.Point(12, 12);
            this.settingsBox.Name = "settingsBox";
            this.settingsBox.Size = new System.Drawing.Size(284, 198);
            this.settingsBox.TabIndex = 0;
            this.settingsBox.TabStop = false;
            this.settingsBox.Text = "Rescurves Settings";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(178, 169);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save and close";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // columnCellsTB
            // 
            this.columnCellsTB.Location = new System.Drawing.Point(230, 42);
            this.columnCellsTB.Name = "columnCellsTB";
            this.columnCellsTB.Size = new System.Drawing.Size(47, 20);
            this.columnCellsTB.TabIndex = 1;
            // 
            // columnCellsLabel
            // 
            this.columnCellsLabel.AutoSize = true;
            this.columnCellsLabel.Location = new System.Drawing.Point(6, 36);
            this.columnCellsLabel.Name = "columnCellsLabel";
            this.columnCellsLabel.Size = new System.Drawing.Size(218, 26);
            this.columnCellsLabel.TabIndex = 0;
            this.columnCellsLabel.Text = "Number of columns between \r\ncomposition columns (excluding temperature)";
            this.columnCellsLabel.Click += new System.EventHandler(this.columnCellsLabel_Click);
            // 
            // AddinPreferencesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 222);
            this.Controls.Add(this.settingsBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddinPreferencesWindow";
            this.ShowIcon = false;
            this.Text = "Settings";
            this.settingsBox.ResumeLayout(false);
            this.settingsBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox settingsBox;
        private System.Windows.Forms.TextBox columnCellsTB;
        private System.Windows.Forms.Label columnCellsLabel;
        private System.Windows.Forms.Button saveButton;
    }
}