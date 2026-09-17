public abstract class Expr
{
    public abstract int Eval(Dictionary<string, int> env);
    public abstract override string ToString();
    public abstract Expr Simplify();
}

public class CstI(int value) : Expr
{
    public readonly int Value = value;

    public override int Eval(Dictionary<string, int> env)
    {
        return Value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public override Expr Simplify()
    {
        return new CstI(Value);
    }
}

public class Var(string name) : Expr
{
    private readonly string _name = name;

    public override int Eval(Dictionary<string, int> env)
    {
        return env[_name];
    }

    public override string ToString()
    {
        return _name;
    }

    public override Expr Simplify()
    {
        return new Var(_name);
    }
}

public abstract class Binob(Expr lhs, Expr rhs) : Expr
{
    protected readonly Expr Lhs = lhs;
    protected readonly Expr Rhs = rhs;
}

public class Add(Expr lhs, Expr rhs) : Binob(lhs, rhs)
{
    public override int Eval(Dictionary<string, int> env)
    {
        return Lhs.Eval(env) + Rhs.Eval(env);
    }

    public override string ToString()
    {
        return "(" + Lhs.ToString() + " + " + Rhs.ToString() + ")";
    }

    public override Expr Simplify()
    {
        var lhs =  Lhs.Simplify();
        var rhs = Rhs.Simplify();

        if (lhs is CstI left && left.Value == 0)
        {
            return rhs;
        }

        if (rhs is CstI right && right.Value == 0)
        {
            return lhs;
        }
        return new Add(lhs, rhs);
    }
}

public class Sub(Expr lhs, Expr rhs) : Binob(lhs, rhs)
{
    public override int Eval(Dictionary<string, int> env)
    {
        return Lhs.Eval(env) - Rhs.Eval(env);
    }

    public override string ToString()
    {
        return "(" + Lhs.ToString() + " - " + Rhs.ToString() + ")";
    }
    public override Expr Simplify()
    {
        var lhs = Lhs.Simplify();
        var rhs = Rhs.Simplify();

        if (rhs is CstI right && right.Value == 0)
        {
            return lhs;
        }

        if (rhs.ToString() == lhs.ToString())
        {
            return new  CstI(0);
        }

        return new Sub(lhs, rhs);
    }
}

public class Mul(Expr lhs, Expr rhs) : Binob(lhs, rhs)
{
    public override int Eval(Dictionary<string, int> env)
    {
        return Lhs.Eval(env) * Rhs.Eval(env);
    }

    public override string ToString()
    {
        return "(" + Lhs.ToString() + " * " + Rhs.ToString() + ")";
    }
    public override Expr Simplify()
    {
        var lhs = Lhs.Simplify();
        var rhs = Rhs.Simplify();

        if (rhs is CstI { Value: 0 } || lhs is CstI { Value: 0 })
        {
            return new CstI(0);
        }

        if (lhs is CstI { Value: 1 })
        {
            return rhs;
        }

        if (rhs is CstI { Value: 1 })
        {
            return lhs;
        }

        return new Mul(lhs, rhs);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var a1 = new Add(new CstI(17), new Mul(new Var("x"), new CstI(20))); 
        var a2 = new Sub(new Var("x"), new Mul(new Var("y"), new CstI(20)));
        var a3 = new Mul(new Var("x"), new CstI(20));
        
        Console.WriteLine(a1);
        Console.WriteLine(a2);
        Console.WriteLine(a3);

        var a4 = new Add(new Var("x"), new CstI(0));
        
        Console.WriteLine(a4.Simplify());
    }
}



