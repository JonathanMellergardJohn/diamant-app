namespace Models;

public class ProblemFactory
{
    public static List<Problem> CreateAG6Full()
    {
        Random rng = new Random();

        var timeCap = new TimeSpan(0, 0, 0, 5);
        List<Problem> problems = new List<Problem>();

        var two = new ProblemCategory(CategoryCode.AG6_1a, "Tvåans tabell");
        var four = new ProblemCategory(CategoryCode.AG6_1b, "Fyrans tabell");
        var three = new ProblemCategory(CategoryCode.AG6_2a, "Trean tabell");
        var five = new ProblemCategory(CategoryCode.AG6_3a, "Femman tabell");
        var six = new ProblemCategory(CategoryCode.AG6_2b, "Sexans tabell");
        var high = new ProblemCategory(CategoryCode.AG6_3b, "Höga faktorer");

        for(var left = 2; left < 10; left++)
        {
            for(var right = left; right < 10; right++)
            {

                Expression exp;

                if (rng.Next(2) == 0)
                {
                    exp = new Expression(new Operand(left), new Operand(right), Operator.Mult);
                }
                else
                {
                    exp = new Expression(new Operand(right), new Operand(left), Operator.Mult);
                }

                Problem problem = new Problem(exp, timeCap);

                bool skipSecondSwitch = false;

                switch (left)
                {
                    case 2:
                        if (right == left)
                        {
                            skipSecondSwitch = true;
                        }
                        problem.ProblemCategories.Add(two);
                        break;
                    case 3:
                        if (right == left)
                        {
                            skipSecondSwitch = true;
                        }
                        problem.ProblemCategories.Add(three);
                        break;
                    case 4:
                        if (right == left)
                        {
                            skipSecondSwitch = true;
                        }
                        problem.ProblemCategories.Add(four);
                        break;
                    case 5:
                        if (right == left)
                        {
                            skipSecondSwitch = true;
                        }
                        problem.ProblemCategories.Add(five);
                        break;
                    case 6:
                        if (right == left)
                        {
                            skipSecondSwitch = true;
                        }
                        problem.ProblemCategories.Add(six);
                        break;
                    default:
                        switch (left)
                        {
                            case 7:
                                if (right >= 7)
                                {
                                    skipSecondSwitch = true;
                                    problem.ProblemCategories.Add(high);
                                }

                                break;
                            case 8:
                                if (right >= 7)
                                {
                                    skipSecondSwitch = true;
                                    problem.ProblemCategories.Add(high);
                                }
                                break;
                            default:
                                if (right >= 7)
                                {
                                    skipSecondSwitch = true;
                                    problem.ProblemCategories.Add(high);
                                }
                                break;
                        }
                        break;
                }

                if (skipSecondSwitch)
                {
                    problems.Add(problem);
                    continue;
                }
                else
                {
                    switch (right)
                    {
                        case 2:
                            problem.ProblemCategories.Add(two);
                            break;
                        case 3:
                            problem.ProblemCategories.Add(three);
                            break;
                        case 4:
                            problem.ProblemCategories.Add(four);
                            break;
                        case 5:
                            problem.ProblemCategories.Add(five);
                            break;
                        case 6:
                            problem.ProblemCategories.Add(six);
                            break;
                        default:
                            break;
                    }
                }
                problems.Add(problem);
            }
        }

        // 1. Initialize a random number generator
        int n = problems.Count;

        // 2. Perform the in-place Fisher-Yates shuffle
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Problem value = problems[k];
            problems[k] = problems[n];
            problems[n] = value;
        }

        return problems;
    }
}
