using System;
using MusicGame.Core;

namespace MusicGame.CoreTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Score score = Score.CreateNew();

            score.Effects.Add(new MeasureChange { Timing = 4, AfterMeasure = 3 });
            score.Effects.Add(new MeasureChange { Timing = 7, AfterMeasure = 4 });

            Console.WriteLine(score.MeasureLines[0].Timing);
            Console.WriteLine(score.MeasureLines[1].Timing);
            Console.WriteLine(score.MeasureLines[2].Timing);
        }
    }
}
