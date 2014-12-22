namespace CavePreview
{
    partial class Form1
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
            this.preview = new System.Windows.Forms.PictureBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.btnContract = new System.Windows.Forms.Button();
            this.btnSmooth = new System.Windows.Forms.Button();
            this.btnEnhance = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
            this.SuspendLayout();
            // 
            // preview
            // 
            this.preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.preview.Location = new System.Drawing.Point(12, 12);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(317, 209);
            this.preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.preview.TabIndex = 0;
            this.preview.TabStop = false;
            // 
            // btnGen
            // 
            this.btnGen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGen.Location = new System.Drawing.Point(12, 231);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(75, 23);
            this.btnGen.TabIndex = 1;
            this.btnGen.Text = "Populate";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // btnContract
            // 
            this.btnContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContract.Location = new System.Drawing.Point(93, 231);
            this.btnContract.Name = "btnContract";
            this.btnContract.Size = new System.Drawing.Size(75, 23);
            this.btnContract.TabIndex = 2;
            this.btnContract.Text = "Grow";
            this.btnContract.UseVisualStyleBackColor = true;
            this.btnContract.Click += new System.EventHandler(this.btnGrow_Click);
            // 
            // btnSmooth
            // 
            this.btnSmooth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSmooth.Location = new System.Drawing.Point(174, 231);
            this.btnSmooth.Name = "btnSmooth";
            this.btnSmooth.Size = new System.Drawing.Size(75, 23);
            this.btnSmooth.TabIndex = 2;
            this.btnSmooth.Text = "Contract";
            this.btnSmooth.UseVisualStyleBackColor = true;
            this.btnSmooth.Click += new System.EventHandler(this.btnContract_Click);
            // 
            // btnEnhance
            // 
            this.btnEnhance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnhance.Location = new System.Drawing.Point(255, 231);
            this.btnEnhance.Name = "btnEnhance";
            this.btnEnhance.Size = new System.Drawing.Size(75, 23);
            this.btnEnhance.TabIndex = 2;
            this.btnEnhance.Text = "Enhance";
            this.btnEnhance.UseVisualStyleBackColor = true;
            this.btnEnhance.Click += new System.EventHandler(this.btnEnhance_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 266);
            this.Controls.Add(this.btnEnhance);
            this.Controls.Add(this.btnSmooth);
            this.Controls.Add(this.btnContract);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.preview);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox preview;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Button btnContract;
        private System.Windows.Forms.Button btnSmooth;
        private System.Windows.Forms.Button btnEnhance;
    }
}

