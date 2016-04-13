using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CustomChannels
{
    public class SimpleRequestChannel : ChannelBase, IRequestChannel
    {
        private IRequestChannel _innerChannel;
        public SimpleRequestChannel(ChannelManagerBase channelManager, IRequestChannel innerChannel) : base(channelManager)
        {
            _innerChannel = innerChannel;
        }


        #region IRequestChannel

        public EndpointAddress RemoteAddress
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Uri Via
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IAsyncResult BeginRequest(Message message, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public Message EndRequest(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public Message Request(Message message)
        {
            throw new NotImplementedException();
        }

        public Message Request(Message message, TimeSpan timeout)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ChannelBase

        protected override void OnAbort()
        {
            PrintHelper.Print(this, "OnAbort");
            this._innerChannel.Abort();
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        protected override void OnClose(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
