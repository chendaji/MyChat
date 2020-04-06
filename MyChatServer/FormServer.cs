using ActiveMQOperator;
using MongoDBOperator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyChatServer
{
    public partial class FormServer : Form
    {
        ActiveMQServer Server = new ActiveMQServer();

        MongoDBOperate mongoDBOperate = new MongoDBOperate();

        public FormServer()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //连接 MQ
            Server.Start();
            Server.RegisterUserRequest += Server_RegisterUserRequest;
            Server.UserLoginRequest += Server_UserLoginRequest;
            Server.SearchFriendsRequest += Server_SearchFriendsRequest;
            Server.AddFriendRequest += Server_AddFriendRequest;
            Server.GetMyFriendsRequest += Server_GetMyFriendsRequest;
            Server.GetUserInfoRequest += Server_GetUserInfoRequest;
            Server.UpdateUserInfoRequest += Server_UpdateUserInfoRequest;
        }

        //发起等登陆请求
        private Tuple<int, List<User>> Server_UserLoginRequest(Tuple<string, string, string> arg)
        {
            int code = -1;
            List<User> friends = new List<User>();
            Invoke(new Action(() =>
            {
                // 校验密码
                code = mongoDBOperate.login(arg.Item1, arg.Item2);
                //成功登陆就打印出来
                if (code == 0)
                {
                    //获取该用户信息
                    User userInfo = mongoDBOperate.GetUserInfo(arg.Item1);
                    // 查询该用户所有好友
                    List<User> users = mongoDBOperate.GetMyFriends(arg.Item1);
                    friends.AddRange(users);
                    // 获取在线好友
                    /*
                    friends.Add(JsonConvert.SerializeObject(new
                    {
                        Username = "",
                        Nickname = "",
                        Address = "",//不在线时为空
                    }));
                    */

                    // 将在线用户加入在线列表。
                    lBUsername.Items.Add(arg.Item1);
                    lVOnlineUsers.Items.Add(new ListViewItem(new string[]
               {
                     userInfo.UserName,userInfo.NickName,arg.Item3
               }));
                }
            }));
            return new Tuple<int, List<User>>(code, friends);
        }
        //发起注册请求
        private int Server_RegisterUserRequest(Tuple<User> e)
        {
            User userInfo = e.Item1;
            int code = -1;
            Invoke(new Action(() =>
            {
                code = mongoDBOperate.RegisterUser(userInfo);
            }));
            return code;
        }

        //查找好友请求
        private Tuple<int, List<User>> Server_SearchFriendsRequest(Tuple<string, string> e)
        {
            List<User> allUsers = new List<User>();
            int code = -1;
            Invoke(new Action(() =>
            {
                //查询所有用户
                allUsers = mongoDBOperate.SearchFriends(e.Item1);
                code = 0;
            }));

            return new Tuple<int, List<User>>(code, allUsers);
        }

        //添加好友，添加本人ID和需要添加的好友ID
        private int Server_AddFriendRequest(Tuple<string, string> e)
        {
            Friends friend = new Friends();
            friend.UserID = e.Item1;
            friend.FriendID = e.Item2;
            int code = -1;
            Invoke(new Action(() =>
            {
                mongoDBOperate.AddFriend(friend);
                code = 0;
            }));
            return code;
        }
        private Tuple<int, List<User>> Server_GetMyFriendsRequest(Tuple<string> e)
        {
            int code = -1;
            List<User> MyFriends = new List<User>();
            Invoke(new Action(() =>
            {
                MyFriends = mongoDBOperate.GetMyFriends(e.Item1);
                code = 0;
            }));
            return new Tuple<int, List<User>>(code, MyFriends);
        }
        private Tuple<int, User> Server_GetUserInfoRequest(Tuple<string> e)
        {
            int code = -1;
            User userInfo = new User();
            Invoke(new Action(() =>
            {
                userInfo = mongoDBOperate.GetUserInfo(e.Item1);
                code = 0;
            }));
            return new Tuple<int, User>(code, userInfo);
        }
        //更新用户信息
        private Tuple<int> Server_UpdateUserInfoRequest(Tuple<User> e)
        {
            int code = -1;
            Invoke(new Action(() =>
            {
                mongoDBOperate.UpdateUserInfo(e.Item1);
                code = 0;
            }));
            return new Tuple<int>(code);
        }

    }
}
