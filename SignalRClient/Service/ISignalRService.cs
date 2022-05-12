using DataAccessLib.Models.DataTypes;
using SignalRClient.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRClient.Service
{
    /// <summary>
    /// SignalRService的interface
    /// </summary>
    public interface ISignalRService
    {
        /// <summary>
        /// 連線到SignalR server
        /// </summary>
        /// <param name="protocol"></param>
        /// <param name="path"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        void ConnectToSignalRServer(SignalRProtocol protocol, string path, string ip, int port, string user, string password);

        /// <summary>
        /// 與SignalR server中斷連線
        /// </summary>
        void DisconnectFromSignalRServer();

        /// <summary>
        /// 加入聊天室
        /// </summary>
        /// <param name="topic">聊天室名稱</param>
        void JoinChat(Topic topic);
    }
}
