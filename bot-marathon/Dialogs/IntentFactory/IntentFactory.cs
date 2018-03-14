using bot_marathon.Dialogs.IntentDialog;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Threading;
using System.Threading.Tasks;

namespace bot_marathon.Dialogs.IntentFactories
{
    public class IntentFactory
    {
        public async Task GetIntent(ResumeAfter<object> messageReceivedAsync, Activity activity, IDialogContext context, object obj = null)
        {
            var message = activity.Text.ToLower();

            var luis = await Rest.LUIS.GetAsync(message.Replace("-", null));

            string topScoringIntent = luis.topScoringIntent.intent.ToLower();

            if (topScoringIntent == "quiz")
            {
                await context.Forward(new QuizDialog(), messageReceivedAsync, activity, CancellationToken.None);
            }
            else if (topScoringIntent == "greeting")
            {
                await context.Forward(new InitDialog(), messageReceivedAsync, activity, CancellationToken.None);
            }
            else if (topScoringIntent == "thanks")
            {
                await context.Forward(new ThanksDialog(), messageReceivedAsync, activity, CancellationToken.None);
            }
            else
            {
                await context.Forward(new NoneDialog(), messageReceivedAsync, activity, CancellationToken.None);
            }
        }
    }
}