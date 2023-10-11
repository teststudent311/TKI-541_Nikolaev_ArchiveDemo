// <copyright file="SetExtensions.cs" company="Васильева М.А.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace Staff.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// Коллекция методов расширения для типа <see cref="ISet{T}"/>.
    /// </summary>
    public static class SetExtensions
    {
        /// <summary>
        /// Добавляет значение <paramref name="value"/> в множество <paramref name="set"/>.
        /// </summary>
        /// <typeparam name="T"> Целевой тип элементов множества. </typeparam>
        /// <param name="set"> Целевое множество. </param>
        /// <param name="value"> Добавляемое значение. </param>
        /// <returns>
        /// <see langword="false"/> в случае если <paramref name="value"/> – <see langword="null"/>
        /// или результат добавления элемента в коллекцию при помощи метода <see cref="ISet{T}.Add(T)"/>.
        /// </returns>
        public static bool? TryAdd<T>(this ISet<T> set, T value)
            where T : class
        {
            return value is null
                ? null
                : set.Add(value);
        }
    }
}
