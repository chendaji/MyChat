namespace MyChat
{
    partial class FormLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBUsername = new System.Windows.Forms.TextBox();
            this.tBPassword = new System.Windows.Forms.TextBox();
            this.bRegister = new System.Windows.Forms.Button();
            this.bLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("宋体", 25F);
            this.label1.Location = new System.Drawing.Point(167, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Font = new System.Drawing.Font("宋体", 25F);
            this.label2.Location = new System.Drawing.Point(167, 192);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 42);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码";
            // 
            // tBUsername
            // 
            this.tBUsername.BackColor = System.Drawing.SystemColors.Control;
            this.tBUsername.Font = new System.Drawing.Font("宋体", 25F);
            this.tBUsername.Location = new System.Drawing.Point(277, 80);
            this.tBUsername.Margin = new System.Windows.Forms.Padding(4);
            this.tBUsername.Name = "tBUsername";
            this.tBUsername.Size = new System.Drawing.Size(330, 55);
            this.tBUsername.TabIndex = 4;
            // 
            // tBPassword
            // 
            this.tBPassword.BackColor = System.Drawing.SystemColors.Control;
            this.tBPassword.Font = new System.Drawing.Font("宋体", 25F);
            this.tBPassword.Location = new System.Drawing.Point(277, 186);
            this.tBPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tBPassword.Name = "tBPassword";
            this.tBPassword.PasswordChar = '*';
            this.tBPassword.Size = new System.Drawing.Size(330, 55);
            this.tBPassword.TabIndex = 5;
            // 
            // bRegister
            // 
            this.bRegister.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bRegister.Font = new System.Drawing.Font("楷体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bRegister.Location = new System.Drawing.Point(500, 328);
            this.bRegister.Margin = new System.Windows.Forms.Padding(4);
            this.bRegister.Name = "bRegister";
            this.bRegister.Size = new System.Drawing.Size(140, 46);
            this.bRegister.TabIndex = 7;
            this.bRegister.Text = "注册";
            this.bRegister.UseVisualStyleBackColor = false;
            this.bRegister.Click += new System.EventHandler(this.bRegister_Click);
            // 
            // bLogin
            // 
            this.bLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bLogin.Font = new System.Drawing.Font("楷体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bLogin.Location = new System.Drawing.Point(187, 328);
            this.bLogin.Margin = new System.Windows.Forms.Padding(4);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(140, 46);
            this.bLogin.TabIndex = 8;
            this.bLogin.Text = "登录";
            this.bLogin.UseVisualStyleBackColor = false;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(832, 477);
            this.Controls.Add(this.bLogin);
            this.Controls.Add(this.bRegister);
            this.Controls.Add(this.tBPassword);
            this.Controls.Add(this.tBUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("楷体", 13F);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBUsername;
        private System.Windows.Forms.TextBox tBPassword;
        private System.Windows.Forms.Button bRegister;
        private System.Windows.Forms.Button bLogin;
    }
}

