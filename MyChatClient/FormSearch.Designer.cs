namespace MyChat
{
    partial class FormSearch
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
            this.bAddFriend = new System.Windows.Forms.Button();
            this.bSearchFriend = new System.Windows.Forms.Button();
            this.lVFriends = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // bAddFriend
            // 
            this.bAddFriend.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.bAddFriend.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.bAddFriend.Location = new System.Drawing.Point(683, 393);
            this.bAddFriend.Name = "bAddFriend";
            this.bAddFriend.Size = new System.Drawing.Size(105, 45);
            this.bAddFriend.TabIndex = 1;
            this.bAddFriend.Text = "添加";
            this.bAddFriend.UseVisualStyleBackColor = false;
            this.bAddFriend.Click += new System.EventHandler(this.bAddFriend_Click);
            // 
            // bSearchFriend
            // 
            this.bSearchFriend.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.bSearchFriend.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.bSearchFriend.Location = new System.Drawing.Point(683, 326);
            this.bSearchFriend.Name = "bSearchFriend";
            this.bSearchFriend.Size = new System.Drawing.Size(105, 45);
            this.bSearchFriend.TabIndex = 1;
            this.bSearchFriend.Text = "查询";
            this.bSearchFriend.UseVisualStyleBackColor = false;
            this.bSearchFriend.Click += new System.EventHandler(this.bSearchFriend_Click);
            // 
            // lVFriends
            // 
            this.lVFriends.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lVFriends.BackgroundImageTiled = true;
            this.lVFriends.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lVFriends.Font = new System.Drawing.Font("楷体", 15F);
            this.lVFriends.HideSelection = false;
            this.lVFriends.Location = new System.Drawing.Point(12, 12);
            this.lVFriends.Name = "lVFriends";
            this.lVFriends.Size = new System.Drawing.Size(788, 308);
            this.lVFriends.TabIndex = 0;
            this.lVFriends.UseCompatibleStateImageBehavior = false;
            this.lVFriends.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "用户名";
            this.columnHeader1.Width = 96;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "昵称";
            this.columnHeader2.Width = 79;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "在线/离线";
            this.columnHeader3.Width = 148;
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bSearchFriend);
            this.Controls.Add(this.bAddFriend);
            this.Controls.Add(this.lVFriends);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormSearch";
            this.Text = "FormSearch";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lVFriends;
        private System.Windows.Forms.Button bAddFriend;
        private System.Windows.Forms.Button bSearchFriend;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}