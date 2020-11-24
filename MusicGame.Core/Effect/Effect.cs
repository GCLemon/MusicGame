using System;
using System.Collections.Generic;
using System.Linq;

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

        public double GetTimingMSAbs()
        {
            if(_TimingMSAbs == null)
            {
                List<TempoChange> changes = Score.Effects
                    .Where(x => x is TempoChange)
                    .Cast<TempoChange>()
                    .ToList();

                _TimingMSAbs = 0;

                int index = 0;
                double prevTiming = 0;
                double tempo = Score.InitBPM;

                while(index < changes.Count && changes[index].Timing <= Timing)
                {
                    _TimingMSAbs += (int)((changes[index].Timing - prevTiming) * 60000 / tempo);

                    prevTiming = changes[index].Timing;
                    tempo = changes[index].AfterTempo;
                    ++index;
                }

                _TimingMSAbs += (int)((Timing - prevTiming) * 60000 / tempo);
            }

            return _TimingMSAbs.Value;
        }
        private int? _TimingMSAbs = null;
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