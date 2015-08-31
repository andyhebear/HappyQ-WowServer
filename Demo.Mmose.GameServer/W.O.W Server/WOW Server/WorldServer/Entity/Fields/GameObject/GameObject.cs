using Demo.Wow.WorldServer.Entity.Common;
using Demo.Wow.WorldServer.Util;

namespace Demo.Wow.WorldServer.Entity.Fields
{
    public partial class GameObjectField : WorldObjectField
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly UpdateFieldId s_GameObjectFieldCount = Utility.GetMaxEnumValue<GameObjectFields>() + 1;

        /// <summary>
        /// 
        /// </summary>
        public override UpdateFieldId ObjectUpdateFieldCount
        {
            get { return s_GameObjectFieldCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override ObjectTypeId ObjectTypeId
        {
            get { return ObjectTypeId.GameObject; }
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
        private static readonly UpdateFieldCollection s_UpdateFieldInfos = UpdateFieldManager.GetCollection( ObjectTypeId.GameObject );
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
            //if ( m_entry is GODuelFlagEntry )
            //    return UpdateTypes.CreateSelf;

            return UpdateTypes.Create;
        }

        /// <summary>
        /// 
        /// </summary>
        public override ObjectTypeCustom CustomType
        {
            get { return ObjectTypeCustom.Object | ObjectTypeCustom.GameObject; }
        }
    }
}
