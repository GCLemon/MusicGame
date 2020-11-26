using Altseed2;
using System;
using System.Collections.Generic;

namespace MusicGame.Editor
{
    public enum EditorMode
    {
        Append,
        Select,
        Delete,
    }
    
    public enum AppendMode
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

    public class EditorModel
    {
        public static EditorModel Instance { get; } = new EditorModel();

        private string _EditPath;

        private Stack<byte[]> _UndoQueue;
        private Stack<byte[]> _RedoQueue;

        public Core.Score Score { get; private set; }

        public int Measure
        {
            get { return _Measure; }
            set { _Measure = Math.Max(value, 1); }
        }
        private int _Measure;

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

        private EditorModel()
        {
            _EditPath = null;
            _UndoQueue = new Stack<byte[]>();
            _RedoQueue = new Stack<byte[]>();
            Score = Core.Score.CreateNew();
            Initialize();
        }

        private void Initialize()
        {
            _UndoQueue.Clear();
            _RedoQueue.Clear();

            Measure = 4;
            Quantize = 16;

            EditorMode = EditorMode.Append;
            AppendMode = AppendMode.TapNote;

            DefaultLength = 1;
            DefaultNextSpeed = 1;
            DefaultNextTempo = 120;
            DefaultNextMeasure = 4;
        }

        public void New()
        {
            _EditPath = null;
            Score = Core.Score.CreateNew();
            Initialize();
        }

        public void Open()
        {
            string path = Engine.Tool.OpenDialog(".score", ".");
            if(path != null && path != string.Empty)
            {
                _EditPath = path;
                Score = Core.Score.CreateFromFile(path);
                Initialize();
            }
        }

        public void Save()
        {
            if(_EditPath == null) SaveAs();
            else Core.Score.SaveToFile(_EditPath, Score);
        }

        public void SaveAs()
        {
            string path = Engine.Tool.SaveDialog(".score", ".");
            if(path != null && path != string.Empty)
            {
                _EditPath = path;
                Core.Score.SaveToFile(path, Score);
            }
        }

        public void ArraySave()
        {
            Core.Score.SaveToArray(out byte[] serialzed, Score);
            _UndoQueue.Push(serialzed);
        }

        public void Undo()
        {
            if(_UndoQueue.TryPop(out byte[] serialized))
            {
                Score = Core.Score.CreateFromArray(serialized);
                _RedoQueue.Push(serialized);
            }
        }

        public void Redo()
        {
            if(_RedoQueue.TryPop(out byte[] serialized))
            {
                Score = Core.Score.CreateFromArray(serialized);
                _UndoQueue.Push(serialized);
            }
        }
    }
}