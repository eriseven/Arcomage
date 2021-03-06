﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain;
using Arcomage.Domain.Decks;
using Arcomage.Domain.Players;
using Arcomage.Domain.Rules;
using SmartLocalization;

namespace Arcomage.Unity.Shared.Scripts
{
    public class SingleSettings
    {
        public string FirstPlayer = LanguageManager.Instance.GetTextValue("SettingsFirstPlayerDefaultName");

        public string SecondPlayer = LanguageManager.Instance.GetTextValue("SettingsSecondPlayerDefaultName");

        public RuleInfo Rule = new ClassicRuleInfo("EmpireCapital", 2, 5, 2, 5, 2, 5, 5, 20, 50, 150, 3);

        public DeckInfo Deck = new ClassicDeckInfo("Classic", new Random());

        public PlayerKind PlayerKind = PlayerKind.First;

        public GameBuilderContext<SingleSettings> GameBuilderContext { get; set; }
    }
}
