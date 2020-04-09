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
    public partial class FormRegister : Form
    {
        ActiveMQClient Client;
        public FormRegister(ActiveMQClient client)
        {
            Client = client;

            Client.RegisterUserResponse += Client_RegisterUserResponse;

            InitializeComponent();
        }

        private void Client_RegisterUserResponse(object sender, int e)
        {
            Invoke(new Action(()=>
            {
                if (this.IsDisposed) return;
                switch (e)
                {
                    case 0:
                        MessageBox.Show("注册成功。");
                        DialogResult = DialogResult.OK;
                        break;
                    case 1:
                        MessageBox.Show("账号已存在，请重新输入！！");
                        DialogResult = DialogResult.Cancel;
                        break;
                    default:
                        DialogResult = DialogResult.Cancel;
                        MessageBox.Show("异常！！！");
                        break;
                }
                this.Close();
            }));
        }

        //取消注册
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //确认注册
        private void button1_Click(object sender, EventArgs e)
        {
            if (passWord.Text.Trim().Equals(confirmPassword.Text.Trim()))
            {
                User user = new User();
                user.Id = Guid.NewGuid().ToString();
                user.UserName = userName.Text.Trim();
                user.Password = passWord.Text.Trim();
                user.Age = int.Parse(age.Text.Trim());
                user.NickName = nikeName.Text.Trim();
                user.Sex = sex.Text.Trim();
                Client.RegisterUser(user);
                //MongoDBOperate mongoDBOperate = new MongoDBOperate();
                //mongoDBOperate.Connect();
                //int code=mongoDBOperate.RegisterUser(user);
                //if (code==0)
                //{
                //    MessageBox.Show("注册成功。");
                //}
                //else if(code==1)
                //{
                //    MessageBox.Show("账号已存在，请重新输入！！");
                //}
                //else
                //{
                //    MessageBox.Show("异常！！！");
                //}
            }
            else
            {
                MessageBox.Show("两次密码输入不一致！！");
            }
        }

        private void register_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Client.RegisterUserResponse -= Client_RegisterUserResponse;
        }
    }
}
