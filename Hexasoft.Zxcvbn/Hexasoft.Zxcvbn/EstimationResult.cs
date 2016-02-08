using System.Collections.Generic;
using System.Linq;

namespace Hexasoft.Zxcvbn
{
    public class EstimationResult
    {
        /// <summary>
        /// The password under analysis
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Estimated guesses needed to crack password
        /// </summary>
        public double Guesses { get; private set; }

        /// <summary>
        /// Order of magnitude of Guesses
        /// </summary>
        public double GuessesLog10 { get; private set; }

        /// <summary>
        /// Dictionary of back-of-the-envelope crack time estimations, in seconds, based on a few scenarios
        /// </summary>
        public CrackTimesSeconds CrackTimesSeconds { get; private set; }

        /// <summary>
        /// Dictionary of back-of-the-envelope crack time estimations, based on a few scenarios, with friendlier display string values: "less than a second", "3 hours", "centuries", etc.
        /// </summary>
        public CrackTimesDisplay CrackTimesDisplay { get; private set; }

        /// <summary>
        /// Integer from 0-4 (useful for implementing a strength bar)
        /// 0 = too guessable: risky password. (guesses < 10^3)
        /// 1 = very guessable: protection from throttled online attacks. (guesses < 10^6)
        /// 2 = somewhat guessable: protection from unthrottled online attacks. (guesses < 10^8)
        /// 3 = safely unguessable: moderate protection from offline slow-hash scenario. (guesses < 10^10)
        /// 4 = very unguessable: strong protection from offline slow-hash scenario. (guesses >= 10^10)
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// Verbal feedback to help choose better passwords. set when score <= 2.
        /// </summary>
        public Feedback Feedback { get; private set; }

        /// <summary>
        /// The list of patterns that zxcvbn based the guess calculation on.
        /// </summary>
        public dynamic Sequence { get; private set; }

        /// <summary>
        /// How long it took zxcvbn to calculate an answer, in milliseconds.
        /// </summary>
        public long CalcTime { get; private set; }

        public EstimationResult(
            string password,
            double guesses,
            double guessesLog10,
            CrackTimesSeconds crackTimeSeconds,
            CrackTimesDisplay crackTimeDisplay,
            int score,
            Feedback feedback,
            dynamic sequence,
            long calcTime
            )
        {
            Password = password;
            Guesses = guesses;
            GuessesLog10 = guessesLog10;
            CrackTimesSeconds = crackTimeSeconds;
            CrackTimesDisplay = crackTimeDisplay;
            Score = score;
            Feedback = feedback;
            Sequence = sequence;
            CalcTime = calcTime;
        }       

        public static EstimationResult FromDynamic(dynamic result)
        {
            var suggestions = result.feedback.suggestions as object[];

            return new EstimationResult(
                result.password.ToString(),
                double.Parse(result.guesses.ToString()),
                double.Parse(result.guesses_log10.ToString()),
                new CrackTimesSeconds(
                    double.Parse(result.crack_times_seconds.online_throttling_100_per_hour.ToString()),
                    double.Parse(result.crack_times_seconds.online_no_throttling_10_per_second.ToString()),
                    double.Parse(result.crack_times_seconds.offline_slow_hashing_1e4_per_second.ToString()),
                    double.Parse(result.crack_times_seconds.offline_fast_hashing_1e10_per_second.ToString())
                    ),
                new CrackTimesDisplay(
                    result.crack_times_display.online_throttling_100_per_hour.ToString(),
                    result.crack_times_display.online_no_throttling_10_per_second.ToString(),
                    result.crack_times_display.offline_slow_hashing_1e4_per_second.ToString(),
                    result.crack_times_display.offline_fast_hashing_1e10_per_second.ToString()
                    ),
                int.Parse(result.score.ToString()),
                new Feedback(
                    result.feedback.warning.ToString(),
                    (suggestions != null) ? suggestions.Select(v => v.ToString()) : null
                    ),
                result.sequence, // TODO: process this one
                long.Parse(result.calc_time.ToString())
            );
        }
    }
}
