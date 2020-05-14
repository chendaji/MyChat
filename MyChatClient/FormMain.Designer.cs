namespace MyChat
{
    partial class FormMain
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
            this.userName = new System.Windows.Forms.Label();
            this.modifyData = new System.Windows.Forms.Button();
            this.addFriends = new System.Windows.Forms.Button();
            this.lVMyFriends = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.BackColor = System.Drawing.Color.Silver;
            this.userName.Font = new System.Drawing.Font("楷体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userName.Location = new System.Drawing.Point(105, 0);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(93, 25);
            this.userName.TabIndex = 0;
            this.userName.Text = "请登录";
            // 
            // modifyData
            // 
            this.modifyData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.modifyData.Font = new System.Drawing.Font("楷体", 12F);
            this.modifyData.Location = new System.Drawing.Point(122, 43);
            this.modifyData.Name = "modifyData";
            this.modifyData.Size = new System.Drawing.Size(128, 35);
            this.modifyData.TabIndex = 3;
            this.modifyData.Text = "修改资料";
            this.modifyData.UseVisualStyleBackColor = false;
            this.modifyData.Click += new System.EventHandler(this.modifyData_Click);
            // 
            // addFriends
            // 
            this.addFriends.BackColor = System.Drawing.Color.WhiteSmoke;
            this.addFriends.Font = new System.Drawing.Font("楷体", 12F);
            this.addFriends.Location = new System.Drawing.Point(281, 43);
            this.addFriends.Name = "addFriends";
            this.addFriends.Size = new System.Drawing.Size(129, 35);
            this.addFriends.TabIndex = 4;
            this.addFriends.Text = "添加好友";
            this.addFriends.UseVisualStyleBackColor = false;
            this.addFriends.Click += new System.EventHandler(this.addFriends_Click);
            // 
            // lVMyFriends
            // 
            this.lVMyFriends.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lVMyFriends.BackgroundImageTiled = true;
            this.lVMyFriends.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lVMyFriends.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lVMyFriends.HideSelection = false;
            this.lVMyFriends.Location = new System.Drawing.Point(-1, 84);
            this.lVMyFriends.Name = "lVMyFriends";
            this.lVMyFriends.Size = new System.Drawing.Size(334, 689);
            this.lVMyFriends.TabIndex = 8;
            this.lVMyFriends.UseCompatibleStateImageBehavior = false;
            this.lVMyFriends.View = System.Windows.Forms.View.Details;
            this.lVMyFriends.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lVMyFriends_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "我的好友";
            this.columnHeader1.Width = 118;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "状态";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::MyChat.Properties.Resources._90;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(482, 686);
            this.Controls.Add(this.lVMyFriends);
            this.Controls.Add(this.addFriends);
            this.Controls.Add(this.modifyData);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.userName);
            this.Name = "FormMain";
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.Meun_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button modifyData;
        private System.Windows.Forms.Button addFriends;
        private System.Windows.Forms.ListView lVMyFriends;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}