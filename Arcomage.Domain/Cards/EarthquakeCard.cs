﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Землетрясение"
    /// </summary>
    [Serializable]
    public class EarthquakeCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 0;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.FirstPlayer.Resources.Quarry -= 1;
            game.Players.SecondPlayer.Resources.Quarry -= 1;
        }
    }
}
