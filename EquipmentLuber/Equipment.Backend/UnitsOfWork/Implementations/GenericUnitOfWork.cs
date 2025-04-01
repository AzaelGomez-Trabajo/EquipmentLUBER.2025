﻿using Equipment.Backend.UnitsOfWork.Interfaces;
using Equipment.Backend.Repositories.Interfaces;
using Equipment.Shared.Responses;

namespace Equipment.Backend.UnitsOfWork.Implementations
{
    public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericUnitOfWork(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual Task<ActionResponse<T>> AddAsync(T entity) => _repository.AddAsync(entity);

        public virtual async Task<ActionResponse<T>> DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public virtual Task<ActionResponse<IEnumerable<T>>> GetAsync() => _repository.GetAsync();

        public virtual Task<ActionResponse<T>> GetAsync(int id) => _repository.GetAsync(id);

        public virtual Task<ActionResponse<T>> UpdateAsync(T entity) => _repository.UpdateAsync(entity);
    }
}