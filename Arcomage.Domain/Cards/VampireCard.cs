﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class VampireCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 17;

        public override void Activate(Game game)
        {
            game.GetAdversaryPlayer().Buildings.Damage(10);
            game.GetAdversaryPlayer().Resources.Recruits -= 5;
            game.GetAdversaryPlayer().Resources.Dungeons -= 1;
        }
    }
}