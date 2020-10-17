using DB;
using DB.Models;
using ModuleFramework;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using YodaTranslation.Models;

namespace YodaTranslation
{
    [ModuleFramework.Module(Author = "C3sxr", Name = "YodaTranslation", Version = "1.0")]
    public class YodaTranslation
    {
        private TelegramBotClient _telegramBotClient;

        public YodaTranslation(Instance db, Setting setting, TelegramBotClient telegramBotClient)
        {
            _telegramBotClient = telegramBotClient;
        }

        [ChatCommand(Triggers = new [] { "yodatranslation", "Translate"}, HelpText = "Translate your phrase to a Yoda phrase")]
        public async Task<CommandResponse> GetYodaTranslation()
        {
            var yodaHelper = new YodaHelper();
            Console.Write("What text you want to translato to Yoda? ");
            var originalText = Console.ReadLine();

            var yodaTranslation = await yodaHelper.GetTranslation(originalText);
            
            return new CommandResponse($"{yodaTranslation.contents.translated}");

        }
    }
}
