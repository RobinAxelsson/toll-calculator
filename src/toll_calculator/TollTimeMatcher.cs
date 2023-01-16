internal interface TollCompareTo
{
    public TollCompareMatch LessThan(int hour, int minute, int second);
}
internal interface TollCompareMatch
{
    public bool Match(DateTime date);
}


internal class TollTimeMatcher : TollCompareTo, TollCompareMatch
{
    private readonly TimeSpan from;
    private TimeSpan? to;

    private TollTimeMatcher(TimeSpan from)
    {
        this.from = from;
    }

    public static TollCompareTo StartFrom(int hour, int minute, int second)
    {
        return new TollTimeMatcher(new TimeSpan(hour, minute, second));
    }

    public TollCompareMatch LessThan(int hour, int minute, int second)
    {
        to = new TimeSpan(hour, minute, second);
        return this;
    }

    public bool Match(DateTime date)
    {
        var passing = new TimeSpan(date.Hour, date.Minute, date.Second);
        return (from <= passing && passing < to);
    }
}