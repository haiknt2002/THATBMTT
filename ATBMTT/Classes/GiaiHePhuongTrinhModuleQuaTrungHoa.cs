using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATBMTT.Classes
{
    internal class GiaiHePhuongTrinhModuleQuaTrungHoa
    {
        // Hàm giải hệ phương trình modulo bằng định lý số dư trung hòa
        public long SolveModularEquation(long[] m, long[] a)
        {
            // Tính giá trị M
            long M = 1;
            foreach (long mi in m)
            {
                M *= mi;
            }

            // Tính dãy b
            long[] b = new long[m.Length];
            for (int i = 0; i < m.Length; i++)
            {
                b[i] = M / m[i];
            }

            // Tìm nghịch đảo modulo của b[i] theo m[i]
            long[] bInverse = new long[m.Length];
            for (int i = 0; i < m.Length; i++)
            {
                bInverse[i] = ModInverse(b[i], m[i]);
            }

            // Tính kết quả
            long x = 0;
            for (int i = 0; i < m.Length; i++)
            {
                x += a[i] * b[i] * bInverse[i] % M;
                x %= M;
            }

            return x;
        }

        // Hàm tính nghịch đảo modulo
        private long ModInverse(long a, long m)
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
    }
}
