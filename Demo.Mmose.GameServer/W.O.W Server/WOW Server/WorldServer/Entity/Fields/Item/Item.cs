using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Wow.WorldServer.Entity.Common;
using Demo.Wow.WorldServer.Util;

namespace Demo.Wow.WorldServer.Entity.Fields
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ItemField : BaseField
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly UpdateFieldId s_ItemFieldCount = Utility.GetMaxEnumValue<ItemFields>() + 1;
        /// <summary>
        /// 
        /// </summary>
        public override UpdateFieldId ObjectUpdateFieldCount
        {
            get { return s_ItemFieldCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override ObjectTypeId ObjectTypeId
        {
            get { return ObjectTypeId.Item; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override UpdateFlag UpdateFlags
        {
            get { return UpdateFlag.HasLowGuid | UpdateFlag.HasHighGuid; }
        }

        /// <summary>
        /// 
        /// </summary>
        private static readonly UpdateFieldCollection s_UpdateFieldInfos = UpdateFieldManager.GetCollection( ObjectTypeId.Item );
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
        /// <param name="updatingSelf"></param>
        /// <returns></returns>
        public override UpdateTypes GetCreationUpdateType( bool updatingSelf )
        {
            return UpdateTypes.Create;
        }

        /// <summary>
        /// 
        /// </summary>
        public override ObjectTypeCustom CustomType
        {
            get { return ObjectTypeCustom.Object | ObjectTypeCustom.Item; }
        }

    }
}
