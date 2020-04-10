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
        string ToUserName;
        static ActiveMQOperate activeMQ = new ActiveMQOperate();

        Guid guid = Guid.NewGuid();
        public FormChat(string CurrentUser, string ToUserName, string NickName, ActiveMQClient Client)
        {
            this.CurrentUser = CurrentUser;
            this.ToUserName = ToUserName;
            InitializeComponent();
            this.Text = "正在和" + NickName + "聊天";
            activeMQ.Connect("MyChat");
            activeMQ.Received += ActiveMQ_Received;
        }

        private void BSend_Click(object sender, EventArgs e)
        {

            string text = string.Format("{0} 说:{1}", CurrentUser, tMessage.Text);
            this.rtAllMsg.AppendText(string.Format("\r\n{0}", text));
            this.rtAllMsg.SelectionAlignment = HorizontalAlignment.Right;

            Package package = new Package(
             guid,
            "Request",
            "Connect",
           text);

            activeMQ.Send("MyChat", package.ToString());
        }
        private void ActiveMQ_Received(object sender, string e)
        {
            Package package = JsonConvert.DeserializeObject<Package>(e);
            guid = package.SessionID;
            Invoke(new Action(() =>
            {
                this.rtAllMsg.AppendText(string.Format("\r\n{0}", package.Data));
                this.rtAllMsg.SelectionAlignment = HorizontalAlignment.Left;

            }));
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            activeMQ.Received -= ActiveMQ_Received;
        }
    }
}
