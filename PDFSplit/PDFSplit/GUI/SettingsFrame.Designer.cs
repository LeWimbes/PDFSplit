namespace PDFSplit.GUI {
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
            this.sizeTable = new System.Windows.Forms.TableLayoutPanel();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.unitLabel = new System.Windows.Forms.Label();
            this.unitComboBox = new System.Windows.Forms.ComboBox();
            this.sizeNumericTextBox = new PDFSplit.GUI.NumericTextBox();
            this.safeButton = new System.Windows.Forms.Button();
            this.baseTable.SuspendLayout();
            this.sizeTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseTable
            // 
            this.baseTable.ColumnCount = 1;
            this.baseTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.baseTable.Controls.Add(this.sizeTable, 0, 0);
            this.baseTable.Controls.Add(this.safeButton, 0, 1);
            this.baseTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTable.Location = new System.Drawing.Point(0, 0);
            this.baseTable.Name = "baseTable";
            this.baseTable.RowCount = 2;
            this.baseTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.baseTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.baseTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.baseTable.Size = new System.Drawing.Size(384, 103);
            this.baseTable.TabIndex = 0;
            // 
            // sizeTable
            // 
            this.sizeTable.ColumnCount = 2;
            this.sizeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sizeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sizeTable.Controls.Add(this.sizeLabel, 0, 0);
            this.sizeTable.Controls.Add(this.unitLabel, 1, 0);
            this.sizeTable.Controls.Add(this.unitComboBox, 1, 1);
            this.sizeTable.Controls.Add(this.sizeNumericTextBox, 0, 1);
            this.sizeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sizeTable.Location = new System.Drawing.Point(3, 3);
            this.sizeTable.Name = "sizeTable";
            this.sizeTable.RowCount = 2;
            this.sizeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.25253F));
            this.sizeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.74747F));
            this.sizeTable.Size = new System.Drawing.Size(378, 61);
            this.sizeTable.TabIndex = 0;
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
            // safeButton
            // 
            this.safeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.safeButton.Location = new System.Drawing.Point(306, 77);
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
            this.ClientSize = new System.Drawing.Size(384, 103);
            this.Controls.Add(this.baseTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsFrame";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Einstellungen";
            this.TopMost = true;
            this.baseTable.ResumeLayout(false);
            this.sizeTable.ResumeLayout(false);
            this.sizeTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel baseTable;
        private System.Windows.Forms.TableLayoutPanel sizeTable;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Label unitLabel;
        protected System.Windows.Forms.ComboBox unitComboBox;
        protected NumericTextBox sizeNumericTextBox;
        private System.Windows.Forms.Button safeButton;
    }
}