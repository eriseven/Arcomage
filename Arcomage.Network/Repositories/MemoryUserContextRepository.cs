﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Repositories
{
    public class MemoryUserContextRepository : IUserContextRepository
    {
        private readonly ConcurrentDictionary<Guid, UserContext> userStorage;

        public MemoryUserContextRepository(ConcurrentDictionary<Guid, UserContext> userStorage)
        {
            this.userStorage = userStorage;

#warning Hardcode users
            userStorage.AddOrUpdate(Guid.Parse("EB3AB862-E0D0-413B-B732-6BDD86B3A1A2"),
                new UserContext { Id = Guid.Parse("EB3AB862-E0D0-413B-B732-6BDD86B3A1A2") }, (_, u) => u);

            userStorage.AddOrUpdate(Guid.Parse("EB3AB862-E0D0-413B-B732-6BDD86B3A1A3"),
                new UserContext { Id = Guid.Parse("EB3AB862-E0D0-413B-B732-6BDD86B3A1A3") }, (_, u) => u);
        }

        public Task<bool> Add(UserContext userContext)
        {
            userStorage.AddOrUpdate(userContext.Id, userContext, (_, g) => g);

            return Task.FromResult(true);
        }

        public Task<bool> Save(UserContext userContext)
        {
            userStorage.AddOrUpdate(userContext.Id, userContext, (_, g) => userContext);

            return Task.FromResult(true);
        }

        public Task<bool> Update(UserContext userContext, params Action<UserContext>[] update)
        {
            userStorage.AddOrUpdate(userContext.Id,
                id =>
                {
                    Array.ForEach(update, u => u.Invoke(userContext));

                    return userContext;
                },
                (id, uc) =>
                {
                    Array.ForEach(update, u => u.Invoke(userContext));
                    Array.ForEach(update, u => u.Invoke(uc));

                    return uc;
                });

            return Task.FromResult(true);
        }

        public Task<UserContext> GetById(Guid id)
        {
            userStorage.TryGetValue(id, out var userContext);

            return Task.FromResult(userContext);
        }
    }
}
