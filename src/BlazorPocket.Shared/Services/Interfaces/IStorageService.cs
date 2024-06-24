namespace BlazorPocket.Shared.Services.Interfaces;


public interface IStorageService
{
    /// <summary>
    /// Retrieves an item from the storage asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the item to retrieve.</typeparam>
    /// <param name="key">The key of the item to retrieve.</param>
    /// <returns>A <see cref="ValueTask{T}"/> representing the asynchronous operation. The task result contains the retrieved item, or null if the item does not exist.</returns>
    ValueTask<T?> GetItemAsync<T>(string key);

    /// <summary>
    /// Removes an item from the storage asynchronously.
    /// </summary>
    /// <param name="key">The key of the item to remove.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    ValueTask RemoveItemAsync(string key);

    /// <summary>
    /// Sets an item in the storage asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the item to set.</typeparam>
    /// <param name="key">The key of the item to set.</param>
    /// <param name="value">The value of the item to set.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    ValueTask SetItemAsync<T>(string key, T value);
}

