namespace TennisSimulator.Services
{
    public interface ITennisServiceFactory
    {
        TennisMatch GetMatchService();
        TennisSet GetSetService();
        TennisGame GetGameService();
    }
}
