using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Map;
using Demo.Mmose.Core.Common;
using Demo.Wow.WorldServer.World;

namespace Demo.Wow.WorldServer.WorldServer.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class WowMap : BaseMap
    {
        private WowWorld m_WowWorld = null;

        public WowMap()
        {
            m_WowWorld = base.World as WowWorld;
        }

        public override void OnProcessSlice( DateTime updateDelta )
        {
            base.OnProcessSlice( updateDelta );
        }
    }
}
