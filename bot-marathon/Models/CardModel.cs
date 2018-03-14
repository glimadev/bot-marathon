using System.Collections.Generic;

namespace bot_marathon.Models
{
    public class CardModel
    {
        public CardModel()
        {
            Buttons = new List<CardButtonModel>();
        }

        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Image { get; set; }
        public List<CardButtonModel> Buttons { get; set; }
    }

    public class CardButtonModel
    {
        public object Value { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
    }
}