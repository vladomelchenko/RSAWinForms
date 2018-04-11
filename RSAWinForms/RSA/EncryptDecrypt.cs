using System;
using System.Collections.Generic;
using System.Numerics;

namespace RSAWinForms.RSA
{
    public class EncryptDecrypt
    {
        public KeyValuePair<int, int> PublicKey { get; set; }
        public KeyValuePair<int, int> PrivateKey { get; set; }
        private static int _p;
        private static int _q;
        private static int _n;
        private static int _fn;
        private static int _e;
        private static int _d;

        public BigInteger Encrypr(BigInteger data)
        {
            BigInteger res = 1;
            for (int i = 0; i < PublicKey.Key; i++)
            {
                res *= data;
            }
            return res % PublicKey.Value;
        }

        public BigInteger Decrypt(BigInteger data)
        {
            BigInteger res = 1;
            for (int i = 0; i < PrivateKey.Key; i++)
            {
                res *= data;
            }
            return res % PrivateKey.Value;
        }

        private void InitKeys()
        {
            _p = AllFunctions.GeneratePrimaryNum();
            _q = AllFunctions.GeneratePrimaryNum();
            _n = AllFunctions.ComputeN(_p, _q);
            _fn = AllFunctions.ComputeFn(_p, _q);
            _e = AllFunctions.GenerateE(_fn);
            _d = AllFunctions.ComputeD(_fn, _e);

            PublicKey = new KeyValuePair<int, int>(_e, _n);
            PrivateKey = new KeyValuePair<int, int>(_d, _n);
        }

        public void InitKeys(int p, int q, int e)
        {
            if (AllFunctions.IsPrime(p))
            {
                _p = p;
            }
            else
            {
                throw new Exception("p isn't prime ");
            }
            if (AllFunctions.IsPrime(q))
            {
                _q = q;
            }
            else
            {
                throw new Exception("q isn't prime ");
            }
            _n = AllFunctions.ComputeN(_p, _q);
            _fn = AllFunctions.ComputeFn(_p, _q);
            if (AllFunctions.IsCoprime(e, _fn))
            {
                _e = e;
            }
            else
            {
                throw new Exception("e isn't coprime ");
            }
            _d = AllFunctions.ComputeD(_fn, _e);

            PublicKey = new KeyValuePair<int, int>(_e, _n);
            PrivateKey = new KeyValuePair<int, int>(_d, _n);
        }
    }
}