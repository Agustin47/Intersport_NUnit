

using System;
using System.Collections.Generic;

namespace ContentConsole.Contract
{
    public class BannedWords : IDisposable
    {

        private static BannedWords _instance;

        protected BannedWords()
        {
            this.Words = new List<string>() { "swine", "bad", "nasty", "horrible" };
        }

        public static BannedWords Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BannedWords();
                return _instance;
            }
        }

        public int AddWord( string newWord)
        {
            this.Words.Add(newWord);
            return this.Words.Count;
        }

        public void Dispose()
        {
            _instance = null;
            Words = null;
        }

        public List<string> Words { get; set; }

    }
}
