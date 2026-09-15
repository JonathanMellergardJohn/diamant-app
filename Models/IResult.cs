namespace Models;

public interface IResult {
    int MistakeCount();
    int SlowCount();
    int MistakeAndSlowCount();
}
