﻿using MongoDBOperator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ActiveMQOperator
{
    public class ActiveMQServer
    {
        ActiveMQOperate activeMQ = new ActiveMQOperate();
        ActiveMQOperate TopicactiveMQ = new ActiveMQOperate();

        public void Start()
        {
            activeMQ.Connect("MyChat");
            TopicactiveMQ.TopicConnect();
            activeMQ.Received += ActiveMQ_Received;
            TopicactiveMQ.Received += ActiveMQ_Received;
        }

        //前面参数输入，后面返回参数
        public event Func<Tuple<User>, int> RegisterUserRequest;

        public event Func<Tuple<string, string, string>, Tuple<int, List<User>>> UserLoginRequest;

        public event Func<Tuple<string, string, string>, Tuple<int, List<User>>> SearchFriendsRequest;
        //返回自己和朋友信息 code eurrentUser friend
        public event Func<Tuple<string, string>, Tuple<int, User, User>> AddFriendRequest;

        public event Func<Tuple<string>, Tuple<int, List<User>>> GetMyFriendsRequest;

        public event Func<Tuple<string>, Tuple<int, User>> GetUserInfoRequest;

        public event Func<Tuple<User>, Tuple<int>> UpdateUserInfoRequest;

        public event Func<string, int> LogoutRequest;

        private void ActiveMQ_Received(object sender, string e)
        {
            var package = JsonConvert.DeserializeObject<Package>(e);

            switch (package.Type)
            {
                case "Request":
                    {
                        switch (package.Method)
                        {
                            case "RegisterUser":
                                {
                                    var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                    {
                                        Address = default(string),
                                        user = default(User),
                                        //Username = default(string),
                                        //Password = default(string),
                                        //Info = default(string)
                                    });

                                    // TODO:数据库处理。
                                    var Result = RegisterUserRequest?.Invoke(new Tuple<User>(data.user));
                                    if (data.Address == null) break;
                                    // TODO:响应客户端。
                                    activeMQ.Send(data.Address, new Package(package.SessionID, "Response", package.Method, JsonConvert.SerializeObject(new
                                    {
                                        Result
                                    })).ToString());
                                }
                                break;
                            case "UserLogin":
                                {
                                    var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                    {
                                        Address = default(string),
                                        Username = default(string),
                                        Password = default(string),
                                    });

                                    if (data.Address == null) break;

                                    // TODO:数据库处理。
                                    var Result = UserLoginRequest?.Invoke(new Tuple<string, string, string>(data.Username, data.Password, data.Address));

                                    // TODO:响应客户端。
                                    activeMQ.Send(data.Address, new Package(package.SessionID, "Response", package.Method, JsonConvert.SerializeObject(new
                                    {
                                        Result
                                    })).ToString());
                                    // 广播地址
                                    TopicactiveMQ.TopicSend("Topic", new Package(package.SessionID, "Notice", "FriendLoginNotice", JsonConvert.SerializeObject(new
                                    {
                                        Username = data.Username,
                                        Address = data.Address
                                    })).ToString());
                                }

                                break;
                            case "SearchFriends":
                                {
                                    var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                    {
                                        Address = default(string),
                                        MyUserName = default(string),
                                        Condition = default(string)
                                    });

                                    if (data.Address == null) break;

                                    // TODO:数据库处理。
                                    var Result = SearchFriendsRequest?.Invoke(new Tuple<string, string, string>(data.Address, data.MyUserName, data.Condition));

                                    // TODO:响应客户端。
                                    activeMQ.Send(data.Address, new Package(package.SessionID, "Response", package.Method, JsonConvert.SerializeObject(new
                                    {
                                        Result
                                    })).ToString());
                                }
                                break;
                            case "AddFriend":
                                {
                                    var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                    {
                                        Address = default(string),
                                        MyUserID = default(string),
                                        FriendID = default(string)
                                    });

                                    if (data.Address == null) break;

                                    // TODO:数据库处理。
                                    var Result = AddFriendRequest?.Invoke(new Tuple<string, string>(data.MyUserID, data.FriendID));

                                    // 响应客户端,在主界面绑定好友信息。
                                    activeMQ.Send(data.Address, new Package(package.SessionID, "Response", package.Method, JsonConvert.SerializeObject(new
                                    {
                                        Result
                                    })).ToString());

                                    // 通知被加好友方
                                    activeMQ.Send(Result.Item3.Address, new Package(package.SessionID, "Notice", package.Method, JsonConvert.SerializeObject(new
                                    {
                                        Result
                                    })).ToString());
                                }
                                break;
                            case "GetMyFriends":
                                {
                                    var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                    {
                                        Address = default(string),
                                        UserName = default(string)
                                    });

                                    if (data.Address == null) break;

                                    // TODO:数据库处理。
                                    var Result = GetMyFriendsRequest?.Invoke(new Tuple<string>(data.UserName));

                                    // TODO:响应客户端。
                                    activeMQ.Send(data.Address, new Package(package.SessionID, "Response", package.Method, JsonConvert.SerializeObject(new
                                    {
                                        Result
                                    })).ToString());
                                }
                                break;
                            case "GetUserInfo":
                                {
                                    var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                    {
                                        Address = default(string),
                                        UserName = default(string)
                                    });

                                    if (data.Address == null) break;

                                    // TODO:数据库处理。
                                    var Result = GetUserInfoRequest?.Invoke(new Tuple<string>(data.UserName));

                                    // TODO:响应客户端。
                                    activeMQ.Send(data.Address, new Package(package.SessionID, "Response", package.Method, JsonConvert.SerializeObject(new
                                    {
                                        Result
                                    })).ToString());
                                }
                                break;
                            case "UpdateUserInfo":
                                {
                                    var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                    {
                                        Address = default(string),
                                        User = default(User)
                                    });

                                    if (data.Address == null) break;

                                    // TODO:数据库处理。
                                    var Result = UpdateUserInfoRequest?.Invoke(new Tuple<User>(data.User));

                                    // TODO:响应客户端。
                                    activeMQ.Send(data.Address, new Package(package.SessionID, "Response", package.Method, JsonConvert.SerializeObject(new
                                    {
                                        Result
                                    })).ToString());
                                }
                                break;
                            case "Logout":
                                {
                                    var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                    {
                                        Address = default(string),
                                        UserName = default(string)
                                    });

                                    if (data.Address == null) break;

                                    // 数据库处理。
                                    var Result = LogoutRequest?.Invoke(data.UserName);

                                    // 广播好友退出信息
                                    TopicactiveMQ.TopicSend("Topic", new Package(package.SessionID, "Notice", "Logout", JsonConvert.SerializeObject(new
                                    {
                                        Result,
                                        data.UserName
                                    })).ToString());
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        public void FriendAdded(string Address, string FriendUsername, string FriendNickname, string FriendAddress)
        {
            var id = Guid.NewGuid();

            var package = new Package(id, "Notice", nameof(FriendAdded), JsonConvert.SerializeObject(new
            {
                Address,
                FriendUsername,
                FriendNickname,
                FriendAddress,
            }));

            //Sessions[id] = package;

            activeMQ.Send("MyChat", package.ToString());
        }
    }
}
