using System;
using Castle.Core.Logging;
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

            _container.Register(Component.For<ITennisPointWinnerService>().ImplementedBy<RandomTennisPointWinnerService>());
            _container.Register(Component.For<IUserInterface>().ImplementedBy<ConsoleUserInterface>());

            var player1 = new Player("Andy Murray");
            var player2 = new Player("Roger Federer");

            var ui = _container.Resolve<IUserInterface>();
            var match = new TennisMatch(ui, player1, player2);

            match.PlayMatch();
            ui.WaitForUserInput();
        }
    }
}
