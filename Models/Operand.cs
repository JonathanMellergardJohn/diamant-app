namespace Models;

public class Operand: IExpressionComponent
{
    public decimal Value { get; set; }

    public Operand(decimal value)
    {
        Value = value;
    }

    public decimal Evaluate() => Value;

    public override string ToString() => Value.ToString();

}
