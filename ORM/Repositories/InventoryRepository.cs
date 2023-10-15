// <copyright file="InventoryRepository.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain;
    using NHibernate;

    /// <summary>
    /// Репозиторий для управления сущностями <see cref="Inventory"/>.
    /// </summary>
    public class InventoryRepository : IRepository<Inventory>
    {
        private readonly ISession session;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InventoryRepository"/>.
        /// </summary>
        /// <param name="session">Сессия NHibernate.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, когда сессия равна null.</exception>
        public InventoryRepository(ISession session)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
        }

        /// <summary>
        /// Удаляет инвентарь из базы данных.
        /// </summary>
        /// <param name="entity">Инвентарь, который необходимо удалить.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если переданный инвентарь равен null.</exception>
        public void Delete(Inventory entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.session.Delete(entity);
            this.session.Flush();
        }

        /// <summary>
        /// Фильтрует инвентарь на основе предиката.
        /// </summary>
        /// <param name="predicate">Предикат для фильтрации.</param>
        /// <returns>Отфильтрованный инвентарь.</returns>
        public IQueryable<Inventory> Filter(Expression<Func<Inventory, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }

        /// <summary>
        /// Находит инвентарь на основе предиката.
        /// </summary>
        /// <param name="predicate">Предикат для поиска.</param>
        /// <returns>Найденный инвентарь.</returns>
        public Inventory Find(Expression<Func<Inventory, bool>> predicate)
        {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return this.GetAll().FirstOrDefault(predicate);
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        /// <summary>
        /// Получает инвентарь по ID.
        /// </summary>
        /// <param name="id">ID инвентаря.</param>
        /// <returns>Инвентарь с указанным ID.</returns>
        public Inventory Get(int id)
        {
            return this.session.Get<Inventory>(id);
        }

        /// <summary>
        /// Получает весь инвентарь.
        /// </summary>
        /// <returns>Весь инвентарь.</returns>
        public IQueryable<Inventory> GetAll()
        {
            return this.session.Query<Inventory>();
        }

        /// <summary>
        /// Сохраняет инвентарь.
        /// </summary>
        /// <param name="entity">Инвентарь для сохранения.</param>
        /// <returns>True, если инвентарь был успешно сохранен; в противном случае, false.</returns>
        public bool Save(Inventory entity)
        {
            if (entity == null)
            {
                return false;
            }

            this.session.Save(entity);
            this.session.Flush();
            return true;
        }
    }
}
