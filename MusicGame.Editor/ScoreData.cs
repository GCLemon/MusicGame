using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ScoreEditor
{
    [Serializable]
    enum Difficulty
    {
        Novice,
        Medium,
        Expert,
        Maniac,
    }

    [Serializable]
    class ScoreData
    {
        public static ScoreData Instance { get; private set; } = new ScoreData();
        
        [NonSerialized]
        private static Stack<byte[]> _UndoStack = new Stack<byte[]>();

        [NonSerialized]
        private static Stack<byte[]> _RedoStack = new Stack<byte[]>();

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        private string _Title;
        public string Subtitle
        {
            get { return _Subtitle; }
            set { _Subtitle = value; }
        }
        private string _Subtitle;
        public string SoundPath
        {
            get { return _SoundPath; }
            set { _SoundPath = value; }
        }
        private string _SoundPath;
        public string JacketPath
        {
            get { return _JacketPath; }
            set { _JacketPath = value; }
        }
        private string _JacketPath;

        public Difficulty Difficulty
        {
            get { return _Difficulty; }
            set { _Difficulty = value; }
        }
        private Difficulty _Difficulty;
        public int Level 
        {
            get { return _Level; }
            set { _Level = Math.Clamp(value, 1, 15); }
        }
        private int _Level;

        public double InitialBPM
        {
            get { return _InitialBPM; }
            set { _InitialBPM = Math.Max(0, value); }
        }
        private double _InitialBPM;
        public double Ofset
        {
            get { return _Ofset; }
            set { _Ofset = value; }
        }
        private double _Ofset;

        public double DemoStart
        {
            get { return _DemoStart; }
            set { _DemoStart = Math.Max(0, value); }
        }
        private double _DemoStart;
        public double DemoEnd
        {
            get { return _DemoEnd; }
            set { _DemoEnd = Math.Max(0, value); }
        }
        private double _DemoEnd;

        public List<PlotObjectInfo> PlotedObjects { get; set; }

        private ScoreData() { Initialize(); }

        private byte[] Serialize(ScoreData data)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, data);
            stream.Position = 0;
            byte[] result = stream.GetBuffer();
            stream.Close();

            return result;
        }

        private ScoreData Deserialize(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();
            stream.Write(data, 0 , data.Length);
            stream.Position = 0;
            ScoreData result = (ScoreData)formatter.Deserialize(stream);
            stream.Close();

            return result;
        }

        public void Initialize()
        {
            _Title = _Subtitle = _SoundPath = _JacketPath = "";
            _Difficulty = Difficulty.Novice;
            _Level = 1;
            _InitialBPM = 120;
            _Ofset = 0;
            _DemoStart = 0;
            _DemoEnd = 0;

            PlotedObjects = new List<PlotObjectInfo>();
        }

        public void Save()
        {
            _UndoStack.Push(Serialize(this));
        }

        public void Undo()
        {
            if(_UndoStack.TryPop(out byte[] serialized))
            {
                _RedoStack.Push(Serialize(this));
                Instance = Deserialize(serialized);
            }
        }

        public void Redo()
        {
            if(_RedoStack.TryPop(out byte[] serialized))
            {
                _UndoStack.Push(Serialize(this));
                Instance = Deserialize(serialized);
            }
        }
    }
}