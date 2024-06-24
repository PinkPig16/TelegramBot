namespace TelegramParse.Entity
{
    public class Update
    {

        public class Rootobject
        {
            public int update_id { get; set; }
            public Message message { get; set; }
        }
    }
}
