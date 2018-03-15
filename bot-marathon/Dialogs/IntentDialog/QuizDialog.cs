using bot_marathon.Dialogs.EnumDialog;
using bot_marathon.Helpers;
using bot_marathon.Models;
using bot_marathon.Repository;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace bot_marathon.Dialogs.IntentDialog
{
    [Serializable]
    public class QuizDialog : IDialog<object>
    {
        private DbQuizDialog _db = new DbQuizDialog();

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(QuizMessageReceivedAsync);

            return Task.CompletedTask;
        }

        public async Task QuizMessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
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

                if (_db.ConversationSituation == (int)QuizEnum.Init)
                {
                    await ConversationInit(activity, context);
                }
                else if (_db.ConversationSituation == (int)QuizEnum.Pergunta1)
                {
                    await ConversationPergunta1(activity, context);
                }
                else if (_db.ConversationSituation == (int)QuizEnum.Pergunta2)
                {
                    await ConversationPergunta2(activity, context);
                }
                else if (_db.ConversationSituation == (int)QuizEnum.Pergunta3)
                {
                    await ConversationPergunta3(activity, context);
                }
                else if (_db.ConversationSituation == (int)QuizEnum.Pergunta4)
                {
                    await ConversationPergunta4(activity, context);
                }
                else if (_db.ConversationSituation == (int)QuizEnum.Pergunta5)
                {
                    await ConversationPergunta5(activity, context);
                }
                else if (_db.ConversationSituation == (int)QuizEnum.Pergunta6)
                {
                    await ConversationPergunta6(activity, context);
                }
                else if (_db.ConversationSituation == (int)QuizEnum.Pergunta7)
                {
                    await ConversationPergunta7(activity, context);
                }
                else if (_db.ConversationSituation == (int)QuizEnum.Pergunta8)
                {
                    await ConversationPergunta8(activity, context);
                }
                else if (_db.ConversationSituation == (int)QuizEnum.Pergunta9)
                {
                    await ConversationPergunta9(activity, context);
                }
                else if (_db.ConversationSituation == (int)QuizEnum.Pergunta10)
                {
                    await ConversationFinal(activity, context);
                }
                else if (_db.ConversationSituation == (int)QuizEnum.Fim)
                {
                    await ConversationConclusao(activity, context);
                }
            }
            catch (Exception ex)
            {
                context.Done(new ResultDialog { Activity = context.Activity as Activity });
            }
        }

        private async Task ConversationInit(Activity activity, IDialogContext context)
        {
            await context.SendMessage(activity, "Vamos ver quanto você sabe sobre carros:");

            await context.DoSuggestedActions("Qual carro foi criado pela Chevrolet para substituir o Astra?", _db.Answers1, QuizMessageReceivedAsync);

            _db.Points = 0;

            _db.ConversationSituation = (int)QuizEnum.Pergunta1;
        }

        private async Task ConversationPergunta1(Activity activity, IDialogContext context)
        {
            string message = activity.Text.ToLower();

            if (_db.Answers1.Any(x => x.ToLower() == message))
            {
                if (message == "cruze")
                {
                    _db.Points += 1;
                }

                await context.DoSuggestedActions("Qual dos carros abaixo foi o último modelo da Fiat a ser criado?", _db.Answers2, QuizMessageReceivedAsync);

                _db.ConversationSituation = (int)QuizEnum.Pergunta2;
            }
            else
            {
                context.Done(new ResultDialog { Activity = activity });
            }
        }

        private async Task ConversationPergunta2(Activity activity, IDialogContext context)
        {
            string message = activity.Text.ToLower();

            if (_db.Answers2.Any(x => x.ToLower() == message))
            {
                if (message == "mobi")
                {
                    _db.Points += 1;
                }

                await context.DoSuggestedActions("Qual o primeiro carro a ter um motor rodando com etanol?", _db.Answers3, QuizMessageReceivedAsync);

                _db.ConversationSituation = (int)QuizEnum.Pergunta3;
            }
            else
            {
                context.Done(new ResultDialog { Activity = activity });
            }
        }

        private async Task ConversationPergunta3(Activity activity, IDialogContext context)
        {
            string message = activity.Text.ToLower();

            if (_db.Answers3.Any(x => x.ToLower() == message))
            {
                if (message == "corcel")
                {
                    _db.Points += 1;
                }

                await context.DoSuggestedActions("Qual das marcas abaixo não é alemã?", _db.Answers4, QuizMessageReceivedAsync);

                _db.ConversationSituation = (int)QuizEnum.Pergunta4;
            }
            else
            {
                context.Done(new ResultDialog { Activity = activity });
            }
        }

        private async Task ConversationPergunta4(Activity activity, IDialogContext context)
        {
            string message = activity.Text.ToLower();

            if (_db.Answers4.Any(x => x.ToLower() == message))
            {
                if (message == "volvo")
                {
                    _db.Points += 1;
                }

                await context.DoSuggestedActions("Qual é a unidade utilizada para medir a velocidade de giro do motor?", _db.Answers5, QuizMessageReceivedAsync);

                _db.ConversationSituation = (int)QuizEnum.Pergunta5;
            }
            else
            {
                context.Done(new ResultDialog { Activity = activity });
            }
        }

        private async Task ConversationPergunta5(Activity activity, IDialogContext context)
        {
            string message = activity.Text.ToLower();

            if (_db.Answers5.Any(x => x.ToLower() == message))
            {
                if (message == "rpm")
                {
                    _db.Points += 1;
                }

                await context.DoSuggestedActions("Ayrton Senna ajudou a desenvolver o chassi e algumas outras partes para qual carro?", _db.Answers6, QuizMessageReceivedAsync);

                _db.ConversationSituation = (int)QuizEnum.Pergunta6;
            }
            else
            {
                context.Done(new ResultDialog { Activity = activity });
            }
        }

        private async Task ConversationPergunta6(Activity activity, IDialogContext context)
        {
            string message = activity.Text.ToLower();

            if (_db.Answers6.Any(x => x.ToLower() == message))
            {
                if (message == "honda nsx")
                {
                    _db.Points += 1;
                }

                await context.DoSuggestedActions("Qual é o nome do carro conhecido por fazer parte dos filmes de espião 007?", _db.Answers7, QuizMessageReceivedAsync);

                _db.ConversationSituation = (int)QuizEnum.Pergunta7;
            }
            else
            {
                context.Done(new ResultDialog { Activity = activity });
            }
        }

        private async Task ConversationPergunta7(Activity activity, IDialogContext context)
        {
            string message = activity.Text.ToLower();

            if (_db.Answers7.Any(x => x.ToLower() == message))
            {
                if (message == "aston martin db5")
                {
                    _db.Points += 1;
                }
                await context.DoSuggestedActions("Que distância, no mínimo, um carro elétrico pode percorrer após ser carregado?", _db.Answers8, QuizMessageReceivedAsync);

                _db.ConversationSituation = (int)QuizEnum.Pergunta8;
            }
            else
            {
                context.Done(new ResultDialog { Activity = activity });
            }
        }

        private async Task ConversationPergunta8(Activity activity, IDialogContext context)
        {
            string message = activity.Text.ToLower();

            if (_db.Answers8.Any(x => x.ToLower() == message))
            {
                if (message == "150 km")
                {
                    _db.Points += 1;
                }
                await context.DoSuggestedActions("Qual é o carro mais antigo em fabricação no Brasil?", _db.Answers9, QuizMessageReceivedAsync);

                _db.ConversationSituation = (int)QuizEnum.Pergunta9;
            }
            else
            {
                context.Done(new ResultDialog { Activity = activity });
            }
        }

        private async Task ConversationPergunta9(Activity activity, IDialogContext context)
        {
            string message = activity.Text.ToLower();

            if (_db.Answers9.Any(x => x.ToLower() == message))
            {
                if (message == "kombi")
                {
                    _db.Points += 1;
                }
                await context.DoSuggestedActions("Qual das montadoras abaixo é brasileira?", _db.Answers10, QuizMessageReceivedAsync);

                _db.ConversationSituation = (int)QuizEnum.Pergunta10;
            }
            else
            {
                context.Done(new ResultDialog { Activity = activity });
            }
        }

        private async Task ConversationFinal(Activity activity, IDialogContext context)
        {
            string message = activity.Text.ToLower();

            if (_db.Answers10.Any(x => x.ToLower() == message))
            {
                if (message == "agrale")
                {
                    _db.Points += 1;
                }
                await context.SendMessage(activity, "Calculando seu resultado...");

                if (_db.Points > 7)
                {
                    await context.SendMessage(activity, "Você fez " + _db.Points + " pontos de 10");

                    await context.DoSuggestedActions("🎈", _db.ConversationOption, QuizMessageReceivedAsync);
                }
                else
                {
                    await context.DoSuggestedActions("Você fez " + _db.Points + " pontos de 10", _db.ConversationOption, QuizMessageReceivedAsync);
                }

                _db.ConversationSituation = (int)QuizEnum.Fim;
            }
            else
            {
                context.Done(new ResultDialog { Activity = activity });
            }
        }

        private async Task ConversationConclusao(Activity activity, IDialogContext context)
        {
            var message = activity.Text;

            if (message == "Responder de novo")
            {
                await ConversationInit(activity, context);
            }
            else
            {
                context.Done(new ResultDialog { Activity = activity });
            }
        }
    }
}