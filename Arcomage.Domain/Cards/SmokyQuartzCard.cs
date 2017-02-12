﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Дымчатый кварц"
    /// </summary>
    [Serializable]
    public class SmokyQuartzCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 2;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.AdversaryPlayer.Buildings.Tower -= 1;
            game.PlayAgain += 1;
        }
    }
}
