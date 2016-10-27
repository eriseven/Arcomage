﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Services
{
    public class DiscardCardCriteria : IDiscardCardCriteria
    {
        public bool CanDiscardCard(Game game, int cardIndex)
        {
            return true;
        }
    }
}
