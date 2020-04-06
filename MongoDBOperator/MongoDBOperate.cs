using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBOperator
{
    public class MongoDBOperate
    {
        MongoDBHelper<User> UserHelper = new MongoDBHelper<User>("user");
        //注册
        /**
         * code 0 成功
         * 
         * code 1 数据库已存在
         * code -1 服务出错
         * **/
        public int RegisterUser(User userInfo)
        {
            int code = -1;
            try
            {

                Document filter = new Document();
                filter.Add("UserName", userInfo.UserName);
                List<User> list = UserHelper.SelectMore(filter);
                if (list.Count > 0)
                {
                    code = 1;
                }
                else
                {
                    UserHelper.Insert(userInfo);
                    code = 0;
                }
            }
            catch (Exception ex)
            {
                code = -1;
            }
            return code;
        }
        /**
         *code 0 成功
        *
        * code 1 登录失败
        ***/
        public int login(string userName, string passWord)
        {
            int code = -1;
            try
            {
                Document filter = new Document();
                filter.Add("UserName", userName);
                filter.Add("Password", passWord);
                User user = UserHelper.SelectOne(filter);
                if (user == null)
                {
                    code = 1;
                }
                else
                {
                    code = 0;
                }
            }
            catch (Exception ex)
            {
                code = -1;
            }
            return code;
        }

        //查询好友
        public List<User> SearchFriends(string condition)
        {
            // TODO: 数据库操作
            List<User> list = UserHelper.SelectALl();
            return list;
        }
        //寻找我的好友
        public List<User> GetMyFriends(string Username)
        {
            List<User> users = new List<User>();
            Document filter = new Document();
            filter.Add("UserID", Username);
            List<Friends> friends = FriendsHelper.SelectMore(filter);   
            foreach(var friend in friends)
            {
                filter = new Document();
                filter.Add("UserName", friend.FriendID);
                User userInfo = UserHelper.SelectOne(filter);
                users.Add(userInfo);
            }
            return users;
        }
        MongoDBHelper<Friends> FriendsHelper = new MongoDBHelper<Friends>("friends");

        public void AddFriend(Friends friends)
        {
            FriendsHelper.Insert(friends);
        }
    }
}
