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
        User userInfo;
        public FormModify(string UserName, ActiveMQClient Client)
        {
            InitializeComponent();
            this.UserName = UserName;
            this.Client = Client;
            Client.GetUserInfo(UserName);
            Client.GetUserInfoResponse += Client_GetUserInfoResponse;
            Client.UpdateUserInfoResponse += Client_UpdateUserInfoResponse;
        }
        private void Client_GetUserInfoResponse(object sender, Tuple<int, User> result)
        {
            Invoke(new Action(() =>
            {
                userInfo = result.Item2;
                tUserName.Text = userInfo.UserName;
                tNickName.Text = userInfo.NickName;
                tSex.Text = userInfo.Sex;
                tAge.Text = userInfo.Age + "";
            }));
        }
        private void Client_UpdateUserInfoResponse(object sender, Tuple<int> result)
        {
            Invoke(new Action(() =>
            {
                if (result.Item1==0)
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }));
        }
        //修改资料
        private void bModify_Click(object sender, EventArgs e)
        {
            if (!tPassWord.Equals(tConfirnPassword))
            {
                if (!"".Equals(tPassWord.Text))
                {
                    userInfo.Password = tPassWord.Text;
                }
                userInfo.NickName = tNickName.Text;
                userInfo.Sex = tSex.Text;
                userInfo.Age = int.Parse(tAge.Text);
                Client.UpdateUserInfo(userInfo);
            }
            else
            {
                MessageBox.Show("两次密码输入不一致!");
                tPassWord.Focus();
            }

        }
        private void FormModify_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
