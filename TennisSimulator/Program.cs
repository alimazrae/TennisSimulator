using System;
using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
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
            _container.Register(Component.For<ITennisMatch>().ImplementedBy<TennisMatch>().LifestyleSingleton());


            var player1 = new Player("Andy Murray");
            var player2 = new Player("Roger Federer");

            var match = _container.Resolve<ITennisMatch>();
            
            var result = match.PlayMatch();
        }
    }
}
