using System;

namespace ATBMTT.Classes
{
    internal class TimNgichDaoModuleTheoEuclid
    {
        //TÌM NGHỊCH ĐẢO 𝒙 = 𝒂^(−𝟏) 𝒎𝒐𝒅 𝒏 THEO ĐỊNH NGHĨA VÀ THUẬT TOÁN EUCLID – MỞ RỘNG
        public long a;
        public long n;
        public TimNgichDaoModuleTheoEuclid() { }
        public TimNgichDaoModuleTheoEuclid(long a, long n)
        {
            this.a = a;
            this.n = n;
        }

        // Hàm tính gcd(a, b) và trả về x, y sao cho ax + by = gcd(a, b)

        /*
         * ri = ax + by
         * => ri = r i-2 mod r i-1      => qi = r i-2 / r i-1
         *      xi = x i-2 - qi * x i-1
         *       yi = y i-2 - qi * y i-1
         */
        public long ExtendedEuclidean(long a, long b, out long x, out long y)
        {
            if (b == 0)
            {
                x = 1;
                y = 0;
                return a;
            }

            long x1, y1;
            long gcd = ExtendedEuclidean(b, a % b, out x1, out y1);

            x = y1;
            y = x1 - (a / b) * y1;

            return gcd;
        }

        // Hàm tính nghịch đảo modulo
        public long ModInverse()
        {
            long x, y;
            long gcd = ExtendedEuclidean(a, n, out x, out y);

            // a và n phải là số nguyên tố cùng nhau để có nghịch đảo modulo
            if (gcd != 1)
                throw new Exception("a và n phải là số nguyên tố cùng nhau");

            // Đảm bảo kết quả là số dương
            return (x % n + n) % n;
        }
    }

}
