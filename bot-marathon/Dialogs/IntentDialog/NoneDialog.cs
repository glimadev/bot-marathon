using bot_marathon.Helpers;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Threading.Tasks;

namespace bot_marathon.Dialogs.IntentDialog
{
    [Serializable]
    public class NoneDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(NoneMessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task NoneMessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            await context.DontUnderstandMessage();

            context.Done(new ResultDialog { Activity = activity });
        }
    }
}