using bot_marathon.Helpers;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Scorables.Internals;
using Microsoft.Bot.Connector;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace bot_marathon.Scorable
{
    public class DirtyWordScorable : ScorableBase<IActivity, string, double>
    {
        private readonly IBotToUser _botToUser;

        private static string[] words = new string[] { "idiota", "porra", "vagaba", "cacete", "viada", "cuzão", "vagabunda", "cretina", "arrombada", "puta", "desgraçada", "capeta", "toma no cú", "piranha", "safada", "merda" };

        private static string[] answers = new string[] { "Mas que boca suja..", "Por favor não fale assim comigo", "Não gosto de palavrões" };

        public DirtyWordScorable(IBotToUser botToUser)
        {
            SetField.NotNull(out _botToUser, nameof(_botToUser), botToUser);
        }

        protected override async Task<string> PrepareAsync(IActivity activity, CancellationToken token)
        {
            var message = activity as IMessageActivity;

            if (message != null && !string.IsNullOrWhiteSpace(message.Text))
            {
                var messages = message.Text.Split(' ');

                if (words.Any(word => messages.Any(mes => mes.Equals(word, StringComparison.InvariantCultureIgnoreCase))))
                {
                    return message.Text;
                }
            }

            return null;
        }

        protected override bool HasScore(IActivity item, string state)
        {
            return state != null;
        }

        protected override double GetScore(IActivity item, string state)
        {
            return 1.0;
        }

        protected override async Task PostAsync(IActivity item, string state, CancellationToken token)
        {
            var message = item as IMessageActivity;

            if (message != null)
            {
                var reply = _botToUser.MakeMessage();

                reply.Text = answers.SelectRandomdly();

                await _botToUser.PostAsync(reply);
            }
        }

        protected override Task DoneAsync(IActivity item, string state, CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}