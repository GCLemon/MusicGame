using System;

namespace MusicGame.Core
{
    [Serializable]
    public class MeasureLine
    {
        internal Score Score { get; set; }

        public double Timing { get; set; }

        public double GetTimingMSAbs()
        {
            throw new NotImplementedException();
        }

        public double GetTimingMSRel()
        {
            throw new NotImplementedException();
        }
    }
}