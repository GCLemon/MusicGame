using System;

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

        public double GetTimingMSAbs()
        {
            throw new NotImplementedException();
        }

        public double GetTimingMSRel()
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public abstract class LongNote : Note
    {
        public double Length { get; set; }

        public double GetLengthMSAbs()
        {
            throw new NotImplementedException();
        }

        public double GetLengthMSRel()
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class TapNote : Note
    {
        public override NoteType NoteType => NoteType.HoldNote;
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