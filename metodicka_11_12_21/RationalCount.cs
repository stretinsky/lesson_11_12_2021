using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metodicka_11_12_21
{
    [DeveloperInfo("Данил")]
    class RationalCount
    {
        private long numerator { get; set; } 
        public long denominator { get; set; } 
        public RationalCount(long numerator)
        {
            this.numerator = numerator;
            denominator = 1;
        }
        public RationalCount(long numerator, long denominator)
        {
            if (denominator != 0)
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }
            else
            {
                Console.WriteLine("Знаменатель не может быть равен 0. Теперь знаменатель по умолчанию равен 1 ");
                this.numerator = numerator;
                this.denominator = 1;
            }
            
        }
        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }
        public override bool Equals(object obj)
        {
            if (obj is RationalCount)
            {
                RationalCount count = obj as RationalCount;
                if (numerator * count.denominator == denominator * count.numerator)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(RationalCount one, RationalCount two)
        {
            if (one.numerator * two.denominator == one.denominator * two.numerator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(RationalCount one, RationalCount two)
        {
            if (one.numerator * two.denominator == one.denominator * two.numerator)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool operator <(RationalCount one, RationalCount two)
        {
            if (one.numerator * two.denominator < two.numerator * one.denominator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >(RationalCount one, RationalCount two)
        {
            if (one.numerator * two.denominator > two.numerator * one.denominator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >=(RationalCount one, RationalCount two)
        {
            if (one.numerator * two.denominator >= two.numerator * one.denominator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <=(RationalCount one, RationalCount two)
        {
            if (one.numerator * two.denominator <= two.numerator * one.denominator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static RationalCount operator +(RationalCount one, RationalCount two)
        {
            long d = one.denominator * two.denominator;
            long n = one.numerator * two.denominator + two.numerator * one.denominator;
            RationalCount count = new RationalCount(n, d);
            return Reduct(count);
        }
        public static RationalCount operator -(RationalCount one, RationalCount two)
        {
            long d = one.denominator * two.denominator;
            long n = one.numerator * two.denominator - two.numerator * one.denominator;
            RationalCount count = new RationalCount(n, d);
            return Reduct(count);
        }
        public static RationalCount operator ++(RationalCount count)
        {
            RationalCount temp = new RationalCount(count.numerator + count.denominator, count.denominator);
            return Reduct(temp);
        }
        public static RationalCount operator --(RationalCount count)
        {
            RationalCount temp = new RationalCount(count.numerator - count.denominator, count.denominator);
            return Reduct(temp);
        }
        public static explicit operator float(RationalCount count)
        {
            return (float)count.numerator / count.denominator;
        }
        private long Nod(RationalCount count)
        {
            long n = count.numerator;
            long d = count.denominator;
            n = Math.Abs(n);
            d = Math.Abs(d);
            while (d != 0 && n != 0)
            {
                if (n % d > 0)
                {
                    long temp = n;
                    n = d;
                    d = temp % d;
                }
                else break;
            }
            if (d != 0 && n != 0)
            {
                return d;
            }
            return 0;
        }
        public static RationalCount Reduct(RationalCount count)
        {
            long n = count.numerator / count.Nod(count);
            long d = count.denominator / count.Nod(count);
            return new RationalCount(n, d);
        }
        public static explicit operator RationalCount(float count)
        {
            int s = count.ToString().Split(',')[1].Length;
            long n = (long)(count * Math.Pow(10, s));
            RationalCount temp = new RationalCount(n, (long)Math.Pow(10, s));
            return Reduct(temp);
        }
        public static RationalCount operator *(RationalCount one, RationalCount two)
        {
            RationalCount temp = new RationalCount(one.numerator * two.numerator, one.denominator * two.denominator);
            return Reduct(temp);
        }
        public static RationalCount operator /(RationalCount one, RationalCount two)
        {
            RationalCount temp = new RationalCount(one.numerator * two.denominator, one.denominator * two.numerator);
            return Reduct(temp);
        }
    }
}
