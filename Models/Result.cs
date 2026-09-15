namespace Models;

public class Result : IResult
{
    public string Name { get; set; }
    public List<Problem> Problems { get; set; } = new List<Problem>();
    public List<ResultGroup> GroupedProblems { get; set; } = new List<ResultGroup>();

    public Result(string name, List<Problem> problems)
    {
        Name = name;
        Problems = problems;

        // logic for setting GroupedProblems

        foreach (var problem in Problems)
        {
            if (problem.ProblemCategories == null) continue;

            foreach (var category in problem.ProblemCategories)
            {
                var existingGroup = GroupedProblems.Find(g => g.Category == category);

                if (existingGroup == null)
                {
                    existingGroup = new ResultGroup(category);
                    GroupedProblems.Add(existingGroup);

                }
                existingGroup.Problems.Add(problem);
            }
        }

        GroupedProblems = GroupedProblems.OrderBy(g => g.Category.Code switch
        {
            CategoryCode.AG6_1a => 1, // Tvåan
            CategoryCode.AG6_2a => 2, // Trean
            CategoryCode.AG6_3a => 3, // Femman
            CategoryCode.AG6_1b => 4, // Fyran
            CategoryCode.AG6_2b => 5, // Sexan
            CategoryCode.AG6_3b => 6, // Höga faktorer
            _ => 100                 // Any unexpected fallback category sits at the end
        }).ToList();

    }
    public int MistakeCount()
    {
        int count = 0;
        foreach (var problem in Problems)
        {
            if (!problem.UserIsCorrect())
            {
                count++;
            }
        }
        return count;
    }

    public int SlowCount()
    {
        int count = 0;
        foreach (var problem in Problems)
        {
            if (problem.UserTime > problem.TimeCap)
            {
                count++;
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

    public decimal ReturnGrade()
    {
        if (GroupedProblems.Count == 0)
        {
            return 0;
        }
        decimal gradeSum = 0;

        foreach(var group in GroupedProblems)
        {
            gradeSum = gradeSum + group.ReturnGrade();
        }

        decimal average = gradeSum / GroupedProblems.Count;

        return Math.Round(average, 2, MidpointRounding.AwayFromZero);
    }
}
