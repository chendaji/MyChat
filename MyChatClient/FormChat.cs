using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyChat
{
    public partial class FormChat : Form
    {
        //当前用户
        string CurrentUser;
        //选择聊天的用户
        string ToUserName;
        public FormChat(string CurrentUser,string ToUserName,string NickName)
        {
            this.CurrentUser = CurrentUser;
            this.ToUserName = ToUserName;
            InitializeComponent();
            this.Text = "正在和" + NickName + "聊天";
        }

        private void BSend_Click(object sender, EventArgs e)
        {
            string text = string.Format("{0} 说:{1}", CurrentUser, tMessage.Text);
            this.rtAllMsg.AppendText(string.Format("\r\n{0}", text));
            this.rtAllMsg.SelectionAlignment = HorizontalAlignment.Right;
        }
    }
}
