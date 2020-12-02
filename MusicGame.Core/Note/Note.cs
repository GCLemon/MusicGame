using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicGame.Core
{
    [Serializable]
    public enum NoteType
    {
        TapNote,
        HoldNote,
        SwipeNote,
        SlideNote,
    }

    [Serializable]
    public enum LaneType
    {
        Red,
        Yellow,
        Green,
        Blue,
        Orange,
        Purple,
    }

    [Serializable]
    public abstract class Note
    {
        internal Score Score { get; set; }

        public abstract NoteType NoteType { get; }

        public LaneType LaneType { get; set; }
        public double Timing { get; set; }

        public int GetTimingMSAbs()
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

        public int GetTimingMSRel()
        {
            if(_TimingMSRel == null)
            {
                List<Effect> changes = Score.Effects
                    .Where(x => x is TempoChange || x is SpeedChange)
                    .ToList();

                _TimingMSRel = 0;

                int index = 0;
                double prevTiming = 0;
                double tempo = Score.InitBPM;
                double speed = 1;

                while(index < changes.Count && changes[index].Timing <= Timing)
                {
                    _TimingMSRel += (int)((changes[index].Timing - prevTiming) * 60000 * speed / tempo);

                    prevTiming = changes[index].Timing;
                    if(changes[index] is TempoChange) tempo = ((TempoChange)changes[index]).AfterTempo;
                    if(changes[index] is SpeedChange) speed = ((SpeedChange)changes[index]).AfterSpeed;
                    ++index;
                }

                _TimingMSRel += (int)((Timing - prevTiming) * 60000 / tempo);
            }

            return _TimingMSRel.Value;
        }
        private int? _TimingMSRel = null;
    }

    [Serializable]
    public abstract class LongNote : Note
    {
        public double Length { get; set; }

        public double GetLengthMSAbs()
        {
            if(_LengthMSAbs == null)
            {
                List<TempoChange> changes = Score.Effects
                    .Where(x => x is TempoChange)
                    .Cast<TempoChange>()
                    .ToList();

                _LengthMSAbs = 0;

                int index = 0;
                double prevTiming = 0;
                double tempo = Score.InitBPM;

                while(index < changes.Count && changes[index].Timing <= Timing + Length)
                {
                    _LengthMSAbs += (int)((changes[index].Timing - prevTiming) * 60000 / tempo);

                    prevTiming = changes[index].Timing;
                    tempo = changes[index].AfterTempo;
                    ++index;
                }

                _LengthMSAbs += (int)((Timing - prevTiming) * 60000 / tempo);
            }

            return _LengthMSAbs.Value - GetTimingMSAbs();
        }
        private int? _LengthMSAbs = null;

        public double GetLengthMSRel()
        {
            if(_LengthMSRel == null)
            {
                List<Effect> changes = Score.Effects
                    .Where(x => x is TempoChange || x is SpeedChange)
                    .ToList();

                _LengthMSRel = 0;

                int index = 0;
                double prevTiming = 0;
                double tempo = Score.InitBPM;
                double speed = 1;

                while(index < changes.Count && changes[index].Timing <= Timing + Length)
                {
                    _LengthMSRel += (int)((changes[index].Timing - prevTiming) * 60000 * speed / tempo);

                    prevTiming = changes[index].Timing;
                    if(changes[index] is TempoChange) tempo = ((TempoChange)changes[index]).AfterTempo;
                    if(changes[index] is SpeedChange) speed = ((SpeedChange)changes[index]).AfterSpeed;
                    ++index;
                }

                _LengthMSRel += (int)((Timing - prevTiming) * 60000 / tempo);
            }

            return _LengthMSRel.Value - GetTimingMSRel();
        }
        private int? _LengthMSRel = null;
    }

    [Serializable]
    public class TapNote : Note
    {
        public override NoteType NoteType => NoteType.TapNote;
    }

    [Serializable]
    public class HoldNote : LongNote
    {
        public override NoteType NoteType => NoteType.HoldNote;
    }

    [Serializable]
    public class SwipeNote : Note
    {
        public override NoteType NoteType => NoteType.SwipeNote;
    }

    [Serializable]
    public class SlideNote : LongNote
    {
        public override NoteType NoteType => NoteType.SlideNote;
    }
}