﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Actions;
using Arcomage.Network.Games;

namespace Arcomage.Network.Domain
{
    public class MemoryStartGameCommand : IStartGameCommand
    {
        private readonly GameBuilder gameBuilder;

        private readonly ConcurrentDictionary<Guid, Game> gameStorage;

        private readonly IChangeStateGameCommand changeStateGameCommand;

        public MemoryStartGameCommand(GameBuilder gameBuilder, ConcurrentDictionary<Guid, Game> gameStorage, IChangeStateGameCommand changeStateGameCommand)
        {
            this.gameBuilder = gameBuilder;
            this.gameStorage = gameStorage;
            this.changeStateGameCommand = changeStateGameCommand;
        }

        public Task Start(GameContext gameContext)
        {
            var gameBuilderContext = gameBuilder.CreateContext();
            var game = gameBuilderContext.Resolve<Game>();

            gameStorage.AddOrUpdate(gameContext.Id, game, (_, g) => g);

            Task.Run(() => StartGame(gameContext, game));

            return Task.CompletedTask;
        }

        private async Task StartGame(GameContext gameContext, Game game)
        {
            var rootPlayAction = new RootPlayAction(game.PlayAction);
            await changeStateGameCommand.ChangeState(gameContext, GameState.Played);
            
            while (!game.Rule.IsWin(game))
            {
                var gameResult = await rootPlayAction.WaitPlay(game);
            }

            await changeStateGameCommand.ChangeState(gameContext, GameState.Finished);
        }
    }
}
