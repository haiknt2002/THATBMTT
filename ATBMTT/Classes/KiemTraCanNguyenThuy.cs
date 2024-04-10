using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATBMTT.Classes
{
    internal class KiemTraCanNguyenThuy
    {
        // Hàm kiểm tra xem một số có là căn nguyên thủy của một số khác hay không
        public bool IsPrimitiveRoot(int a, int n)
        {
            // Kiểm tra điều kiện a và n
            if (a <= 0 || n <= 1 || n % 2 == 0)
                return false;

            // Tính giá trị (n - 1) / 2
            int exp = (n - 1) / 2;

            // Tính a^(n-1)/2 mod n
            int result = ModPow(a, exp, n);

            // Kiểm tra nếu a^(n-1)/2 ≡ 1 (mod n) hoặc a^(n-1)/2 ≡ -1 (mod n)
            return result == 1 || result == n - 1;
        }

        // Hàm tính lũy thừa modulo
        private int ModPow(int a, int exp, int n)
        {
            int result = 1;
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
