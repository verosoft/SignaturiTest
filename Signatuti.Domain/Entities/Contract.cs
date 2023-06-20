using Signaturi.Domain.ValueObjects;

namespace Signaturi.Domain.Entities
{
    public class Contract
    {
        public string Name { get; private set; }

        public IList<ISignature?> Signatures { get; private set; }

        public Contract(IList<ISignature?> signatures, string name)
        {
            Signatures = new List<ISignature?>(signatures);

            if (Signatures.Any(x=>x?.GetValue() == 5))
            {
                var signaturisV = Signatures.Where(x => x?.GetValue() == 1).ToList();
                foreach (var signature in signaturisV)
                {
                    var index = Signatures.IndexOf(signature);
                    Signatures[index] = null;

                }

            }

            Name = name;
        }

        public ISignature? MinimumSignatureNecessaryWinTrial(Contract defendan)
        {
            if (defendan != null)
            {
                var plaintiffScore = this.Signatures.Sum(s => s?.GetValue());
                var defendanScore = defendan.Signatures.Sum(s => s?.GetValue());


                var minimumPlaintiffScore = (plaintiffScore < defendanScore)
                    ? ((defendanScore - plaintiffScore) == 1)
                    ? 2
                    : ((defendanScore - plaintiffScore) >= 2)
                    ? 5
                    : ((defendanScore - plaintiffScore) == 0)
                    ? 1
                    : 0
                    :0;

                    

                var minimumDefendanScore = (defendanScore < plaintiffScore)
                    ? ((plaintiffScore - defendanScore) == 1)
                    ? 2
                    : ((plaintiffScore - defendanScore) >= 2)
                    ? 5
                    : ((plaintiffScore - defendanScore) == 0)
                    ? 1
                    : 0
                    : 0;



                ISignature? result = minimumPlaintiffScore > 0
                    ? new Signature(minimumPlaintiffScore)
                    : minimumDefendanScore > 0
                    ? new Signature(minimumDefendanScore)
                    : null;

                return result;
;            }

            return null;
        }

        public Contract Trial(Contract defendan)
        {
            if (defendan != null)
            {
                var plaintiffScore = this.Signatures.Sum(s => s?.GetValue());
                var defendanScore = defendan.Signatures.Sum(s => s?.GetValue());

                return plaintiffScore >= defendanScore ? this : defendan;
            }

            return this;
        }
    }
}
