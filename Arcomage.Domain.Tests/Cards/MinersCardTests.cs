﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class MinersCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            MinersCard sut)
        {
            sut.Activate(game);

            Assert.Equal(3, game.Players.FirstPlayer.Resources.Quarry);
        }
    }
}
