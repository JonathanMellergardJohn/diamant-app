namespace Models;

public class Problem
{
    public Expression Expression { get; set; }
	public TimeSpan? UserTime { get; set; } = null;
	public string? UserAnswer { get; set; } = null;
	public List<ProblemCategory> ProblemCategories { get; set; } = new List<ProblemCategory>();
	public TimeSpan? TimeCap { get; set; } = null;

    public Problem(Expression expression, TimeSpan timeCap)
    {
        Expression = expression;
        TimeCap = timeCap;
    }

    public bool UserIsCorrect()
    {
        decimal answerAsDecimal;

        if (decimal.TryParse(UserAnswer, out answerAsDecimal))
        {
            if (answerAsDecimal == Expression.Evaluate())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public decimal? TimeToCapQuot()
    {
        if (UserTime == null || TimeCap == null)
        {
            return null;
        }
        else
        {
            return (decimal)(UserTime.Value / TimeCap.Value);
        }

    }

    public string ExpressionToString() => Expression.ToString();

    public string UserAnswerToString()
    {
        if (UserAnswer == "" || UserAnswer == null) return "-";
        else return UserAnswer;
    }
}
