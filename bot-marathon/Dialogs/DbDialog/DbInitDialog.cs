using bot_marathon.Dialogs.DbDialog;

namespace bot_marathon.Models
{
    public class DbInitDialog : DbBaseDialog
    {
        public DbInitDialog()
        {
            ConversationSitutaion = 0;
        }

        public int ConversationSitutaion { get; set; }
    }
}