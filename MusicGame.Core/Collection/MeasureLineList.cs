using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MusicGame.Core
{
    [Serializable]
    public class MeasureLineList : IEnumerable<MeasureLine>
    {
        
        [Serializable]
        public struct MeasureLineEnumerator : IEnumerator<MeasureLine>
        {
            private readonly MeasureLineList _Master;
            private double _Timing;
            private double _Measure;
            private int _Index;

            public MeasureLine Current { get; private set; }

            object IEnumerator.Current
            {
                get
                {
                    if (_Index == 0)
                        throw new InvalidOperationException();

                    return Current;
                }
            }

            internal MeasureLineEnumerator(MeasureLineList master)
            {
                _Master = master;
                _Timing = 0;
                _Measure = 4;
                _Index = 0;
                Current = default;
            }

            public void Reset()
            {
                _Index = 0;
                Current = default;
            }

            public bool MoveNext()
            {
                Current = new MeasureLine
                {
                    Score = _Master._Score,
                    Timing = _Timing,
                };

                _Timing += _Measure;

                List<MeasureChange> changes =_Master._Score.Effects
                    .Where(x => x is MeasureChange)
                    .Cast<MeasureChange>()
                    .ToList();

                while(_Index < changes.Count && changes[_Index].Timing <= _Timing)
                {
                    double bMeasure = _Measure;
                    double aMeasure = changes[_Index].AfterMeasure;
                    double timingDif = _Timing - changes[_Index].Timing;

                    _Timing = changes[_Index].Timing;
                    _Timing += timingDif * (aMeasure / bMeasure);
                    _Measure = aMeasure;

                    ++_Index;
                }

                return true;
            }

            public void Dispose() { }
        }

        private Score _Score;

        public MeasureLine this[int index]
        {
            get
            {
                MeasureLineEnumerator enumerator = GetEnumerator();
                for(int i = 0; i <= index; ++i) enumerator.MoveNext();
                return enumerator.Current;
            }
        }
        
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
            return new MeasureLineEnumerator(this);
        }
    }
}