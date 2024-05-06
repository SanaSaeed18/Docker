using System;

//Grammer of CC
//Expr -> Expr + Term | Term
//Term -> Term * Factor | Factor
//Factor -> Number
//Number -> [0-9]

public abstract class Node
{
    public abstract int Evaluate();
}

public class Expr : Node
{
    public char Op { get; }
    public Node Left { get; }
    public Node Right { get; }

    public Expr(char op, Node left, Node right)
    {
        Op = op;
        Left = left;
        Right = right;
    }

    public override int Evaluate()
    {
        if (Op == '+')
            return Left.Evaluate() + Right.Evaluate();
        else if (Op == '-')
            return Left.Evaluate() - Right.Evaluate();
        return 0; 
    }
}

public class Term : Node
{
    public char Op { get; }
    public Node Left { get; }
    public Node Right { get; }

    public Term(char op, Node left, Node right)
    {
        Op = op;
        Left = left;
        Right = right;
    }

    public override int Evaluate()
    {
        if (Op == '*')
            return Left.Evaluate() * Right.Evaluate();
        else if (Op == '/')
            return Left.Evaluate() / Right.Evaluate();
        return 0; 
    }
}

public class Factor : Node
{
    public Node Value { get; }

    public Factor(Node value)
    {
        Value = value;
    }

    public override int Evaluate()
    {
        return Value.Evaluate();
    }
}

public class Number : Node
{
    public int Value { get; }

    public Number(int value)
    {
        Value = value;
    }

    public override int Evaluate()
    {
        return Value;
    }
}

class Program
{
    static void Main(string[] args)
    {
       
        Node expr = new Expr('+', new Term('*', new Factor(new Number(2)), new Factor(new Number(3))), new Factor(new Number(4)));

        
        int result = expr.Evaluate();
        Console.WriteLine("Result: " + result);
    }
}
