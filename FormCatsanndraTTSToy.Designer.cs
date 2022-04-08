namespace Catsanndra_TTS_Toy
{
    partial class frmCatsanndraTTSToy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCatsanndraTTSToy));
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSpeak = new System.Windows.Forms.Button();
            this.cmbVoices = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.txtDebugOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(13, 13);
            this.txtInput.MaxLength = 1000000000;
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(433, 425);
            this.txtInput.TabIndex = 0;
            this.txtInput.Text = resources.GetString("txtInput.Text");
            // 
            // btnSpeak
            // 
            this.btnSpeak.Location = new System.Drawing.Point(453, 13);
            this.btnSpeak.Name = "btnSpeak";
            this.btnSpeak.Size = new System.Drawing.Size(75, 23);
            this.btnSpeak.TabIndex = 1;
            this.btnSpeak.Text = "Speak";
            this.btnSpeak.UseVisualStyleBackColor = true;
            this.btnSpeak.Click += new System.EventHandler(this.btnSpeak_Click);
            // 
            // cmbVoices
            // 
            this.cmbVoices.FormattingEnabled = true;
            this.cmbVoices.Location = new System.Drawing.Point(453, 43);
            this.cmbVoices.Name = "cmbVoices";
            this.cmbVoices.Size = new System.Drawing.Size(121, 21);
            this.cmbVoices.TabIndex = 2;
            this.cmbVoices.SelectedIndexChanged += new System.EventHandler(this.cmbVoices_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(453, 71);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(453, 99);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 4;
            // 
            // txtDebugOutput
            // 
            this.txtDebugOutput.Location = new System.Drawing.Point(453, 127);
            this.txtDebugOutput.MaxLength = 1000000000;
            this.txtDebugOutput.Multiline = true;
            this.txtDebugOutput.Name = "txtDebugOutput";
            this.txtDebugOutput.Size = new System.Drawing.Size(335, 311);
            this.txtDebugOutput.TabIndex = 5;
            // 
            // frmCatsanndraTTSToy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtDebugOutput);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.cmbVoices);
            this.Controls.Add(this.btnSpeak);
            this.Controls.Add(this.txtInput);
            this.Name = "frmCatsanndraTTSToy";
            this.Text = "Catsanndra TTS Toy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCatsanndraTTSToy_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSpeak;
        private System.Windows.Forms.ComboBox cmbVoices;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox txtDebugOutput;
    }
}

