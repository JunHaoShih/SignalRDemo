using DataAccessLib.Models.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalRClient.SignalR
{
    /// <summary>
    /// 暴露給外部操作SignalRClientHandler的interface
    /// </summary>
    public interface ISignalRClientHandler
    {
        /// <summary>
        /// 使用者名稱
        /// </summary>
        UserName UserName { get; }

        /// <summary>
        /// 密碼
        /// </summary>
        Password Password { get; }

        /// <summary>
        /// SignalR server url
        /// </summary>
        string Url { get; }

        /// <summary>
        /// 啟動客戶端
        /// </summary>
        /// <returns></returns>
        Task StartAsync();

        /// <summary>
        /// 停止客戶端
        /// </summary>
        /// <returns></returns>
        Task StopAsync();

        /// <summary>
        /// 發布訊息
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="chatText"></param>
        /// <returns></returns>
        Task PublishAsync(Topic topic, ChatText chatText);

        /// <summary>
        /// 訂閱topic
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        Task SubscribeAsync(Topic topic);
    }
}
