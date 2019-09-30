using System;
using System.Collections.Generic;

namespace dotnet_crawler.services
{
    public class Function
    {
        private readonly static Dictionary<string, string> replacements = new Dictionary<string, string>()
        {
            ["a"] = "z",
            ["b"] = "y",
            ["c"] = "x",
            ["d"] = "w",
            ["e"] = "v",
            ["f"] = "u",
            ["g"] = "t",
            ["h"] = "s",
            ["i"] = "r",
            ["j"] = "q",
            ["k"] = "p",
            ["l"] = "o",
            ["m"] = "n",
            ["n"] = "m",
            ["o"] = "l",
            ["p"] = "k",
            ["q"] = "j",
            ["r"] = "i",
            ["s"] = "h",
            ["t"] = "g",
            ["u"] = "f",
            ["v"] = "e",
            ["w"] = "d",
            ["x"] = "c",
            ["y"] = "b",
            ["z"] = "a",
            ["0"] = "9",
            ["1"] = "8",
            ["2"] = "7",
            ["3"] = "6",
            ["4"] = "5",
            ["5"] = "4",
            ["6"] = "3",
            ["7"] = "2",
            ["8"] = "1",
            ["9"] = "0",
        };

        public static string getDecodedToken(string token)
        {
            char[] chars = token.ToCharArray();
            char[] e = chars;
            char tempChar;
            for (int t = 0; t < e.Length; t++)
            {
                tempChar = e[t];
                try {
                    var index = tempChar.ToString();
                    var newChar = replacements[index];
                    e[t] = newChar[0];
                } catch {
                    e[t] = tempChar;
                }
            }
            return new String(e);
        }
    }
}