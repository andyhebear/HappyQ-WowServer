using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Wow.WorldServer.Entity.Common;
using Demo.Wow.WorldServer.Util;

namespace Demo.Wow.WorldServer.Entity.Fields
{
    public partial class CorpseField : WorldObjectField
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly UpdateFieldId s_CorpseFieldCount = Utility.GetMaxEnumValue<CorpseFields>() + 1;

        /// <summary>
        /// 
        /// </summary>
        public override UpdateFieldId ObjectUpdateFieldCount
        {
            get { return s_CorpseFieldCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override ObjectTypeId ObjectTypeId
        {
            get { return ObjectTypeId.Corpse; }
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
        private static readonly UpdateFieldCollection s_UpdateFieldInfos = UpdateFieldManager.GetCollection( ObjectTypeId.Corpse );
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
            get { return ObjectTypeCustom.Object | ObjectTypeCustom.Corpse; }
        }
    }
}
