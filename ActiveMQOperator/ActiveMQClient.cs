﻿using MongoDBOperator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveMQOperator
{
    public class ActiveMQClient
    {
        ActiveMQOperate activeMQ = new ActiveMQOperate();
        ActiveMQOperate TopicactiveMQ = new ActiveMQOperate();
        public string Address { get; private set; }

        public void Start(Guid id)
        {
            // Address = Guid.NewGuid().ToString().ToUpper();
            Address = id.ToString().ToUpper();
            activeMQ.Connect(Address);
            activeMQ.Received += ActiveMQ_Received;
            TopicactiveMQ.TopicConnect();
            TopicactiveMQ.Received += ActiveMQ_Received;
        }


        public event EventHandler<int> RegisterUserResponse;
        public event EventHandler<Tuple<int, List<User>>> UserLoginResponse;
        public event EventHandler<List<User>> FriendsSearchedResponse;
        public event EventHandler<Tuple<int, User, User>> AddFriendResponse;
        public event EventHandler<Tuple<int, List<User>>> GetMyFriendsResponse;
        public event EventHandler<Tuple<int, User>> GetUserInfoResponse;
        public event EventHandler<Tuple<int>> UpdateUserInfoResponse;
        public event EventHandler<Tuple<int, string>> LogoutResponse;
        // friend login notice address
        public event EventHandler<Tuple<string, string>> FriendLoginNotice;

        public event EventHandler<Tuple<int, User, User>> FriendAddedNotice;

        //接收信息
        private void ActiveMQ_Received(object sender, string e)
        {
            var package = JsonConvert.DeserializeObject<Package>(e);

            switch (package.Type)
            {
                case "Response":
                    {
                        switch (package.Method)
                        {
                            case nameof(RegisterUser):
                                {
                                    if (Sessions.ContainsKey(package.SessionID))
                                    {
                                        var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                        {
                                            Result = default(int)
                                        });

                                        RegisterUserResponse?.Invoke(this, data.Result);
                                    }
                                }
                                break;
                            case nameof(UserLogin):
                                {
                                    if (Sessions.ContainsKey(package.SessionID))
                                    {
                                        var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                        {
                                            Result = default(Tuple<int, List<User>>)
                                        });

                                        UserLoginResponse?.Invoke(this, data.Result);
                                    }
                                }
                                break;
                            case nameof(SearchFriends):
                                {
                                    if (Sessions.ContainsKey(package.SessionID))
                                    {
                                        var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                        {
                                            Result = default(Tuple<int, List<User>>)
                                        });

                                        FriendsSearchedResponse?.Invoke(this, data.Result.Item2);
                                    }
                                }
                                break;
                            case nameof(AddFriend):
                                {
                                    if (Sessions.ContainsKey(package.SessionID))
                                    {
                                        var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                        {
                                            Result = default(Tuple<int, User, User>)
                                        });

                                        AddFriendResponse?.Invoke(this, data.Result);
                                    }
                                }
                                break;
                            case nameof(GetMyFriends):
                                {
                                    if (Sessions.ContainsKey(package.SessionID))
                                    {
                                        var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                        {
                                            Result = default(Tuple<int, List<User>>)

                                        });

                                        GetMyFriendsResponse?.Invoke(this, data.Result);
                                    }
                                }
                                break;
                            case nameof(GetUserInfo):
                                {
                                    if (Sessions.ContainsKey(package.SessionID))
                                    {
                                        var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                        {
                                            Result = default(Tuple<int, User>)

                                        });

                                        GetUserInfoResponse?.Invoke(this, data.Result);
                                    }
                                }
                                break;
                            case nameof(UpdateUserInfo):
                                {
                                    if (Sessions.ContainsKey(package.SessionID))
                                    {
                                        var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                        {
                                            Result = default(Tuple<int>)

                                        });

                                        UpdateUserInfoResponse?.Invoke(this, data.Result);
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case "Notice":
                    {
                        switch (package.Method)
                        {
                            case "AddFriend":
                                {

                                    var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                    {
                                        Result = default(Tuple<int, User, User>)
                                    });

                                    FriendAddedNotice?.Invoke(this, data.Result);
                                }
                                break;
                            //好友登录广播地址
                            case "FriendLoginNotice":
                                {
                                    if (!Sessions.ContainsKey(package.SessionID))
                                    {
                                        var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                        {
                                            Username = default(string),
                                            Address = default(string)
                                        }); ;

                                        FriendLoginNotice?.Invoke(this, new Tuple<string, string>(data.Username, data.Address));
                                    }
                                }
                                break;
                            case "Logout":
                                {
                                    if (!Sessions.ContainsKey(package.SessionID))
                                    {
                                        var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                        {
                                            Result = default(int),
                                            UserName = default(string)
                                        });

                                        LogoutResponse?.Invoke(this, new Tuple<int, string>(data.Result, data.UserName));
                                    }
                                }
                                break;
                        }
                    }
                    break;
                case "Chat":
                    {
                        switch (package.Method)
                        {
                            case "Text":
                                var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                {
                                    Username = default(string),
                                    Message = default(string)
                                });

                                ChatReceived?.Invoke(this, new Tuple<string, string>(data.Username, data.Message));
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

        Dictionary<Guid, Package> Sessions = new Dictionary<Guid, Package>();

        public void RegisterUser(User user)
        {
            var id = Guid.NewGuid();

            var package = new Package(id, "Request", nameof(RegisterUser), JsonConvert.SerializeObject(new
            {
                Address,
                user
            }));

            Sessions[id] = package;

            activeMQ.Send("MyChat", package.ToString());
        }

        public void UserLogin(Guid id, string Username, string Password)
        {
            //var id = Guid.NewGuid();

            var package = new Package(id, "Request", nameof(UserLogin), JsonConvert.SerializeObject(new
            {
                Address,
                Username,
                Password,
            }));

            Sessions[id] = package;

            activeMQ.Send("MyChat", package.ToString());
        }

        //查找好友（目前是还没条件查找，默认列出所有好友）
        public void SearchFriends(string myUserName,string Condition)
        {
            var id = Guid.NewGuid();
            var package = new Package(id, "Request", nameof(SearchFriends), JsonConvert.SerializeObject(new
            {
                Address,
                myUserName,
                Condition
            }));
            Sessions[id] = package;

            activeMQ.Send("MyChat", package.ToString());
        }

        //添加好友
        public void AddFriend(string MyUserID, string FriendID)
        {
            var id = Guid.NewGuid();
            var package = new Package(id, "Request", nameof(AddFriend), JsonConvert.SerializeObject(new
            {
                Address,
                MyUserID,
                FriendID
            }));
            Sessions[id] = package;

            activeMQ.Send("MyChat", package.ToString());
        }
        //通过用户的userName查找所有好友
        public void GetMyFriends(string UserName)
        {
            var id = Guid.NewGuid();
            var package = new Package(id, "Request", nameof(GetMyFriends), JsonConvert.SerializeObject(new
            {
                Address,
                UserName
            }));
            Sessions[id] = package;

            activeMQ.Send("MyChat", package.ToString());
        }
        //获取用户信息
        public void GetUserInfo(string UserName)
        {
            var id = Guid.NewGuid();
            var package = new Package(id, "Request", nameof(GetUserInfo), JsonConvert.SerializeObject(new
            {
                Address,
                UserName
            }));
            Sessions[id] = package;

            activeMQ.Send("MyChat", package.ToString());
        }
        //更新用户信息
        public void UpdateUserInfo(User user)
        {
            var id = Guid.NewGuid();
            var package = new Package(id, "Request", nameof(UpdateUserInfo), JsonConvert.SerializeObject(new
            {
                Address,
                user
            }));
            Sessions[id] = package;

            activeMQ.Send("MyChat", package.ToString());
        }

        public event EventHandler<Tuple<string, string>> ChatReceived;

        public void Chat(string Address, string Username, string Message)
        {
            Package package = new Package(
               Guid.NewGuid(),
               "Chat",
               "Text",
              JsonConvert.SerializeObject(new
              {
                  Username,
                  Message
              }));
            activeMQ.Send(Address, package.ToString());
        }

        public void Logout(string UserName)
        {
            var id = Guid.NewGuid();
            var package = new Package(id, "Request", nameof(Logout), JsonConvert.SerializeObject(new
            {
                Address,
                UserName
            }));
            Sessions[id] = package;

            activeMQ.Send("MyChat", package.ToString());
        }
    }
}
