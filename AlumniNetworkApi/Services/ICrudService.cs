namespace AlumniNetworkApi.Services
{
    public interface ICrudService<T, ID>
    {
        /// <summary>
        /// Returns a collection of objects of type T, asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the collection of objects of type T.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Returns an object of type T, asynchronously, based on its unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the object to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the object of type T that matches the specified ID.</returns>
        Task<T> GetByIdAsync(ID id);

        /// <summary>
        /// Adds an object of type T, asynchronously.
        /// </summary>
        /// <param name="obj">The object of type T to add to the collection.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddAsync(T obj);

        /// <summary>
        /// Updates an object of type T, asynchronously.
        /// </summary>
        /// <param name="obj">The object of type T to update in the collection.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated object of type T.</returns>
        Task<T> UpdateAsync(T obj);

        /// <summary>
        /// Deletes an object of type T, asynchronously, based on its unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the object to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteByIdAsync(ID id);
    }
}
