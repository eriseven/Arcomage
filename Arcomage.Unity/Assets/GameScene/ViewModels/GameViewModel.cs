﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain;
using Arcomage.Domain.Players;

namespace Arcomage.Unity.GameScene.ViewModels
{
    public class GameViewModel
    {
        // HACK
        public Game game;

        public ResourcesViewModel LeftResources { get; set; }

        public BuildingsViewModel LeftBuildings { get; set; }

        public ResourcesViewModel RightResources { get; set; }

        public BuildingsViewModel RightBuildings { get; set; }

        public FinishedMenuViewModel FinishedMenu { get; set; }

        public HistoryViewModel History { get; set; }

        public HandViewModel Hand { get; set; }

        public PlayerKind PlayerKind { get; set; }

        public int DiscardOnly { get; set; }
    }
}
