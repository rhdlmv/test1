using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            //Uri listenUri = new Uri(@"http://127.0.0.1:9999/listener");
            //Binding binding = new BasicHttpBinding();
            //IChannelFactory<IRequestChannel> channelFactory = binding.BuildChannelFactory<IRequestChannel>();
            //channelFactory.Open();

            //IRequestChannel channel = channelFactory.CreateChannel(new EndpointAddress(listenUri));
            //channel.Open();

            //Message replyMessage = channel.Request(CreateRequestMessage(binding));
            //Console.WriteLine("接收到的回复消息:\n{0}", replyMessage);


            Console.WriteLine(TimeSpan.FromDays(30));


            Console.Read();
        }

        private static Message CreateRequestMessage(Binding binding)
        {
            string action = "urn:artech.com/request";
            string body = "这是一个简单的请求消息！";
            return Message.CreateMessage(binding.MessageVersion, action, body);
        }
    }
}
