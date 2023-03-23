﻿using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface ITokenHandlerRepository
    {
        Task<string> CreateTokenAsync(User user);
    }
}
