using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MusicGame.Core
{
    [Serializable]
    public class Score
    {
        public static Score CreateNew()
        {
            return new Score();
        }

        public static Score CreateFromArray(byte[] serialized)
        {
            using MemoryStream stream = new MemoryStream(serialized);
            BinaryFormatter formatter = new BinaryFormatter();
            return (Score)formatter.Deserialize(stream);
        }

        public static Score CreateFromFile(string path)
        {
            using FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            return (Score)formatter.Deserialize(stream);
        }

        public static void SaveToArray(out byte[] serialized, Score score)
        {
            using MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, score);
            serialized = stream.GetBuffer();
        }

        public static void SaveToFile(string path, Score score)
        {
            using FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, score);
        }

        public string Title { get; set; }
        public string Subitle { get; set; }
        public string SouncPath { get; set; }
        public string JacketPath { get; set; }

        public Difficulty Difficulty { get; set; }
        public int Level { get; set; }
        public double InitBPM { get; set; }
        public double Offset { get; set; }

        public int DemoStart { get; set; }
        public int DemoEnd { get; set; }

        public NoteList Notes { get; }
        public EffectList Effects { get; }
        public MeasureLineList MeasureLines { get; }

        private Score()
        {
            Notes = new NoteList(this);
            Effects = new EffectList(this);
            MeasureLines = new MeasureLineList(this);
        }
    }
}
