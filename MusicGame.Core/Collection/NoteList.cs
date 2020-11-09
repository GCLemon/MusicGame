using System.Collections;
using System.Collections.Generic;

namespace MusicGame.Core
{
    public class NoteList : IEnumerable<Note>
    {
        public struct NoteEnumerator : IEnumerator<Note>
        {
            public Note Current { get; private set; }

            object IEnumerator.Current
            {
                get
                {
                    return null;
                }
            }

            public void Reset()
            {

            }

            public bool MoveNext()
            {
                return false;
            }

            public void Dispose()
            {

            }
        }

        Score _Score;

        internal NoteList(Score score)
        {
            _Score = score;
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
            return new NoteEnumerator();
        }
    }
}