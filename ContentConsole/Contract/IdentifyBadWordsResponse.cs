
namespace ContentConsole.Contract
{
    public class IdentifyBadWordsResponse
    {

        public string Content { get; set; }

        public int BadWordsCount { get; set; }


        public override bool Equals(object obj)
        {
            var resp = obj as IdentifyBadWordsResponse;

            if (resp == null)
                return false;

            if (resp.BadWordsCount != this.BadWordsCount)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return BadWordsCount*7;
        }
    }
}
