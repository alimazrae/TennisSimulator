namespace TennisSimulator.Services
{
    public class TennisServiceFactory : ITennisServiceFactory
    {
        private readonly ITennisPointWinnerService _tennisPointWinner;

        public TennisServiceFactory(ITennisPointWinnerService tennisPointWinner)
        {
            _tennisPointWinner = tennisPointWinner;
        }

        public TennisMatch GetMatchService()
        {
            return new TennisMatch(this);
        }

        public TennisSet GetSetService()
        {
            return new TennisSet(this);
        }

        public TennisGame GetGameService()
        {
            return new TennisGame(_tennisPointWinner);
        }
    }
}
