using bot_marathon.Helpers;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace bot_marathon.Dialogs.IntentDialog
{
    [Serializable]
    public class ThanksDialog : IDialog<object>
    {
        private static string[] _thanks = new string[] { "Disponha, estou aqui para ajudar =)", "Não há de que, se precisar estou aqui", "Qualquer coisa só chamar!" };

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(ThanksMessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task ThanksMessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync(_thanks.SelectRandomdly());

            context.Done(new ResultDialog { Wait = true });
        }
    }
}