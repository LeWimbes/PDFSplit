namespace PDFSplitForPDF24 {
    partial class SettingsFrame {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.baseTable = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.unitLabel = new System.Windows.Forms.Label();
            this.unitComboBox = new System.Windows.Forms.ComboBox();
            this.sizeNumericTextBox = new PDFSplitForPDF24.NumericTextBox();
            this.cacheTable = new System.Windows.Forms.TableLayoutPanel();
            this.cacheLabel = new System.Windows.Forms.Label();
            this.cacheInfoLabel = new System.Windows.Forms.Label();
            this.cacheTextTable = new System.Windows.Forms.TableLayoutPanel();
            this.cacheTextBox = new System.Windows.Forms.TextBox();
            this.cacheCacheTextBox = new System.Windows.Forms.TextBox();
            this.safeButton = new System.Windows.Forms.Button();
            this.baseTable.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.cacheTable.SuspendLayout();
            this.cacheTextTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseTable
            // 
            this.baseTable.ColumnCount = 1;
            this.baseTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.baseTable.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.baseTable.Controls.Add(this.cacheTable, 0, 1);
            this.baseTable.Controls.Add(this.safeButton, 0, 2);
            this.baseTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTable.Location = new System.Drawing.Point(0, 0);
            this.baseTable.Name = "baseTable";
            this.baseTable.RowCount = 3;
            this.baseTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.28571F));
            this.baseTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.71429F));
            this.baseTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.baseTable.Size = new System.Drawing.Size(384, 211);
            this.baseTable.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.sizeLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.unitLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.unitComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.sizeNumericTextBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.25253F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.74747F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(378, 61);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sizeLabel.Location = new System.Drawing.Point(3, 0);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(183, 15);
            this.sizeLabel.TabIndex = 0;
            this.sizeLabel.Text = "Geben Sie eine Ganzzahl ein";
            // 
            // unitLabel
            // 
            this.unitLabel.AutoSize = true;
            this.unitLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitLabel.Location = new System.Drawing.Point(192, 0);
            this.unitLabel.Name = "unitLabel";
            this.unitLabel.Size = new System.Drawing.Size(183, 15);
            this.unitLabel.TabIndex = 1;
            this.unitLabel.Text = "Wählen Sie die Einheit";
            // 
            // unitComboBox
            // 
            this.unitComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitComboBox.FormattingEnabled = true;
            this.unitComboBox.Location = new System.Drawing.Point(192, 18);
            this.unitComboBox.Name = "unitComboBox";
            this.unitComboBox.Size = new System.Drawing.Size(183, 21);
            this.unitComboBox.TabIndex = 2;
            // 
            // sizeNumericTextBox
            // 
            this.sizeNumericTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sizeNumericTextBox.Location = new System.Drawing.Point(3, 18);
            this.sizeNumericTextBox.Name = "sizeNumericTextBox";
            this.sizeNumericTextBox.Size = new System.Drawing.Size(183, 20);
            this.sizeNumericTextBox.TabIndex = 3;
            // 
            // cacheTable
            // 
            this.cacheTable.ColumnCount = 1;
            this.cacheTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.cacheTable.Controls.Add(this.cacheLabel, 0, 0);
            this.cacheTable.Controls.Add(this.cacheInfoLabel, 0, 1);
            this.cacheTable.Controls.Add(this.cacheTextTable, 0, 2);
            this.cacheTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cacheTable.Location = new System.Drawing.Point(3, 70);
            this.cacheTable.Name = "cacheTable";
            this.cacheTable.RowCount = 3;
            this.cacheTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.cacheTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.cacheTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.cacheTable.Size = new System.Drawing.Size(378, 102);
            this.cacheTable.TabIndex = 1;
            // 
            // cacheLabel
            // 
            this.cacheLabel.AutoSize = true;
            this.cacheLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cacheLabel.Location = new System.Drawing.Point(3, 0);
            this.cacheLabel.Name = "cacheLabel";
            this.cacheLabel.Size = new System.Drawing.Size(372, 28);
            this.cacheLabel.TabIndex = 0;
            this.cacheLabel.Text = "Wählen Sie den Ort für Cache";
            // 
            // cacheInfoLabel
            // 
            this.cacheInfoLabel.AutoSize = true;
            this.cacheInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cacheInfoLabel.Location = new System.Drawing.Point(3, 28);
            this.cacheInfoLabel.Name = "cacheInfoLabel";
            this.cacheInfoLabel.Size = new System.Drawing.Size(372, 28);
            this.cacheInfoLabel.TabIndex = 2;
            this.cacheInfoLabel.Text = "%work% = Ordner der PDF; %install% = Ordner von diesem Programm";
            // 
            // cacheTextTable
            // 
            this.cacheTextTable.ColumnCount = 2;
            this.cacheTextTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.35484F));
            this.cacheTextTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.64516F));
            this.cacheTextTable.Controls.Add(this.cacheTextBox, 0, 0);
            this.cacheTextTable.Controls.Add(this.cacheCacheTextBox, 1, 0);
            this.cacheTextTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cacheTextTable.Location = new System.Drawing.Point(3, 59);
            this.cacheTextTable.Name = "cacheTextTable";
            this.cacheTextTable.RowCount = 1;
            this.cacheTextTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.cacheTextTable.Size = new System.Drawing.Size(372, 40);
            this.cacheTextTable.TabIndex = 3;
            // 
            // cacheTextBox
            // 
            this.cacheTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cacheTextBox.Location = new System.Drawing.Point(3, 3);
            this.cacheTextBox.Name = "cacheTextBox";
            this.cacheTextBox.Size = new System.Drawing.Size(252, 20);
            this.cacheTextBox.TabIndex = 2;
            // 
            // cacheCacheTextBox
            // 
            this.cacheCacheTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cacheCacheTextBox.Enabled = false;
            this.cacheCacheTextBox.Location = new System.Drawing.Point(261, 3);
            this.cacheCacheTextBox.Name = "cacheCacheTextBox";
            this.cacheCacheTextBox.Size = new System.Drawing.Size(108, 20);
            this.cacheCacheTextBox.TabIndex = 3;
            this.cacheCacheTextBox.Text = "\\Cache";
            // 
            // safeButton
            // 
            this.safeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.safeButton.Location = new System.Drawing.Point(306, 185);
            this.safeButton.Name = "safeButton";
            this.safeButton.Size = new System.Drawing.Size(75, 23);
            this.safeButton.TabIndex = 2;
            this.safeButton.Text = "Speichern";
            this.safeButton.UseVisualStyleBackColor = true;
            // 
            // SettingsFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.baseTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsFrame";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Einstellungen";
            this.TopMost = true;
            this.baseTable.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.cacheTable.ResumeLayout(false);
            this.cacheTable.PerformLayout();
            this.cacheTextTable.ResumeLayout(false);
            this.cacheTextTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel baseTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Label unitLabel;
        protected System.Windows.Forms.ComboBox unitComboBox;
        protected NumericTextBox sizeNumericTextBox;
        private System.Windows.Forms.TableLayoutPanel cacheTable;
        private System.Windows.Forms.Label cacheLabel;
        private System.Windows.Forms.Label cacheInfoLabel;
        private System.Windows.Forms.TableLayoutPanel cacheTextTable;
        protected System.Windows.Forms.TextBox cacheTextBox;
        private System.Windows.Forms.TextBox cacheCacheTextBox;
        private System.Windows.Forms.Button safeButton;
    }
}