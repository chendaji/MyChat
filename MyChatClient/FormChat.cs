using ActiveMQOperator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyChat
{
    public partial class FormChat : Form
    {
        //当前用户
        string CurrentUser;
        //选择聊天的用户
        string FriendUserName;
        string FriendNickName;
        //static ActiveMQOperate activeMQ = new ActiveMQOperate();
        ActiveMQClient Client;
        Guid guid = Guid.NewGuid();
        string FriendAddress;
        // 当前用户，好友NickName，好友Address
        public FormChat(string CurrentUser, string FriendUserName, string FriendNickName, string FriendAddress, ActiveMQClient Client)
        {
            this.CurrentUser = CurrentUser;
            this.FriendUserName = FriendUserName;
            this.FriendNickName = FriendNickName;
            InitializeComponent();
            this.Text = "正在和" + FriendNickName + "聊天";
            //activeMQ.Connect("MyChat");
            //activeMQ.Received += ActiveMQ_Received;
            this.FriendAddress = FriendAddress;
            this.Client = Client;
        }

        private void BSend_Click(object sender, EventArgs e)
        {

            //string text = string.Format("{0} 说:{1}", CurrentUser, tMessage.Text);
            this.rtAllMsg.AppendText(string.Format("\r\n{0}", tMessage.Text));
            this.rtAllMsg.SelectionAlignment = HorizontalAlignment.Right;

            // Package package = new Package(
            //  guid,
            // "Request",
            // "Connect",
            //text);

            Client.Chat(FriendAddress, CurrentUser, tMessage.Text);
            tMessage.Text = "";
            tMessage.Focus();
        }
        //private void ActiveMQ_Received(object sender, string e)
        //{
        //    Package package = JsonConvert.DeserializeObject<Package>(e);
        //    guid = package.SessionID;
        //    Invoke(new Action(() =>
        //    {
        //        this.rtAllMsg.AppendText(string.Format("\r\n{0}", package.Data));
        //        this.rtAllMsg.SelectionAlignment = HorizontalAlignment.Left;

        //    }));
        //}

        public void Chat(string Message)
        {
            Invoke(new Action(() =>
            {
                this.rtAllMsg.AppendText($"\r\n{FriendNickName}({DateTime.Now}):\r\n{Message}");
                this.rtAllMsg.SelectionAlignment = HorizontalAlignment.Left;
            }));
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            //activeMQ.Received -= ActiveMQ_Received;
            e.Cancel = true;
            Hide();
        }

        public static implicit operator Dictionary<object, object>(FormChat v)
        {
            throw new NotImplementedException();
        }
    }
}
