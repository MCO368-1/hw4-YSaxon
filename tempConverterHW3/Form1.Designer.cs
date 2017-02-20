namespace tempConverterHW3
{
    partial class TempConverter
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
            this.degreesOutput = new System.Windows.Forms.Label();
            this.degreesInput = new System.Windows.Forms.TextBox();
            this.scaleIn = new System.Windows.Forms.ComboBox();
            this.scaleOut = new System.Windows.Forms.ComboBox();
            this.message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // degreesOutput
            // 
            this.degreesOutput.AutoSize = true;
            this.degreesOutput.Location = new System.Drawing.Point(83, 179);
            this.degreesOutput.Name = "degreesOutput";
            this.degreesOutput.Size = new System.Drawing.Size(114, 13);
            this.degreesOutput.TabIndex = 0;
            this.degreesOutput.Text = "-complete other boxes-";
            this.degreesOutput.Click += new System.EventHandler(this.degreesOutput_Click);
            // 
            // degreesInput
            // 
            this.degreesInput.Location = new System.Drawing.Point(86, 47);
            this.degreesInput.Name = "degreesInput";
            this.degreesInput.Size = new System.Drawing.Size(61, 20);
            this.degreesInput.TabIndex = 1;
            this.degreesInput.WordWrap = false;
            this.degreesInput.TextChanged += new System.EventHandler(this.degreesInput_TextChanged);
            // 
            // scaleIn
            // 
            this.scaleIn.FormattingEnabled = true;
            this.scaleIn.Location = new System.Drawing.Point(231, 47);
            this.scaleIn.Name = "scaleIn";
            this.scaleIn.Size = new System.Drawing.Size(80, 21);
            this.scaleIn.TabIndex = 2;
            this.scaleIn.SelectedIndexChanged += new System.EventHandler(this.scaleIn_SelectedIndexChanged);
            // 
            // scaleOut
            // 
            this.scaleOut.FormattingEnabled = true;
            this.scaleOut.Location = new System.Drawing.Point(231, 171);
            this.scaleOut.Name = "scaleOut";
            this.scaleOut.Size = new System.Drawing.Size(80, 21);
            this.scaleOut.TabIndex = 3;
            this.scaleOut.SelectedIndexChanged += new System.EventHandler(this.scaleOut_SelectedIndexChanged);
            // 
            // message
            // 
            this.message.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.message.Location = new System.Drawing.Point(139, 207);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(436, 23);
            this.message.TabIndex = 4;
            this.message.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.message.Click += new System.EventHandler(this.label1_Click);
            // 
            // TempConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 239);
            this.Controls.Add(this.message);
            this.Controls.Add(this.scaleOut);
            this.Controls.Add(this.scaleIn);
            this.Controls.Add(this.degreesInput);
            this.Controls.Add(this.degreesOutput);
            this.Name = "TempConverter";
            this.Text = "Temperature Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label degreesOutput;
        private System.Windows.Forms.TextBox degreesInput;
        private System.Windows.Forms.ComboBox scaleIn;
        private System.Windows.Forms.ComboBox scaleOut;
        private System.Windows.Forms.Label message;
    }
}

