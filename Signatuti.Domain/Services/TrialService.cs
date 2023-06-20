

using Signaturi.Domain.Entities;
using Signaturi.Domain.ValueObjects;

namespace Signaturi.Domain.Services
{
    public class TrialService : ITrialService
    {
        public ISignature? MinimumSignatureNecessaryWinTrial(Contract plaintiff, Contract defendan)
        {
            return plaintiff.MinimumSignatureNecessaryWinTrial(defendan);
        }

        public Contract Trial(Contract plaintiff, Contract defendan)
        {
            return plaintiff.Trial(defendan);
        }
    }
}
