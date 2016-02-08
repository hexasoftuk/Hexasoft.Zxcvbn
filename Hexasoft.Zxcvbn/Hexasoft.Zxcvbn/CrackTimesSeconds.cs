namespace Hexasoft.Zxcvbn
{
    /// <summary>
    /// Dictionary of back-of-the-envelope crack time estimations, in seconds, based on a few scenarios
    /// </summary>
    public class CrackTimesSeconds
    {
        /// <summary>
        /// Online attack on a service that ratelimits password auth attempts.
        /// </summary>
        public double OnlineThrottling100PerHour { get; private set; }

        /// <summary>
        /// Online attack on a service that doesn't ratelimit, or where an attacker has outsmarted ratelimiting.
        /// </summary>
        public double OnlineNoThrottling10PerSecond { get; private set; }

        /// <summary>
        /// Offline attack. Assumes multiple attackers, proper user-unique salting, and a slow hash function w/ moderate work factor, such as bcrypt, scrypt, PBKDF2.
        /// </summary>
        public double OfflineSlowHashing1e4PerSecond { get; private set; }

        /// <summary>
        /// Offline attack with user-unique salting but a fast hash function like SHA-1, SHA-256 or MD5. A wide range of reasonable numbers anywhere from one billion - one trillion guesses per second, depending on number of cores and machines. Ballparking at 10B/sec.
        /// </summary>
        public double OfflineFastHashing1e10PerSecond { get; private set; }

        public CrackTimesSeconds(double onlineThrottling100PerHour, double onlineNoThrottling10PerSecond, double offlineSlowHashing1e4PerSecond, double offlineFastHashing1e10PerSecond)
        {
            OnlineThrottling100PerHour = onlineThrottling100PerHour;
            OnlineNoThrottling10PerSecond = onlineNoThrottling10PerSecond;
            OfflineSlowHashing1e4PerSecond = offlineSlowHashing1e4PerSecond;
            OfflineFastHashing1e10PerSecond = offlineFastHashing1e10PerSecond;
        }
    }
}
