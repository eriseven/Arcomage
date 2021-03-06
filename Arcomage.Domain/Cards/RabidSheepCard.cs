﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Бешеная овца"
    /// </summary>
    [Serializable]
    public class RabidSheepCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 6;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.AdversaryPlayer.Buildings.Full -= 6;
            game.Players.AdversaryPlayer.Resources.Recruits -= 3;
        }
    }
}
