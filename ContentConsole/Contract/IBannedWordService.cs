
namespace ContentConsole.Contract
{
    public interface IBannedWordService
    {
        /// <summary>
        /// Identiry bad words.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IdentifyBadWordsResponse IdentifyBadWords(IdentifyBadWordsRequest request);

        /// <summary>
        /// Add new bad words to count.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddBadWordsResponse AddBadWords(AddBadWordsRequest request);

        /// <summary>
        /// Replace BadWords with #
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ReplaceBadWordsResponse ReplaceBadWords(ReplaceBadWordsRequest request);

    }
}
