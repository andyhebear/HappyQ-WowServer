#if !ONLY_MISC_BUILD

using System;

namespace Demo.Mmose.LuaInterface
{
    /// <summary>
    /// Add a specific type for Lua exceptions (kevinh)
    /// </summary>
    public class LuaException : ApplicationException
    {
        public LuaException( string reason )
            : base( reason )
        {
        }
    }
}

#endif