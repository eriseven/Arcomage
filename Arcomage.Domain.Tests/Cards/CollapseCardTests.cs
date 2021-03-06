﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class CollapseCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            CollapseCard sut)
        {
            sut.Activate(game);

            Assert.Equal(1, game.Players.SecondPlayer.Resources.Quarry);
        }
    }
}
