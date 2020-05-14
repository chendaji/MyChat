namespace MyChat
{
    partial class FormModify
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
            this.bModify = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tPassWord = new System.Windows.Forms.TextBox();
            this.tConfirnPassword = new System.Windows.Forms.TextBox();
            this.tNickName = new System.Windows.Forms.TextBox();
            this.tSex = new System.Windows.Forms.TextBox();
            this.tAge = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bModify
            // 
            this.bModify.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bModify.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.bModify.Location = new System.Drawing.Point(114, 619);
            this.bModify.Name = "bModify";
            this.bModify.Size = new System.Drawing.Size(97, 41);
            this.bModify.TabIndex = 0;
            this.bModify.Text = "确认";
            this.bModify.UseVisualStyleBackColor = false;
            this.bModify.Click += new System.EventHandler(this.bModify_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.AliceBlue;
            this.label3.Font = new System.Drawing.Font("楷体", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(51, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "确认密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.AliceBlue;
            this.label4.Font = new System.Drawing.Font("楷体", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(103, 439);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 28);
            this.label4.TabIndex = 1;
            this.label4.Text = "年龄：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.AliceBlue;
            this.label5.Font = new System.Drawing.Font("楷体", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(103, 344);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 28);
            this.label5.TabIndex = 1;
            this.label5.Text = "性别：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.AliceBlue;
            this.label6.Font = new System.Drawing.Font("楷体", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(77, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 28);
            this.label6.TabIndex = 1;
            this.label6.Text = "新密码：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.AliceBlue;
            this.label7.Font = new System.Drawing.Font("楷体", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(103, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 28);
            this.label7.TabIndex = 1;
            this.label7.Text = "昵称：";
            // 
            // tPassWord
            // 
            this.tPassWord.BackColor = System.Drawing.Color.White;
            this.tPassWord.Font = new System.Drawing.Font("楷体", 16F);
            this.tPassWord.Location = new System.Drawing.Point(199, 56);
            this.tPassWord.Name = "tPassWord";
            this.tPassWord.Size = new System.Drawing.Size(300, 38);
            this.tPassWord.TabIndex = 2;
            // 
            // tConfirnPassword
            // 
            this.tConfirnPassword.BackColor = System.Drawing.Color.White;
            this.tConfirnPassword.Font = new System.Drawing.Font("楷体", 16F);
            this.tConfirnPassword.Location = new System.Drawing.Point(199, 151);
            this.tConfirnPassword.Name = "tConfirnPassword";
            this.tConfirnPassword.Size = new System.Drawing.Size(300, 38);
            this.tConfirnPassword.TabIndex = 2;
            // 
            // tNickName
            // 
            this.tNickName.BackColor = System.Drawing.Color.White;
            this.tNickName.Font = new System.Drawing.Font("楷体", 16F);
            this.tNickName.Location = new System.Drawing.Point(199, 246);
            this.tNickName.Name = "tNickName";
            this.tNickName.Size = new System.Drawing.Size(300, 38);
            this.tNickName.TabIndex = 2;
            // 
            // tSex
            // 
            this.tSex.BackColor = System.Drawing.Color.White;
            this.tSex.Font = new System.Drawing.Font("楷体", 16F);
            this.tSex.Location = new System.Drawing.Point(199, 341);
            this.tSex.Name = "tSex";
            this.tSex.Size = new System.Drawing.Size(300, 38);
            this.tSex.TabIndex = 2;
            // 
            // tAge
            // 
            this.tAge.BackColor = System.Drawing.Color.White;
            this.tAge.Font = new System.Drawing.Font("楷体", 16F);
            this.tAge.Location = new System.Drawing.Point(199, 436);
            this.tAge.Name = "tAge";
            this.tAge.Size = new System.Drawing.Size(300, 38);
            this.tAge.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(374, 619);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 41);
            this.button1.TabIndex = 3;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // FormModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(582, 741);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tAge);
            this.Controls.Add(this.tSex);
            this.Controls.Add(this.tNickName);
            this.Controls.Add(this.tConfirnPassword);
            this.Controls.Add(this.tPassWord);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bModify);
            this.Name = "FormModify";
            this.Text = "Modifydata";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bModify;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tPassWord;
        private System.Windows.Forms.TextBox tConfirnPassword;
        private System.Windows.Forms.TextBox tNickName;
        private System.Windows.Forms.TextBox tSex;
        private System.Windows.Forms.TextBox tAge;
        private System.Windows.Forms.Button button1;
    }
}