using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Listener
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri listenUri = new Uri(@"http://127.0.0.1:9999/listener");
            Binding binding = new BasicHttpBinding();
            IChannelListener<IReplyChannel> channelListener = binding.BuildChannelListener<IReplyChannel>(listenUri);
            channelListener.Open();

            IReplyChannel channel = channelListener.AcceptChannel(TimeSpan.MaxValue);
            channel.Open();

            Console.WriteLine("开始监听...");

            while (true)
            {
                RequestContext requestContext = channel.ReceiveRequest(TimeSpan.MaxValue);
                Console.WriteLine("接收到的请求消息： \n{0}", requestContext.RequestMessage);
                requestContext.Reply(CreateReplyMessage(binding));
            }

        }

        private static Message CreateReplyMessage(Binding binding)
        {
            string action = "urn:artech.com/reply";
            string body = "这是一个简单的回复消息！";
            return Message.CreateMessage(binding.MessageVersion, action, body);
        }
    }
}
