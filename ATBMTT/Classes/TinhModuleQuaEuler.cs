namespace ATBMTT.Classes
{
    internal class TinhModuleQuaEuler
    {
        // Hàm tính lũy thừa modulo theo Định lý Euler
        public long ModPowEuler(long a, long m, long n)
        {
            long phi = PhiEuler(n); // Tính giá trị của hàm Euler phi(n)
            long exp = m % phi; // Lấy phần dư của m khi chia cho giá trị của hàm Euler

            return ModPow(a, exp, n);
        }

        // Hàm tính giá trị của hàm Euler Phi
        public long PhiEuler(long n)
        {
            long result = n;

            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    result -= result / i;
                    while (n % i == 0)
                    {
                        n /= i;
                    }
                }
            }

            if (n > 1)
            {
                result -= result / n;
            }

            return result;
        }

        // Hàm tính lũy thừa modulo
        private long ModPow(long a, long exp, long n)
        {
            long result = 1;
            a %= n;

            while (exp > 0)
            {
                if (exp % 2 == 1)
                {
                    result = (result * a) % n;
                }
                exp >>= 1;
                a = (a * a) % n;
            }

            return result;
        }
    }
}
