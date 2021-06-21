/*
 * Third Party Code that is not to be changed.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lot.O.Invitation.Codes.Services
{
    public partial class EntropyService
    {
        public sealed class ByteEnumerator : IEnumerator<byte>
        {
            private readonly IEnumerator<byte> _enumerator;
            private readonly Queue<byte> _buffer = new Queue<byte>();
            private bool peeked = false;
            private bool isReset = true;

            public ByteEnumerator(IEnumerator<byte> enumerator)
            {
                _enumerator = enumerator;
            }

            public byte Current
            {
                get
                {
                    peeked = true;
                    return _buffer.Peek();
                }
            }

            object IEnumerator.Current => Current;

            private void Cleanup()
            {
                isReset = true;
                if (peeked)
                    _buffer.Dequeue();

                peeked = false;
            }

            public void Dispose() => Cleanup();

            public bool MoveNext()
            {
                if (isReset && _buffer.Any())
                {
                    isReset = false;
                    return true;
                }

                if (peeked)
                {
                    peeked = false;
                    _buffer.Dequeue();
                    if (_buffer.Any())
                        return true;
                }

                if (!_enumerator.MoveNext())
                    return false;

                _buffer.Enqueue(_enumerator.Current);
                return true;
            }

            public void Reset() => Cleanup();
        }
    }
}
