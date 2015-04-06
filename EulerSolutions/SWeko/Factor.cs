using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.SWeko
{
    public class Factor
    {
        public long Prime { get; set; }
        public int Cardinality { get; set; }

        public override string ToString()
        {
            return string.Format("{0}^{1}", Prime, Cardinality);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof(Factor))
                return false;
            return Equals((Factor)obj);
        }

        public bool Equals(Factor other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return other.Prime == Prime && other.Cardinality == Cardinality;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Prime.GetHashCode() * 397) ^ Cardinality;
            }
        }

        public Factor()
        {

        }

        public Factor(long prime, int cardinality)
        {
            Prime = prime;
            Cardinality = cardinality;
        }
    }
}
