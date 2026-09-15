namespace Models;

public class Expression: IExpressionComponent
{
    public IExpressionComponent Left { get; set; }
    public IExpressionComponent Right { get; set; }
    public Operator Operator { get; set; }

    public Expression(IExpressionComponent left, IExpressionComponent right, Operator op)
    {
        Left = left;
        Operator = op;
        Right = right;
    }

    public decimal Evaluate()
    {
        decimal leftVal = Left.Evaluate();
        decimal rightVal = Right.Evaluate();

        return Operator switch
        {
            Operator.Add => leftVal + rightVal,
            Operator.Sub => leftVal - rightVal,
            Operator.Mult => leftVal * rightVal,
            Operator.Div => rightVal != 0 ? leftVal / rightVal : throw new DivideByZeroException("Cannot divide by zero."),
            _ => throw new NotImplementedException($"Operator {Operator} is not implemented.")
        };
    }
    public override string ToString()
    {
        string opSymbol = Operator switch
        {
            Operator.Add => "+",
            Operator.Sub => "-",
            Operator.Mult => "×",
            Operator.Div => "/",
            _ => "?"
        };

        return $"{Left.ToString()} {opSymbol} {Right.ToString()}";
    }
}
