namespace ATBMTT.Classes
{
    using System;

    internal class TinhModuleQuaFermat
    {
        //SỬ DỤNG ĐỊNH LÝ FERMAT ĐỂ TÍNH LŨY THỪA MODULO 𝒃 = 𝒂^𝒎 𝒎𝒐𝒅 𝒏

        // Hàm kiểm tra xem một số có phải là số nguyên tố hay không
        private bool IsPrime(long n)
        {
            if (n <= 1)
                return false;
            if (n <= 3)
                return true;
            if (n % 2 == 0 || n % 3 == 0)
                return false;

            for (long i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }

            return true;
        }

        // Hàm tính lũy thừa modulo theo Định lý Fermat
        //𝒃 = 𝒂^𝒎 𝒎𝒐𝒅 𝒏
        public long ModPowFermat(long a, long m, long n)
        {
            if (!IsPrime(n))
            {
                throw new ArgumentException("n phải là số nguyên tố.");
            }

            // Tính a^(m mod (n - 1))
            long exp = m % (n - 1);
            long result = 1;

            for (int i = 0; i < exp; i++)
            {
                result = (result * a) % n;
            }

            return result;
        }
    }

}
