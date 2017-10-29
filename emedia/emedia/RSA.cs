using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emedia {
    public static class RSA {
        private static int p;
        private static int q;

        public static Key publicKey;
        public static Key privateKey;

        public static void createKeys(int p, int q) {
            RSA.p = p;
            RSA.q = q;

            int euler = (p - 1) * (q - 1);
            int module = p * q;
            int e = relativelyPrime(euler);
            int d = eulerInverse(e, euler);
            publicKey = new Key(e, module);
            privateKey = new Key(d, module);
        }


        public static byte[] getEncryptedData(byte[] bytes) {
            List<byte> result = new List<byte>();
            int value = 0;
            string hexArray = "";

            Console.WriteLine("bytes: " + bytes.Length);
            for (int j = 0; j < bytes.Length; j += 2) {
                for (int i = j; i < j + 2; i++) {
                    if (i >= bytes.Length)
                        hexArray = hexArray + "00";
                    else {
                        hexArray = hexArray + bytes[i].ToString("X2");
                    }
                }
                value = Convert.ToInt32(hexArray, 16);
                value = powerModulo(value, publicKey.e, publicKey.n);
                hexArray = value.ToString("X6");
                string text = "";
                for (int i = 0; i < hexArray.Length; i += 2) {
                    text = hexArray[i].ToString() + hexArray[i + 1].ToString();
                    result.Add(Convert.ToByte(text, 16));
                }
                hexArray = "";
            }

            Console.WriteLine("after encrypt bytes: " + result.ToArray().Length);
            return result.ToArray();
        }

        public static byte[] getDecryptedData(byte[] bytes) {
            List<byte> result = new List<byte>();
            int value = 0;
            string hexArray = "";
            for (int j = 0; j < bytes.Length; j += 3) {
                for (int i = j; i < j + 3; i++) {
                    if (i >= bytes.Length)
                        hexArray = hexArray + "00";
                    else {
                        hexArray = hexArray + bytes[i].ToString("X2");
                    }
                }
                value = Convert.ToInt32(hexArray, 16);
                value = powerModulo(value, privateKey.e, privateKey.n);
                hexArray = value.ToString("X4");
                string text = "";
                for (int i = 0; i < hexArray.Length; i += 2) {
                    text = hexArray[i].ToString() + hexArray[i + 1].ToString();
                    result.Add(Convert.ToByte(text, 16));
                }
                hexArray = "";
            }

            Console.WriteLine("after decrypt bytes: " + result.ToArray().Length);
            return result.ToArray();
        }


        private static int relativelyPrime(int a) {
            int e;
            for (e = 3; GCD(e, a) != 1; e += 2) ;
            return e;
        }

        private static int eulerInverse(int e, int baza) {
            int result = 0;
            int rest = 0;
            while (rest != 1) {
                ++result;
                rest = (e * result) % baza;
            }
            return result;
        }

        private static int GCD(int a, int b) {
            int Remainder;

            while (b != 0) {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }

            return a;
        }

        private static int powerModulo(int value, int b, int n) {
            int i;
            long result = 1;
            long x = value % n;

            for (i = 1; i <= b; i <<= 1) {
                x %= n;
                if ((b & i) != 0) {
                    result *= x;
                    result %= n;
                }
                x *= x;
            }

            return (int)result;
        }
    }

    public struct Key {
        public int e { get; private set; }
        public int n { get; private set; }
        public Key(int e, int n) {
            this.e = e;
            this.n = n;
        }
    }
}
