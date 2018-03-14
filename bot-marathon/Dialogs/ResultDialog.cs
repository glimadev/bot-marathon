using Microsoft.Bot.Connector;

namespace bot_marathon.Dialogs
{
    public class ResultDialog
    {
        public object Obj { get; set; }

        public bool Wait { get; set; }

        public Activity Activity { get; set; }
    }
}