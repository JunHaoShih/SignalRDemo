using DataAccessLib.Models;
using DataAccessLib.Models.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLib.DAOs
{
    public interface IChatRoomDao
    {
        /// <summary>
        /// 用topic名稱取得聊天室(topic為惟一值)
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        ChatRoom GetChatRoom(Topic topic);

        /// <summary>
        /// 新增一個聊天室
        /// </summary>
        /// <param name="chatRoom">新聊天室</param>
        /// <returns></returns>
        ChatRoom InsertChatRoom(ChatRoom chatRoom);
    }
}
