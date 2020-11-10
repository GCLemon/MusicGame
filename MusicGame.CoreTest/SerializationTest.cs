using NUnit.Framework;
using MusicGame.Core;

namespace MusicGame.CoreTest
{
    public class SerializationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ArraySerialization()
        {
            byte[] serialized = null;

            {
                Score score = Score.CreateNew();
                
                score.Notes.Add(new TapNote() { Timing = 0, LaneType = LaneType.Red });
                score.Notes.Add(new TapNote() { Timing = 1, LaneType = LaneType.Yellow });
                score.Notes.Add(new TapNote() { Timing = 2, LaneType = LaneType.Green });
                score.Notes.Add(new TapNote() { Timing = 3, LaneType = LaneType.Blue });

                score.Notes.Add(new SwipeNote() { Timing = 4, LaneType = LaneType.Orange });
                score.Notes.Add(new SwipeNote() { Timing = 6, LaneType = LaneType.Purple });

                Score.SaveToArray(out serialized, score);
            }
            
            {
                Score score = Score.CreateFromArray(serialized);

                Assert.IsTrue(score.Notes.Count == 6);
                Assert.IsTrue(score.Notes[3].LaneType == LaneType.Blue);
            }
        }

        [Test]
        public void FileSerialization()
        {
            {
                Score score = Score.CreateNew();
                
                score.Notes.Add(new TapNote() { Timing = 0, LaneType = LaneType.Red });
                score.Notes.Add(new TapNote() { Timing = 1, LaneType = LaneType.Yellow });
                score.Notes.Add(new TapNote() { Timing = 2, LaneType = LaneType.Green });
                score.Notes.Add(new TapNote() { Timing = 3, LaneType = LaneType.Blue });

                score.Notes.Add(new SwipeNote() { Timing = 4, LaneType = LaneType.Orange });
                score.Notes.Add(new SwipeNote() { Timing = 6, LaneType = LaneType.Purple });

                Score.SaveToFile("./Serialize.dat", score);
            }
            
            {
                Score score = Score.CreateFromFile("./Serialize.dat");

                Assert.IsTrue(score.Notes.Count == 6);
                Assert.IsTrue(score.Notes[3].LaneType == LaneType.Blue);
            }
        }
    }
}