using ContentConsole.Contract;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ContentConsole.Implementation
{
    public class BannedWordService : IBannedWordService, IDisposable
    {
        public AddBadWordsResponse AddBadWords(AddBadWordsRequest request)
            => new AddBadWordsResponse
                { BadWordCounts = BannedWords.Instance.AddWord(request.NewWord) };

        public void Dispose()
        {
        }

        public IdentifyBadWordsResponse IdentifyBadWords(IdentifyBadWordsRequest request)
        {

            var bannerWords = BannedWords.Instance.Words
                        .Where(x => request.Content.Contains(x))
                        .ToList();

            return new IdentifyBadWordsResponse
            {
                BadWordsCount = bannerWords.Count()
            };

        }

        public ReplaceBadWordsResponse ReplaceBadWords(ReplaceBadWordsRequest request)
        {

            var wordsToReplace = BannedWords.Instance.Words
                .Where(x => request.Content.Contains(x))
                .ToList();

            var resp = request.Content;

            foreach (var item in wordsToReplace)
            {
                var newWord = Enumerable.Repeat('#', item.Length).ToList();
                newWord[0] = item.First();
                newWord[newWord.Count - 1] = item.Last();
                resp = Regex.Replace(resp, String.Join("", item) , String.Join("",newWord));
            }

            return new ReplaceBadWordsResponse
            {
                NiceText = resp
            };
        }
    }
}
