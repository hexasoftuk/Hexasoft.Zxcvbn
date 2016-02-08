using System.Collections.Generic;
using System.Linq;

namespace Hexasoft.Zxcvbn
{
    /// <summary>
    /// Verbal feedback to help choose better passwords. set when score <= 2.
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// Explains what's wrong, eg. 'this is a top-10 common password'. Not always set -- sometimes an empty string
        /// </summary>
        public string Warning { get; private set; }

        /// <summary>
        /// A possibly-empty list of suggestions to help choose a less guessable password. eg. 'Add another word or two'
        /// </summary>
        public IEnumerable<string> Suggestions { get; private set; }

        public Feedback(string warning, IEnumerable<string> suggestions)
        {
            Warning = warning ?? "";
            Suggestions = suggestions ?? Enumerable.Empty<string>();
        }
    }
}
