namespace PDFSplitForPDF24 {
    partial class MainFrame {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.baseTable = new System.Windows.Forms.TableLayoutPanel();
            this.convertTable = new System.Windows.Forms.TableLayoutPanel();
            this.selectLabel = new System.Windows.Forms.Label();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.splitProgressBar = new System.Windows.Forms.ProgressBar();
            this.settingsButton = new System.Windows.Forms.Button();
            this.baseTable.SuspendLayout();
            this.convertTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseTable
            // 
            this.baseTable.ColumnCount = 1;
            this.baseTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.baseTable.Controls.Add(this.convertTable, 0, 0);
            this.baseTable.Controls.Add(this.settingsButton, 0, 1);
            this.baseTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTable.Location = new System.Drawing.Point(0, 0);
            this.baseTable.Name = "baseTable";
            this.baseTable.RowCount = 2;
            this.baseTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.baseTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.baseTable.Size = new System.Drawing.Size(384, 161);
            this.baseTable.TabIndex = 0;
            // 
            // convertTable
            // 
            this.convertTable.ColumnCount = 2;
            this.convertTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.convertTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.convertTable.Controls.Add(this.selectLabel, 0, 0);
            this.convertTable.Controls.Add(this.filePathTextBox, 0, 1);
            this.convertTable.Controls.Add(this.selectFileButton, 1, 1);
            this.convertTable.Controls.Add(this.startButton, 0, 2);
            this.convertTable.Controls.Add(this.splitProgressBar, 0, 3);
            this.convertTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.convertTable.Location = new System.Drawing.Point(3, 3);
            this.convertTable.Name = "convertTable";
            this.convertTable.RowCount = 4;
            this.convertTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.convertTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.convertTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.convertTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.convertTable.Size = new System.Drawing.Size(378, 125);
            this.convertTable.TabIndex = 0;
            // 
            // selectLabel
            // 
            this.selectLabel.AutoSize = true;
            this.selectLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectLabel.Location = new System.Drawing.Point(3, 0);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(315, 25);
            this.selectLabel.TabIndex = 0;
            this.selectLabel.Text = "Wählen Sie eine PDF-Datei aus:";
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filePathTextBox.Location = new System.Drawing.Point(3, 28);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(315, 20);
            this.filePathTextBox.TabIndex = 1;
            // 
            // selectFileButton
            // 
            this.selectFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectFileButton.Location = new System.Drawing.Point(324, 28);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(51, 21);
            this.selectFileButton.TabIndex = 2;
            this.selectFileButton.Text = "...";
            this.selectFileButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startButton.Location = new System.Drawing.Point(3, 55);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(315, 24);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start splitting";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // splitProgressBar
            // 
            this.splitProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitProgressBar.Location = new System.Drawing.Point(3, 85);
            this.splitProgressBar.Name = "splitProgressBar";
            this.splitProgressBar.Size = new System.Drawing.Size(315, 37);
            this.splitProgressBar.TabIndex = 4;
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.Location = new System.Drawing.Point(281, 135);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(100, 23);
            this.settingsButton.TabIndex = 1;
            this.settingsButton.Text = "Einstellungen";
            this.settingsButton.UseVisualStyleBackColor = true;
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.baseTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFrame";
            this.ShowIcon = false;
            this.Text = "PDF Split for PDF24";
            this.baseTable.ResumeLayout(false);
            this.convertTable.ResumeLayout(false);
            this.convertTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel baseTable;
        private System.Windows.Forms.TableLayoutPanel convertTable;
        private System.Windows.Forms.Label selectLabel;
        protected System.Windows.Forms.ProgressBar splitProgressBar;
        protected System.Windows.Forms.Button selectFileButton;
        protected System.Windows.Forms.Button startButton;
        protected System.Windows.Forms.Button settingsButton;
        protected System.Windows.Forms.TextBox filePathTextBox;
    }
}

