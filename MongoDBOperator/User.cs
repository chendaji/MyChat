using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBOperator
{
    public class User
    {
        String id;
        String userName;
        String password;
        String nickName;
        int age;
        String sex;
        // 在线地址
        string address;

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string NickName { get => nickName; set => nickName = value; }
        public int Age { get => age; set => age = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Id { get => id; set => id = value; }
        public string Address { get => address; set => address = value; }
    }
}
