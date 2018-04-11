using System;

namespace RSAWinForms.RSA
{
    public class AllFunctions
    {
        public static int GeneratePrimaryNum()
        {
            Random rnd = new Random();
            int result;
            result = rnd.Next(50);
            while (!IsPrime(result))
            {
                result++;
            }
            return result;
        }

        public static bool IsPrime(int num)
        {
            for (int i = 2; i < num / 2; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int ComputeN(int p, int q)
        {
            return p * q;
        }

        public static int ComputeFn(int p, int q)
        {
            return (p - 1) * (q - 1);
        }

        public static bool IsCoprime(int m, int n)
        {
            var tmp = 0;
            if (m < n)
            {
                tmp = m;
                m = n;
                n = tmp;
            }
            while (n != 0)
            {
                tmp = m % n;
                m = n;
                n = tmp;
            }
            return m == 1;
        }

        public static int GenerateE(int fn)
        {
            notprime:
            Random rnd = new Random();
            int result;

            result = rnd.Next(10);
            while (!IsCoprime(result, fn))
            {
                result++;
            }
            if (result > fn)
            {
                goto notprime;
            }
            else
            {
                return result;
            }
        }

        public static int ComputeD(int fn, int e)
        {
            var d = 0;
            while ((d * e) % fn != 1)
            {
                d++;
            }
            return d;
        }
    }
}