namespace Models;

public class ResultGroup: IResult
{
    public ProblemCategory Category { get; set; }
    public List<Problem> Problems { get; set; } = new List<Problem>();

    public ResultGroup(ProblemCategory category)
    {
        Category = category;
    }

    public int MistakeCount()
    {
        int count = 0;
        foreach (var problem in Problems)
        {
            if (problem.UserIsCorrect())
            {
                count++;
            }
        }
        return count;
    }

    // slow exclusive, e.i problems that are mistakes are not counted
    public int SlowCount()
    {
        int count = 0;
        foreach (var problem in Problems)
        {
            if (problem.UserIsCorrect())
            {
                if (problem.UserTime > problem.TimeCap)
                {
                    count++;
                }
            }
        }
        return count;
    }
    // method does NOT double count!
    public int MistakeAndSlowCount() {
        int count = 0;

        foreach (var problem in Problems)
        {
            if (!problem.UserIsCorrect())
            {
                count++;
                continue;
            }
            if (problem.UserTime > problem.TimeCap)
            {
                count++;
            }
        }

        return count;
    }
    public int ReturnGrade()
    {
        if (Problems.Count == 0)
        {
            return 0;
        }
        int mistakeAndSlow = MistakeAndSlowCount();

        if (mistakeAndSlow == 0)
        {
            return 0;
        }

        decimal ratio = (decimal)mistakeAndSlow / Problems.Count;

        if (ratio <= 0.2m )
        {
            return 1;
        }
        else if (ratio <= 0.4m)
        {
            return 2;
        }
        else if (ratio <= 0.6m)
        {
            return 3;
        }
        else
        {
            return 4;
        }
    }
}

// with ten problems, one mistake => yellow, but one slow => green
// tree mistakes => red; 2-5 slow => yellow
// > 5 slow => red
