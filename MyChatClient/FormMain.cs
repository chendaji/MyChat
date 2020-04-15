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

            Client.ChatReceived += Client_ChatReceived;
            Client.FriendAddedNotice += Client_FriendAddedNotice;
            Client.AddFriendResponse += Client_AddFriendResponse;
        }
        Dictionary<string, FormChat> Chats = new Dictionary<string, FormChat>();
        private void Client_ChatReceived(object sender, Tuple<string, string> e)
        {
            Invoke(new Action(() =>
            {
                if (!Chats.ContainsKey(e.Item1))
                {
                    // 当前用户,聊天好友，好友NickName，好友Address
                    // Get Nickname and Address by e.Item1(Friend Username)
                    string FirnedUserName = e.Item1;
                    string FriendNickName = "";
                    string FriendAddress = "";
                    foreach (User friendInfo in MyFriends)
                    {
                        if (FirnedUserName.Equals(friendInfo.UserName))
                        {
                            FriendNickName = friendInfo.NickName;
                            FriendAddress = friendInfo.Address;
                        }
                    }
                    Chats[e.Item1] = new FormChat(UserName, FirnedUserName, FriendNickName, FriendAddress, Client);
                }
                Chats[e.Item1].Show();
                Chats[e.Item1].BringToFront();
                Chats[e.Item1].Chat(e.Item2);
            }));
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
            formSearch.Show();

        }

        private void TVFriends_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = TVFriends.SelectedNode;
            if (node == null) { MessageBox.Show("Node is null"); return; }
            //好友信息
            User userInfo = (User)node.Tag;
            if (!Chats.ContainsKey(userInfo.UserName))
            {
                Chats[userInfo.UserName] = new FormChat(UserName, userInfo.UserName, node.Text, userInfo.Address, Client);
            }
            Chats[userInfo.UserName].Show();
            Chats[userInfo.UserName].BringToFront();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //退出登录
            Client.Logout(UserName);
            Application.Exit();
        }
        //主动添加好友通知
        //返回自己和朋友信息 code eurrentUser friendInfo
        private void Client_AddFriendResponse(object sender, Tuple<int, User, User> e)
        {
            Invoke(new Action(() =>
            {
                if (e.Item1 == 0)
                {
                    User firnedInfo = e.Item3;
                    foreach (TreeNode node in TVFriends.Nodes)
                    {
                        //将姓名子节点加到姓名父节点上去
                        TreeNode n = new TreeNode(firnedInfo.NickName);
                        n.Tag = firnedInfo;
                        node.Nodes.Add(n);
                    }

                }
                else
                {
                    MessageBox.Show("添加好友失败");
                }
            }));

        }
        //被添加好友通知
        private void Client_FriendAddedNotice(object sender, Tuple<int, User, User> e)
        {
            //data.FriendUsername, data.FriendNickname, data.FriendAddress
            int code = e.Item1;
            User user = e.Item2;

            Invoke(new Action(() =>
            {
                foreach (TreeNode node in TVFriends.Nodes)
                {
                    //将姓名子节点加到姓名父节点上去
                    TreeNode n = new TreeNode(user.NickName);
                    n.Tag = user;
                    node.Nodes.Add(n);
                }
            }));
            MessageBox.Show("用户" + user.NickName + "您添加为好友");
        }
    }
}
