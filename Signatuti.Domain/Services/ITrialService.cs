using Signaturi.Domain.Entities;
using Signaturi.Domain.ValueObjects;

namespace Signaturi.Domain.Services
{
    public interface ITrialService
    {
        Contract Trial(Contract plaintiff, Contract defendan);

        public ISignature? MinimumSignatureNecessaryWinTrial(Contract plaintiff, Contract defendan);
    }
}