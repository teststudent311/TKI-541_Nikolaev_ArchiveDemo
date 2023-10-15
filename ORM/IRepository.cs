// <copyright file="IRepository.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Интерфейс для репозиториев.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Получает сущность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Сущность.</returns>
        TEntity Get(int id);

        /// <summary>
        /// Находит сущность по выражению.
        /// </summary>
        /// <param name="predicate">Выражение для поиска.</param>
        /// <returns>Сущность.</returns>
        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Получает все сущности.
        /// </summary>
        /// <returns>Все сущности.</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Фильтрует сущности по выражению.
        /// </summary>
        /// <param name="predicate">Выражение для фильтрации.</param>
        /// <returns>Отфильтрованные сущности.</returns>
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Сохраняет сущность.
        /// </summary>
        /// <param name="entity">Сущность для сохранения.</param>
        /// <returns>Результат сохранения.</returns>
        bool Save(TEntity entity);
    }
}
