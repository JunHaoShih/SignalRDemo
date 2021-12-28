using DataAccessLib.Models.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLib.Models
{
    public class ChatRoom
    {
        /// <summary>
        /// 聊天室ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 聊天室名稱
        /// </summary>
        public Topic Topic { get; set; }
    }
}
