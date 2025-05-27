namespace Agent
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.markdownViewer = new Agent.Controls.MarkdownViewer();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnAttachFile = new System.Windows.Forms.Button();
            this.btnProcessReceipts = new System.Windows.Forms.Button();
            this.btnPlanTrip = new System.Windows.Forms.Button();
            this.btnSearchDocs = new System.Windows.Forms.Button();
            this.lblAttachedFiles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // markdownViewer
            // 
            this.markdownViewer.Location = new System.Drawing.Point(12, 12);
            this.markdownViewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.markdownViewer.Name = "markdownViewer";
            this.markdownViewer.ScriptErrorsSuppressed = true;
            this.markdownViewer.Size = new System.Drawing.Size(776, 300);
            this.markdownViewer.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 330);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(600, 60);
            this.txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(630, 330);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 30);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnAttachFile
            // 
            this.btnAttachFile.Location = new System.Drawing.Point(630, 360);
            this.btnAttachFile.Name = "btnAttachFile";
            this.btnAttachFile.Size = new System.Drawing.Size(75, 30);
            this.btnAttachFile.TabIndex = 3;
            this.btnAttachFile.Text = "Attach";
            this.btnAttachFile.UseVisualStyleBackColor = true;
            this.btnAttachFile.Click += new System.EventHandler(this.btnAttachFile_Click);
            // 
            // btnProcessReceipts
            // 
            this.btnProcessReceipts.Location = new System.Drawing.Point(12, 410);
            this.btnProcessReceipts.Name = "btnProcessReceipts";
            this.btnProcessReceipts.Size = new System.Drawing.Size(120, 30);
            this.btnProcessReceipts.TabIndex = 4;
            this.btnProcessReceipts.Text = "Process Receipts";
            this.btnProcessReceipts.UseVisualStyleBackColor = true;
            this.btnProcessReceipts.Click += new System.EventHandler(this.btnProcessReceipts_Click);
            // 
            // btnPlanTrip
            // 
            this.btnPlanTrip.Location = new System.Drawing.Point(150, 410);
            this.btnPlanTrip.Name = "btnPlanTrip";
            this.btnPlanTrip.Size = new System.Drawing.Size(120, 30);
            this.btnPlanTrip.TabIndex = 5;
            this.btnPlanTrip.Text = "Plan Trip";
            this.btnPlanTrip.UseVisualStyleBackColor = true;
            this.btnPlanTrip.Click += new System.EventHandler(this.btnPlanTrip_Click);
            // 
            // btnSearchDocs
            // 
            this.btnSearchDocs.Location = new System.Drawing.Point(290, 410);
            this.btnSearchDocs.Name = "btnSearchDocs";
            this.btnSearchDocs.Size = new System.Drawing.Size(120, 30);
            this.btnSearchDocs.TabIndex = 6;
            this.btnSearchDocs.Text = "Search Docs";
            this.btnSearchDocs.UseVisualStyleBackColor = true;
            this.btnSearchDocs.Click += new System.EventHandler(this.btnSearchDocs_Click);
            // 
            // lblAttachedFiles
            // 
            this.lblAttachedFiles.AutoSize = true;
            this.lblAttachedFiles.Location = new System.Drawing.Point(12, 395);
            this.lblAttachedFiles.Name = "lblAttachedFiles";
            this.lblAttachedFiles.Size = new System.Drawing.Size(0, 15);
            this.lblAttachedFiles.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAttachedFiles);
            this.Controls.Add(this.btnSearchDocs);
            this.Controls.Add(this.btnPlanTrip);
            this.Controls.Add(this.btnProcessReceipts);
            this.Controls.Add(this.btnAttachFile);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.markdownViewer);
            this.Name = "Form1";
            this.Text = "AI Agent Assistant";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private Agent.Controls.MarkdownViewer markdownViewer;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnAttachFile;
        private System.Windows.Forms.Button btnProcessReceipts;
        private System.Windows.Forms.Button btnPlanTrip;
        private System.Windows.Forms.Button btnSearchDocs;
        private System.Windows.Forms.Label lblAttachedFiles;
    }
}
