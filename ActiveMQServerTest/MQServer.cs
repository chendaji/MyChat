using ActiveMQOperator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveMQServerTest
{
    class MQServer
    {
        static ActiveMQOperate activeMQ = new ActiveMQOperate();

        static void Main(string[] args)
        {
            Console.WriteLine("ActiveMQ Server Start Test...");


            activeMQ.Connect("MyChat");
            activeMQ.Received += ActiveMQ_Received;

            Console.ReadLine();
        }

        private static void ActiveMQ_Received(object sender, string e)
        {
            Console.WriteLine(e);

            Package package = JsonConvert.DeserializeObject<Package>(e);
            Console.WriteLine(package.SessionID);
            Console.WriteLine(package.Type);
            Console.WriteLine(package.Method);
            Console.WriteLine(package.Data);
            var data = JsonConvert.DeserializeAnonymousType(package.Data, new { Address = default(string) });

            activeMQ.Send(data.Address, new Package(package.SessionID, "Response", package.Method, JsonConvert.SerializeObject(new
            {
                Result = true
            })).ToString());
        }
    }
}
