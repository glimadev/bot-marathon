using bot_marathon.Enum;
using bot_marathon.Helpers;
using bot_marathon.Models;
using bot_marathon.Repository;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bot_marathon.Dialogs.IntentDialog
{
    [Serializable]
    public class InitDialog : IDialog<object>
    {
        private DbInitDialog _db = new DbInitDialog();

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            try
            {
                var activity = await result as Activity;

                if (activity == null)
                {
                    activity = context.Activity as Activity;
                }

                _db.MessageRepository = new MessageRepository();

                await _db.MessageRepository.SaveMessage(activity);

                if (_db.ConversationSitutaion == (int)InitEnum.Init)
                {
                    await ConversationInit(activity, context);
                }
                else
                {
                    context.Done(new ResultDialog { Activity = activity });
                }
            }
            catch (TooManyAttemptsException ex)
            {
                context.Done(new ResultDialog { Activity = context.Activity as Activity });
            }
        }

        public string DoGreeting(string name)
        {
            List<string> result = new List<string>() { "Olá " + name, "Oi " + name, "Olá " + name + " 😉!", "Oi " + name + " 😉!" };

            var date = DateTime.Now;

            if (date.Hour >= 5 && date.Hour < 12)
            {
                result.Add("Bom dia " + name);
            }
            else if (date.Hour >= 12 && date.Hour < 18)
            {
                result.Add("Boa tarde " + name);
            }
            else
            {
                result.Add("Boa noite " + name);
            }

            return result.SelectRandomdly();
        }

        private async Task ConversationInit(Activity activity, IDialogContext context)
        {
            await context.SendMessage(activity, $"{DoGreeting(context.Activity.From.Name)}");

            await context.DoSuggestedActions("Você quer jogar um quiz?", new string[] { "Sim, quero jogar um quiz!", "Não muito obrigado" }, MessageReceivedAsync);

            _db.ConversationSitutaion = (int)InitEnum.End;
        }
    }
}