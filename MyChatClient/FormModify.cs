using ActiveMQOperator;
using MongoDBOperator;
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
    public partial class FormModify : Form
    {
        ActiveMQClient Client;
        string UserName;
        public FormModify(string UserName, ActiveMQClient Client)
        {
            InitializeComponent();
            this.UserName = UserName;
            this.Client = Client;
            Client.GetUserInfo(UserName);
            Client.GetUserInfoResponse += Client_GetUserInfoResponse;
        }
        private void Client_GetUserInfoResponse(object sender, Tuple<int, User> result)
        {
            Invoke(new Action(() =>
            {
                User userInfo = result.Item2;
                tUserName.Text = userInfo.UserName;
                tNickName.Text = userInfo.NickName;
                tSex.Text = userInfo.Sex;
                tAge.Text = userInfo.Age + "";
            }));
        }
        private void FormModify_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
