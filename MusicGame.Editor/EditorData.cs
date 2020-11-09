using System;
using System.Collections.Generic;

namespace ScoreEditor
{
    enum EditorMode
    {
        Append,
        Select,
        Delete,
    }

    enum AppendMode
    {
        TapNote,
        HoldNote,
        SwipeNoteRight,
        SlideNoteRight,
        SwipeNoteLeft,
        SlideNoteLeft,
        SpeedChange,
        TempoChange,
        MeasureChange,
    }

    class EditorData
    {
        public static EditorData Instance { get; } = new EditorData();

        public int BeatPerMeasure
        {
            get { return _BeatPerMeasure; }
            set { _BeatPerMeasure = Math.Max(value, 1); }
        }
        private int _BeatPerMeasure;
        public int Quantize
        {
            get { return _Quantize; }
            set { _Quantize = Math.Max(value, 1); }
        }
        private int _Quantize;

        public EditorMode EditorMode { get; set; }
        public AppendMode AppendMode { get; set; }

        public float DefaultLength
        {
            get { return _DefaultLength; }
            set { _DefaultLength = Math.Max(value, 0); }
        }
        private float _DefaultLength;

        public float DefaultNextSpeed
        {
            get { return _DefaultNextSpeed; }
            set { _DefaultNextSpeed = value; }
        }
        private float _DefaultNextSpeed;

        public float DefaultNextTempo
        {
            get { return _DefaultNextTempo; }
            set { _DefaultNextTempo = Math.Max(value, 1); }
        }
        private float _DefaultNextTempo;

        public int DefaultNextMeasure
        {
            get { return _DefaultNextMeasure; }
            set { _DefaultNextMeasure = Math.Max(value, 1); }
        }
        private int _DefaultNextMeasure;

        public List<PlotObjectInfo> ClipBoard { get; set; }

        private EditorData() { Initialize(); }

        public void Initialize()
        {
            BeatPerMeasure = 4;
            Quantize = 16;

            EditorMode = EditorMode.Append;
            AppendMode = AppendMode.TapNote;

            DefaultLength = 1;
            DefaultNextSpeed = 1;
            DefaultNextTempo = 120;
            DefaultNextMeasure = 4;

            ClipBoard = new List<PlotObjectInfo>();
        }
    }
}