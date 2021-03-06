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

        public float DefaultAfterSpeed
        {
            get { return _DefaultAfterSpeed; }
            set { _DefaultAfterSpeed = value; }
        }
        private float _DefaultAfterSpeed;

        public float DefaultAfterTempo
        {
            get { return _DefaultAfterTempo; }
            set { _DefaultAfterTempo = Math.Max(value, 1); }
        }
        private float _DefaultAfterTempo;

        public int DefaultAfterMeasure
        {
            get { return _DefaultAfterMeasure; }
            set { _DefaultAfterMeasure = Math.Max(value, 1); }
        }
        private int _DefaultAfterMeasure;

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
            DefaultAfterSpeed = 1;
            DefaultAfterTempo = 120;
            DefaultAfterMeasure = 4;
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
            if(_UndoQueue.TryPop(out byte[] undo))
            {
                Core.Score.SaveToArray(out byte[] redo, Score);
                _RedoQueue.Push(redo);

                Score = Core.Score.CreateFromArray(undo);
            }
        }

        public void Redo()
        {
            if(_RedoQueue.TryPop(out byte[] redo))
            {
                Core.Score.SaveToArray(out byte[] undo, Score);
                _UndoQueue.Push(undo);

                Score = Core.Score.CreateFromArray(redo);
            }
        }
    }
}