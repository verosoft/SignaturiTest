using Signaturi.Domain.Entities;
using Signaturi.Domain.Services;
using Signaturi.Domain.ValueObjects;

namespace Signaturi.ApplicationService
{
    public class TrialApp : ITrialApp
    {
        private readonly ITrialService _trialService;

        public TrialApp(ITrialService trialService)
        {
            _trialService = trialService;
        }

        public string MinimumSignatureNecessaryWinTrial(string plaintiff, string defendan)
        {
            CheckArguments(plaintiff, defendan);
            
            BuildSignatures(plaintiff, defendan, out IList<ISignature?> plaintiffSignatures, out IList<ISignature?> defendanSignatures);

            var contractPlaintiff = new Contract(plaintiffSignatures, nameof(plaintiff));
            var contractDefendan = new Contract(defendanSignatures, nameof(defendan));

            var minimunSignature = _trialService.MinimumSignatureNecessaryWinTrial(contractPlaintiff, contractDefendan);

            if (minimunSignature == null)
                return string.Empty;

            string result;

            switch (minimunSignature.GetValue())
            {
                case 5:
                    result = "K";
                    break;
                case 2:
                    result = "N";
                    break;
                case 1:
                    result = "V";
                    break;
                default:
                    result = string.Empty;
                    break;
            }

            return result;

        }

        public Contract Trial(string plaintiff, string defendan)
        {
            CheckArguments(plaintiff, defendan);

            BuildSignatures(plaintiff, defendan, out IList<ISignature?> plaintiffSignatures, out IList<ISignature?> defendanSignatures);


            var contractPlaintiff = new Contract(plaintiffSignatures, nameof(plaintiff));
            var contractDefendan = new Contract(defendanSignatures, nameof(defendan));

            var result = _trialService.Trial(contractPlaintiff, contractDefendan);

            return result;

        }

        private static void BuildSignatures(string plaintiff, string defendan, out IList<ISignature?> plaintiffSignatures, out IList<ISignature?> defendanSignatures)
        {
            plaintiffSignatures = new List<ISignature?>();
            defendanSignatures = new List<ISignature?>();
            foreach (var signature in plaintiff)
            {
                switch (signature)
                {
                    case 'K':
                        plaintiffSignatures.Add(new Signature(5));
                        break;
                    case 'N':
                        plaintiffSignatures.Add(new Signature(2));
                        break;
                    case 'V':
                        plaintiffSignatures.Add(new Signature(1));
                        break;
                    case '#':
                        plaintiffSignatures.Add(null);
                        break;
                    
                }
            }

            foreach (var signature in defendan)
            {
                switch (signature)
                {
                    case 'K':
                        defendanSignatures.Add(new Signature(5));
                        break;
                    case 'N':
                        defendanSignatures.Add(new Signature(2));
                        break;
                    case 'V':
                        defendanSignatures.Add(new Signature(1));
                        break;
                    case '#':
                        defendanSignatures.Add(null);
                        break;
                }
            }
        }


        private static void CheckArguments(string plaintiff, string defendan)
        {
            if (string.IsNullOrEmpty(plaintiff))
            {
                throw new ArgumentNullException(nameof(plaintiff));
            }

            if (string.IsNullOrEmpty(defendan))
            {
                throw new ArgumentNullException(nameof(defendan));
            }

            if (plaintiff.Length > 3)
            {
                throw new ArgumentException("Length must be less than 3", nameof(plaintiff));
            }

            if (defendan.Length > 3)
            {
                throw new ArgumentException("Length must be less than 3", nameof(defendan));
            }
        }
    }
}