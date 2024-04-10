using System;
namespace ATBMTT.MaCongKhai
{
    internal class RSA
    {
        // Phương thức tính ước số chung lớn nhất của hai số nguyên
        public long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Phương thức tìm số nguyên dương nhỏ nhất thỏa mãn ax + by = gcd(a, b)
        public long FindModInverse(long a, long m)
        {
            long m0 = m, t, q;
            long x0 = 0, x1 = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                q = a / m;
                t = m;

                m = a % m;
                a = t;
                t = x0;
                x0 = x1 - q * x0;
                x1 = t;
            }

            if (x1 < 0)
                x1 += m0;

            return x1;
        }

        // Phương thức mã hóa thông điệp
        public long Encrypt(long message, long e, long n)
        {
            return ModPow(message, e, n);
        }

        // Phương thức giải mã bản mã
        public long Decrypt(long cipher, long d, long n)
        {
            return ModPow(cipher, d, n);
        }

        // Phương thức tính toán a^b mod m
        public long ModPow(long a, long b, long m)
        {
            if (b == 0)
                return 1;

            long t = ModPow(a, b / 2, m);
            long result = (t * t) % m;
            if (b % 2 == 1)
                result = (result * a) % m;

            return result;
        }

    }
}