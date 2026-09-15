namespace Models;

public enum CategoryCode {
    AG6_1a,
    AG6_1b,
    AG6_2a,
    AG6_2b,
    AG6_3a,
    AG6_3b
}

public class ProblemCategory
{
    public CategoryCode Code { get; set; }
    public string Name {get; set;}
    public string Description { get; set; }

    public ProblemCategory(CategoryCode code, string name, string description = "")
    {
        Code = code;
        Name = name;
        Description = description;
    }
}
