using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signaturi.Domain.ValueObjects
{
    public class Signature : ISignature
    {
        private readonly int _value;

        public Signature(int value)
        {
            _value = value;
        }

        public int GetValue() => _value;

    }
}
