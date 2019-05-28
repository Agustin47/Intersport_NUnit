using System;
using SimpleInjector;
using ContentConsole.Contract;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var app = Inicialize();

            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            int badWords = app.IdentifyBadWords(content);


            string niceText = app.ReplaceBadWords(content);


            //string bannedWord1 = "swine";
            //string bannedWord2 = "bad";
            //string bannedWord3 = "nasty";
            //string bannedWord4 = "horrible";

            //string content =
            //    "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            //int badWords = 0;
            //if (content.Contains(bannedWord1))
            //{
            //    badWords = badWords + 1;
            //}
            //if (content.Contains(bannedWord2))
            //{
            //    badWords = badWords + 1;
            //}
            //if (content.Contains(bannedWord3))
            //{
            //    badWords = badWords + 1;
            //}
            //if (content.Contains(bannedWord4))
            //{
            //    badWords = badWords + 1;
            //}

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + badWords);
            Console.WriteLine("Nice text: " + niceText);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();




        }


        public static AppController Inicialize()
        {
            // Contenedor
            var container = new Container();

            // Servicios
            container.Register<IBannedWordService, Implementation.BannedWordService>(Lifestyle.Singleton);

            return container.GetInstance<AppController>(); ;

        }

    }

}
