using TennisSimulator.Data;

namespace TennisSimulator.Infrastructure
{
    public interface IUserInterface
    {
        void Clear();
        void Write(string message);
        void WriteWithNewLine(string message);
        void WaitForUserInput();
        void WriteMatch(MatchResult matchResult);
    }
}
