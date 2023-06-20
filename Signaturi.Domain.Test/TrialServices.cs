
using Signaturi.Domain.Entities;
using Signaturi.Domain.ValueObjects;

namespace Signaturi.Domain.Test
{
    [TestClass]
    public class TrialServices
    {
        [TestMethod]
        public void In_Trial_When_the_sum_of_the_signatures_of_the_plaintiff_is_greater_than_the_sum_of_the_signatures_of_the_defendant_the_plaintiff_wins()
        {
            var trialService = new Services.TrialService();
            var plaintiff = new Contract(new List<ISignature?>() { new Signature(5), new Signature(2) }, "plaintiff");
            var defendan = new Contract(new List<ISignature?>() { new Signature(1), new Signature(2), new Signature(2) }, "defendan");
            var winer = trialService.Trial(plaintiff, defendan);
            Assert.IsNotNull(winer);
            Assert.AreEqual("plaintiff", winer.Name);
        }

        [TestMethod]
        public void In_Trial_When_the_sum_of_the_signatures_of_the_defendant_is_greater_than_the_sum_of_the_signatures_of_the_plaintiff_the_defendant_wins()
        {
            var trialService = new Services.TrialService();
            var plaintiff = new Contract(new List<ISignature?>() { new Signature(1), new Signature(2), new Signature(1) }, "plaintiff");
            var defendan = new Contract(new List<ISignature?>() { new Signature(1), new Signature(2), new Signature(2) }, "defendan");
            var winer = trialService.Trial(plaintiff, defendan);
            Assert.IsNotNull(winer);
            Assert.AreEqual("defendan", winer.Name);
        }

        [TestMethod]
        public void The_minimum_signature_required_for_the_defendant_to_win_must_be_five()
        {
            var trialService = new Services.TrialService();
            var plaintiff = new Contract(new List<ISignature?>() { new Signature(5), new Signature(2) }, "plaintiff");
            var defendan = new Contract(new List<ISignature?>() { new Signature(1), new Signature(2), new Signature(2) }, "defendan");
            var minimumSignature =  trialService.MinimumSignatureNecessaryWinTrial(plaintiff, defendan);

            Assert.IsNotNull(minimumSignature);
            Assert.AreEqual(5, minimumSignature.GetValue());
        }


    }
}