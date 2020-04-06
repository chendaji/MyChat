using ActiveMQOperator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActiveMQClientTest
{
    class MQClient
    {
        static ActiveMQOperate activeMQ = new ActiveMQOperate();

        static void Main(string[] args)
        {
            Console.WriteLine("ActiveMQ Client Start Test...");

            activeMQ.Received += ActiveMQ_Received;

            var Address = Guid.NewGuid().ToString().ToUpper();
            activeMQ.Connect(Address);

            Thread.Sleep(3000);

            Package package = new Package(
                Guid.NewGuid(),
                "Request",
                "Connect",
                JsonConvert.SerializeObject(new
                {
                    Address
                }));

            activeMQ.Send("MyChat", package.ToString());

            Console.ReadLine();
        }

        private static void ActiveMQ_Received(object sender, string e)
        {
            Package package = JsonConvert.DeserializeObject<Package>(e);

            Console.WriteLine(package.SessionID);
            Console.WriteLine(package.Type);
            Console.WriteLine(package.Method);
            Console.WriteLine(package.Data);

            var data = JsonConvert.DeserializeAnonymousType(package.Data, new { Result = default(string) });

            Console.WriteLine(data.Result);
        }
    }
}
