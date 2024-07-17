namespace TelegramParse.Interfaces
{
    public interface IMessage
    {
       Task Send(string text, long id);
    }
}
