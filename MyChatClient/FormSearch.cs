using ActiveMQOperator;
using MongoDBOperator;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyChat
{
    public partial class FormSearch : Form
    {
        ActiveMQClient Client;
        string UserName;
        List<User> MyFriends;

        public FormSearch(ActiveMQClient Client, string UserName, List<User> MyFriends)
        {
            InitializeComponent();
            this.Client = Client;
            this.UserName = UserName;
            this.MyFriends = MyFriends;
            Client.FriendsSearchedResponse += Client_FriendsSearchedResponse;
        }

        private void Client_FriendsSearchedResponse(object sender, List<User> friends)
        {
            lVFriends.Items.Clear();
            foreach (var friend in friends)
            {
                if (friend.UserName.Equals(UserName))
                {
                    continue;
                }

                lVFriends.Items.Add(new ListViewItem(new string[]
                      {
                           friend.UserName,friend.NickName,friend.Status
                     }));
            }
        }

        private void bSearchFriend_Click(object sender, EventArgs e)
        {
            Client.SearchFriends(this.UserName, "");
        }


        private void bAddFriend_Click(object sender, EventArgs e)
        {
            if (lVFriends.SelectedItems != null)
            {
                foreach (ListViewItem item in lVFriends.SelectedItems)
                {
                    foreach (var userInfo in MyFriends)
                    {
                        if (userInfo.UserName.Equals(item.Text))
                        {
                            MessageBox.Show("该用户已经是您的好友");
                        }
                        else
                        {
                            Client.AddFriend(UserName, item.Text);
                        }
                    }
                }
            }

        }

    }
}
