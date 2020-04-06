using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBOperator
{
    public class Friends
    {
        string userID;
        string friendID;

        public string UserID { get => userID; set => userID = value; }
        public string FriendID { get => friendID; set => friendID = value; }
    }
}
