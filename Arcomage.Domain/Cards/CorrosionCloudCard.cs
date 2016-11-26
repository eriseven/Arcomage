﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class CorrosionCloudCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 11;

        public override void Activate(Game game)
        {
            if (game.GetAdversaryPlayer().Buildings.Wall > 0)
                game.GetAdversaryPlayer().Buildings.Damage(10);
            else
                game.GetAdversaryPlayer().Buildings.Damage(7);
        }
    }
}