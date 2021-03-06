﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.Framework.Bindings;
using UnityEngine;

namespace Arcomage.Unity.Framework
{
    /// <summary>
    /// Представление компонента, которое может использовать автоматически обновляемые свойства при их изменении
    /// </summary>
    public abstract class View : MonoBehaviour
    {
        /// <summary>
        /// Коллекция привязок, зарегистрированных на этом представлении компонента
        /// </summary>
        private readonly List<Binding> bindingCollection = new List<Binding>();

        /// <summary>
        /// Создает привзяку к заданному значению. Проверка изменения значения каждый цикл не производится, код 
        /// привязки выполняется только в первом цикле
        /// </summary>
        /// <typeparam name="TValue">Тип значения</typeparam>
        /// <param name="value">Значение</param>
        /// <returns>Привязка</returns>
        protected ConstBinding<TValue> Bind<TValue>(TValue value)
        {
            var binding = new ConstBinding<TValue>(value);
            bindingCollection.Add(binding);

            return binding;
        }

        /// <summary>
        /// Создает привязку к методу. Вызов метода выполняется каждый цикл и вызывается зарегитрированный на эту 
        /// привязку обработчик
        /// </summary>
        /// <param name="action">Делегат, представляющий вызов метода</param>
        /// <returns>Привязка</returns>
        protected ActionBinding Bind(Action action)
        {
            var binding = new ActionBinding(action);
            bindingCollection.Add(binding);

            return binding;
        }

        /// <summary>
        /// Создает привязку к методу объекта. Вызов метода выполняется каждый цикл и вызывается зарегистрированный 
        /// на эту привязку обработчик
        /// </summary>
        /// <typeparam name="TSource">Тип объекта, относительно которого выполяняется привязка</typeparam>
        /// <param name="source">Объект, относительно которого выполняется привязка</param>
        /// <param name="action">Делегат, предоставляющий вызов метода</param>
        /// <returns>Привзяка</returns>
        protected ActionBinding<TSource> Bind<TSource>(TSource source, Action<TSource> action)
        {
            var binding = new ActionBinding<TSource>(source, action);
            bindingCollection.Add(binding);

            return binding;
        }

        /// <summary>
        /// Создает привязку к методу объекта. Проверка значения выполняется каждый цикл и в случае изменения значения
        /// вызывается зарегистрированный на эту привязку обработчик
        /// </summary>
        /// <typeparam name="TValue">Тип значения привязки</typeparam>
        /// <param name="func">Делегат, предоставляющий доступ к объекту привязки</param>
        /// <returns>Привязка</returns>
        protected ValueBinding<TValue> Bind<TValue>(Func<TValue> func)
        {
            var binding = new ValueBinding<TValue>(func);
            bindingCollection.Add(binding);

            return binding;
        }

        /// <summary>
        /// Создает привязку к свойству или методу объекта. Проверка изменения значения выполняется каждый цикл и в 
        /// случае изменения значения вызывается зарегистрированный на эту привязку обработчик
        /// </summary>
        /// <typeparam name="TSource">Тип объекта, относительно которого выполяняется привязка</typeparam>
        /// <typeparam name="TValue">Тип значения привязки</typeparam>
        /// <param name="source">Объект, относительно которого выполняется привязка</param>
        /// <param name="func">Делегат, предоставляющий доступ к объекту привязки</param>
        /// <returns>Привзяка</returns>
        protected ValueBinding<TSource, TValue> Bind<TSource, TValue>(TSource source, Func<TSource, TValue> func)
        {
            var binding = new ValueBinding<TSource, TValue>(source, func);
            bindingCollection.Add(binding);

            return binding;
        }

        /// <summary>
        /// Создает привзяку к коллекции объекта. Проверка на изменение состава коллекции (удаление, добавление, 
        /// изменение элементов коллекции) выполняется каждый цикл и в случае изменения коллекции вызывается
        /// зарегистрированный на эту привзяку обработчик
        /// </summary>
        /// <typeparam name="TSource">Тип объекта, относительно которого выполяняется привязка</typeparam>
        /// <typeparam name="TValue">Тип элементов коллекции</typeparam>
        /// <param name="source">Объект, относительно которого выполняется привязка</param>
        /// <param name="func">Делегат, предоставляющий доступ к коллекции объектов</param>
        /// <returns>Привзяка</returns>
        protected CollectionBinding<TSource, TValue> Bind<TSource, TValue>(TSource source, Func<TSource, IList<TValue>> func)
        {
            var binding = new CollectionBinding<TSource, TValue>(source, func);
            bindingCollection.Add(binding);

            return binding;
        }

        public virtual void Start()
        {
            bindingCollection.ForEach(b => b.Update());
        }

        public virtual void Update()
        {
            bindingCollection.ForEach(b => b.Update());
        }

        protected TaskBinding<T> Bind<T>(Task<T> task)
        {
            var taskBinding = new TaskBinding<T>(task);
            StartCoroutine(taskBinding.StartCoroutine());

            return taskBinding;
        }

        protected TaskBinding<object> Bind(Task task)
        {
            var taskBinding = new TaskBinding<object>(task.ContinueWith(t => default(object), TaskContinuationOptions.ExecuteSynchronously));
            StartCoroutine(taskBinding.StartCoroutine());

            return taskBinding;
        }
    }
}
