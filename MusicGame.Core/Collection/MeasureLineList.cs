using System.Collections;
using System.Collections.Generic;

namespace MusicGame.Core
{
    public class MeasureLineList : IEnumerable<MeasureLine>
    {
        public struct MeasureLineEnumerator : IEnumerator<MeasureLine>
        {
            public MeasureLine Current { get; private set; }

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

        private Score _Score;
        
        internal MeasureLineList(Score score)
        {
            _Score = score;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<MeasureLine> IEnumerable<MeasureLine>.GetEnumerator()
        {
            return GetEnumerator();
        }

        MeasureLineEnumerator GetEnumerator()
        {
            return new MeasureLineEnumerator();
        }
    }
}