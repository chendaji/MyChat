namespace MyChat
{
    partial class FormChat
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
            this.tMessage = new System.Windows.Forms.TextBox();
            this.BSend = new System.Windows.Forms.Button();
            this.rtAllMsg = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tMessage
            // 
            this.tMessage.Location = new System.Drawing.Point(12, 344);
            this.tMessage.Multiline = true;
            this.tMessage.Name = "tMessage";
            this.tMessage.Size = new System.Drawing.Size(606, 109);
            this.tMessage.TabIndex = 1;
            // 
            // BSend
            // 
            this.BSend.Location = new System.Drawing.Point(624, 344);
            this.BSend.Name = "BSend";
            this.BSend.Size = new System.Drawing.Size(164, 109);
            this.BSend.TabIndex = 2;
            this.BSend.Text = "发送";
            this.BSend.UseVisualStyleBackColor = true;
            this.BSend.Click += new System.EventHandler(this.BSend_Click);
            // 
            // rtAllMsg
            // 
            this.rtAllMsg.Location = new System.Drawing.Point(12, 1);
            this.rtAllMsg.Name = "rtAllMsg";
            this.rtAllMsg.Size = new System.Drawing.Size(776, 337);
            this.rtAllMsg.TabIndex = 3;
            this.rtAllMsg.Text = "";
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtAllMsg);
            this.Controls.Add(this.BSend);
            this.Controls.Add(this.tMessage);
            this.Name = "FormChat";
            this.Text = "FormChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tMessage;
        private System.Windows.Forms.Button BSend;
        private System.Windows.Forms.RichTextBox rtAllMsg;
    }
}