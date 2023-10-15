// <copyright file="ReadingRoomRepository.cs" company="Николаев А.М.">
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
    /// Репозиторий для управления сущностями <see cref="ReadingRoom"/>.
    /// </summary>
    public class ReadingRoomRepository : IRepository<ReadingRoom>
    {
        private readonly ISession session;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ReadingRoomRepository"/>.
        /// </summary>
        /// <param name="session">Сессия NHibernate.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, когда сессия равна null.</exception>
        public ReadingRoomRepository(ISession session)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
        }

        /// <summary>
        /// Удаляет читальный зал из базы данных.
        /// </summary>
        /// <param name="entity">Читальный зал, который необходимо удалить.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если переданный читальный зал равен null.</exception>
        public void Delete(ReadingRoom entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.session.Delete(entity);
            this.session.Flush();
        }

        /// <summary>
        /// Фильтрует читальные залы на основе предиката.
        /// </summary>
        /// <param name="predicate">Предикат для фильтрации.</param>
        /// <returns>Отфильтрованные читальные залы.</returns>
        public IQueryable<ReadingRoom> Filter(Expression<Func<ReadingRoom, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }

        /// <summary>
        /// Находит читальный зал на основе предиката.
        /// </summary>
        /// <param name="predicate">Предикат для поиска.</param>
        /// <returns>Найденный читальный зал.</returns>
        public ReadingRoom Find(Expression<Func<ReadingRoom, bool>> predicate)
        {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return this.GetAll().FirstOrDefault(predicate);
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        /// <summary>
        /// Получает читальный зал по ID.
        /// </summary>
        /// <param name="id">ID читального зала.</param>
        /// <returns>Читальный зал с указанным ID.</returns>
        public ReadingRoom Get(int id)
        {
            return this.session.Get<ReadingRoom>(id);
        }

        /// <summary>
        /// Получает все читальные залы.
        /// </summary>
        /// <returns>Все читальные залы.</returns>
        public IQueryable<ReadingRoom> GetAll()
        {
            return this.session.Query<ReadingRoom>();
        }

        /// <summary>
        /// Сохраняет читальный зал.
        /// </summary>
        /// <param name="entity">Читальный зал для сохранения.</param>
        /// <returns>True, если читальный зал был успешно сохранен; в противном случае, false.</returns>
        public bool Save(ReadingRoom entity)
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
