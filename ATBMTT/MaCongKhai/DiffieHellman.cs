using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATBMTT.MaCongKhai
{
    internal class DiffieHellman
    {
        // Phương thức tính toán a^b mod m
        public long ModPow(long a, long b, long m)
        {
            if (b == 0)
                return 1;

            long t = ModPow(a, b / 2, m);
            long result = (t * t) % m;
            if (b % 2 == 1)
                result = (result * a) % m;

            return (long)result;
        }

        // Phương thức thực hiện giao thức Diffie-Hellman
        public void DoDiffieHellman(long q, long a, long xA, long xB)
        {

            // Tính toán khóa công khai cho An và Ba
            long yA = ModPow(a, xA, q);
            long yB = ModPow(a, xB, q);

            Console.WriteLine("Khóa công khai của An (yA): " + yA);
            Console.WriteLine("Khóa công khai của Ba (yB): " + yB);

            // Tính toán khóa phiên cho An và Ba
            long K_A = ModPow(yB, xA, q);
            long K_B = ModPow(yA, xB, q);

            Console.WriteLine("Khóa phiên của An (KA): " + K_A);
            Console.WriteLine("Khóa phiên của Ba (KB): " + K_B);
        }
    }
}
