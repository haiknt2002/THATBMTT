namespace ATBMTT.Classes
{
    internal class TinhModuleBangHaBacLuyThua
    {
        //TÍNH LŨY THỪA MODULO 𝒃 = 𝒂^𝒎 𝒎𝒐𝒅 𝒏 BẰNG CÁCH HẠ BẬC LŨY THỪA
        public long a;
        public long m;
        public long n;
        public TinhModuleBangHaBacLuyThua() { }
        public TinhModuleBangHaBacLuyThua(long a, long m, long n)
        {
            this.a = a;
            this.m = m;
            this.n = n;
        }

        // Hàm tính a^m mod n
        public long ModPow(long a, long m, long n)
        {
            if (m == 0)
                return 1;

            long result = ModPow(a, m / 2, n);
            result = (result * result) % n;

            if (m % 2 == 1)
                result = (result * a) % n;

            return result;
        }

        // Hàm gọi để tính kết quả
        public long GetOutput()
        {
            return ModPow(a, m, n);
        }
    }

}
