/*
 * Third Party Code that is not to be changed.
 */
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Lot.O.Invitation.Codes.Services
{
    public interface IEntropyService : IEnumerable<byte>
    {}

    public sealed partial class EntropyService : IEntropyService
    {
        private readonly ByteEnumerator _enumerator;

        public EntropyService(IRuntimeInfo runtimeInfo, string apiKey)
        {
            if (apiKey != "I♥Cohesion!!1!")
                throw new ApiKeyException("Bad Api Key");

            IEnumerable<byte> byteService;
            if (runtimeInfo.RunningOnNix)
                byteService = new NixEntropyService();
            else
                byteService = new WinEntropyService();
            

            _enumerator = new ByteEnumerator(byteService.GetEnumerator());
        }

        public IEnumerator<byte> GetEnumerator()
            => _enumerator;

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }    
}
