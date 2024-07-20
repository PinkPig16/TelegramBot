namespace TelegramParse.Data.Enum
{
    public class ITPosition
    {
        private readonly HashSet<string> _position = new() 
        {
            "trainee",
            "junior",
            "middle",
            "senior",
            "PM",
            "team_lead",
            "architect"
        };
        

        public HashSet<string> getPosition() 
        { 
            return _position; 
        }
    }
}
