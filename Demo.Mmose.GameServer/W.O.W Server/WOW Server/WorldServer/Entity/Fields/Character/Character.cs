using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Wow.WorldServer.Entity.Common;
using Demo.Wow.WorldServer.Util;

namespace Demo.Wow.WorldServer.Entity.Fields
{
    public partial class CharacterField : UnitField
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly UpdateFieldId s_PlayerFieldCount = Utility.GetMaxEnumValue<PlayerFields>() + 1;

        /// <summary>
        /// 
        /// </summary>
        public override UpdateFieldId ObjectUpdateFieldCount
        {
            get { return s_PlayerFieldCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        private static readonly UpdateFieldCollection s_UpdateFieldInfos = UpdateFieldManager.GetCollection( ObjectTypeId.Player );
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
            return updatingSelf ? UpdateTypes.CreateSelf : UpdateTypes.Create;
        }

        /// <summary>
        /// 
        /// </summary>
        public override ObjectTypeCustom CustomType
        {
            get { return ObjectTypeCustom.Object | ObjectTypeCustom.Unit | ObjectTypeCustom.Player; }
        }
    }
}
