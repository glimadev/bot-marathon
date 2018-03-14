namespace bot_marathon.Models
{
    public class DbQuizDialog
    {
        public DbQuizDialog()
        {
            Points = 0;
            ConversationSituation = 0;
            Answers1 = new string[] { "Spin", "Cobalt", "Classic", "Cruze", "Vectra" };
            Answers2 = new string[] { "Mobi", "Linea", "Palio", "Siena", "Tipo" };
            Answers3 = new string[] { "Corcel", "Fusca", "Del Rey", "Chevete", "Kombi" };
            Answers4 = new string[] { "Volkswagen", "Volvo", "Mercedes-Benz", "BMW", "Opel" };
            Answers5 = new string[] { "km/h", "kgf.m", "N.M", "RPM", "MPH" };
            Answers6 = new string[] { "Ferrari Modena", "Nissan 350Z", "Porsche 911", "Audi R8", "Honda NSX" };
            Answers7 = new string[] { "Shelby Mustang", "Hummer H2", "Porsche 911", "Aston Martin DB5", "Audi R8" };
            Answers8 = new string[] { "200 km", "150 km", "250 km", "300 km", "500 km" };
            Answers9 = new string[] { "Gol", "Fiorino", "Classic", "Kombi", "Fusca" };
            Answers10 = new string[] { "Agrale", "Cometa", "Busscar", "Scania", "Comil" };
            ConversationOption = new string[] { "Ok, valeu!", "Responder de novo" };
        }

        public int ConversationSituation { get; set; }
        public int Points { get; set; }
        public string[] Answers1 { get; set; }
        public string[] Answers2 { get; set; }
        public string[] Answers3 { get; set; }
        public string[] Answers4 { get; set; }
        public string[] Answers5 { get; set; }
        public string[] Answers6 { get; set; }
        public string[] Answers7 { get; set; }
        public string[] Answers8 { get; set; }
        public string[] Answers9 { get; set; }
        public string[] Answers10 { get; set; }
        public string[] ConversationOption { get; set; }
    }
}