namespace InMaFSS
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lst_files = new System.Windows.Forms.ListBox();
            this.txt_consumer_key = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.lbl_seperator = new System.Windows.Forms.Label();
            this.btn_upload = new System.Windows.Forms.Button();
            this.lbl_link = new System.Windows.Forms.LinkLabel();
            this.txt_consumer_secret = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(228, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "InMaFSS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(45, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "URL";
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(20, 17);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(367, 20);
            this.txt_url.TabIndex = 2;
            this.txt_url.Text = "http://localhost/InMaFSS/";
            this.txt_url.TextChanged += new System.EventHandler(this.txt_url_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(12, 60);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txt_consumer_secret);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.lst_files);
            this.splitContainer1.Panel2.Controls.Add(this.txt_consumer_key);
            this.splitContainer1.Panel2.Controls.Add(this.txt_url);
            this.splitContainer1.Size = new System.Drawing.Size(539, 236);
            this.splitContainer1.SplitterDistance = 135;
            this.splitContainer1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(34, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dateien";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(20, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Consumerkey";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Entfernen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Hinzufügen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lst_files
            // 
            this.lst_files.FormattingEnabled = true;
            this.lst_files.Location = new System.Drawing.Point(20, 101);
            this.lst_files.Name = "lst_files";
            this.lst_files.Size = new System.Drawing.Size(367, 95);
            this.lst_files.TabIndex = 4;
            // 
            // txt_consumer_key
            // 
            this.txt_consumer_key.Location = new System.Drawing.Point(20, 49);
            this.txt_consumer_key.Name = "txt_consumer_key";
            this.txt_consumer_key.Size = new System.Drawing.Size(367, 20);
            this.txt_consumer_key.TabIndex = 3;
            this.txt_consumer_key.TextChanged += new System.EventHandler(this.txt_apikey_TextChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(232, 302);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 27);
            this.button3.TabIndex = 5;
            this.button3.Text = "Speichern";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbl_seperator
            // 
            this.lbl_seperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_seperator.Location = new System.Drawing.Point(12, 347);
            this.lbl_seperator.Name = "lbl_seperator";
            this.lbl_seperator.Size = new System.Drawing.Size(539, 2);
            this.lbl_seperator.TabIndex = 6;
            this.lbl_seperator.Text = "lbl_seperator";
            // 
            // btn_upload
            // 
            this.btn_upload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_upload.Location = new System.Drawing.Point(200, 370);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(138, 66);
            this.btn_upload.TabIndex = 7;
            this.btn_upload.Text = "Upload";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.button4_Click);
            // 
            // lbl_link
            // 
            this.lbl_link.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbl_link.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_link.Location = new System.Drawing.Point(0, 439);
            this.lbl_link.Name = "lbl_link";
            this.lbl_link.Size = new System.Drawing.Size(563, 23);
            this.lbl_link.TabIndex = 9;
            this.lbl_link.TabStop = true;
            this.lbl_link.Text = "http://flx5.com/inmafss";
            this.lbl_link.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txt_consumer_secret
            // 
            this.txt_consumer_secret.Location = new System.Drawing.Point(20, 75);
            this.txt_consumer_secret.Name = "txt_consumer_secret";
            this.txt_consumer_secret.Size = new System.Drawing.Size(367, 20);
            this.txt_consumer_secret.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(20, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Consumersecret";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 462);
            this.Controls.Add(this.lbl_link);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.lbl_seperator);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "InMaFSS Upload";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lst_files;
        private System.Windows.Forms.TextBox txt_consumer_key;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbl_seperator;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.LinkLabel lbl_link;
        private System.Windows.Forms.TextBox txt_consumer_secret;
        private System.Windows.Forms.Label label5;


    }
}

