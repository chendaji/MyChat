using MongoDBOperator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ActiveMQOperator
{
    public class ActiveMQServer
    {
        ActiveMQOperate activeMQ = new ActiveMQOperate();

        public void Start()
        {
            activeMQ.Connect("MyChat");

            activeMQ.Received += ActiveMQ_Received;
        }

        //前面参数输入，后面返回参数
        public event Func<Tuple<User>, int> RegisterUserRequest;

        public event Func<Tuple<string, string>, Tuple<int, List<User>>> UserLoginRequest;

        public event Func<Tuple<string, string>, Tuple<int, List<User>>> SearchFriendsRequest;

        public event Func<Tuple<string, string>, int> AddFriendRequest;

        public event Func<Tuple<string>, Tuple<int, List<User>>> GetMyFriendsRequest;

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
                                    var Result = UserLoginRequest?.Invoke(new Tuple<string, string>(data.Username, data.Password));

                                    // TODO:响应客户端。
                                    activeMQ.Send(data.Address, new Package(package.SessionID, "Response", package.Method, JsonConvert.SerializeObject(new
                                    {
                                        Result
                                    })).ToString());
                                }

                                break;
                            case "SearchFriends":
                                {
                                    var data = JsonConvert.DeserializeAnonymousType(package.Data, new
                                    {
                                        Address = default(string),
                                        Condition = default(string)
                                    });

                                    if (data.Address == null) break;

                                    // TODO:数据库处理。
                                    var Result = SearchFriendsRequest?.Invoke(new Tuple<string, string>(data.Address, data.Condition));

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

                                    // TODO:响应客户端。
                                    activeMQ.Send(data.Address, new Package(package.SessionID, "Response", package.Method, JsonConvert.SerializeObject(new
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
                            default:
                                break;
                        }
                    }
                    break;
                case "Chat":

                    break;
                default:
                    break;
            }
        }


    }
}
