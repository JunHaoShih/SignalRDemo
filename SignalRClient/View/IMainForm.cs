using DataAccessLib.Models;
using DataAccessLib.Models.DataTypes;
using SignalRClient.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRClient.View
{
    public interface IMainForm
    {
        /// <summary>
        /// 連線按鈕click事件
        /// </summary>
        event Action<SignalRProtocol, string, string, int, string, string> OnConnectionClicked;

        /// <summary>
        /// 登出按鈕click事件
        /// </summary>
        event EventHandler OnDisconnectClicked;

        /// <summary>
        /// 加入聊天室click事件
        /// </summary>
        event EventHandler OnJoinChatClicked;

        /// <summary>
        /// 設定連線UI是否可以使用
        /// </summary>
        /// <param name="enable"></param>
        void EnableConnectionUI(bool enable);

        /// <summary>
        /// 設定panelCenter是否可以使用
        /// </summary>
        /// <param name="enable"></param>
        void EnablePanelCenter(bool enable);

        /// <summary>
        /// 嘗試為topic新增一個tabpage，若該topic不存在，則新增tabpage、並用chatControl回傳<br/>
        /// 反之method回傳false
        /// </summary>
        /// <param name="topic">特定topic</param>
        /// <param name="chatControl">若新增成功，則回傳該ChatControl</param>
        /// <returns>如果新增成功，則回傳true，反之則為</returns>
        bool TryAddChatTabPage(Topic topic, out ChatControl chatControl);

        /// <summary>
        /// 將特定Topic的訊息加到到對應的聊天頁面
        /// </summary>
        /// <param name="topic">topic</param>
        /// <param name="chatMessage">topic的聊天訊息</param>
        void AppendTopicMessage(string topic, ChatRoomMessage chatMessage);

        /// <summary>
        /// 清除聊天的tabpage與dictionary
        /// </summary>
        void ClearAllTopics();
    }
}
