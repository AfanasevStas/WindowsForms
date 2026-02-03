namespace Clock
{
    partial class FontDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontDialog));
            this.comboBoxFonts = new System.Windows.Forms.ComboBox();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.labelExemple = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCansel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxFonts
            // 
            this.comboBoxFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFonts.FormattingEnabled = true;
            this.comboBoxFonts.Location = new System.Drawing.Point(13, 27);
            this.comboBoxFonts.Name = "comboBoxFonts";
            this.comboBoxFonts.Size = new System.Drawing.Size(340, 21);
            this.comboBoxFonts.TabIndex = 0;
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.Location = new System.Drawing.Point(371, 27);
            this.numericUpDownFontSize.Maximum = new decimal(new int[] {
            58,
            0,
            0,
            0});
            this.numericUpDownFontSize.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownFontSize.TabIndex = 1;
            this.numericUpDownFontSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // labelExemple
            // 
            this.labelExemple.AutoSize = true;
            this.labelExemple.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelExemple.Location = new System.Drawing.Point(13, 66);
            this.labelExemple.Name = "labelExemple";
            this.labelExemple.Size = new System.Drawing.Size(191, 51);
            this.labelExemple.TabIndex = 2;
            this.labelExemple.Text = "Exemple";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(262, 155);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCansel
            // 
            this.buttonCansel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCansel.Location = new System.Drawing.Point(350, 155);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(75, 23);
            this.buttonCansel.TabIndex = 4;
            this.buttonCansel.Text = "Cansel";
            this.buttonCansel.UseVisualStyleBackColor = true;
            // 
            // FontDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 182);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelExemple);
            this.Controls.Add(this.numericUpDownFontSize);
            this.Controls.Add(this.comboBoxFonts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FontDialog";
            this.ShowInTaskbar = false;
            this.Text = "FontDialog";
            this.Load += new System.EventHandler(this.FontDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFonts;
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.Label labelExemple;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCansel;
    }
}