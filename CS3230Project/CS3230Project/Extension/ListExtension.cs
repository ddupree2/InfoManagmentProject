using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CS3230Project.Extension
{
    /// <summary>
    ///     Extends the functionality avaliable to list where they can be used as an observable collection
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        ///     Converts to observablecollection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            return new ObservableCollection<T>(collection);
        }
    }
}
