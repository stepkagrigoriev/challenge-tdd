using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Linq.Expressions; 
using System.Runtime.CompilerServices; 
 
namespace App 
{ 
    public static class PostfixCalculator 
    { 
        public static string Calculate(string postfixExpression) 
        { 
            if (postfixExpression == null) 
                throw new FormatException(); 
            if (postfixExpression.Length == 0) 
                return "0"; 
            var array = postfixExpression.Split(' ').ToList(); 
            int a,b; 
            string c; 
            while (array.Count() > 1) 
            {
                try
                {
                    c = array[2];
                }
                catch
                {
                    throw new FormatException();
                }

                if (int.TryParse(array[0], out a) && int.TryParse(array[1], out b)) 
                { 
                    array[0] = NewResult(a, b, c).ToString(); 
                    array.RemoveAt(1);
                    array.RemoveAt(1);
                } 
                else
                    throw new FormatException(); 
            } 
            if (!int.TryParse(array[0], out a)) 
                throw new FormatException(); 
            return array[0]; 
        } 
        public static double NewResult(double a, double b, string c) 
        { 
            if (c == "+") 
                return a + b; 
            if (c == "-") 
                return a - b; 
            if (c == "*") 
                return a * b; 
            throw new FormatException(); 
        } 
    } 
}