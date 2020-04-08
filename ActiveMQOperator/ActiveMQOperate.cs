using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Newtonsoft.Json;
using System;

namespace ActiveMQOperator
{
    public class ActiveMQOperate
    {
        IConnectionFactory factory;
        IConnection connection;
        ISession session;
        ITextMessage message;
        IMessageConsumer consumer;
        public void Connect(string listenAddress)
        {
            //MQ地址：tcp://localhost:61616
            factory = new ConnectionFactory("tcp://localhost:61616");
            connection = factory.CreateConnection();
            //启动连接，监听的话要主动启动连接
            connection.Start();
            //通过连接创建一个会话
            session = connection.CreateSession();
            //通过会话创建一个消费者，这里就是Queue这种会话类型的监听参数设置
            IMessageConsumer consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue(listenAddress));
            //注册监听事件
            consumer.Listener += new MessageListener(consumer_Listener);
        }

        void consumer_Listener(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;

            Received?.Invoke(this, msg.Text);
        }

        public void Close()
        {
            if (connection != null)
            {
                connection.Stop();
                connection.Close();
            }
        }

        public void Send(string address, string package)
        {
            //通过连接创建Session会话
            using (ISession session = connection.CreateSession())
            {
                //通过会话创建生产者，方法里面new出来的是MQ中的Queue
                IMessageProducer prod = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue(address));
                //创建一个发送的消息对象
                ITextMessage message = prod.CreateTextMessage();
                //给这个对象赋实际的消息
                message.Text = package;
                //生产者把消息发送出去，几个枚举参数MsgDeliveryMode是否长链，MsgPriority消息优先级别，发送最小单位，当然还有其他重载
                prod.Send(message, MsgDeliveryMode.NonPersistent, MsgPriority.Normal, TimeSpan.MinValue);
            }
        }

        public event EventHandler<string> Received;
    }

    public class Package
    {
        public Guid SessionID { get; set; }

        /// <summary>
        /// 消息类型。Request，Response，Chat
        /// </summary>
        public string Type { get; set; }
        //调用方法名：RegisterUser ， UserLogin  or findfriends。。。。
        public string Method { get; set; }
        //聊天内容
        public string Data { get; set; }

        public Package(Guid ID, string Type, string Method, string Data)
        {
            SessionID = ID;
            this.Type = Type;
            this.Method = Method;
            this.Data = Data;
        }

        public override string ToString()
        {   //序列化（JsonConvert），将对象的状态信息转换为可以存储或传输的形式的过程
            return JsonConvert.SerializeObject(this);
        }
    }
}
