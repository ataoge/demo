namespace Ataoge.Core
{
    public interface ISysSession
    {
        int? UserId { get;}
        string GetParam(string name, string defaultValue = null);
    }
}