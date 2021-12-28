using DataAccessLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLib.DAOs
{
    public interface IParticipantDao
    {
        /// <summary>
        /// 取得參與者
        /// </summary>
        /// <param name="chatUser">聊天室使用者</param>
        /// <param name="chatRoom">聊天室</param>
        /// <returns></returns>
        Participant GetParticipant(ChatUser chatUser, ChatRoom chatRoom);

        /// <summary>
        /// 取得該聊天室的所有參與者
        /// </summary>
        /// <param name="chatRoom"></param>
        /// <returns></returns>
        IEnumerable<Participant> GetParticipantsByChatRoom(ChatRoom chatRoom);

        /// <summary>
        /// 取得該使用者的所有聊天室
        /// </summary>
        /// <param name="chatUser"></param>
        /// <returns></returns>
        IEnumerable<Participant> GetParticipantsByChatUser(ChatUser chatUser);

        /// <summary>
        /// 使用者訂閱一個聊天室
        /// </summary>
        /// <param name="chatUser">聊天室使用者</param>
        /// <param name="chatRoom">聊天室</param>
        /// <returns></returns>
        Participant SubscribeChatRoom(ChatUser chatUser, ChatRoom chatRoom);
    }
}
