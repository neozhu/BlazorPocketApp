// Project site: https://github.com/iluvadev/PocketBaseClient-csharp
//
// Issues: https://github.com/iluvadev/PocketBaseClient-csharp/issues
// License (MIT): https://github.com/iluvadev/PocketBaseClient-csharp/blob/main/LICENSE
//
// Copyright (c) 2022, iluvadev, and released under MIT License.
//
// pocketbase-csharp-sdk project: https://github.com/PRCV1/pocketbase-csharp-sdk 
// pocketbase project: https://github.com/pocketbase/pocketbase

using pocketbase_csharp_sdk.Models;
using PocketBaseClient.Orm.Filters;
using System.Collections;
using System.Runtime.CompilerServices;

namespace PocketBaseClient.Orm
{
    /// <summary>
    /// Class that maps a Query to be executed over a Collection in PocketBase
    /// </summary>
    /// <typeparam name="C">The type of the collection</typeparam>
    /// <typeparam name="S">The type that defines the sorting options for the collection</typeparam>
    /// <typeparam name="T">The type mapped to registries in the collection</typeparam>
    public class CollectionQuery<C, S, T> : IEnumerable<T>, IAsyncEnumerable<T>
        where C : CollectionBase<T>
        where T : ItemBase, new()
        where S : ItemBaseSorts, new()
    {
        internal FilterCommand? Filter { get; set; }
        internal SortCommand? Sort { get; set; }
        internal C Collection { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        public CollectionQuery(C collection, FilterCommand? filter)
        {
            Collection = collection;
            Filter = filter;
        }

        /// <summary>
        /// Sorts the Filter in server by the selector
        /// </summary>
        /// <param name="commandSelector">Selector for the sort</param>
        /// <returns></returns>
        public IEnumerable<T> SortBy(Func<S, SortCommand> commandSelector)
        {
            Sort = commandSelector.Invoke(new());
            return this;
        }

        private IEnumerable<T> GetItems()
        {
            foreach (var item in Collection.GetItemsFromPb(Filter?.Command, Sort?.Command))
                yield return item;
        }
        
        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
            => GetItems().GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private async IAsyncEnumerable<T> GetItemsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            await foreach (var item in Collection.GetItemsFromPbAsync(Filter?.Command, Sort?.Command).WithCancellation(cancellationToken))
            {
                yield return item;
            }
        }
        /// <inheritdoc />
        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            => GetItemsAsync(cancellationToken).GetAsyncEnumerator();


        /// <summary>
        /// Gets a page of items from PocketBase.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve.</param>
        /// <param name="perPage">The number of items per page.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a PagedCollectionModel of items.</returns>
        public async Task<PagedCollectionModel<T>> GetPagedItemsAsync(int pageNumber, int perPage)
        {
            var page = await Collection.GetPageFromPbAsync(pageNumber, perPage, Filter?.Command, Sort?.Command);
            if (page == null)
            {
                return new PagedCollectionModel<T>
                {
                    Page = pageNumber,
                    PerPage = perPage,
                    TotalItems = 0,
                    TotalPages = 0,
                    Items = Array.Empty<T>()
                };
            }

            // Cache all items in the page
            foreach (var item in page.Items ?? Enumerable.Empty<T>())
            {
                Collection.Cache.AddOrUpdate(item);
                item.Metadata_.SetLoaded();
            }

            return page;
        }

        /// <summary>
        /// Gets a page of items from PocketBase.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve.</param>
        /// <param name="perPage">The number of items per page.</param>
        /// <returns>A PagedCollectionModel of items.</returns>
        public PagedCollectionModel<T> GetPagedItems(int pageNumber, int perPage)
        {
            var page = Collection.GetPageFromPb(pageNumber, perPage, Filter?.Command, Sort?.Command);
            if (page == null)
            {
                return new PagedCollectionModel<T>
                {
                    Page = pageNumber,
                    PerPage = perPage,
                    TotalItems = 0,
                    TotalPages = 0,
                    Items = Array.Empty<T>()
                };
            }

            // Cache all items in the page
            foreach (var item in page.Items ?? Enumerable.Empty<T>())
            {
                Collection.Cache.AddOrUpdate(item);
                item.Metadata_.SetLoaded();
            }

            return page;
        }
    }
}
