//This file is under the same license as Form_hashFunctions.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cs276_bjt_11__2008_hashFunctions
{
    class Lexer
    {
        /// <summary>
        /// Lexing a string of input into a list of tokens
        /// </summary>
        /// <param name="input"> input string </param>
        /// <returns> list of tokens </returns>
        public static List<Element> Lex(string input)
        {
            string[] buf; // buffer for handling the stream

            List<string> stream = new List<string>(); // the stream of input

            char[] delim = C.Delims; // delimeters

            if (input != null) // if there is some input
            {
                while (input != "") // while we have input
                {
                    buf = input.Split(delim, 2); // getting the next token
                    stream.Add(buf[0]); // adding the element to the list
                    input = input.Remove(0, buf[0].Length); // removing the added element
                    if (input.Length > 0) // if there was a delimeter
                    {
                        stream.Add(input[0].ToString()); // getting the delimeter
                        input = input.Remove(0, 1); // removing the delimeter from the input
                    }
                }
            }

            // removing junk from the stream
            for (int i = 0; i < stream.Count; i++) if (stream[i] == " " || stream[i] == "") stream.RemoveAt(i--);

            List<Element> token = StringsToElements(stream);

            return token;
        } // Lex

        /// <summary>
        /// Transfering a list of strings to a list of token elements
        /// </summary>
        /// <param name="ListS"> list of strings </param>
        /// <returns> list of token elements </returns>
        static List<Element> StringsToElements(List<string> ListS)
        {
            List<Element> ListE = new List<Element>();
            foreach (string s in ListS)
            {
                Element n = new Element(s);
                switch (n.Type)
                {
                    case C.Operation: n = new Operation(n); break;
                    case C.Number: n = new Number(n); break;
                    case C.Function: n = new FunctionElement(n); break;
                    case C.Control: n = new Control(n); break;
                }
                ListE.Add(n);
            }
            return ListE;
        } // StringsToElements

        
    } // LEXER
}
