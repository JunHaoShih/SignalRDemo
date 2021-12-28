using DataAccessLib.DAOs;
using DataAccessLib.Models;
using DataAccessLib.Models.DataTypes;
using DataAccessLib.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SignalRServer.SignalR
{
    public class ChatHub : Hub
    {
        private readonly IChatUserDao chatUserDao;

        private readonly IChatRoomMessageDao chatRoomMessageDao;

        private readonly IParticipantDao participantDao;

        private readonly IChatRoomDao chatRoomDao;

        public ChatHub(IChatUserDao chatUserDao, IChatRoomMessageDao chatRoomMessageDao, IParticipantDao participantDao, IChatRoomDao chatRoomDao)
        {
            this.chatUserDao = chatUserDao;
            this.chatRoomMessageDao = chatRoomMessageDao;
            this.participantDao = participantDao;
            this.chatRoomDao = chatRoomDao;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync(HubData.ReceiveMessage, user, message);

        }

        public async Task SendTopicMessage(string user, string topic, string message)
        {
            var isValid = UserName.TryParse(user, out UserName userName);
            if (!isValid)
            {
                await Clients.Client(Context.ConnectionId).SendAsync(HubData.SendTopicMessageResult, HttpStatusCode.BadRequest, "非法使用者名稱");
                return;
            }

            isValid = Topic.TryParse(topic, out Topic topicObj);
            if (!isValid)
            {
                await Clients.Client(Context.ConnectionId).SendAsync(HubData.SendTopicMessageResult, HttpStatusCode.BadRequest, "非法Topic名稱");
                return;
            }

            isValid = ChatText.TryParse(message, out ChatText chatText);
            if (!isValid)
            {
                await Clients.Client(Context.ConnectionId).SendAsync(HubData.SendTopicMessageResult, HttpStatusCode.BadRequest, "非法訊息");
                return;
            }

            ChatRoomMessage chatRoomMessage = new ChatRoomMessage() { UserName = userName, Topic = topicObj, ChatMessage = chatText };
            chatRoomMessage = chatRoomMessageDao.InsertChatRoomMessage(chatRoomMessage);

            await Clients.Group(topicObj.ToString()).SendAsync(HubData.ReceiveTopicMessage, userName.ToString(), topicObj.ToString(), chatText.ToString());

        }

        public async Task Subscribe(string user, string topic)
        {
            var isValid = UserName.TryParse(user, out UserName userName);
            if (!isValid)
            {
                await Clients.Client(Context.ConnectionId).SendAsync(HubData.SubscribeResult, HttpStatusCode.BadRequest, "非法使用者名稱");
                return;
            }

            isValid = Topic.TryParse(topic, out Topic topicObj);
            if (!isValid)
            {
                await Clients.Client(Context.ConnectionId).SendAsync(HubData.SubscribeResult, HttpStatusCode.BadRequest, "非法Topic名稱");
                return;
            }

            var chatUser = chatUserDao.GetChatUser(userName);
            if (chatUser == null)
            {
                await Clients.Client(Context.ConnectionId).SendAsync(HubData.SubscribeResult, HttpStatusCode.BadRequest, "使用者「" + userName + "」不存在!");
                return;
            }

            var chatRoom = chatRoomDao.GetChatRoom(topicObj);
            if (chatRoom == null)
            {
                chatRoom = new ChatRoom() { Topic = topicObj };
                chatRoom = chatRoomDao.InsertChatRoom(chatRoom);
                //await Clients.Client(Context.ConnectionId).SendAsync(HubData.SubscribeResult, HttpStatusCode.BadRequest, "Topic「" + topicObj + "」不存在!");
                //return;
            }
            var participant = participantDao.GetParticipant(chatUser, chatRoom);
            if (participant == null)
                participantDao.SubscribeChatRoom(chatUser, chatRoom);

            await Groups.AddToGroupAsync(Context.ConnectionId, topic);

            await Clients.Client(Context.ConnectionId).SendAsync(HubData.SubscribeResult, HttpStatusCode.OK, topic);
        }

        public async Task Login(string user, string password)
        {
            var isValid = UserName.TryParse(user, out UserName userName);
            if (!isValid)
            {
                await Clients.Client(Context.ConnectionId).SendAsync(HubData.LoginResult, HttpStatusCode.BadRequest, "非法使用者名稱");
                return;
            }

            isValid = Password.TryParse(password, out Password passwordObj);
            if (!isValid)
            {
                await Clients.Client(Context.ConnectionId).SendAsync(HubData.LoginResult, HttpStatusCode.BadRequest, "非法密碼");
                return;
            }

            var chatUser = chatUserDao.GetChatUser(userName);
            if (chatUser == null)
            {
                chatUser = new ChatUser() { UserName = userName, Password = passwordObj };
                chatUserDao.InsertChatUser(chatUser);
            }
            else
            {
                if (chatUser.Password != password)
                {
                    await Clients.Client(Context.ConnectionId).SendAsync(HubData.LoginResult, HttpStatusCode.BadRequest, "密碼不正確");
                    return;
                }
            }

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, userName));

            var claimsIdentity = new ClaimsIdentity(Context.User.Identity, claims);
            Context.User.AddIdentity(claimsIdentity);

            await Clients.Client(Context.ConnectionId).SendAsync(HubData.LoginResult, HttpStatusCode.OK, "登入成功");
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var name = Context.User.Claims.ToList().Where(claim => claim.Type == ClaimTypes.Name).FirstOrDefault().Value;
            if (name != null)
            {
                var isValid = UserName.TryParse(name, out UserName userName);
                var chatUser = chatUserDao.GetChatUser(userName);
                var participants = participantDao.GetParticipantsByChatUser(chatUser);

                foreach (var participant in participants)
                {
                    Groups.RemoveFromGroupAsync(Context.ConnectionId, participant.ChatRoom.Topic);
                }
                //Clients.Client(Context.ConnectionId).SendAsync(HubData.ClientOnDisconnectMethod, "離線成功");
            }

            return base.OnDisconnectedAsync(exception);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
