using System.Collections;
using System.Collections.Generic;

namespace MusicGame.Core
{
    public class EffectList : IEnumerable<Effect>
    {
        public struct EffectEnumerator : IEnumerator<Effect>
        {
            public Effect Current { get; private set; }

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
        
        internal EffectList(Score score)
        {
            _Score = score;
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
            return new EffectEnumerator();
        }
    }
}