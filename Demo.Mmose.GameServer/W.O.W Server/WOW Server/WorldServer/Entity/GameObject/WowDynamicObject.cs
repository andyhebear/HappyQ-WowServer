using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Mmose.Core.Entity.GameObject;
using Demo.Wow.WorldServer.Entity.Fields;
using Demo.Wow.WorldServer.Entity.Common;

namespace Demo.Wow.WorldServer.Object
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WowDynamicObject : BaseGameObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        protected override void DefaultGameObjectInit()
        {
            base.DefaultGameObjectInit();

            // IWowUpdate
            this.RegisterComponent<IWowUpdate>( WowUpdate.WOW_UPDATE_COMPONENT_ID, this );

            // CorpseField
            this.DynamicObjectField.EventRequestUpdate += new RequestUpdateEventHandler( this.OnFieldRequestUpdate );
        }
        #endregion

    }
}
