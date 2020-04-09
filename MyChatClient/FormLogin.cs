using ActiveMQOperator;
using MongoDBOperator;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyChat
{
    public partial class FormLogin : Form
    {
        ActiveMQClient Client;

        public string userName;

        public List<User> MyFriends;


        public string Username => tBUsername.Text;
        public string Password => tBPassword.Text;

        public string UserName { get => userName; set => userName = value; }

        public FormLogin(ActiveMQClient Client)
        {
            this.Client = Client;
            Client.UserLoginResponse += Client_UserLoginResponse;
            InitializeComponent();
        }

        private void Client_UserLoginResponse(object sender, Tuple<int, List<User>> result)
        {
            Invoke(new Action(() =>
            {
                //我所有的好友
                this.MyFriends = result.Item2;
                switch (result.Item1)
                {
                    case 0:
                        MessageBox.Show("登录成功。");
                        UserName = Username;
                        DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    case 1:
                        MessageBox.Show("账号或密码错误！！");
                        break;
                    default:
                        MessageBox.Show("异常！！！");
                        break;
                }
            }));
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            Client.UserLogin(Username, Password);
        }

        private void bRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister(Client);

            formRegister.ShowDialog();
        }
    }
}
