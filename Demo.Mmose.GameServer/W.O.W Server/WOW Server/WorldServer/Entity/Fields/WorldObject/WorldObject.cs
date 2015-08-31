using Demo.Wow.WorldServer.Entity.Common;

namespace Demo.Wow.WorldServer.Entity.Fields
{
    public abstract partial class WorldObjectField : BaseField
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="updatingSelf"></param>
        /// <returns></returns>
        public override UpdateTypes GetCreationUpdateType( bool updatingSelf )
        {
            return UpdateTypes.Create;
        }
    }
}
