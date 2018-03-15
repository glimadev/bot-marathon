using App.Framework.Repository.NoSQL.Common;

namespace bot_marathon.Models
{
    public class MessageModel : Base
    {
        public string conversationId { get; set; }
        public string from { get; set; }
        public string message { get; set; }
    }
}