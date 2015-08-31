using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class RealmPacketHandlers : BasePacketHandlers
    {
        // Create an IEnumerable that enumerates an array. Make sure that only enumerable stuff is used and no downcasts to ICollection are taken advantage of.
        protected static IEnumerable<T> EnumerableFromArray<T>( T[] arrayT )
        {
            foreach ( T itemT in arrayT )
                yield return itemT;
        }
    }
}
