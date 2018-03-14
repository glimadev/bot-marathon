using bot_marathon.Dialogs;
using bot_marathon.Dialogs.IntentFactories;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Threading.Tasks;

namespace bot_marathon.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            await new IntentFactory().GetIntent(ResumeAfterCompleted, activity, context);
        }

        public async Task ResumeAfterCompleted(IDialogContext context, IAwaitable<object> result)
        {
            var resultDialog = await result as ResultDialog;

            if (resultDialog.Wait)
            {
                context.Wait(MessageReceivedAsync);

                return;
            }

            await new IntentFactory().GetIntent(ResumeAfterCompleted, resultDialog.Activity, context, resultDialog.Obj);
        }
    }
}