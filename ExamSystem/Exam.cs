using ExaminationSystem;

public abstract class Exam : ICloneable, IComparable<Exam>
{
    public abstract DateTime ExamTime { get; set; }
    public abstract int QusetinNumber { get; set; }
    public List<Question> Questions { get; set; }

    protected Exam()
    {
    }

    public object Clone()
    {
        Exam clone = (Exam)this.MemberwiseClone();
        clone.Questions = new List<Question>(this.Questions);
        return clone;
    }

    public int CompareTo(Exam? other)
    {
        if (other == null) return 1;
        return this.ExamTime.CompareTo(other.ExamTime);
    }

    public override string ToString()
    => $"question numbers is {QusetinNumber} with {ExamTime} Minutes";


    public abstract void ShowExam();
}
