﻿namespace TelegramParse.Entity
{
    public class Message
    {
        public int message_id { get; set; }
        public User user { get; set; }
        public Chat chat { get; set; }
        public int date { get; set; }
        public string? text { get; set; }
        public Entity[] entities { get; set; }
    }
}
