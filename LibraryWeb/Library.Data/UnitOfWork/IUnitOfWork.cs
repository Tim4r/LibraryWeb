﻿using Library.BL.Services;
using Library.Data.Repository.Interfaces;

namespace Library.Core.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IBookRepository Books {  get; }
    IAuthorRepository Authors { get; }

    Task<int> CompleteAsync();
}