using Dapper;
using DataAccessLib.Models;
using DataAccessLib.Models.DataTypes;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLib.DAOs.Implements
{
    public class SqliteChatRoomDao : IChatRoomDao
    {
        /// <summary>
        /// Sqlite的連線字串
        /// </summary>
        private readonly string connectionString;

        public SqliteChatRoomDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ChatRoom GetChatRoom(Topic topic)
        {
            ChatRoom chatRoom = null;
            using (var connection = new SqliteConnection(connectionString))
            {
                string cmd = "SELECT * FROM chat_rooms WHERE topic = @Topic";
                var chatRooms = connection.Query<ChatRoom>(cmd, new { Topic = topic }).ToList();
                chatRoom = chatRooms.Count == 0 ? null : chatRooms[0];
            }
            return chatRoom;
        }

        public ChatRoom InsertChatRoom(ChatRoom chatRoom)
        {
            string cmd = @"
INSERT INTO chat_rooms (topic) VALUES (@Topic);
SELECT seq FROM sqlite_sequence WHERE name = 'chat_rooms'
";
            using (var connection = new SqliteConnection(connectionString))
            {
                var id = connection.ExecuteScalar<int>(cmd, chatRoom);
                chatRoom.Id = id;
            }
            return chatRoom;
        }
    }
}
