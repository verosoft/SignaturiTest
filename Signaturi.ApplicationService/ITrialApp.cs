using Signaturi.Domain.Entities;

namespace Signaturi.ApplicationService
{
    public interface ITrialApp
    {
        string MinimumSignatureNecessaryWinTrial(string plaintiff, string defendan);
        Contract Trial(string plaintiff, string defendan);
    }
}