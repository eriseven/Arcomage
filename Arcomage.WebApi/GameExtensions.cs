﻿using System;
using System.Collections.Generic;
using System.Linq;
using Arcomage.Domain;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Players;
using Arcomage.Network;

namespace Arcomage.WebApi
{
    public static class GameExtensions
    {
        public static string GetIdentifier(this Card card)
        {
            var name = card.GetType().Name;

            if (name.EndsWith("Card"))
                return name.Substring(0, name.Length - 4);

            return name;
        }

        public static string GetIdentifier(this GameResult gameResult)
        {
            if (gameResult.IsTowerBuild)
                return "TowerBuild";

            if (gameResult.IsTowerDestroy)
                return "TowerDestroy";

            if (gameResult.IsResourcesAccumulate)
                return "ResourcesAccumulate";

            if (gameResult.IsPlayerTimeout)
                return "PlayerTimeout";

            return "";
        }

        public static string GetName(this GameContext settings, PlayerKind playerKind)
        {
            if (playerKind == PlayerKind.First)
                return settings.FirstUser.Id.ToString();

            if (playerKind == PlayerKind.Second)
                return settings.SecondUser.Id.ToString();

            throw new InvalidOperationException();
        }

        public static PlayerKind GetPlayerKind(this GameContext gameContext, User user)
        {
            if (gameContext.FirstUser.Id == user.Id)
                return PlayerKind.First;

            if (gameContext.SecondUser.Id == user.Id)
                return PlayerKind.Second;

            throw new InvalidOperationException();
        }
    }
}