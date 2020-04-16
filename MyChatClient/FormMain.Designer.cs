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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("我的好友");
            this.userName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.modifyData = new System.Windows.Forms.Button();
            this.addFriends = new System.Windows.Forms.Button();
            this.TVFriends = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bFresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Location = new System.Drawing.Point(141, 9);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(52, 15);
            this.userName.TabIndex = 0;
            this.userName.Text = "请登录";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::MyChat.Properties.Resources._4;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 64);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // modifyData
            // 
            this.modifyData.Location = new System.Drawing.Point(214, 46);
            this.modifyData.Name = "modifyData";
            this.modifyData.Size = new System.Drawing.Size(83, 23);
            this.modifyData.TabIndex = 3;
            this.modifyData.Text = "修改资料";
            this.modifyData.UseVisualStyleBackColor = true;
            this.modifyData.Click += new System.EventHandler(this.modifyData_Click);
            // 
            // addFriends
            // 
            this.addFriends.Location = new System.Drawing.Point(316, 46);
            this.addFriends.Name = "addFriends";
            this.addFriends.Size = new System.Drawing.Size(84, 23);
            this.addFriends.TabIndex = 4;
            this.addFriends.Text = "添加好友";
            this.addFriends.UseVisualStyleBackColor = true;
            this.addFriends.Click += new System.EventHandler(this.addFriends_Click);
            // 
            // TVFriends
            // 
            this.TVFriends.Location = new System.Drawing.Point(-1, 75);
            this.TVFriends.Name = "TVFriends";
            treeNode1.Name = "节点1";
            treeNode1.Text = "我的好友";
            this.TVFriends.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.TVFriends.Size = new System.Drawing.Size(320, 550);
            this.TVFriends.TabIndex = 5;
            this.TVFriends.DoubleClick += new System.EventHandler(this.TVFriends_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "当前状态：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(299, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // bFresh
            // 
            this.bFresh.Location = new System.Drawing.Point(118, 46);
            this.bFresh.Name = "bFresh";
            this.bFresh.Size = new System.Drawing.Size(75, 23);
            this.bFresh.TabIndex = 8;
            this.bFresh.Text = "刷新好友";
            this.bFresh.UseVisualStyleBackColor = true;
            this.bFresh.Click += new System.EventHandler(this.bFresh_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 773);
            this.Controls.Add(this.bFresh);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TVFriends);
            this.Controls.Add(this.addFriends);
            this.Controls.Add(this.modifyData);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.userName);
            this.Name = "FormMain";
            this.Text = "主界面";
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
        private System.Windows.Forms.TreeView TVFriends;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button bFresh;
    }
}