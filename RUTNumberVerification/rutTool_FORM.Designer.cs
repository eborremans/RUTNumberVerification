namespace RUTNumberVerification
{
    partial class rutTool_FORM
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
            this.rutNumber_TXT = new System.Windows.Forms.TextBox();
            this.isValidRUT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.generateRUT_BTN = new System.Windows.Forms.Button();
            this.test_BTN = new System.Windows.Forms.Button();
            this.nrOfTests_UPDWN = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nrOfTests_UPDWN)).BeginInit();
            this.SuspendLayout();
            // 
            // rutNumber_TXT
            // 
            this.rutNumber_TXT.Font = new System.Drawing.Font("Microsoft Tai Le", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rutNumber_TXT.Location = new System.Drawing.Point(14, 136);
            this.rutNumber_TXT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rutNumber_TXT.Name = "rutNumber_TXT";
            this.rutNumber_TXT.Size = new System.Drawing.Size(216, 49);
            this.rutNumber_TXT.TabIndex = 0;
            this.rutNumber_TXT.Text = "13460882-k";
            this.rutNumber_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rutNumber_TXT.TextChanged += new System.EventHandler(this.rutNumber_TXT_TextChanged);
            // 
            // isValidRUT
            // 
            this.isValidRUT.AutoSize = true;
            this.isValidRUT.Font = new System.Drawing.Font("Microsoft Tai Le", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isValidRUT.Location = new System.Drawing.Point(249, 140);
            this.isValidRUT.Name = "isValidRUT";
            this.isValidRUT.Size = new System.Drawing.Size(228, 42);
            this.isValidRUT.TabIndex = 1;
            this.isValidRUT.Text = "<not verified>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(463, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter RUT (inclusing verification character)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(356, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "<7 or 8 digits>-<1 digit or \'K\'> :";
            // 
            // generateRUT_BTN
            // 
            this.generateRUT_BTN.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateRUT_BTN.Location = new System.Drawing.Point(569, 131);
            this.generateRUT_BTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.generateRUT_BTN.Name = "generateRUT_BTN";
            this.generateRUT_BTN.Size = new System.Drawing.Size(257, 54);
            this.generateRUT_BTN.TabIndex = 4;
            this.generateRUT_BTN.Text = "Generate RUT";
            this.generateRUT_BTN.UseVisualStyleBackColor = true;
            this.generateRUT_BTN.Click += new System.EventHandler(this.generateRUT_BTN_Click);
            // 
            // test_BTN
            // 
            this.test_BTN.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.test_BTN.Location = new System.Drawing.Point(569, 51);
            this.test_BTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.test_BTN.Name = "test_BTN";
            this.test_BTN.Size = new System.Drawing.Size(87, 54);
            this.test_BTN.TabIndex = 5;
            this.test_BTN.Text = "Test";
            this.test_BTN.UseVisualStyleBackColor = true;
            this.test_BTN.Click += new System.EventHandler(this.test_BTN_Click);
            // 
            // nrOfTests_UPDWN
            // 
            this.nrOfTests_UPDWN.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nrOfTests_UPDWN.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nrOfTests_UPDWN.Location = new System.Drawing.Point(662, 54);
            this.nrOfTests_UPDWN.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nrOfTests_UPDWN.Name = "nrOfTests_UPDWN";
            this.nrOfTests_UPDWN.Size = new System.Drawing.Size(164, 48);
            this.nrOfTests_UPDWN.TabIndex = 7;
            this.nrOfTests_UPDWN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nrOfTests_UPDWN.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // rutTool_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 204);
            this.Controls.Add(this.nrOfTests_UPDWN);
            this.Controls.Add(this.test_BTN);
            this.Controls.Add(this.generateRUT_BTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.isValidRUT);
            this.Controls.Add(this.rutNumber_TXT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "rutTool_FORM";
            this.Text = "RUT Tool";
            ((System.ComponentModel.ISupportInitialize)(this.nrOfTests_UPDWN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rutNumber_TXT;
        private System.Windows.Forms.Label isValidRUT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button generateRUT_BTN;
        private System.Windows.Forms.Button test_BTN;
        private System.Windows.Forms.NumericUpDown nrOfTests_UPDWN;
    }
}

