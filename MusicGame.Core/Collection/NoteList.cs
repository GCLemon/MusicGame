using System;
using System.Collections;
using System.Collections.Generic;

namespace MusicGame.Core
{
    public class NoteList : IEnumerable<Note>
    {
        public struct NoteEnumerator : IEnumerator<Note>
        {
            private readonly NoteList _Master;
            private readonly int _Version;
            private int _Index;

            public Note Current { get; private set; }

            object IEnumerator.Current
            {
                get
                {
                    if (_Index == 0 || _Index > _Master.Count)
                        throw new InvalidOperationException();

                    return Current;
                }
            }

            internal NoteEnumerator(NoteList master)
            {
                _Master = master;
                _Version = master._Version;
                _Index = 0;
                Current = default;
            }

            public void Reset()
            {
                if (_Version != _Master._Version)
                    throw new InvalidOperationException();

                _Index = 0;
                Current = default;
            }

            public bool MoveNext()
            {
                if (_Version != _Master._Version)
                    throw new InvalidOperationException();

                if (_Index < _Master.Count)
                {
                    Current = _Master[_Index++];
                    return true;
                }
                else
                {
                    Current = default;
                    _Index = _Master.Count + 1;
                    return false;
                }
            }

            public void Dispose() { }
        }

        private Score _Score;
        private List<Note> _Notes;
        private int _Version;

        public int Count => _Notes.Count;
        public Note this[int index] => _Notes[index];

        internal NoteList(Score score)
        {
            _Score = score;
            _Notes = new List<Note>();
            _Version = 0;
        }

        public int IndexOf(Note note) => _Notes.IndexOf(note);
        public bool Contains(Note note) => _Notes.Contains(note);

        public void Add(Note note)
        {
            ++_Version;
            note.Score = _Score;
            _Notes.Add(note);
        }

        public bool Remove(Note note)
        {
            ++_Version;
            return _Notes.Remove(note);
        }

        public void Clear()
        {
            _Version = 0;
            _Notes.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Note> IEnumerable<Note>.GetEnumerator()
        {
            return GetEnumerator();
        }

        NoteEnumerator GetEnumerator()
        {
            return new NoteEnumerator(this);
        }
    }
}