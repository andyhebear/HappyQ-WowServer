using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Wow.WorldServer.Util
{
    /// <summary>
    /// 
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Gets the biggest value of a numeric enum
        /// </summary>
        public static EnumT GetMaxEnumValue<EnumT>()
        {
            EnumT[] enumValues = (EnumT[])Enum.GetValues( typeof( EnumT ) );

            return enumValues.Max();
        }

        /// <summary>
        /// Gets the biggest value of a numeric enum
        /// </summary>
        public static EnumT GetMinEnumValue<EnumT>()
        {
            EnumT[] enumValues = (EnumT[])Enum.GetValues( typeof( EnumT ) );

            return enumValues.Min();
        }
    }
}
