using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using ContentConsole.Contract;
using ContentConsole.Implementation;

/*
//string bannedWord1 = "swine";
//string bannedWord2 = "bad";
//string bannedWord3 = "nasty";
//string bannedWord4 = "horrible";
//string content =
//    "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
*/

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class BannedWordServiceTests
    {


        private BannedWordService _bannedWordService;

        [SetUp]
        public void Setup()
        {
            _bannedWordService = new BannedWordService();
        }

        [TearDown]
        public void Teardown()
        {
            _bannedWordService.Dispose();
            _bannedWordService = null;
            BannedWords.Instance.Dispose();
        }


        [TestCase("The weather in horrible in winter is bad", 2)]
        [TestCase("It rains all the time, swine", 1)]
        [TestCase("it must be nasty for people visiting.", 1)]
        public void IdentifyBadWords_Words_ResturnsCountOfBadWords(string word, int expectedCount)
        {

            var result = _bannedWordService.IdentifyBadWords(new IdentifyBadWordsRequest
            {
                Content = word
            });

            Assert.That(result.BadWordsCount, Is.EqualTo(expectedCount));

        }

        [TestCase("weather", 5)]
        [TestCase("visiting.", 5)]
        public void AddBadWords_NewWord_ReturnsIfCanIdentify(string newWord, int expectedNumberOfBadWords)
        {

            var result = _bannedWordService.AddBadWords(new AddBadWordsRequest
            {
                NewWord = newWord
            });

            Assert.That(result.BadWordCounts, Is.EqualTo(expectedNumberOfBadWords));
        }


        [TestCase("The weather in horrible in winter is bad")]
        [TestCase("It rains all the time, swine")]
        [TestCase("it must be nasty for people visiting.")]
        public void ReplaceBadWords_PhrasesWithBadWords(string prhase)
        {
            var niceText = _bannedWordService.ReplaceBadWords(new ReplaceBadWordsRequest
            {
                Content = prhase
            });

            var isOk = _bannedWordService.IdentifyBadWords(new IdentifyBadWordsRequest
            {
                Content = niceText.NiceText
            });

            Assert.That(isOk.BadWordsCount, Is.EqualTo(0));

        }

    }

    

}
