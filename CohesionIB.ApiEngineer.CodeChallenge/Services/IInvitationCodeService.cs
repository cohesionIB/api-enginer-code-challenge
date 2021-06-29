using Lot.O.Invitation.Codes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CohesionIB.ApiEngineer.CodeChallenge.Services
{
    public interface IInvitationCodeService
    {
        bool HasCode { get; }
        ulong Code { get; }
    }

    public class InvitationCodeService : IInvitationCodeService
    {
        private readonly Lazy<ulong?> _code;

        public InvitationCodeService(IEntropyService entropyService)
        {
            _code = new Lazy<ulong?>(() =>
            {
                if (entropyService.Count() > 0)
                {
                    var bytes = entropyService.Take(8).ToList();
                    return BitConverter.ToUInt64(bytes.ToArray());
                }
                
                return null;
            });
        }

        public bool HasCode => _code.Value.HasValue;

        public ulong Code => _code.Value.Value;
    }
}
