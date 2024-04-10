namespace ATBMTT.Classes
{
    internal class TinhModuleQuaSoDuTrungHoa
    {
        //SỬ DỤNG ĐỊNH LÝ SỐ DƯ TRUNG HOA ĐỂ TÍNH LŨY THỪA modulo 𝒃 = 𝒂^𝒌 𝒎𝒐𝒅 𝒏 
        public  long ModPowChineseRemainder(long a, long k, long n)
        {
            // Tính giá trị M
            long M = n - 1;

            // Tính dãy b
            long[] m = { n };

            // Tìm nghịch đảo modulo của b[i] theo m[i]
            long bInverse = ModInverse(a, M);

            // Tính kết quả
            long x = ModPow(a, k, n);

            return x;
        }

        // Hàm tính nghịch đảo modulo
        private  long ModInverse(long a, long m)
        {
            long m0 = m;
            long y = 0, x = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                long q = a / m;
                long t = m;

                m = a % m;
                a = t;
                t = y;

                y = x - q * y;
                x = t;
            }

            if (x < 0)
                x += m0;

            return x;
        }

        // Hàm tính lũy thừa modulo
        private  long ModPow(long a, long exp, long n)
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

