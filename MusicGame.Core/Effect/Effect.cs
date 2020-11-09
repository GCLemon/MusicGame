using System;

namespace MusicGame.Core
{
    public enum EffectType
    {
        SpeedChange,
        TempoChange,
        MeasureChange,
    }

    [Serializable]
    public abstract class Effect
    {
        internal Score Score { get; set; }

        public abstract EffectType EffectType { get; }

        public double Timing { get; set; }

        public double GetMSAbs()
        {
            return 0;
        }
    }

    [Serializable]
    public class SpeedChange : Effect
    {
        public override EffectType EffectType => EffectType.SpeedChange;

        public double AfterSpeed { get; set; }
    }

    [Serializable]
    public class TempoChange : Effect
    {
        public override EffectType EffectType => EffectType.TempoChange;

        public double AfterTempo { get; set; }
    }

    [Serializable]
    public class MeasureChange : Effect
    {
        public override EffectType EffectType => EffectType.MeasureChange;

        public int AfterMeasure { get; set; }
    }
}