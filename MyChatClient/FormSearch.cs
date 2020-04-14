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
    public partial class FormSearch : Form
    {
        ActiveMQClient Client;
        string UserName;

        public FormSearch(ActiveMQClient Client, string UserName)
        {
            InitializeComponent();
            this.Client = Client;
            this.UserName = UserName;

            Client.FriendsSearchedResponse += Client_FriendsSearchedResponse;
           // Client.AddFriendResponse += Client_AddFriendResponse;
        }

        private void Client_FriendsSearchedResponse(object sender, List<User> friends)
        {
            lVFriends.Items.Clear();
            foreach (var friend in friends)
            {
                //排除自己，不塞自己进去
                if (!UserName.Equals(friend.UserName))
                {
                    lVFriends.Items.Add(new ListViewItem(new string[]
                  {
                     friend.UserName,friend.NickName,"离线"
                  }));
                }

            }
        }
        private void Client_AddFriendResponse(object sender, Tuple<int, User> e)
        {
            Invoke(new Action(() =>
            {
                if (e.Item1 == 0)
                {
                    MessageBox.Show("添加好友成功");

                }
                else
                {
                    MessageBox.Show("添加好友失败");
                }
            }));

        }

        private void bSearchFriend_Click(object sender, EventArgs e)
        {
            Client.SearchFriends("");
        }


        private void bAddFriend_Click(object sender, EventArgs e)
        {
            if (lVFriends.SelectedItems != null)
            {
                foreach (ListViewItem item in lVFriends.SelectedItems)
                {
                    Client.AddFriend(UserName, item.Text);
                }
            }

        }

    }
}
