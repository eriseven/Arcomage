﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;

namespace Arcomage.Network
{
    public class GameContext : Entity
    {
        public string JobId { get; set; }

        public int Version { get; set; }

        public GameState State { get; set; }

        public DateTime? StartedDate { get; set; }

        public DateTime? FinishedDate { get; set; }

        public DateTime? CancelledDate { get; set; }

        public Game Game { get; set; }

        public User FirstUser { get; set; }

        public User SecondUser { get; set; }

        public Guid FirstUserId { get; set; }

        public Guid SecondUserId { get; set; }
    }
}
