using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var data = Console.ReadLine();
            TagcheckerFunction(data);
        }


        public static void TagcheckerFunction(string data) {

            //var data = "<B>This should be in boldface, but there is an extra closingtag </ B ></ C >#";
            //var data = "<B><C>This should be centered and in boldface, but there is a missing closing tag</C>";
            var stack = new Stack<char>();
            var counter = 0;
            var endcounter = 0;

            foreach (var i in data)
            {

                if (i == '<' && counter == 0)
                {
                    counter++;
                }
                else if (counter == 1 && (Convert.ToInt32(i) >= 65 && Convert.ToInt32(i) <= 97))
                {
                    stack.Push(i);
                    counter++;

                }
                else if (counter == 1 && i == '/')
                {
                    //counter++;
                    endcounter++;
                }
                else if (counter == 1 && (Convert.ToInt32(i) >= 65 && Convert.ToInt32(i) <= 97))
                {

                    stack.Pop();
                    stack.Pop();
                    counter -= 2;
                }
                else if (counter == 2 && i == '>' && endcounter == 0)
                {
                    counter = 0;
                }
                else if (counter == 2 && i == '>' && endcounter == 1)
                {
                    char a;
                    char b;
                    a = stack.Pop();
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("Expected #  found </" + a + ">");
                        return;
                    }
                    else
                    {
                        b = stack.Pop();
                    }

                    counter = 0;
                    endcounter = 0;
                    if (a != b)
                    {
                        Console.WriteLine("Expected </" + b + "> found </" + a + ">");
                        //break;
                        return;
                    }
                }



            }
            if (stack.Count == 0) { Console.WriteLine("Correctly tagged paragraph"); }
            else { Console.WriteLine("Expected </" + stack.Pop() + "> Found #"); }

        }
    }
}