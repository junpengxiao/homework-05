﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace GoldNumberServer
{
    public partial class ComSession : AppSession<ComSession>
    {
        public string UserId;
        public bool Joined;
        public bool Commited;
        public double CommitNumber;

        protected override void OnSessionStarted()
        {
            this.Send("Welcome to SuperSocket Telnet Server");
        }

        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            this.Send("Unknow request");
        }

        protected override void HandleException(Exception e)
        {
            this.Send("Application error: {0}", e.Message);
        }

        protected override void OnSessionClosed(CloseReason reason)
        {
            base.OnSessionClosed(reason);
            if (UserId != null) (AppServer as PlayServer).Logout(UserId);
        }
    }
}
