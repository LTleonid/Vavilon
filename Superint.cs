using System;
using System.Text;


namespace Superint
{
    class Superint
    {
        public char[] chars;

        public string superinteger;

        public Superint()
        {
            chars = new char[] {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'й', 'ц', 'у', 'к', 'е', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ъ',
            'ф', 'ы', 'в', 'а', 'п', 'р', 'о', 'л', 'д', 'ж', 'э', 'я',
            'ч', 'с', 'м', 'и', 'т', 'ь', 'б', 'ю',
            'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's',
            'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b',
            'n', 'm', '.', ',', ':', '-', ' '
            };
            superinteger = "";
        }

        public string Transfer(int integer)
        {
            if (integer == 0)
            {
                superinteger = "0";
                return superinteger;
            }

            string temp = "";
            while (integer > 0)
            {
                temp += chars[integer % chars.Length];
                integer /= chars.Length;
            }

            char[] charArray = temp.ToCharArray();
            Array.Reverse(charArray);
            superinteger = new string(charArray);

            return superinteger;
        }
        public int Transfer(string text)
        {
            if (text == "0") return 0;
            int integer = 0;
            int temp = 0;
            foreach (char i in text)
            {
                integer = integer * chars.Length +  Array.IndexOf(chars, i);
                temp++;
            }
            superinteger = text;
            return integer;

        }

        public static Superint operator ++(Superint superint)
        {
            superint.superinteger = Increment(superint.superinteger, superint.chars);
            return superint;
        }


        public static Superint operator --(Superint superint)
        {
            superint.superinteger = Decrement(superint.superinteger, superint.chars);
            return superint;
        }

        public static Superint operator +(Superint a, Superint b)
        {
            int sum = a.Transfer(a.superinteger) + b.Transfer(b.superinteger);
            Superint result = new Superint();
            result.superinteger = result.Transfer(sum);
            return result;
        }


        public static Superint operator +(Superint a, int b)
        {
            int sum = a.Transfer(a.superinteger) + b;
            Superint result = new Superint();
            result.superinteger = result.Transfer(sum);
            return result;
        }

        public static Superint operator +(Superint a, string b)
        {
            int sum = a.Transfer(a.superinteger) + a.Transfer(b);
            Superint result = new Superint();
            result.superinteger = result.Transfer(sum);
            return result;
        }


        private static string Increment(string value, char[] chars)
        {
            char[] temp = value.ToCharArray();
            int i = temp.Length - 1;
            bool newDigit = true;

            while (i >= 0 && newDigit)
            {
                int idx = Array.IndexOf(chars, temp[i]);
                if (idx == chars.Length - 1)
                {
                    temp[i] = chars[0];
                    i--;
                }
                else
                {
                    temp[i] = chars[idx + 1];
                    newDigit = false;
                }
            }

            if (newDigit)
            {
                return chars[1] + new string(temp);
            }
            else
            {
                return new string(temp);
            }
        }


        private static string Decrement(string value, char[] chars)
        {
            if (value == "0") return "0";
            char[] temp = value.ToCharArray();
            int i = temp.Length - 1;
            bool needBorrow = true;

            while (i >= 0 && needBorrow)
            {
                int idx = Array.IndexOf(chars, temp[i]);
                if (idx == 0)
                {
                    temp[i] = chars[chars.Length - 1];
                    i--;
                }
                else
                {
                    temp[i] = chars[idx - 1];
                    needBorrow = false;
                }
            }

            string result = new string(temp).TrimStart(chars[0]);
            return result;
        }


        
        
    }
}
