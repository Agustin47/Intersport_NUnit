
using ContentConsole.Contract;
using System;

namespace ContentConsole
{
    public class AppController
    {

        private IBannedWordService _bannedWordService;

        public AppController(IBannedWordService bannedWordService)
        {
            _bannedWordService = bannedWordService;
        }

        public int IdentifyBadWords( string content )
        {
            var resp =_bannedWordService.IdentifyBadWords(new IdentifyBadWordsRequest
            {
                Content = content
            });

            return resp.BadWordsCount;
        }

        public string ReplaceBadWords( string content)
        {
            var resp = _bannedWordService.ReplaceBadWords(new ReplaceBadWordsRequest
            {
                Content = content
            });

            return resp.NiceText;
        }


    }
}
