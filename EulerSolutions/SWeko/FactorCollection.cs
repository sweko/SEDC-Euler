using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.SWeko
{
    public class FactorCollection : List<Factor>
    {
        public FactorCollection()
        {

        }

        public FactorCollection(IEnumerable<Factor> factors)
            : base(factors)
        {

        }

        public long GetNumber()
        {
            checked
            {
                try
                {
                    return this.Aggregate<Factor, long>(1, (current, factor) => current*factor.Prime.Power(factor.Cardinality));
                }
                catch (Exception)
                {
                    return long.MaxValue;
                }
            }
        }

        //internal IntX GetNumberX()
        //{
        //    IntX number = 1;
        //    foreach (Factor factor in this)
        //    {
        //        number *= new IntX(factor.Prime).Power(factor.Cardinality);
        //    }
        //    return number;
        //}

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof(FactorCollection))
                return false;
            return Equals((FactorCollection)obj);
        }

        public bool Equals(FactorCollection other)
        {
            if (other.Count != Count)
                return false;

            foreach (Factor factor in this)
            {
                if (!other.Contains(factor))
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetNumber() + " = ");
            foreach (Factor factor in this)
            {
                sb.Append(factor);
                sb.Append(" * ");
            }
            sb.Remove(sb.Length - 3, 3);
            return sb.ToString();
        }

        internal FactorCollection Copy()
        {
            FactorCollection result = new FactorCollection();
            result.AddRange(this.Select(factor => new Factor {Prime = factor.Prime, Cardinality = factor.Cardinality}));
            return result;
        }

        internal Factor FindPrime(long prime)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Prime == prime)
                    return this[i];
            }
            return null;
        }


        internal FactorCollection Square()
        {
            FactorCollection result = this.Copy();

            foreach (Factor factor in result)
            {
                factor.Cardinality *= 2;
            }
            return result;
        }

        internal FactorCollection Append(FactorCollection that)
        {
            //assumes well ordering by primes
            FactorCollection result = new FactorCollection();
            int tindex = 0;
            int findex = 0;

            while ((findex < that.Count) && (tindex < this.Count))
            {
                if (this[tindex].Prime < that[findex].Prime)
                {
                    result.Add(new Factor { Prime = this[tindex].Prime, Cardinality = this[tindex].Cardinality });
                    tindex++;
                }
                else if (this[tindex].Prime > that[findex].Prime)
                {
                    result.Add(new Factor { Prime = that[findex].Prime, Cardinality = that[findex].Cardinality });
                    findex++;
                }
                else
                {
                    result.Add(new Factor
                    {
                        Prime = this[tindex].Prime,
                        Cardinality = this[tindex].Cardinality + that[findex].Cardinality
                    });
                    tindex++;
                    findex++;
                }
            }

            for (; tindex < this.Count; tindex++)
            {
                result.Add(new Factor { Prime = this[tindex].Prime, Cardinality = this[tindex].Cardinality });
            }

            for (; findex < that.Count; findex++)
            {
                result.Add(new Factor { Prime = that[findex].Prime, Cardinality = that[findex].Cardinality });
            }

            return result;


        }

        internal FactorCollection Combine(FactorCollection that)
        {
            FactorCollection result = new FactorCollection();
            int tindex = 0;
            int findex = 0;

            while ((findex < that.Count) && (tindex < this.Count))
            {
                if (this[tindex].Prime < that[findex].Prime)
                {
                    result.Add(new Factor { Prime = this[tindex].Prime, Cardinality = this[tindex].Cardinality });
                    tindex++;
                }
                else if (this[tindex].Prime > that[findex].Prime)
                {
                    result.Add(new Factor { Prime = that[findex].Prime, Cardinality = that[findex].Cardinality });
                    findex++;
                }
                else
                {
                    result.Add(new Factor
                    {
                        Prime = this[tindex].Prime,
                        Cardinality = Math.Max(this[tindex].Cardinality, that[findex].Cardinality)
                    });
                    tindex++;
                    findex++;
                }
            }

            for (; tindex < this.Count; tindex++)
            {
                result.Add(new Factor { Prime = this[tindex].Prime, Cardinality = this[tindex].Cardinality });
            }

            for (; findex < that.Count; findex++)
            {
                result.Add(new Factor { Prime = that[findex].Prime, Cardinality = that[findex].Cardinality });
            }

            return result;
        }
    }
}
