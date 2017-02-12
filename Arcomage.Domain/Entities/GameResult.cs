﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    /// <summary>
    /// Результат игры
    /// </summary>
    [Serializable]
    public struct GameResult
    {
        /// <summary>
        /// Представляет отсутствие результата игры
        /// </summary>
        public static readonly GameResult None = new GameResult();

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="GameResult"/>
        /// </summary>
        /// <param name="player">Победивший игрок</param>
        /// <param name="isTowerBuild">Игрок победил, построив собственную башню</param>
        /// <param name="isTowerDestroy">Игрок победил, разрушив башню соперника</param>
        /// <param name="isResourcesAccumulate">Игрок победил, собрав собственные ресурсы</param>
        public GameResult(PlayerKind player, bool isTowerBuild, bool isTowerDestroy, bool isResourcesAccumulate)
            : this()
        {
            Contract.Requires(Enum.IsDefined(typeof(PlayerKind), player));

            Player = player;
            IsTowerBuild = isTowerBuild;
            IsTowerDestroy = isTowerDestroy;
            IsResourcesAccumulate = isResourcesAccumulate;
        }

        /// <summary>
        /// Победивший игрок
        /// </summary>
        public PlayerKind Player { get; }

        /// <summary>
        /// Игрок победил, построив собственную башню
        /// </summary>
        public bool IsTowerBuild { get; }

        /// <summary>
        /// Игрок победил, разрушив башню соперника
        /// </summary>
        public bool IsTowerDestroy { get; }

        /// <summary>
        /// Игрок победил, собрав собственные ресурсы
        /// </summary>
        public bool IsResourcesAccumulate { get; }

        /// <summary>
        /// Оператор преобразования результата игры в булевое значение. Если <paramref name="x"/> равен 
        /// <see cref="None"/>, возвращается значение false, и true в противном случае
        /// </summary>
        /// <param name="x">Результат игры</param>
        public static implicit operator bool(GameResult x) => !Equals(x, None);
    }
}
