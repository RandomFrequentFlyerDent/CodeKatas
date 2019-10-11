using Anagrams;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodeKatasTests
{
    [TestFixture]
    public class AnagramTests
    {
        [Test]
        public void EmptyList()
        {
            var words = new List<string>();
            var actual = Logic.GetAnagrams(words);
            var expected = new Dictionary<string, List<string>>();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneWord()
        {
            var words = new List<string> { "apple" };
            var actual = Logic.GetAnagrams(words);
            var expected = new Dictionary<string, List<string>>();
            expected.Add("apple", new List<string>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TwoWordsNoAnagrams()
        {
            var words = new List<string> { "apple", "pear" };
            var actual = Logic.GetAnagrams(words);
            var expected = new Dictionary<string, List<string>>();
            expected.Add("apple", new List<string>());
            expected.Add("pear", new List<string>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TwoWordsBothAnagrams()
        {
            var words = new List<string> { "done", "node" };
            var actual = Logic.GetAnagrams(words);
            var expected = new Dictionary<string, List<string>>();
            expected.Add("done", new List<string>() { "node" });
            expected.Add("node", new List<string>() { "done" });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FourWordsTwoAnagrams()
        {
            var words = new List<string> { "done", "node", "apple", "pear" };
            var actual = Logic.GetAnagrams(words);
            var expected = new Dictionary<string, List<string>>();
            expected.Add("done", new List<string>() { "node" });
            expected.Add("node", new List<string>() { "done" });
            expected.Add("apple", new List<string>());
            expected.Add("pear", new List<string>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AllWordsAnagrams()
        {
            var words = new List<string> { "skin", "sink", "kins" };
            var actual = Logic.GetAnagrams(words);
            var expected = new Dictionary<string, List<string>>();
            expected.Add("skin", new List<string>() { "sink", "kins" });
            expected.Add("sink", new List<string>() { "skin", "kins" });
            expected.Add("kins", new List<string>() { "skin", "sink" });

            Assert.AreEqual(expected, actual);
        }
    }
}
