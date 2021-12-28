using Dapper;
using DataAccessLib.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLib.DAOs.Implements
{
    public class SqliteParticipantDao : IParticipantDao
    {
        /// <summary>
        /// Sqlite的連線字串
        /// </summary>
        private readonly string connectionString;

        public SqliteParticipantDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Participant GetParticipant(ChatUser chatUser, ChatRoom chatRoom)
        {
            Participant participant = null;
            using (var connection = new SqliteConnection(connectionString))
            {
                string cmd = @"
SELECT chat_users.*, chat_rooms.* FROM participants
INNER JOIN chat_users ON
  participants.chat_user_id = chat_users.id
INNER JOIN chat_rooms ON
  participants.chat_room_id = chat_rooms.id
WHERE
  chat_user_id = @ChatUserId AND chat_room_id = @ChatRoomId";
                var participants = connection.Query<ChatUser, ChatRoom, Participant>(cmd, (chatUser, chatRoom) =>
                {
                    var currentParticipant = new Participant() { ChatUser = chatUser, ChatRoom = chatRoom };
                    return currentParticipant;
                }, new { ChatUserId = chatUser.Id, ChatRoomId = chatRoom.Id }).ToList();
                participant = participants.Count == 0 ? null : participants[0];
            }
            return participant;
        }

        public IEnumerable<Participant> GetParticipantsByChatRoom(ChatRoom chatRoom)
        {
            IEnumerable<Participant> participants;
            using (var connection = new SqliteConnection(connectionString))
            {
                string cmd = @"
SELECT chat_users.*, chat_rooms.* FROM participants
INNER JOIN chat_users ON
  participants.chat_user_id = chat_users.id
INNER JOIN chat_rooms ON
  participants.chat_room_id = chat_rooms.id
WHERE
  chat_room_id = @ChatRoomId";
                participants = connection.Query<ChatUser, ChatRoom, Participant>(cmd, (chatUser, chatRoom) =>
                {
                    var currentParticipant = new Participant() { ChatUser = chatUser, ChatRoom = chatRoom };
                    return currentParticipant;
                }, new { ChatRoomId = chatRoom.Id }).ToList();
            }
            return participants;
        }

        public IEnumerable<Participant> GetParticipantsByChatUser(ChatUser chatUser)
        {
            IEnumerable<Participant> participants;
            using (var connection = new SqliteConnection(connectionString))
            {
                string cmd = @"
SELECT chat_users.*, chat_rooms.* FROM participants
INNER JOIN chat_users ON
  participants.chat_user_id = chat_users.id
INNER JOIN chat_rooms ON
  participants.chat_room_id = chat_rooms.id
WHERE
  chat_user_id = @ChatUserId";
                participants = connection.Query<ChatUser, ChatRoom, Participant>(cmd, (chatUser, chatRoom) =>
                {
                    var currentParticipant = new Participant() { ChatUser = chatUser, ChatRoom = chatRoom };
                    return currentParticipant;
                }, new { ChatUserId = chatUser.Id }).ToList();
            }
            return participants;
        }

        public Participant SubscribeChatRoom(ChatUser chatUser, ChatRoom chatRoom)
        {
            Participant participant = new Participant() { ChatUser = chatUser, ChatRoom = chatRoom };
            string cmd = @"
INSERT INTO participants (chat_user_id, chat_room_id) VALUES (@ChatUserId, @ChatRoomId);
";
            using (var connection = new SqliteConnection(connectionString))
            {
                var result = connection.Execute(cmd, new { ChatUserId = chatUser.Id, ChatRoomId = chatRoom.Id });
            }
            return participant;
        }
    }
}
