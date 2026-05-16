namespace Kursowaya_V.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ShuffleTests
    {
        [Test]
        public void Shuffle_PreservesAllElements()
        {
            var form = new Form1();
            var original = new List<string> { "A", "B", "C", "D", "E" };
            var list = new List<string>(original);
            form.Shuffle(list);
            Assert.That(list.Count, Is.EqualTo(original.Count));
            foreach (var item in original)
                Assert.That(list.Contains(item), Is.True);
        }

        [Test]
        public void Shuffle_EmptyList_DoesNothing()
        {
            var form = new Form1();
            var list = new List<string>();
            form.Shuffle(list);
            Assert.That(list.Count, Is.EqualTo(0));
        }

        [Test]
        public void Shuffle_SingleElement_DoesNothing()
        {
            var form = new Form1();
            var list = new List<string> { "only" };
            form.Shuffle(list);
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0], Is.EqualTo("only"));
        }

        [Test]
        public void Shuffle_LargeList_PreservesElements()
        {
            var form = new Form1();
            var original = Enumerable.Range(1, 100).Select(i => i.ToString()).ToList();
            var list = new List<string>(original);
            form.Shuffle(list);
            Assert.That(list.Count, Is.EqualTo(100));
        }

        [Test]
        public void Shuffle_ProducesDifferentOrder()
        {
            var form = new Form1();
            var original = Enumerable.Range(1, 20).Select(i => i.ToString()).ToList();
            bool anyDifferent = false;
            for (int i = 0; i < 10; i++)
            {
                var list = new List<string>(original);
                form.Shuffle(list);
                if (!list.SequenceEqual(original))
                {
                    anyDifferent = true;
                    break;
                }
            }
            Assert.That(anyDifferent, Is.True);
        }

        [Test]
        public void Shuffle_PairsList_AllPairsPresent()
        {
            var form = new Form1();
            var pairs = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                pairs.Add($"card{i}");
                pairs.Add($"card{i}");
            }
            var shuffled = new List<string>(pairs);
            form.Shuffle(shuffled);
            Assert.That(shuffled.Count, Is.EqualTo(16));
            for (int i = 0; i < 8; i++)
            {
                Assert.That(shuffled.Count(x => x == $"card{i}"), Is.EqualTo(2));
            }
        }
    }

    [TestFixture]
    public class CheckRecordsTests
    {
        [Test]
        public void CheckRecords_FirstGame_SetsRecords()
        {
            var form = new Form1();
            form.Seconds = 30;
            form.MoveCount = 15;
            form.CheckRecords();
            Assert.That(form.bestTime, Is.EqualTo(30));
            Assert.That(form.bestMoves, Is.EqualTo(15));
        }

        [Test]
        public void CheckRecords_BetterTime_UpdatesTimeRecord()
        {
            var form = new Form1();
            form.bestTime = 50;
            form.bestMoves = 20;
            form.Seconds = 30;
            form.MoveCount = 25;
            form.CheckRecords();
            Assert.That(form.bestTime, Is.EqualTo(30));
            Assert.That(form.bestMoves, Is.EqualTo(20));
        }

        [Test]
        public void CheckRecords_BetterMoves_UpdatesMovesRecord()
        {
            var form = new Form1();
            form.bestTime = 30;
            form.bestMoves = 20;
            form.Seconds = 40;
            form.MoveCount = 15;
            form.CheckRecords();
            Assert.That(form.bestTime, Is.EqualTo(30));
            Assert.That(form.bestMoves, Is.EqualTo(15));
        }

        [Test]
        public void CheckRecords_WorseResult_KeepsOldRecords()
        {
            var form = new Form1();
            form.bestTime = 20;
            form.bestMoves = 10;
            form.Seconds = 50;
            form.MoveCount = 30;
            form.CheckRecords();
            Assert.That(form.bestTime, Is.EqualTo(20));
            Assert.That(form.bestMoves, Is.EqualTo(10));
        }

        [Test]
        public void CheckRecords_EqualResult_KeepsOldRecords()
        {
            var form = new Form1();
            form.bestTime = 25;
            form.bestMoves = 12;
            form.Seconds = 25;
            form.MoveCount = 12;
            form.CheckRecords();
            Assert.That(form.bestTime, Is.EqualTo(25));
            Assert.That(form.bestMoves, Is.EqualTo(12));
        }

        [Test]
        public void CheckRecords_BothBetter_UpdatesBoth()
        {
            var form = new Form1();
            form.bestTime = 60;
            form.bestMoves = 30;
            form.Seconds = 20;
            form.MoveCount = 10;
            form.CheckRecords();
            Assert.That(form.bestTime, Is.EqualTo(20));
            Assert.That(form.bestMoves, Is.EqualTo(10));
        }
    }

    [TestFixture]
    public class GameLogicTests
    {
        [Test]
        public void StartGame_ResetsCounters()
        {
            var form = new Form1();
            form.MoveCount = 100;
            form.Seconds = 50;
            form.StartGame(4);
            Assert.That(form.MoveCount, Is.EqualTo(0));
            Assert.That(form.Seconds, Is.EqualTo(0));
        }

        [Test]
        public void StartGame_SetsGridSize()
        {
            var form = new Form1();
            form.StartGame(8);
            Assert.That(form.GridSize, Is.EqualTo(8));
        }

        [Test]
        public void StartGame_10x10_SetsGridSize()
        {
            var form = new Form1();
            form.StartGame(10);
            Assert.That(form.GridSize, Is.EqualTo(10));
        }

        [Test]
        public void EmojisArray_Has50Elements()
        {
            var form = new Form1();
            Assert.That(form.GetEmojis().Length, Is.EqualTo(50));
        }

        [Test]
        public void EmojisArray_AllUnique()
        {
            var form = new Form1();
            var unique = new HashSet<string>(form.GetEmojis());
            Assert.That(unique.Count, Is.EqualTo(50));
        }
    }
}