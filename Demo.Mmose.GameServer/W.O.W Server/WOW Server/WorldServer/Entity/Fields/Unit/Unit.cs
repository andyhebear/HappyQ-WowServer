using Demo.Wow.WorldServer.Entity.Common;
using Demo.Wow.WorldServer.Util;

namespace Demo.Wow.WorldServer.Entity.Fields
{
    public partial class UnitField : WorldObjectField
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly UpdateFieldId s_UnitFieldCount = Utility.GetMaxEnumValue<UnitFields>() + 1;

        /// <summary>
        /// 
        /// </summary>
        public override UpdateFieldId ObjectUpdateFieldCount
        {
            get { return s_UnitFieldCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override ObjectTypeId ObjectTypeId
        {
            get { return ObjectTypeId.Unit; }
        }

        /// <summary>
        /// 
        /// </summary>
        private static readonly UpdateFieldCollection s_UpdateFieldInfos = UpdateFieldManager.GetCollection( ObjectTypeId.Unit );
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
        public override UpdateFlag UpdateFlags
        {
            get { return UpdateFlag.HasPosition | UpdateFlag.Living | UpdateFlag.HasHighGuid; }
        }
    }
}
