using bot_marathon.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace bot_marathon.Helpers
{
    public static class DialogContextExtension
    {
        private static string[] _reply1 = new string[] { "Achei um!" };

        private static string[] _reply2 = new string[] { "Veja se algum lhe interessa", "Que tal estes?", "Veja os que eu encontrei" };

        public static async Task DoCarousel(this IDialogContext context, List<CardModel> data)
        {
            var replyToConversation = context.MakeMessage();

            replyToConversation.Attachments = new List<Attachment>();

            if (context.Activity.ChannelId != "skype")
            {
                replyToConversation.AttachmentLayout = AttachmentLayoutTypes.Carousel;

                foreach (var cardContent in data)
                {
                    List<CardImage> cardImages = new List<CardImage>();

                    cardImages.Add(new CardImage(url: cardContent.Image));

                    List<CardAction> cardButtons = new List<CardAction>();

                    foreach (var item in cardContent.Buttons)
                    {
                        CardAction plButton = new CardAction()
                        {
                            Value = item.Value,
                            Type = item.Type,
                            Title = item.Title
                        };

                        cardButtons.Add(plButton);
                    }

                    HeroCard plCard = new HeroCard()
                    {
                        Title = cardContent.Title,
                        Subtitle = cardContent.Subtitle,
                        Images = cardImages,
                        Buttons = cardButtons
                    };

                    Attachment plAttachment = plCard.ToAttachment();

                    replyToConversation.Attachments.Add(plAttachment);
                }
            }
            else
            {
                replyToConversation.AttachmentLayout = AttachmentLayoutTypes.List;

                foreach (var cardContent in data)
                {
                    List<CardImage> cardImages = new List<CardImage>();

                    cardImages.Add(new CardImage(url: cardContent.Image));

                    List<CardAction> cardButtons = new List<CardAction>();

                    foreach (var item in cardContent.Buttons)
                    {
                        CardAction plButton = new CardAction()
                        {
                            Value = item.Value,
                            Type = item.Type,
                            Title = item.Title
                        };

                        cardButtons.Add(plButton);
                    }

                    ThumbnailCard plCard = new ThumbnailCard()
                    {
                        Title = cardContent.Title,
                        Subtitle = cardContent.Subtitle,
                        Images = cardImages,
                        Buttons = cardButtons
                    };

                    Attachment plAttachment = plCard.ToAttachment();

                    replyToConversation.Attachments.Add(plAttachment);
                }
            }

            await context.PostAsync(replyToConversation);
        }

        public static async Task DontUnderstandMessage(this IDialogContext context)
        {
            await context.PostAsync("Ih, não entendi o que você quis dizer...");

            await context.PostAsync("Sou uma robô muito nova ainda! Por favor tente falar de forma mais simples.");
        }

        public static async Task SendTyping(this IDialogContext context, Activity activity)
        {
            var reply = activity.CreateReply(String.Empty);

            reply.Type = ActivityTypes.Typing;

            await context.PostAsync(reply);
        }

        public static async Task SendMessage(this IDialogContext context, Activity activity, string message)
        {
            var reply = activity.CreateReply(String.Empty);

            reply.Type = ActivityTypes.Typing;

            await context.PostAsync(reply);

            await context.PostAsync(message);
        }

        public static async Task IsTyping(this IDialogContext context, Activity activity)
        {
            var reply = activity.CreateReply(String.Empty);

            reply.Type = ActivityTypes.Typing;

            await context.PostAsync(reply);
        }

        public static async Task DoSuggestedActions(this IDialogContext context, string title, string[] values, ResumeAfter<object> messageReceivedAsync, bool notInSkype = false)
        {
            if (!notInSkype && values != null && values.Count() > 0)
            {
                var reply = context.MakeMessage();

                reply.Text = title;

                reply.Type = ActivityTypes.Message;

                reply.TextFormat = TextFormatTypes.Plain;

                if (context.Activity.ChannelId != "skype")
                {
                    var actions = new List<CardAction>();

                    foreach (var item in values)
                    {
                        actions.Add(new CardAction() { Title = item, Type = ActionTypes.ImBack, DisplayText = item, Value = item });
                    }

                    reply.SuggestedActions = new SuggestedActions()
                    {
                        Actions = actions
                    };

                    await context.PostAsync(reply);
                }
                else
                {
                    PromptDialog.Choice(context, messageReceivedAsync, new PromptOptions<object>(title, "Não é uma opção válida", "...", values, 0, new PromptStyler(PromptStyle.Auto)));
                }
            }
        }
    }
}