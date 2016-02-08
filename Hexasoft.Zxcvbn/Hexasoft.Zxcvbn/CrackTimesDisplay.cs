namespace Hexasoft.Zxcvbn
{
    /// <summary>
    /// Dictionary of back-of-the-envelope crack time estimations, based on a few scenarios, with friendlier display string values: "less than a second", "3 hours", "centuries", etc.
    /// </summary>
    public class CrackTimesDisplay
    {
        /// <summary>
        /// Online attack on a service that ratelimits password auth attempts.
        /// </summary>
        public string OnlineThrottling100PerHour { get; private set; }

        /// <summary>
        /// Online attack on a service that doesn't ratelimit, or where an attacker has outsmarted ratelimiting.
        /// </summary>
        public string OnlineNoThrottling10PerSecond { get; private set; }

        /// <summary>
        /// Offline attack. Assumes multiple attackers, proper user-unique salting, and a slow hash function w/ moderate work factor, such as bcrypt, scrypt, PBKDF2.
        /// </summary>
        public string OfflineSlowHashing1e4PerSecond { get; private set; }

        /// <summary>
        /// Offline attack with user-unique salting but a fast hash function like SHA-1, SHA-256 or MD5. A wide range of reasonable numbers anywhere from one billion - one trillion guesses per second, depending on number of cores and machines. Ballparking at 10B/sec.
        /// </summary>
        public string OfflineFastHashing1e10PerSecond { get; private set; }

        public CrackTimesDisplay(string onlineThrottling100PerHour, string onlineNoThrottling10PerSecond, string offlineSlowHashing1e4PerSecond, string offlineFastHashing1e10PerSecond)
        {
            OnlineThrottling100PerHour = onlineThrottling100PerHour;
            OnlineNoThrottling10PerSecond = onlineNoThrottling10PerSecond;
            OfflineSlowHashing1e4PerSecond = offlineSlowHashing1e4PerSecond;
            OfflineFastHashing1e10PerSecond = offlineFastHashing1e10PerSecond;
        }
    }
}
