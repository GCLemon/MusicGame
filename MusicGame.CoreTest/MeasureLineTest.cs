using System.Diagnostics;
using NUnit.Framework;
using MusicGame.Core;

namespace MusicGame.CoreTest
{
    public class MeasureLineTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MeasureChange()
        {
            Score score = Score.CreateNew();

            score.Effects.Add(new MeasureChange { Timing = 4, AfterMeasure = 3 });
            score.Effects.Add(new MeasureChange { Timing = 7, AfterMeasure = 4 });

            Debug.WriteLine(score.MeasureLines[0].Timing);
            Debug.WriteLine(score.MeasureLines[1].Timing);
            Debug.WriteLine(score.MeasureLines[2].Timing);
        }
    }
}