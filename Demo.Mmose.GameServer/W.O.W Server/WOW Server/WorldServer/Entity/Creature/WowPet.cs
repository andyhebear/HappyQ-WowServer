using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Wow.WorldServer.Entity.Fields;
using Demo.Wow.WorldServer.Entity.Common;

namespace Demo.Wow.WorldServer.Creature
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WowPet : BaseCreature
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        protected override void DefaultCreatureInit()
        {
            base.DefaultCreatureInit();

            // IWowUpdate
            this.RegisterComponent<IWowUpdate>( WowUpdate.WOW_UPDATE_COMPONENT_ID, this );

            // NPCField
            this.NPCField.EventRequestUpdate += new RequestUpdateEventHandler( this.OnFieldRequestUpdate );
        }
        #endregion

    }
}
