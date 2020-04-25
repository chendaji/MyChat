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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tUserName = new System.Windows.Forms.TextBox();
            this.tPassWord = new System.Windows.Forms.TextBox();
            this.tConfirnPassword = new System.Windows.Forms.TextBox();
            this.tNickName = new System.Windows.Forms.TextBox();
            this.tSex = new System.Windows.Forms.TextBox();
            this.tAge = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bModify
            // 
            this.bModify.Location = new System.Drawing.Point(205, 380);
            this.bModify.Name = "bModify";
            this.bModify.Size = new System.Drawing.Size(75, 23);
            this.bModify.TabIndex = 0;
            this.bModify.Text = "确认";
            this.bModify.UseVisualStyleBackColor = true;
            this.bModify.Click += new System.EventHandler(this.bModify_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "确认密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "年龄：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "性别：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "新密码：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(188, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "昵称：";
            // 
            // tUserName
            // 
            this.tUserName.Location = new System.Drawing.Point(315, 16);
            this.tUserName.Name = "tUserName";
            this.tUserName.ReadOnly = true;
            this.tUserName.Size = new System.Drawing.Size(116, 25);
            this.tUserName.TabIndex = 2;
            // 
            // tPassWord
            // 
            this.tPassWord.Location = new System.Drawing.Point(315, 64);
            this.tPassWord.Name = "tPassWord";
            this.tPassWord.Size = new System.Drawing.Size(116, 25);
            this.tPassWord.TabIndex = 2;
            // 
            // tConfirnPassword
            // 
            this.tConfirnPassword.Location = new System.Drawing.Point(315, 125);
            this.tConfirnPassword.Name = "tConfirnPassword";
            this.tConfirnPassword.Size = new System.Drawing.Size(116, 25);
            this.tConfirnPassword.TabIndex = 2;
            // 
            // tNickName
            // 
            this.tNickName.Location = new System.Drawing.Point(315, 180);
            this.tNickName.Name = "tNickName";
            this.tNickName.Size = new System.Drawing.Size(116, 25);
            this.tNickName.TabIndex = 2;
            // 
            // tSex
            // 
            this.tSex.Location = new System.Drawing.Point(315, 228);
            this.tSex.Name = "tSex";
            this.tSex.Size = new System.Drawing.Size(116, 25);
            this.tSex.TabIndex = 2;
            // 
            // tAge
            // 
            this.tAge.Location = new System.Drawing.Point(315, 279);
            this.tAge.Name = "tAge";
            this.tAge.Size = new System.Drawing.Size(116, 25);
            this.tAge.TabIndex = 2;
            // 
            // FormModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tAge);
            this.Controls.Add(this.tSex);
            this.Controls.Add(this.tNickName);
            this.Controls.Add(this.tConfirnPassword);
            this.Controls.Add(this.tPassWord);
            this.Controls.Add(this.tUserName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bModify);
            this.Name = "FormModify";
            this.Text = "Modifydata";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bModify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tUserName;
        private System.Windows.Forms.TextBox tPassWord;
        private System.Windows.Forms.TextBox tConfirnPassword;
        private System.Windows.Forms.TextBox tNickName;
        private System.Windows.Forms.TextBox tSex;
        private System.Windows.Forms.TextBox tAge;
    }
}