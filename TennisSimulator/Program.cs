using Castle.MicroKernel.Registration;
using Castle.Windsor;
using TennisSimulator.Data;
using TennisSimulator.Infrastructure;
using TennisSimulator.Services;

namespace TennisSimulator
{
    class Program
    {
        private static IWindsorContainer _container;

        static void Main(string[] args)
        {
            _container = new WindsorContainer();

            _container.Register(Component.For<ITennisPointWinnerService>().ImplementedBy<RandomTennisPointWinnerService>().LifestyleSingleton());
            _container.Register(Component.For<IUserInterface>().ImplementedBy<ConsoleUserInterface>().LifestyleSingleton());
            _container.Register(Component.For<ITennisMatchRunner>().ImplementedBy<TennisMatchConsoleRunner>().LifestyleSingleton());
            _container.Register(Component.For<ITennisMatch>().ImplementedBy<TennisMatch>().LifestyleSingleton());


            var player1 = new Player("Andy Murray");
            var player2 = new Player("Roger Federer");

            var matchRunner = _container.Resolve<ITennisMatchRunner>();
            matchRunner.RunMatch(player1, player2);
        }
    }
}
