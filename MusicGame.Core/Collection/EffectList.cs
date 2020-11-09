using System;
using System.Collections;
using System.Collections.Generic;

namespace MusicGame.Core
{
    public class EffectList : IEnumerable<Effect>
    {
        public struct EffectEnumerator : IEnumerator<Effect>
        {
            private readonly EffectList _Master;
            private readonly int _Version;
            private int _Index;

            public Effect Current { get; private set; }

            object IEnumerator.Current
            {
                get
                {
                    if (_Index == 0 || _Index > _Master.Count)
                        throw new InvalidOperationException();

                    return Current;
                }
            }

            internal EffectEnumerator(EffectList master)
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

        Score _Score;
        private List<Effect> _Effects;
        private int _Version;

        public int Count => _Effects.Count;
        public Effect this[int index] => _Effects[index];
        
        internal EffectList(Score score)
        {
            _Score = score;
            _Effects = new List<Effect>();
            _Version = 0;
        }

        public int IndexOf(Effect effect) => _Effects.IndexOf(effect);
        public bool Contains(Effect effect) => _Effects.Contains(effect);

        public void Add(Effect effect)
        {
            ++_Version;
            effect.Score = _Score;
            _Effects.Add(effect);
        }

        public bool Remove(Effect effect)
        {
            ++_Version;
            return _Effects.Remove(effect);
        }

        public void Clear()
        {
            _Version = 0;
            _Effects.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Effect> IEnumerable<Effect>.GetEnumerator()
        {
            return GetEnumerator();
        }

        EffectEnumerator GetEnumerator()
        {
            return new EffectEnumerator(this);
        }
    }
}