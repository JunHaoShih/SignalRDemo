using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLib.Models
{
    public class Participant
    {
        public ChatUser ChatUser { get; set; }

        public ChatRoom ChatRoom { get; set; }
    }
}
