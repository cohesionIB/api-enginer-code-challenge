/*
 * Third Party Code that is not to be changed.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Lot.O.Invitation.Codes.Services
{
    internal class WinEntropyService : IEnumerable<byte>
    {
        private static readonly RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();
        
        public IEnumerable<byte> Generate()
        {
            var buffer = new byte[8];
            while (true)
            {
                _rng.GetBytes(buffer);
                foreach (var b in buffer)
                    yield return b;
            }
        }

        public IEnumerator<byte> GetEnumerator() => Generate().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
