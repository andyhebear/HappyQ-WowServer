using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Wow.WorldServer.Entity.Common;
using Demo.Wow.WorldServer.Util;

namespace Demo.Wow.WorldServer.Entity.Fields
{
    public partial class DynamicObjectField : WorldObjectField
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly UpdateFieldId s_DynamicObjectFieldCount = Utility.GetMaxEnumValue<DynamicObjectFields>() + 1;

        /// <summary>
        /// 
        /// </summary>
        public override UpdateFieldId ObjectUpdateFieldCount
        {
            get { return s_DynamicObjectFieldCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override ObjectTypeId ObjectTypeId
        {
            get { return ObjectTypeId.DynamicObject; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override UpdateFlag UpdateFlags
        {
            get { return UpdateFlag.HasPosition | UpdateFlag.HasHighGuid | UpdateFlag.HasLowGuid; }
        }

        /// <summary>
        /// 
        /// </summary>
        private static readonly UpdateFieldCollection s_UpdateFieldInfos = UpdateFieldManager.GetCollection( ObjectTypeId.DynamicObject );
        /// <summary>
        /// 
        /// </summary>
        public override UpdateFieldCollection UpdateFieldInfos
        {
            get { return s_UpdateFieldInfos; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override ObjectTypeCustom CustomType
        {
            get { return ObjectTypeCustom.Object | ObjectTypeCustom.DynamicObject; }
        }
    }
}
