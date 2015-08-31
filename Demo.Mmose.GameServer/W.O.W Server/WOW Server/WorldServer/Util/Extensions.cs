using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Wow.WorldServer.Util
{
    /// <summary>
    /// 
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Adds all elements from the collection to the hash set.
        /// </summary>
        /// <typeparam name="T">the type of the elements</typeparam>
        /// <param name="set">the hash set to add to\being extended</param>
        /// <param name="elements">the elements to add</param>
        public static void AddRange<T>( this HashSet<T> hashSet, IEnumerable<T> enumerable )
        {
            foreach ( var item in enumerable )
                hashSet.Add( item );
        }
    }
}
