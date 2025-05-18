using System;


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
        }

}
