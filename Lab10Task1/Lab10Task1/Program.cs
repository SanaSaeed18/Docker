using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SLRParser
{
    public void Parse()
    {
        // Initializations
        ArrayList States = new ArrayList();
        Stack<string> Stack = new Stack<string>();
        List<string> finalArray = new List<string>();
        string Parser;
        string[] Col = { "begin", "(", ")", "{", "int", "a", "b", "c", "=", "5", "10", "0", ";", "if", ">", "print", "else", "$", "}", "+", "end", "Program", "DecS", "AssS", "IffS", "PriS", "Var", "Const" };

        // Define states
        States.Add("Program_begin ( ) { DecS Decs Decs AssS IffS } end");
        States.Add("DecS_int Var = Const ;");
        States.Add("AssS_Var = Var + Var ;");
        States.Add("IffS_if ( Var > Var ) { PriS } else { PriS }");
        States.Add("PriS_print Var ;");
        States.Add("Var_a");
        States.Add("Var_b");
        States.Add("Var_c");
        States.Add("Const_5");
        States.Add("Const_10");
        States.Add("Const_0");

        // Parse Table
        var dict = new Dictionary<string, Dictionary<string, object>>();
        dict.Add("0", new Dictionary<string, object>()
        {
            { "begin", "S2" },
            { "(", "" },
            { ")", ""},
            { "{", "" },
            { "int", "" },
            { "a", "" },
            { "b", "" },
            { "c", "" },
            { "=", "" },
            { "5", "" },
            { "10", "" },
            { "0", ""},
            { ";", ""},
            { "if", ""},
            { ">", "" },
            { "print", "" },
            { "$", "Accept" }
        });

        dict.Add("1", new Dictionary<string, object>()
        {
            { "begin", "R11" },
            { "(", "R11" },
            { ")", "R11" },
            { "{", "R11" },
            { "int", "R11" },
            { "a", "R11" },
            { "b", "R11" },
            { "c", "R11" },
            { "=", "R11" },
            { "5", "R11" },
            { "10", "R11" },
            { "0", "R11" },
            { ";", "R11" },
            { "if", "R11" },
            { ">", "R11" },
            { "print", "R11" },
            { "else", "R11" },
            { "$", "R11" },
            { "}", "R11" },
            { "+", "R11" },
            { "end", "R11" },
            { "Program", "" },
            { "DecS", "" },
            { "AssS", "" },
            { "IffS", "" },
            { "PriS", "" },
            { "Var", "" },
            { "Const", "" }
        });

        

        dict.Add("2", new Dictionary<string, object>()
        {
            { "begin", "" },
            { "(", "" },
            { ")", "" },
            { "{", "" },
            { "int", "" },
            { "a", "" },
            { "b", "" },
            { "c", "" },
            { "=", "" },
            { "5", "" },
            { "10", "" },
            { "0", "" },
            { ";", "" },
            { "if", "" },
            { ">", "" },
            { "print", "" },
            { "else", "" },
            { "$", "" },
            { "}", "" },
            { "+", "" },
            { "end", "" }
        });

        // Add more dictionary entries here...

        // Parsing process
        Stack.Push("0");
        finalArray.Add("$");
        int pointer = 0;

        while (true)
        {
            if (!Col.Contains(finalArray[pointer]))
            {
                Console.WriteLine("Unable to Parse Unknown Input");
                break;
            }

            Parser = dict[Stack.Peek() + ""][finalArray[pointer] + ""] + "";

            if (Parser.Contains("S"))
            {
                Stack.Push(finalArray[pointer] + "");
                Parser = Parser.TrimStart('S');
                Stack.Push(Parser);
                pointer++;
                PrintStack(Stack);
            }
            else if (Parser.Contains("R"))
            {
                Parser = Parser.TrimStart('R');
                string get = States[Convert.ToInt32(Parser) - 1] + "";
                string[] Splitted = get.Split('_');
                string[] Final_ = Splitted[1].Split(' ');
                int test = Final_.Length;
                for (int i = 0; i < test * 2; i++)
                {
                    Stack.Pop();
                }

                string row = Stack.Peek() + "";
                Stack.Push(Splitted[0]);
                Stack.Push(dict[row][Stack.Peek()] + "");
                PrintStack(Stack);
            }
            else if (Parser.Contains("Accept"))
            {
                Console.WriteLine("Parsed successfullyyy");
                break;
            }
            else if (Parser.Equals(""))
            {
                Console.WriteLine("Unable to Parse");
                break;
            }
        }

        finalArray.Remove("$");
        finalArray.Remove("begin");
    }

    private void PrintStack(Stack<string> stack)
    {
        foreach (var item in stack.Reverse())
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SLRParser parser = new SLRParser();
        parser.Parse();
    }
}
