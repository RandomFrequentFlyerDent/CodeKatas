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

        [Test]
        public void GetMostWords()
        {
            var dict = new Dictionary<string, List<string>>();
            dict.Add("most", new List<string> { "bla", "bla2", "bla3" });
            dict.Add("less", new List<string> { "bla", "bla2" });
            dict.Add("least", new List<string> { "bla" });

            var actual = Logic.GetMostWords(dict);
            var expected = "bla bla2 bla3 most";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetLongestWords()
        {
            var dict = new Dictionary<string, List<string>>();
            dict.Add("longest99", new List<string> { "blaaaaaaa", "bla222222", "bla33333" });
            dict.Add("short", new List<string> { "blaaa", "bla222" });
            dict.Add("sho", new List<string> { "bla" });

            var actual = Logic.GetLongestWords(dict);
            var expected = "blaaaaaaa bla222222 bla33333 longest99";

            Assert.AreEqual(expected, actual);
        }
    }
}
