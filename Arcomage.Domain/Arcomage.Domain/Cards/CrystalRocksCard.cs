﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class CrystalRocksCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 9;

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Buildings.Wall += 7;
            game.GetCurrentPlayer().Resources.Gems += 7;
        }
    }
}