﻿namespace WebAPISample.Infrastructure
{
    //Tạo giao diện mẫu chung
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetByIDAsync(int id);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangeAsync();
    }
}
