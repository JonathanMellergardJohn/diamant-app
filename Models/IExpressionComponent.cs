namespace Models;

public interface IExpressionComponent
{
    decimal Evaluate();
    string ToString();
}
