using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Hexasoft.Zxcvbn.Tests
{
    [TestClass]
    public class ZxcvbnEstimatorTest
    {
        private IZxcvbnEstimator _estimator;

        [TestInitialize]
        public void Initialize()
        {
            _estimator = new ZxcvbnEstimator();
        }

        #region Tests from official test page

        // Source of examples: https://dl.dropboxusercontent.com/u/209/zxcvbn/test/index.html

        [TestMethod]
        public void Password_zxcvbn()
        {
            // Act
            var result = _estimator.EstimateStrength("zxcvbn");

            // Assert
            Assert.AreEqual("zxcvbn", result.Password);
            Assert.AreEqual(1.76343, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("35 minutes", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
        }

        [TestMethod]
        public void Password_qwER43__()
        {
            // Act
            var result = _estimator.EstimateStrength("qwER43@!");

            // Assert
            Assert.AreEqual("qwER43@!", result.Password);
            Assert.AreEqual(7.95651, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(2, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("10 days", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("3 hours", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("Short keyboard patterns are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Use a longer keyboard pattern with more turns", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_Tr0ub4dour_3()
        {
            // Act
            var result = _estimator.EstimateStrength("Tr0ub4dour&3");

            // Assert
            Assert.AreEqual("Tr0ub4dour&3", result.Password);
            Assert.AreEqual(7.28008, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(2, result.Score);
            Assert.AreEqual("21 years", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("2 days", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("32 minutes", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(3, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Capitalization doesn't help very much", result.Feedback.Suggestions.ToList()[1]);
            Assert.AreEqual("Predictable substitutions like '@' instead of 'a' don't help very much", result.Feedback.Suggestions.ToList()[2]);
        }

        [TestMethod]
        public void Password_correcthorsebatterystaple()
        {
            // Act
            var result = _estimator.EstimateStrength("correcthorsebatterystaple");

            // Assert
            Assert.AreEqual("correcthorsebatterystaple", result.Password);
            Assert.AreEqual(14.43696, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("8 hours", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_coRrecth0rseba__ery9_23_2007staple_()
        {
            // Act
            var result = _estimator.EstimateStrength("coRrecth0rseba++ery9.23.2007staple$");

            // Assert
            Assert.AreEqual("coRrecth0rseba++ery9.23.2007staple$", result.Password);
            Assert.AreEqual(20.7201, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_p_ssword()
        {
            // Act
            var result = _estimator.EstimateStrength("p@ssword");

            // Assert
            Assert.AreEqual("p@ssword", result.Password);
            Assert.AreEqual(0.69897, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("3 minutes", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is similar to a commonly used password", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Predictable substitutions like '@' instead of 'a' don't help very much", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_p___word()
        {
            // Act
            var result = _estimator.EstimateStrength("p@$$word");

            // Assert
            Assert.AreEqual("p@$$word", result.Password);
            Assert.AreEqual(0.95424, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("5 minutes", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is similar to a commonly used password", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Predictable substitutions like '@' instead of 'a' don't help very much", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_123456()
        {
            // Act
            var result = _estimator.EstimateStrength("123456");

            // Assert
            Assert.AreEqual("123456", result.Password);
            Assert.AreEqual(0.30103, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("1 minute", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is a top-10 common password", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("All-uppercase is almost as easy to guess as all-lowercase", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_123456789()
        {
            // Act
            var result = _estimator.EstimateStrength("123456789");

            // Assert
            Assert.AreEqual("123456789", result.Password);
            Assert.AreEqual(0.77815, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("4 minutes", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is a top-10 common password", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("All-uppercase is almost as easy to guess as all-lowercase", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_11111111()
        {
            // Act
            var result = _estimator.EstimateStrength("11111111");

            // Assert
            Assert.AreEqual("11111111", result.Password);
            Assert.AreEqual(1.80618, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("38 minutes", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is a top-100 common password", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("All-uppercase is almost as easy to guess as all-lowercase", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_zxcvbnm___()
        {
            // Act
            var result = _estimator.EstimateStrength("zxcvbnm,./");

            // Assert
            Assert.AreEqual("zxcvbnm,./", result.Password);
            Assert.AreEqual(3.58984, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual("2 days", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("39 seconds", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("Straight rows of keys are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Use a longer keyboard pattern with more turns", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_love88()
        {
            // Act
            var result = _estimator.EstimateStrength("love88");

            // Assert
            Assert.AreEqual("love88", result.Password);
            Assert.AreEqual(4.22011, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual("7 days", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("3 minutes", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("2 seconds", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is similar to a commonly used password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_angel08()
        {
            // Act
            var result = _estimator.EstimateStrength("angel08");

            // Assert
            Assert.AreEqual("angel08", result.Password);
            Assert.AreEqual(4.35801, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual("10 days", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("4 minutes", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("2 seconds", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("Common names and surnames are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Predictable substitutions like '@' instead of 'a' don't help very much", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_monkey13()
        {
            // Act
            var result = _estimator.EstimateStrength("monkey13");

            // Assert
            Assert.AreEqual("monkey13", result.Password);
            Assert.AreEqual(4.11096, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual("5 days", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("2 minutes", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("1 second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_iloveyou()
        {
            // Act
            var result = _estimator.EstimateStrength("iloveyou");

            // Assert
            Assert.AreEqual("iloveyou", result.Password);
            Assert.AreEqual(1.68124, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("29 minutes", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is a top-100 common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_woaini()
        {
            // Act
            var result = _estimator.EstimateStrength("woaini");

            // Assert
            Assert.AreEqual("woaini", result.Password);
            Assert.AreEqual(4.06232, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual("5 days", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("2 minutes", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("1 second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_wang()
        {
            // Act
            var result = _estimator.EstimateStrength("wang");

            // Assert
            Assert.AreEqual("wang", result.Password);
            Assert.AreEqual(2.94596, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("9 hours", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("9 seconds", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("Names and surnames by themselves are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_tianya()
        {
            // Act
            var result = _estimator.EstimateStrength("tianya");

            // Assert
            Assert.AreEqual("tianya", result.Password);
            Assert.AreEqual(5.31492, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual("3 months", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("34 minutes", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("21 seconds", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("Common names and surnames are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_zhang198822()
        {
            // Act
            var result = _estimator.EstimateStrength("zhang198822");

            // Assert
            Assert.AreEqual("zhang198822", result.Password);
            Assert.AreEqual(7.67744, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(2, result.Score);
            Assert.AreEqual("53 years", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("6 days", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("1 hour", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("Dates are often easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Avoid dates and years that are associated with you", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_li4478()
        {
            // Act
            var result = _estimator.EstimateStrength("li4478");

            // Assert
            Assert.AreEqual("li4478", result.Password);
            Assert.AreEqual(6, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual("1 year", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("3 hours", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("2 minutes", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_a6a4Aa8a()
        {
            // Act
            var result = _estimator.EstimateStrength("a6a4Aa8a");

            // Assert
            Assert.AreEqual("a6a4Aa8a", result.Password);
            Assert.AreEqual(8, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(2, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("12 days", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("3 hours", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_b6b4Bb8b()
        {
            // Act
            var result = _estimator.EstimateStrength("b6b4Bb8b");

            // Assert
            Assert.AreEqual("b6b4Bb8b", result.Password);
            Assert.AreEqual(8, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(2, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("12 days", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("3 hours", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_z6z4Zz8z()
        {
            // Act
            var result = _estimator.EstimateStrength("z6z4Zz8z");

            // Assert
            Assert.AreEqual("z6z4Zz8z", result.Password);
            Assert.AreEqual(8, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(2, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("12 days", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("3 hours", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_aiIiAaIA()
        {
            // Act
            var result = _estimator.EstimateStrength("aiIiAaIA");

            // Assert
            Assert.AreEqual("aiIiAaIA", result.Password);
            Assert.AreEqual(8, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(2, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("12 days", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("3 hours", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_zxXxZzXZ()
        {
            // Act
            var result = _estimator.EstimateStrength("zxXxZzXZ");

            // Assert
            Assert.AreEqual("zxXxZzXZ", result.Password);
            Assert.AreEqual(8, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(2, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("12 days", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("3 hours", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_pässwörd()
        {
            // Act
            var result = _estimator.EstimateStrength("pässwörd");

            // Assert
            Assert.AreEqual("pässwörd", result.Password);
            Assert.AreEqual(8, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(2, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("12 days", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("3 hours", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_alpha_bravo_charlie_delta()
        {
            // Act
            var result = _estimator.EstimateStrength("alpha bravo charlie delta");

            // Assert
            Assert.AreEqual("alpha bravo charlie delta", result.Password);
            Assert.AreEqual(17.7335, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("2 years", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_a_b_c_d_e_f_g_h_i_j_k_l_m_n_o_p_q_r_s_t_u_v_w_x_y_z_0_1_2_3_4_5_6_7_8_9()
        {
            // Act
            var result = _estimator.EstimateStrength("a b c d e f g h i j k l m n o p q r s t u v w x y z 0 1 2 3 4 5 6 7 8 9");

            // Assert
            Assert.AreEqual("a b c d e f g h i j k l m n o p q r s t u v w x y z 0 1 2 3 4 5 6 7 8 9", result.Password);
            Assert.AreEqual(71, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_a_b_c_1_2_3()
        {
            // Act
            var result = _estimator.EstimateStrength("a b c 1 2 3");

            // Assert
            Assert.AreEqual("a b c 1 2 3", result.Password);
            Assert.AreEqual(11, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("31 years", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("4 months", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("10 seconds", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_correct_horse_battery_staple()
        {
            // Act
            var result = _estimator.EstimateStrength("correct-horse-battery-staple");

            // Assert
            Assert.AreEqual("correct-horse-battery-staple", result.Password);
            Assert.AreEqual(20.33003, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_correct_horse_battery_staple_2()
        {
            // Act
            var result = _estimator.EstimateStrength("correct.horse.battery.staple");

            // Assert
            Assert.AreEqual("correct.horse.battery.staple", result.Password);
            Assert.AreEqual(20.33003, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_correct_horse_battery_staple_3()
        {
            // Act
            var result = _estimator.EstimateStrength("correct,horse,battery,staple");

            // Assert
            Assert.AreEqual("correct,horse,battery,staple", result.Password);
            Assert.AreEqual(20.33003, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_correct_horse_battery_staple_4()
        {
            // Act
            var result = _estimator.EstimateStrength("correct~horse~battery~staple");

            // Assert
            Assert.AreEqual("correct~horse~battery~staple", result.Password);
            Assert.AreEqual(20.33003, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_WhyfaultthebardifhesingstheArgives_harshfate_()
        {
            // Act
            var result = _estimator.EstimateStrength("WhyfaultthebardifhesingstheArgives’harshfate?");

            // Assert
            Assert.AreEqual("WhyfaultthebardifhesingstheArgives’harshfate?", result.Password);
            Assert.AreEqual(43.01465, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_Eupithes_sonAntinousbroketheirsilence()
        {
            // Act
            var result = _estimator.EstimateStrength("Eupithes’sonAntinousbroketheirsilence");

            // Assert
            Assert.AreEqual("Eupithes’sonAntinousbroketheirsilence", result.Password);
            Assert.AreEqual(29.048, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_Athena_lavished_a_marvelous_splendor()
        {
            // Act
            var result = _estimator.EstimateStrength("Athena lavished a marvelous splendor");

            // Assert
            Assert.AreEqual("Athena lavished a marvelous splendor", result.Password);
            Assert.AreEqual(24.18462, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_buckmulliganstenderchant()
        {
            // Act
            var result = _estimator.EstimateStrength("buckmulliganstenderchant");

            // Assert
            Assert.AreEqual("buckmulliganstenderchant", result.Password);
            Assert.AreEqual(16.69761, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("2 months", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_seethenthatyewalkcircumspectly()
        {
            // Act
            var result = _estimator.EstimateStrength("seethenthatyewalkcircumspectly");

            // Assert
            Assert.AreEqual("seethenthatyewalkcircumspectly", result.Password);
            Assert.AreEqual(28.47712, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_LihiandthepeopleofMorianton()
        {
            // Act
            var result = _estimator.EstimateStrength("LihiandthepeopleofMorianton");

            // Assert
            Assert.AreEqual("LihiandthepeopleofMorianton", result.Password);
            Assert.AreEqual(22.10524, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_establishedinthecityofZarahemla()
        {
            // Act
            var result = _estimator.EstimateStrength("establishedinthecityofZarahemla");

            // Assert
            Assert.AreEqual("establishedinthecityofZarahemla", result.Password);
            Assert.AreEqual(21.1253, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password___________()
        {
            // Act
            var result = _estimator.EstimateStrength("!\"£$%^&*()");

            // Assert
            Assert.AreEqual("!\"£$%^&*()", result.Password);
            Assert.AreEqual(7.01611, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(2, result.Score);
            Assert.AreEqual("12 years", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("1 day", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("17 minutes", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("Straight rows of keys are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Use a longer keyboard pattern with more turns", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_D0g__________________()
        {
            // Act
            var result = _estimator.EstimateStrength("D0g..................");

            // Assert
            Assert.AreEqual("D0g..................", result.Password);
            Assert.AreEqual(5.64542, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual("6 months", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("1 hour", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("44 seconds", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("Repeats like \"aaa\" are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Avoid repeated words and characters", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_abcdefghijk987654321()
        {
            // Act
            var result = _estimator.EstimateStrength("abcdefghijk987654321");

            // Assert
            Assert.AreEqual("abcdefghijk987654321", result.Password);
            Assert.AreEqual(4.17609, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual("6 days", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("3 minutes", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("2 seconds", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("Sequences like abc or 6543 are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Avoid sequences", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_neverforget13_3_1997()
        {
            // Act
            var result = _estimator.EstimateStrength("neverforget13/3/1997");

            // Assert
            Assert.AreEqual("neverforget13/3/1997", result.Password);
            Assert.AreEqual(9.5426, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(3, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("1 year", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("4 days", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_1qaz2wsx3edc()
        {
            // Act
            var result = _estimator.EstimateStrength("1qaz2wsx3edc");

            // Assert
            Assert.AreEqual("1qaz2wsx3edc", result.Password);
            Assert.AreEqual(3.00043, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("10 hours", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("10 seconds", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_temppass22()
        {
            // Act
            var result = _estimator.EstimateStrength("temppass22");

            // Assert
            Assert.AreEqual("temppass22", result.Password);
            Assert.AreEqual(5.58827, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual("5 months", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("1 hour", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("39 seconds", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is similar to a commonly used password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_briansmith()
        {
            // Act
            var result = _estimator.EstimateStrength("briansmith");

            // Assert
            Assert.AreEqual("briansmith", result.Password);
            Assert.AreEqual(4.17609, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual("6 days", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("3 minutes", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("2 seconds", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("Common names and surnames are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_briansmith4mayor()
        {
            // Act
            var result = _estimator.EstimateStrength("briansmith4mayor");

            // Assert
            Assert.AreEqual("briansmith4mayor", result.Password);
            Assert.AreEqual(10.17898, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("5 years", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("17 days", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("2 seconds", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
         }

        [TestMethod]
        public void Password_password1()
        {
            // Act
            var result = _estimator.EstimateStrength("password1");

            // Assert
            Assert.AreEqual("password1", result.Password);
            Assert.AreEqual(2.27875, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("2 hours", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("2 seconds", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_viking()
        {
            // Act
            var result = _estimator.EstimateStrength("viking");

            // Assert
            Assert.AreEqual("viking", result.Password);
            Assert.AreEqual(2.38739, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("2 hours", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("2 seconds", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_thx1138()
        {
            // Act
            var result = _estimator.EstimateStrength("thx1138");

            // Assert
            Assert.AreEqual("thx1138", result.Password);
            Assert.AreEqual(2.32015, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("2 hours", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("2 seconds", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_ScoRpi0ns()
        {
            // Act
            var result = _estimator.EstimateStrength("ScoRpi0ns");

            // Assert
            Assert.AreEqual("ScoRpi0ns", result.Password);
            Assert.AreEqual(5.46189, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual("4 months", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("48 minutes", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("29 seconds", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Predictable substitutions like '@' instead of 'a' don't help very much", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_do_you_know()
        {
            // Act
            var result = _estimator.EstimateStrength("do you know");

            // Assert
            Assert.AreEqual("do you know", result.Password);
            Assert.AreEqual(9, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(3, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("4 months", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("1 day", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_ryanhunter2000()
        {
            // Act
            var result = _estimator.EstimateStrength("ryanhunter2000");

            // Assert
            Assert.AreEqual("ryanhunter2000", result.Password);
            Assert.AreEqual(8.00325, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(3, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("12 days", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("3 hours", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_rianhunter2000()
        {
            // Act
            var result = _estimator.EstimateStrength("rianhunter2000");

            // Assert
            Assert.AreEqual("rianhunter2000", result.Password);
            Assert.AreEqual(8.39794, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(3, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("29 days", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("7 hours", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_asdfghju7654rewq()
        {
            // Act
            var result = _estimator.EstimateStrength("asdfghju7654rewq");

            // Assert
            Assert.AreEqual("asdfghju7654rewq", result.Password);
            Assert.AreEqual(8.96529, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(3, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("3 months", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("1 day", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_AOEUIDHG____LS_()
        {
            // Act
            var result = _estimator.EstimateStrength("AOEUIDHG&*()LS_");

            // Assert
            Assert.AreEqual("AOEUIDHG&*()LS_", result.Password);
            Assert.AreEqual(9.10726, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(3, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("5 months", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("1 day", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_12345678()
        {
            // Act
            var result = _estimator.EstimateStrength("12345678");

            // Assert
            Assert.AreEqual("12345678", result.Password);
            Assert.AreEqual(0.60206, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("2 minutes", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is a top-10 common password", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("All-uppercase is almost as easy to guess as all-lowercase", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_defghi6789()
        {
            // Act
            var result = _estimator.EstimateStrength("defghi6789");

            // Assert
            Assert.AreEqual("defghi6789", result.Password);
            Assert.AreEqual(4.40824, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual("11 days", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("4 minutes", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("3 seconds", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("Sequences like abc or 6543 are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Avoid sequences", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_rosebud()
        {
            // Act
            var result = _estimator.EstimateStrength("rosebud");

            // Assert
            Assert.AreEqual("rosebud", result.Password);
            Assert.AreEqual(2.43457, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("3 hours", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("3 seconds", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_Rosebud()
        {
            // Act
            var result = _estimator.EstimateStrength("Rosebud");

            // Assert
            Assert.AreEqual("Rosebud", result.Password);
            Assert.AreEqual(2.7348, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("5 hours", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("5 seconds", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Capitalization doesn't help very much", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_ROSEBUD()
        {
            // Act
            var result = _estimator.EstimateStrength("ROSEBUD");

            // Assert
            Assert.AreEqual("ROSEBUD", result.Password);
            Assert.AreEqual(2.7348, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("5 hours", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("5 seconds", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("All-uppercase is almost as easy to guess as all-lowercase", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_rosebuD()
        {
            // Act
            var result = _estimator.EstimateStrength("rosebuD");

            // Assert
            Assert.AreEqual("rosebuD", result.Password);
            Assert.AreEqual(2.7348, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual("5 hours", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("5 seconds", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
        }

        [TestMethod]
        public void Password_ros3bud99()
        {
            // Act
            var result = _estimator.EstimateStrength("ros3bud99");

            // Assert
            Assert.AreEqual("ros3bud99", result.Password);
            Assert.AreEqual(4.80754, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual("27 days", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("11 minutes", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("6 seconds", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is similar to a commonly used password", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Predictable substitutions like '@' instead of 'a' don't help very much", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_r0s3bud99()
        {
            // Act
            var result = _estimator.EstimateStrength("r0s3bud99");

            // Assert
            Assert.AreEqual("r0s3bud99", result.Password);
            Assert.AreEqual(5.07335, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual("2 months", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("20 minutes", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("12 seconds", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("This is similar to a commonly used password", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Predictable substitutions like '@' instead of 'a' don't help very much", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_R0_38uD99()
        {
            // Act
            var result = _estimator.EstimateStrength("R0$38uD99");

            // Assert
            Assert.AreEqual("R0$38uD99", result.Password);
            Assert.AreEqual(6.11754, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(2, result.Score);
            Assert.AreEqual("1 year", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("4 hours", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("2 minutes", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Predictable substitutions like '@' instead of 'a' don't help very much", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void Password_verlineVANDERMARK()
        {
            // Act
            var result = _estimator.EstimateStrength("verlineVANDERMARK");

            // Assert
            Assert.AreEqual("verlineVANDERMARK", result.Password);
            Assert.AreEqual(10.38918, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("8 years", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("28 days", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("2 seconds", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_eheuczkqyq()
        {
            // Act
            var result = _estimator.EstimateStrength("eheuczkqyq");

            // Assert
            Assert.AreEqual("eheuczkqyq", result.Password);
            Assert.AreEqual(10, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(3, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("3 years", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("12 days", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("1 second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_rWibMFACxAUGZmxhVncy()
        {
            // Act
            var result = _estimator.EstimateStrength("rWibMFACxAUGZmxhVncy");

            // Assert
            Assert.AreEqual("rWibMFACxAUGZmxhVncy", result.Password);
            Assert.AreEqual(20, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        public void Password_Ba9ZyWABu99_BK_6MBgbH88Tofv_vs_w()
        {
            // Act
            var result = _estimator.EstimateStrength("Ba9ZyWABu99[BK#6MBgbH88Tofv)vs$w");

            // Assert
            Assert.AreEqual("Ba9ZyWABu99[BK#6MBgbH88Tofv)vs$w", result.Password);
            Assert.AreEqual(32, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        #endregion

        #region Long passwords

        [TestMethod]
        public void PasswordLength_128_Simple()
        {
            // Act
            var result = _estimator.EstimateStrength("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

            // Assert
            Assert.AreEqual("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", result.Password);
            Assert.AreEqual(3.18667, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual("15 hours", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("15 seconds", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("less than a second", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("Repeats like \"aaa\" are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Count());
            Assert.AreEqual("Add another word or two. Uncommon words are better.", result.Feedback.Suggestions.ToList()[0]);
            Assert.AreEqual("Avoid repeated words and characters", result.Feedback.Suggestions.ToList()[1]);
        }

        [TestMethod]
        public void PasswordLength_128_Complex()
        {
            // Act
            var result = _estimator.EstimateStrength("Lpk_PS0w_8JauvudSFE^-4&ysMya1!rI7-WfHk1^vskU3ZZJ?cFWFNP%sRyzJ&a0xiZ@lA3G0fKRfLppFz#$mis6WtTyJ^V#*?%4i+0kw&l4B$=NFx@BJ8c-iDPB!nMW");

            // Assert
            Assert.AreEqual("Lpk_PS0w_8JauvudSFE^-4&ysMya1!rI7-WfHk1^vskU3ZZJ?cFWFNP%sRyzJ&a0xiZ@lA3G0fKRfLppFz#$mis6WtTyJ^V#*?%4i+0kw&l4B$=NFx@BJ8c-iDPB!nMW", result.Password);
            Assert.AreEqual(128, Math.Round(result.GuessesLog10, 5));
            Assert.AreEqual(4, result.Score);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineThrottling100PerHour);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OnlineNoThrottling10PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineSlowHashing1e4PerSecond);
            Assert.AreEqual("centuries", result.CrackTimesDisplay.OfflineFastHashing1e10PerSecond);
            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Password can't be longer than 128 characters")]
        public void PasswordLength_129_Complex()
        {
            // Act
            var result = _estimator.EstimateStrength("Lpk_PS0w_8JauvudSFE^-4&ysMya1!rI7-WfHk1^vskU3ZZJ?cFWFNP%sRyzJ&a0xiZ@lA3G0fKRfLppFz#$mis6WtTyJ^V#*?%4i+0kw&l4B$=NFx@BJ8c-iDPB!nMW_");
        }

        #endregion
    }
}
