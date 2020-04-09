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
    public partial class FormMain : Form
    {
        ActiveMQClient Client = new ActiveMQClient();
        List<User> MyFriends = new List<User>();
        string UserName;

        public FormMain()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//设置该属性 为false
        }
        FormLogin formLogin;
        protected override void OnLoad(EventArgs e)
        {
            Client.Start();
            base.OnLoad(e);
            // TODO:连接 MQ
            formLogin = new FormLogin(Client);

            formLogin.ShowDialog();
            UserName = formLogin.UserName;
            MyFriends = formLogin.MyFriends;
            //显示我的好友
            foreach (TreeNode node in TVFriends.Nodes)
            {
                if (MyFriends != null)
                {
                    foreach (var friend in MyFriends)
                    {
                        //将姓名子节点加到姓名父节点上去
                        TreeNode n = new TreeNode(friend.NickName);
                        n.Tag = friend;
                        node.Nodes.Add(n);
                    }
                }

            }
            userName.Text = UserName;
            //  Client.GetMyFriends(UserName);
            //   Client.GetMyFriendsResponse += Client_GetMyFriendsResponse;
        }

        private void Meun_Load(object sender, EventArgs e)
        {
            //禁止在文本编辑框输入数据的组合框样式
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            //下拉列表中最多允许显示3个选项
            comboBox1.MaxDropDownItems = 3;
            string[] item = { "在线", "离线", "忙碌" };
            //把数据选项逐个添加到组合框的列表中
            for (int i = 0; i < item.Length; i++)
            {
                comboBox1.Items.Add(item[i]);
            }
            //todo 查询数据库，获取好友列表
        }
        public void Client_GetMyFriendsResponse(object sender, Tuple<int, List<User>> result)
        {
            Invoke(new Action(() =>
            {
                MyFriends = result.Item2;
                foreach (TreeNode node in TVFriends.Nodes)
                {
                    foreach (var friend in MyFriends)
                    {
                        //将姓名子节点加到姓名父节点上去
                        TreeNode n = new TreeNode(friend.NickName);
                        n.Tag = friend;
                        node.Nodes.Add(n);
                    }
                }



            }));


        }
        private void modifyData_Click(object sender, EventArgs e)
        {
            FormModify formModify = new FormModify(UserName, Client);
            formModify.ShowDialog();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void addFriends_Click(object sender, EventArgs e)
        {
            FormSearch formSearch = new FormSearch(Client, UserName);

            formSearch.ShowDialog();
        }

        private void TVFriends_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = TVFriends.SelectedNode;
            User userInfo = (User)node.Tag;
            FormChat formChat = new FormChat(UserName, userInfo.UserName, node.Text);
            formChat.Show();
        }
    }
}
