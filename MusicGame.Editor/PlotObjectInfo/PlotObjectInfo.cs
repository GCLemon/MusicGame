using System;

namespace MusicGame.Editor
{
    [Serializable]
    enum ObjectState
    {
        Unselected,
        Selected,
        Moving
    }

    [Serializable]
    enum ObjectType
    {
        TapNote,
        HoldNote,
        SwipeNote,
        SlideNote,
        SpeedChange,
        TempoChange,
        MeasureChange,
    }

    [Serializable]
    enum LaneType
    {
        Red,
        Yellow,
        Green,
        Blue,
        Orange,
        Purple,
    }

    [Serializable]
    class PlotObjectInfo
    {
        public ObjectState ObjectState { get; set; }
        public ObjectType ObjectType { get; set; }
        public LaneType LaneType { get; set; }
        public double Timing { get; set; }
        public double Length { get; set; }
        public double AfterSpeed { get; set; }
        public double AfterTempo { get; set; }
        public int AfterMeasure { get; set; }
    }
}