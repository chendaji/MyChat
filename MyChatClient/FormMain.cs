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
        string Address;

        public FormMain()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//设置该属性 为false
            Client.ChatReceived += Client_ChatReceived;
            Client.FriendAddedNotice += Client_FriendAddedNotice;
            Client.AddFriendResponse += Client_AddFriendResponse;
            Client.LogoutResponse += Client_LogoutResponse;
        }
        Dictionary<string, FormChat> Chats = new Dictionary<string, FormChat>();
        private void Client_ChatReceived(object sender, Tuple<string, string> e)
        {
            // 当前用户,聊天好友，好友NickName，好友Address
            // Get Nickname and Address by e.Item1(Friend Username)
            string FirnedUserName = e.Item1;
            string FriendNickName = "";
            string FriendAddress = "";
            Invoke(new Action(() =>
            {
                if (!Chats.ContainsKey(e.Item1))
                {

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
            Guid id = Guid.NewGuid();
            //当前用户的地址
            this.Address = id.ToString().ToUpper(); ;
            Client.Start(id);
            base.OnLoad(e);
            // TODO:连接 MQ
            formLogin = new FormLogin(id, Client);

            formLogin.ShowDialog();
            UserName = formLogin.UserName;
            // 监听好友登录事件
            Client.FriendLoginNotice += Client_FriendLoginNotice;
            MyFriends = formLogin.MyFriends;
            //显示我的好友
            if (MyFriends != null)
            {
                foreach (var friend in MyFriends)
                {
                    //将姓名子节点加到姓名父节点上去
                    ListViewItem listView = new ListViewItem(new string[] { friend.NickName, friend.Status });
                    listView.Tag = friend;
                    lVMyFriends.Items.Add(listView);
                }
            }
            userName.Text = UserName;
        }

        private void Meun_Load(object sender, EventArgs e)
        {
         
        }
        //public void Client_GetMyFriendsResponse(object sender, Tuple<int, List<User>> result)
        //{
        //    Invoke(new Action(() =>
        //    {
        //        MyFriends = result.Item2;
        //        foreach (TreeNode node in TVFriends.Nodes)
        //        {
        //            foreach (var friend in MyFriends)
        //            {

        //                //将姓名子节点加到姓名父节点上去
        //                TreeNode n = new TreeNode(friend.NickName);
        //                n.Tag = friend;
        //                node.Nodes.Add(n);
        //                lVMyFriends.Items.Add(new ListViewItem(new string[] { friend.NickName, "在线"}));
        //            }
        //        }
        //    }));
        //}
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
            FormSearch formSearch = new FormSearch(Client, UserName,this.MyFriends);
            formSearch.Show();

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
                    //将姓名子节点加到姓名父节点上去
                    ListViewItem listView = new ListViewItem(new string[] { firnedInfo.NickName, firnedInfo.Status });
                    listView.Tag = firnedInfo;
                    lVMyFriends.Items.Add(listView);
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
            this.MyFriends.Add(user);
            Invoke(new Action(() =>
            {
                ListViewItem listView = new ListViewItem(new string[] { user.NickName, user.Status });
                listView.Tag = user;
                lVMyFriends.Items.Add(listView);
            }));
            MessageBox.Show("用户" + user.NickName + "您添加为好友");
        }
        //好友登录通知好友地址
        private void Client_FriendLoginNotice(object sender, Tuple<string, string> e)
        {
            if (e != null && this.UserName != e.Item1)
            {
                Invoke(new Action(() =>
                {
                    string FriendUserName = e.Item1;
                    string Address = e.Item2;
                    for (int i = 0; i < this.MyFriends.Count; i++)
                    {
                        if (this.MyFriends[i].UserName.Equals(FriendUserName))
                        {
                            this.MyFriends[i].Address = Address;
                            this.MyFriends[i].Status = "在线";
                        }
                    }
                    for (int i = 0; i < lVMyFriends.Items.Count; i++)
                    {
                        User userInfo = lVMyFriends.Items[i].Tag as User;
                        if (FriendUserName.Equals(userInfo.UserName))
                        {
                            //将在线好友状态加进去
                            lVMyFriends.Items[i].SubItems[1].Text = "在线";
                        }
                    }
                }));
            }

        }
        //双击好友聊天
        private void lVMyFriends_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = lVMyFriends.HitTest(e.X, e.Y);
            var listView = info.Item as ListViewItem;
            if (listView.Text.ToString().Equals("我的好友"))
            {
                MessageBox.Show("请选择一名好友！");
                return;
            }
            if (listView == null) { MessageBox.Show("请选择一名好友"); return; }
            //好友信息
            User userInfo = (User)listView.Tag;
            if (!Chats.ContainsKey(userInfo.UserName))
            {
                Chats[userInfo.UserName] = new FormChat(UserName, userInfo.UserName, listView.Text, userInfo.Address, Client);
            }
            Chats[userInfo.UserName].Show();
            Chats[userInfo.UserName].BringToFront();
        }
        // 关闭程序退出登录
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //退出登录
            Client.Logout(UserName);
            Application.Exit();
        }
        //好友退出通知
        private void Client_LogoutResponse(object sender, Tuple<int, string> e)
        {
            if (e != null && this.UserName != e.Item2)
            {
                Invoke(new Action(() =>
                {
                    string LogoutName = e.Item2;
                    for (int i = 0; i < this.MyFriends.Count; i++)
                    {
                        if (this.MyFriends[i].UserName.Equals(LogoutName))
                        {
                            this.MyFriends[i].Address = null;
                            this.MyFriends[i].Status = "离线";
                        }
                    }
                    for (int i = 0; i < lVMyFriends.Items.Count; i++)
                    {
                        User userInfo = lVMyFriends.Items[i].Tag as User;
                        if (LogoutName.Equals(userInfo.UserName))
                        {
                            //将在线好友状态加进去
                            lVMyFriends.Items[i].SubItems[1].Text = "离线";
                        }
                    }
                }));
            }

        }
    }
}
