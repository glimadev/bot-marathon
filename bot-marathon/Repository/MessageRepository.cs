using App.Framework.Repository.NoSQL.DocumentDB;
using bot_marathon.Models;
using Microsoft.Bot.Connector;
using System.Threading.Tasks;

namespace bot_marathon.Repository
{
    public class MessageRepository : DocumentDBRepository<MessageModel>
    {
        public MessageRepository(string collectionName = "messages") : base(collectionName)
        {
        }

        public async Task SaveMessage(Activity activity)
        {
            await AddOrUpdateAsync(new MessageModel { message = activity.Text, from = activity.From.Name, conversationId = activity.Conversation.Id });
        }
    }
}