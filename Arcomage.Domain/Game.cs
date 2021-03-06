﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Decks;
using Arcomage.Domain.Histories;
using Arcomage.Domain.Players;
using Arcomage.Domain.Rules;
using Arcomage.Domain.Timers;

namespace Arcomage.Domain
{
    /// <summary>
    /// Контекст игровой сессии
    /// </summary>
    [Serializable]
    public class Game
    {
        /// <summary>
        /// Количество ходов, в течении которых ход не передается другому игроку
        /// </summary>
        private int playAgain;

        /// <summary>
        /// Количество ходов, в течении которых карты можно только скидывать
        /// </summary>
        private int discardOnly;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="Game"/>
        /// </summary>
        /// <param name="rule">Правила игры</param>
        /// <param name="deck">Игровая колода</param>
        /// <param name="history">История сделанных ходов</param>
        /// <param name="players">Игроки</param>
        /// <param name="timer">Таймер</param>
        public Game(IPlayAction playAction, Rule rule, Deck deck, History history, PlayerSet players, Timer timer)
        {
            Contract.Requires(playAction != null);
            Contract.Requires(rule != null);
            Contract.Requires(deck != null);
            Contract.Requires(history != null);
            Contract.Requires(players != null);
            Contract.Requires(timer != null);

            PlayAction = playAction;
            Rule = rule;
            Deck = deck;
            History = history;
            Players = players;
            Timer = timer;
        }

        public IPlayAction PlayAction { get; }

        /// <summary>
        /// Правила игры
        /// </summary>
        public Rule Rule { get; }
        
        /// <summary>
        /// Игровая колода
        /// </summary>
        public Deck Deck { get; }

        /// <summary>
        /// История сделанных ходов
        /// </summary>
        public History History { get; }

        /// <summary>
        /// Игроки
        /// </summary>
        public PlayerSet Players { get; }

        /// <summary>
        /// Таймер
        /// </summary>
        public Timer Timer { get; }

        /// <summary>
        /// Количество ходов, в течении которых ход не передается другому игроку
        /// </summary>
        public int PlayAgain
        {
            get { return playAgain; }
            set { playAgain = Math.Max(value, 0); }
        }

        /// <summary>
        /// Количество ходов, в течении которых карты можно только скидывать
        /// </summary>
        public int DiscardOnly
        {
            get { return discardOnly; }
            set { discardOnly = Math.Max(value, 0); }
        }
    }
}
