using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLib.SignalR
{
    /// <summary>
    /// 由於SignalR是client與server互相invoke對方的method，因此此class紀錄server端的method名稱，統一控管
    /// </summary>
    public class HubServer
    {
        /// <summary>
        /// Server端處理登入的method名稱
        /// </summary>
        public const string Login = "Login";

        /// <summary>
        /// Server端處理發送訊息的method名稱
        /// </summary>
        public const string SendTopicMessage = "SendTopicMessage";

        /// <summary>
        /// Server端處理訂閱的method名稱
        /// </summary>
        public const string Subscribe = "Subscribe";
    }
}
