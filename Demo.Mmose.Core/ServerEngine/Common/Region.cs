#region zh-CHS 2006 - 2008 DemoSoft 团队 | en 2006 - 2008 DemoSoft Team

//     NOTES
// ---------------
//
// This file is a part of the MMOSE(Massively Multiplayer Online Server Engine) for .NET.
//
//                              2006-2008 DemoSoft Team
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Lesser General Public License as published
 *   by the Free Software Foundation; either version 2.1 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Collections.Generic;
using System.Xml;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Map;
#endregion

namespace Demo.Mmose.Core.Common
{
    /// <summary>
    /// 区域(副本)
    /// </summary>
    internal class Region : IComparable
    {
        #region zh-CHS 类常量 | en Class Constants
        /// <summary>
        /// 
        /// </summary>
        public static readonly int DefaultPriority = 50;
        /// <summary>
        /// 
        /// </summary>
        public static readonly int MinZ = sbyte.MinValue;
        /// <summary>
        /// 
        /// </summary>
        public static readonly int MaxZ = sbyte.MaxValue + 1;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        public Region( string strName, BaseMap baseMap, int iPriority, params Rectangle2D[] area ) : this( strName, baseMap, iPriority, ConvertTo3D( area ) )
        {
        }

        public Region( string strName, BaseMap baseMap, int iPriority, params Rectangle3D[] area ) : this( strName, baseMap, null, area )
        {
            m_Priority = iPriority;
        }

        public Region( string strName, BaseMap baseMap, Region parent, params Rectangle2D[] area ) : this( strName, baseMap, parent, ConvertTo3D( area ) )
        {
        }

        public Region( string strName, BaseMap baseMap, Region parent, params Rectangle3D[] area )
        {
            m_Name = strName;
            m_Map = baseMap;
            m_Parent = parent;
            m_Area = area;
            m_Dynamic = true;

            if ( m_Parent == null )
            {
                m_ChildLevel = 0;
                m_Priority = Region.DefaultPriority;
            }
            else
            {
                m_ChildLevel = m_Parent.ChildLevel + 1;
                m_Priority = m_Parent.Priority;
            }
        }
        #endregion

        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 
        /// </summary>
        private string m_Name;
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return m_Name; }
        }

        /// <summary>
        /// 
        /// </summary>
        private BaseMap m_Map;
        /// <summary>
        /// 
        /// </summary>
        public BaseMap Map
        { 
            get { return m_Map; }
        }

        /// <summary>
        /// 
        /// </summary>
        private Region m_Parent;
        /// <summary>
        /// 
        /// </summary>
        public Region Parent
        { 
            get { return m_Parent; }
        }

        /// <summary>
        /// 
        /// </summary>
        private List<Region> m_Children = new List<Region>();
        /// <summary>
        /// 
        /// </summary>
        public List<Region> Children
        { 
            get { return m_Children; }
        }

        /// <summary>
        /// 
        /// </summary>
        private Rectangle3D[] m_Area;
        /// <summary>
        /// 
        /// </summary>
        public Rectangle3D[] Area
        {
            get { return m_Area; }
        }

        /// <summary>
        /// 
        /// </summary>
        private MapSpaceNode[] m_Sectors;
        /// <summary>
        /// 
        /// </summary>
        public MapSpaceNode[] Sectors
        {
            get { return m_Sectors; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool m_Dynamic;
        /// <summary>
        /// 
        /// </summary>
        public bool Dynamic
        {
            get { return m_Dynamic; }
        }

        /// <summary>
        /// 
        /// </summary>
        private long m_Priority;
        /// <summary>
        /// 
        /// </summary>
        public long Priority
        {
            get { return m_Priority; }
        }

        /// <summary>
        /// 
        /// </summary>
        private long m_ChildLevel;
        /// <summary>
        /// 
        /// </summary>
        public long ChildLevel
        {
            get { return m_ChildLevel; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool m_Registered;
        /// <summary>
        /// 
        /// </summary>
        public bool Registered
        {
            get { return m_Registered; }
        }

        /// <summary>
        /// 
        /// </summary>
        private Point3D m_GoLocation;
        /// <summary>
        /// 
        /// </summary>
        public Point3D GoLocation
        {
            get { return m_GoLocation; }
            set { m_GoLocation = value; }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public bool IsDefault
        //{
        //    get { return m_Map.DefaultRegion == this; }
        //}
        #endregion

        #region zh-CHS 静态属性 | en Static Properties
        /// <summary>
        /// 
        /// </summary>
        private static List<Region> s_Regions = new List<Region>();
        /// <summary>
        /// 
        /// </summary>
        public static List<Region> Regions
        {
            get { return s_Regions; }
        }

        /// <summary>
        /// 
        /// </summary>
        private static Type s_DefaultRegionType = typeof( Region );
        /// <summary>
        /// 
        /// </summary>
        public static Type DefaultRegionType
        {
            get { return s_DefaultRegionType; }
            set { s_DefaultRegionType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private static TimeSpan s_StaffLogoutDelay = TimeSpan.FromSeconds( 10.0 );
        /// <summary>
        /// 
        /// </summary>
        public static TimeSpan StaffLogoutDelay
        {
            get { return s_StaffLogoutDelay; }
            set { s_StaffLogoutDelay = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private static TimeSpan s_DefaultLogoutDelay = TimeSpan.FromMinutes( 5.0 );
        /// <summary>
        /// 
        /// </summary>
        public static TimeSpan DefaultLogoutDelay
        {
            get { return s_DefaultLogoutDelay; }
            set { s_DefaultLogoutDelay = value; }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        public void Register()
        {
            if ( m_Registered == true )
                return;

            OnRegister();

            m_Registered = true;

            if ( m_Parent != null )
            {
                m_Parent.m_Children.Add( this );
                m_Parent.OnChildAdded( this );
            }

            s_Regions.Add( this );

            //m_Map.RegisterRegion( this );

            List<MapSpaceNode> l_Sectors = new List<MapSpaceNode>();

            for ( int iIndex = 0; iIndex < m_Area.Length; iIndex++ )
            {
                Rectangle3D rectangle3D = m_Area[iIndex];

                //Point2D start = m_Map.Bound( new Point2D( rectangle3D.Start ) );
                //Point2D end = m_Map.Bound( new Point2D( rectangle3D.End ) );

                //Sector startSector = m_Map.GetSector( start );
                //Sector endSector = m_Map.GetSector( end );

                //for ( float x = startSector.X; x <= endSector.X; x++ )
                //{
                //    for ( long y = startSector.Y; y <= endSector.Y; y++ )
                //    {
                //        Sector sector = m_Map.GetSector( x, y );

                //        //sector.OnEnter( this, rectangle3D );

                //        if ( !l_Sectors.Contains( sector ) )
                //            l_Sectors.Add( sector );
                //    }
                //}
            }

            m_Sectors = l_Sectors.ToArray();
        }

        public void Unregister()
        {
            if ( m_Registered == false)
                return;

            OnUnregister();

            m_Registered = false;

            if ( m_Children.Count > 0 )
                Console.WriteLine( "Warning: Unregistering region '{0}' with children", this );

            if ( m_Parent != null )
            {
                m_Parent.m_Children.Remove( this );
                m_Parent.OnChildRemoved( this );
            }

            s_Regions.Remove( this );

            //m_Map.UnregisterRegion( this );

            if ( m_Sectors != null )
            {
                //for ( int i = 0; i < m_Sectors.Length; i++ )
                //    m_Sectors[i].OnLeave( this );
            }

            m_Sectors = null;
        }

        public bool Contains( Point3D point3D )
        {
            for ( int iIndex = 0; iIndex < m_Area.Length; iIndex++ )
            {
                Rectangle3D rectangle3D = m_Area[iIndex];

                if ( rectangle3D.Contains( point3D ) )
                    return true;
            }

            return false;
        }

        public bool IsChildOf( Region region )
        {
            if ( region == null )
                return false;

            Region p = m_Parent;

            while ( p != null )
            {
                if ( p == region )
                    return true;

                p = p.m_Parent;
            }

            return false;
        }

        public Region GetRegion( Type regionType )
        {
            if ( regionType == null )
                return null;

            Region r = this;

            do
            {
                if ( regionType.IsAssignableFrom( r.GetType() ) )
                    return r;

                r = r.m_Parent;
            }
            while ( r != null );

            return null;
        }

        public Region GetRegion( string regionName )
        {
            if ( regionName == null )
                return null;

            Region r = this;

            do
            {
                if ( r.m_Name == regionName )
                    return r;

                r = r.m_Parent;
            }
            while ( r != null );

            return null;
        }

        public bool IsPartOf( Region region )
        {
            if ( this == region )
                return true;

            return IsChildOf( region );
        }

        public bool IsPartOf( Type regionType )
        {
            return ( GetRegion( regionType ) != null );
        }

        public bool IsPartOf( string regionName )
        {
            return ( GetRegion( regionName ) != null );
        }

        public virtual bool AcceptsSpawnsFrom( Region region )
        {
            if ( !AllowSpawn() )
                return false;

            if ( region == this )
                return true;

            if ( m_Parent != null )
                return m_Parent.AcceptsSpawnsFrom( region );

            return false;
        }

        public List<BaseCreature> GetPlayers()
        {
            List<BaseCreature> list = new List<BaseCreature>();

            if ( m_Sectors != null )
            {
                for ( int i = 0; i < m_Sectors.Length; i++ )
                {
                    MapSpaceNode sector = m_Sectors[i];

                    //foreach ( BaseMobile player in sector.Players )
                    //{
                    //    //if ( player.Region.IsPartOf( this ) )
                    //    //    list.Add( player );
                    //}
                }
            }

            return list;
        }

        public int GetPlayerCount()
        {
            int count = 0;

            if ( m_Sectors != null )
            {
                for ( int i = 0; i < m_Sectors.Length; i++ )
                {
                    MapSpaceNode sector = m_Sectors[i];

                    //foreach ( BaseMobile player in sector.Players )
                    //{
                    //    //if ( player.Region.IsPartOf( this ) )
                    //    //    count++;
                    //}
                }
            }

            return count;
        }

        public List<BaseCreature> GetMobiles()
        {
            List<BaseCreature> list = new List<BaseCreature>();

            if ( m_Sectors != null )
            {
                for ( int i = 0; i < m_Sectors.Length; i++ )
                {
                    MapSpaceNode sector = m_Sectors[i];

                    //foreach ( BaseMobile mobile in sector.Mobiles )
                    //{
                    //    //if ( mobile.Region.IsPartOf( this ) )
                    //    //    list.Add( mobile );
                    //}
                }
            }

            return list;
        }

        public int GetMobileCount()
        {
            int count = 0;

            if ( m_Sectors != null )
            {
                for ( int i = 0; i < m_Sectors.Length; i++ )
                {
                    MapSpaceNode sector = m_Sectors[i];

                    //foreach ( BaseMobile mobile in sector.Mobiles )
                    //{
                    //    //if ( mobile.Region.IsPartOf( this ) )
                    //    //    count++;
                    //}
                }
            }

            return count;
        }

        int IComparable.CompareTo( object obj )
        {
            if ( obj == null )
                return 1;

            Region reg = obj as Region;

            if ( reg == null )
                throw new ArgumentException( "obj is not a Region", "obj" );

            // Dynamic regions go first
            if ( this.Dynamic )
            {
                if ( !reg.Dynamic )
                    return -1;
            }
            else if ( reg.Dynamic )
            {
                return 1;
            }

            long thisPriority = this.Priority;
            long regPriority = reg.Priority;

            if ( thisPriority != regPriority )
                return (int)( regPriority - thisPriority );

            return (int)( reg.ChildLevel - this.ChildLevel );
            //return 0;
        }

        public override string ToString()
        {
            if ( m_Name != null )
                return m_Name;
            else
                return GetType().Name;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void OnRegister()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void OnUnregister()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childRegion"></param>
        public virtual void OnChildAdded( Region childRegion )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childRegion"></param>
        public virtual void OnChildRemoved( Region childRegion )
        {
        }

        //public virtual bool OnMoveInto( BaseMobile m, Direction d, Point3D newLocation, Point3D oldLocation )
        //{
        //    return ( m.WalkRegion == null || AcceptsSpawnsFrom( m.WalkRegion ) );
        //}

        public virtual void OnEnter( BaseCreature baseMobile )
        {
        }

        public virtual void OnExit( BaseCreature baseMobile )
        {
        }

        public virtual void MakeGuard( BaseCreature focusMobile )
        {
            if ( m_Parent != null )
                m_Parent.MakeGuard( focusMobile );
        }

        public virtual Type GetResource( Type type )
        {
            if ( m_Parent != null )
                return m_Parent.GetResource( type );

            return type;
        }

        public virtual bool CanUseStuckMenu( BaseCreature baseMobile )
        {
            if ( m_Parent != null )
                return m_Parent.CanUseStuckMenu( baseMobile );

            return true;
        }

        public virtual void OnAggressed( BaseCreature aggressor, BaseCreature aggressed, bool criminal )
        {
            if ( m_Parent != null )
                m_Parent.OnAggressed( aggressor, aggressed, criminal );
        }

        public virtual void OnDidHarmful( BaseCreature harmer, BaseCreature harmed )
        {
            if ( m_Parent != null )
                m_Parent.OnDidHarmful( harmer, harmed );
        }

        public virtual void OnGotHarmful( BaseCreature harmer, BaseCreature harmed )
        {
            if ( m_Parent != null )
                m_Parent.OnGotHarmful( harmer, harmed );
        }

        public virtual void OnLocationChanged( BaseCreature m, Point3D oldLocation )
        {
            if ( m_Parent != null )
                m_Parent.OnLocationChanged( m, oldLocation );
        }

        //public virtual bool OnTarget( BaseMobile m, Target t, object o )
        //{
        //    if ( m_Parent != null )
        //        return m_Parent.OnTarget( m, t, o );

        //    return true;
        //}

        public virtual bool OnCombatantChange( BaseCreature m, BaseCreature Old, BaseCreature New )
        {
            if ( m_Parent != null )
                return m_Parent.OnCombatantChange( m, Old, New );

            return true;
        }

        public virtual bool AllowHousing( BaseCreature from, Point3D p )
        {
            if ( m_Parent != null )
                return m_Parent.AllowHousing( from, p );

            return true;
        }

        public virtual bool SendInaccessibleMessage( BaseItem item, BaseCreature from )
        {
            if ( m_Parent != null )
                return m_Parent.SendInaccessibleMessage( item, from );

            return false;
        }

        public virtual bool CheckAccessibility( BaseItem item, BaseCreature from )
        {
            if ( m_Parent != null )
                return m_Parent.CheckAccessibility( item, from );

            return true;
        }

        public virtual bool OnDecay( BaseItem item )
        {
            if ( m_Parent != null )
                return m_Parent.OnDecay( item );

            return true;
        }

        public virtual bool AllowHarmful( BaseCreature from, BaseCreature target )
        {
            if ( m_Parent != null )
                return m_Parent.AllowHarmful( from, target );

            //if ( Mobile.AllowHarmfulHandler != null )
            //    return Mobile.AllowHarmfulHandler( from, target );

            return true;
        }

        public virtual void OnCriminalAction( BaseCreature m, bool message )
        {
            //if ( m_Parent != null )
            //    m_Parent.OnCriminalAction( m, message );
            //else if ( message )
            //    m.SendLocalizedMessage( 1005040 ); // You've committed a criminal act!!
        }

        public virtual bool AllowBeneficial( BaseCreature from, BaseCreature target )
        {
            if ( m_Parent != null )
                return m_Parent.AllowBeneficial( from, target );

            //if ( Mobile.AllowBeneficialHandler != null )
            //    return Mobile.AllowBeneficialHandler( from, target );

            return true;
        }

        public virtual void OnBeneficialAction( BaseCreature helper, BaseCreature target )
        {
            if ( m_Parent != null )
                m_Parent.OnBeneficialAction( helper, target );
        }

        public virtual void OnGotBeneficialAction( BaseCreature helper, BaseCreature target )
        {
            if ( m_Parent != null )
                m_Parent.OnGotBeneficialAction( helper, target );
        }

        public virtual void SpellDamageScalar( BaseCreature caster, BaseCreature target, ref double damage )
        {
            if ( m_Parent != null )
                m_Parent.SpellDamageScalar( caster, target, ref damage );
        }

        //public virtual void OnSpeech( SpeechEventArgs args )
        //{
        //    if ( m_Parent != null )
        //        m_Parent.OnSpeech( args );
        //}

        public virtual bool OnSkillUse( BaseCreature m, int Skill )
        {
            if ( m_Parent != null )
                return m_Parent.OnSkillUse( m, Skill );

            return true;
        }

        public virtual bool OnBeginSpellCast( BaseCreature m, ISpell s )
        {
            if ( m_Parent != null )
                return m_Parent.OnBeginSpellCast( m, s );

            return true;
        }

        public virtual void OnSpellCast( BaseCreature m, ISpell s )
        {
            if ( m_Parent != null )
                m_Parent.OnSpellCast( m, s );
        }

        public virtual bool OnResurrect( BaseCreature m )
        {
            if ( m_Parent != null )
                return m_Parent.OnResurrect( m );

            return true;
        }

        public virtual bool OnDeath( BaseCreature m )
        {
            if ( m_Parent != null )
                return m_Parent.OnDeath( m );

            return true;
        }

        public virtual bool OnDamage( BaseCreature m, ref int Damage )
        {
            if ( m_Parent != null )
                return m_Parent.OnDamage( m, ref Damage );

            return true;
        }

        public virtual bool OnHeal( BaseCreature m, ref int Heal )
        {
            if ( m_Parent != null )
                return m_Parent.OnHeal( m, ref Heal );

            return true;
        }

        public virtual bool OnDoubleClick( BaseCreature m, object o )
        {
            if ( m_Parent != null )
                return m_Parent.OnDoubleClick( m, o );

            return true;
        }

        public virtual bool OnSingleClick( BaseCreature m, object o )
        {
            if ( m_Parent != null )
                return m_Parent.OnSingleClick( m, o );

            return true;
        }

        public virtual bool AllowSpawn()
        {
            if ( m_Parent != null )
                return m_Parent.AllowSpawn();

            return true;
        }

        public virtual void AlterLightLevel( BaseCreature m, ref int global, ref int personal )
        {
            if ( m_Parent != null )
                m_Parent.AlterLightLevel( m, ref global, ref personal );
        }

        //public virtual TimeSpan GetLogoutDelay( BaseMobile m )
        //{
        //    if ( m_Parent != null )
        //        return m_Parent.GetLogoutDelay( m );
        //    else if ( m.AccessLevel > AccessLevel.Player )
        //        return m_StaffLogoutDelay;
        //    else
        //        return m_DefaultLogoutDelay;
        //}


        //internal static bool CanMove( BaseCreature m, Direction d, Point3D newLocation, Point3D oldLocation, BaseMap map )
        //{
        //    //Region oldRegion = m.Region;
        //    //Region newRegion = Find( newLocation, map );

        //    //while ( oldRegion != newRegion )
        //    //{
        //    //    if ( !newRegion.OnMoveInto( m, d, newLocation, oldLocation ) )
        //    //        return false;

        //    //    if ( newRegion.m_Parent == null )
        //    //        return true;

        //    //    newRegion = newRegion.m_Parent;
        //    //}

        //    return true;
        //}

        internal static void OnRegionChange( BaseCreature m, Region oldRegion, Region newRegion )
        {
            //if ( newRegion != null && m.NetState != null )
            //{
            //    m.CheckLightLevels( false );

            //    if ( oldRegion == null || oldRegion.Music != newRegion.Music )
            //    {
            //        m.Send( PlayMusic.GetInstance( newRegion.Music ) );
            //    }
            //}

            Region oldR = oldRegion;
            Region newR = newRegion;

            while ( oldR != newR )
            {
                long oldRChild = ( oldR != null ? oldR.ChildLevel : -1 );
                long newRChild = ( newR != null ? newR.ChildLevel : -1 );

                if ( oldRChild >= newRChild )
                {
                    oldR.OnExit( m );
                    oldR = oldR.Parent;
                }

                if ( newRChild >= oldRChild )
                {
                    newR.OnEnter( m );
                    newR = newR.Parent;
                }
            }
        }


        internal static void Load()
        {
            //if ( !System.IO.File.Exists( "Data/Regions.xml" ) )
            //{
            //    Console.WriteLine( "Error: Data/Regions.xml does not exist" );
            //    return;
            //}

            //Console.Write( "Regions: Loading..." );

            //XmlDocument doc = new XmlDocument();
            //doc.Load( System.IO.Path.Combine( BaseServer.BaseDirectory, "Data/Regions.xml" ) );

            //XmlElement root = doc["ServerRegions"];

            //if ( root == null )
            //{
            //    Console.WriteLine( "Could not find root element 'ServerRegions' in Regions.xml" );
            //}
            //else
            //{
            //    //foreach ( XmlElement facet in root.SelectNodes( "Facet" ) )
            //    //{
            //    //    Map map = null;
            //    //    if ( ReadMap( facet, "name", ref map ) )
            //    //    {
            //    //        if ( map == Map.Internal )
            //    //            Console.WriteLine( "Invalid internal map in a facet element" );
            //    //        else
            //    //            LoadRegions( facet, map, null );
            //    //    }
            //    //}
            //}

            //Console.WriteLine( "done" );
        }

        private static void LoadRegions( XmlElement xml, BaseMap map, Region parent )
        {
            foreach ( XmlElement xmlReg in xml.SelectNodes( "region" ) )
            {
                Type type = DefaultRegionType;

                ReadType( xmlReg, "type", ref type, false );

                if ( !typeof( Region ).IsAssignableFrom( type ) )
                {
                    Console.WriteLine( "Invalid region type '{0}' in regions.xml", type.FullName );
                    continue;
                }

                Region region = null;
                try
                {
                    region = (Region)Activator.CreateInstance( type, new object[] { xmlReg, map, parent } );
                }
                catch ( Exception ex )
                {
                    Console.WriteLine( "Error during the creation of region type '{0}': {1}", type.FullName, ex );
                    continue;
                }

                region.Register();

                LoadRegions( xmlReg, map, region );
            }
        }

        public Region( XmlElement xml, BaseMap map, Region parent )
        {
            m_Map = map;
            m_Parent = parent;
            m_Dynamic = false;

            if ( m_Parent == null )
            {
                m_ChildLevel = 0;
                m_Priority = DefaultPriority;
            }
            else
            {
                m_ChildLevel = m_Parent.ChildLevel + 1;
                m_Priority = m_Parent.Priority;
            }

            ReadString( xml, "name", ref m_Name, false );

            if ( parent == null )
                ReadInt32( xml, "priority", ref m_Priority, false );


            long minZ = MinZ;
            long maxZ = MaxZ;

            XmlElement zrange = xml["zrange"];
            ReadInt32( zrange, "min", ref minZ, false );
            ReadInt32( zrange, "max", ref maxZ, false );


            List<Rectangle3D> area = new List<Rectangle3D>();
            foreach ( XmlElement xmlRect in xml.SelectNodes( "rect" ) )
            {
                Rectangle3D rect = new Rectangle3D();
                if ( ReadRectangle3D( xmlRect, minZ, maxZ, ref rect ) )
                    area.Add( rect );
            }

            m_Area = area.ToArray();

            if ( m_Area.Length == 0 )
                Console.WriteLine( "Empty area for region '{0}'", this );


            if ( !ReadPoint3D( xml["go"], map, ref m_GoLocation, false ) && m_Area.Length > 0 )
            {
                Point3D start = m_Area[0].Start;
                Point3D end = m_Area[0].End;

                float x = start.X + ( end.X - start.X ) / 2;
                float y = start.Y + ( end.Y - start.Y ) / 2;

                //m_GoLocation = new Point3D( x, y, m_Map.GetAverageZ( x, y ) );
            }
        }

        protected static string GetAttribute( XmlElement xml, string attribute, bool mandatory )
        {
            if ( xml == null )
            {
                if ( mandatory )
                    Console.WriteLine( "Missing element for attribute '{0}'", attribute );

                return null;
            }
            else if ( xml.HasAttribute( attribute ) )
            {
                return xml.GetAttribute( attribute );
            }
            else
            {
                if ( mandatory )
                    Console.WriteLine( "Missing attribute '{0}' in element '{1}'", attribute, xml.Name );

                return null;
            }
        }

        public static bool ReadString( XmlElement xml, string attribute, ref string value )
        {
            return ReadString( xml, attribute, ref value, true );
        }

        public static bool ReadString( XmlElement xml, string attribute, ref string value, bool mandatory )
        {
            string s = GetAttribute( xml, attribute, mandatory );

            if ( s == null )
                return false;

            value = s;
            return true;
        }

        public static bool ReadInt32( XmlElement xml, string attribute, ref long value )
        {
            return ReadInt32( xml, attribute, ref value, true );
        }

        public static bool ReadInt32( XmlElement xml, string attribute, ref long value, bool mandatory )
        {
            string s = GetAttribute( xml, attribute, mandatory );

            if ( s == null )
                return false;

            try
            {
                value = XmlConvert.ToInt32( s );
            }
            catch
            {
                Console.WriteLine( "Could not parse integer attribute '{0}' in element '{1}'", attribute, xml.Name );
                return false;
            }

            return true;
        }

        public static bool ReadBoolean( XmlElement xml, string attribute, ref bool value )
        {
            return ReadBoolean( xml, attribute, ref value, true );
        }

        public static bool ReadBoolean( XmlElement xml, string attribute, ref bool value, bool mandatory )
        {
            string s = GetAttribute( xml, attribute, mandatory );

            if ( s == null )
                return false;

            try
            {
                value = XmlConvert.ToBoolean( s );
            }
            catch
            {
                Console.WriteLine( "Could not parse boolean attribute '{0}' in element '{1}'", attribute, xml.Name );
                return false;
            }

            return true;
        }

        public static bool ReadDateTime( XmlElement xml, string attribute, ref DateTime value )
        {
            return ReadDateTime( xml, attribute, ref value, true );
        }

        public static bool ReadDateTime( XmlElement xml, string attribute, ref DateTime value, bool mandatory )
        {
            string s = GetAttribute( xml, attribute, mandatory );

            if ( s == null )
                return false;

            try
            {
                value = XmlConvert.ToDateTime( s, XmlDateTimeSerializationMode.Local );
            }
            catch
            {
                Console.WriteLine( "Could not parse DateTime attribute '{0}' in element '{1}'", attribute, xml.Name );
                return false;
            }

            return true;
        }

        public static bool ReadTimeSpan( XmlElement xml, string attribute, ref TimeSpan value )
        {
            return ReadTimeSpan( xml, attribute, ref value, true );
        }

        public static bool ReadTimeSpan( XmlElement xml, string attribute, ref TimeSpan value, bool mandatory )
        {
            string s = GetAttribute( xml, attribute, mandatory );

            if ( s == null )
                return false;

            try
            {
                value = XmlConvert.ToTimeSpan( s );
            }
            catch
            {
                Console.WriteLine( "Could not parse TimeSpan attribute '{0}' in element '{1}'", attribute, xml.Name );
                return false;
            }

            return true;
        }

        public static bool ReadEnum( XmlElement xml, string attribute, Type type, ref object value )
        {
            return ReadEnum( xml, attribute, type, ref value, true );
        }

        public static bool ReadEnum( XmlElement xml, string attribute, Type type, ref object value, bool mandatory )
        {
            string s = GetAttribute( xml, attribute, mandatory );

            if ( s == null )
                return false;

            try
            {
                value = Enum.Parse( type, s, true );
            }
            catch
            {
                Console.WriteLine( "Could not parse {0} enum attribute '{1}' in element '{2}'", type, attribute, xml.Name );
                return false;
            }

            return true;
        }

        public static bool ReadMap( XmlElement xml, string attribute, ref BaseMap value )
        {
            return ReadMap( xml, attribute, ref value, true );
        }

        public static bool ReadMap( XmlElement xml, string attribute, ref BaseMap value, bool mandatory )
        {
            string s = GetAttribute( xml, attribute, mandatory );

            if ( s == null )
                return false;

            //try
            //{
            //    value = Map.Parse( s );
            //}
            //catch
            //{
            //    Console.WriteLine( "Could not parse Map attribute '{0}' in element '{1}'", attribute, xml.Name );
            //    return false;
            //}

            return true;
        }

        public static bool ReadType( XmlElement xml, string attribute, ref Type value )
        {
            return ReadType( xml, attribute, ref value, true );
        }

        public static bool ReadType( XmlElement xml, string attribute, ref Type value, bool mandatory )
        {
            string s = GetAttribute( xml, attribute, mandatory );

            if ( s == null )
                return false;

            //Type type;
            try
            {
                //type = ScriptCompiler.FindTypeByName( s, false );
            }
            catch
            {
                Console.WriteLine( "Could not parse Type attribute '{0}' in element '{1}'", attribute, xml.Name );
                return false;
            }

            //if ( type == null )
            //{
            //    Console.WriteLine( "Could not find Type '{0}'", s );
            //    return false;
            //}

            //value = type;
            return true;
        }

        public static bool ReadPoint3D( XmlElement xml, BaseMap map, ref Point3D value )
        {
            return ReadPoint3D( xml, map, ref value, true );
        }

        public static bool ReadPoint3D( XmlElement xml, BaseMap map, ref Point3D value, bool mandatory )
        {
            long x = 0, y = 0, z = 0;

            bool xyOk = ReadInt32( xml, "x", ref x, mandatory ) & ReadInt32( xml, "y", ref y, mandatory );
            bool zOk = ReadInt32( xml, "z", ref z, mandatory && map == null );

            if ( xyOk && ( zOk || map != null ) )
            {
                //if ( !zOk )
                //    z = map.GetAverageZ( x, y );

                value = new Point3D( x, y, z );
                return true;
            }

            return false;
        }

        public static bool ReadRectangle3D( XmlElement xml, long defaultMinZ, long defaultMaxZ, ref Rectangle3D value )
        {
            return ReadRectangle3D( xml, defaultMinZ, defaultMaxZ, ref value, true );
        }

        public static bool ReadRectangle3D( XmlElement xml, long defaultMinZ, long defaultMaxZ, ref Rectangle3D value, bool mandatory )
        {
            long x1 = 0, y1 = 0, x2 = 0, y2 = 0;

            if ( xml.HasAttribute( "x" ) )
            {
                if ( ReadInt32( xml, "x", ref x1, mandatory )
                    & ReadInt32( xml, "y", ref y1, mandatory )
                    & ReadInt32( xml, "width", ref x2, mandatory )
                    & ReadInt32( xml, "height", ref y2, mandatory ) )
                {
                    x2 += x1;
                    y2 += y1;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if ( !ReadInt32( xml, "x1", ref x1, mandatory )
                    | !ReadInt32( xml, "y1", ref y1, mandatory )
                    | !ReadInt32( xml, "x2", ref x2, mandatory )
                    | !ReadInt32( xml, "y2", ref y2, mandatory ) )
                {
                    return false;
                }
            }

            long z1 = defaultMinZ;
            long z2 = defaultMaxZ;

            ReadInt32( xml, "zmin", ref z1, false );
            ReadInt32( xml, "zmax", ref z2, false );

            value = new Rectangle3D( new Point3D( x1, y1, z1 ), new Point3D( x2, y2, z2 ) );

            return true;
        }
        #endregion

        #region zh-CHS 静态方法 | en Static Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="baseMap"></param>
        /// <returns></returns>
        //public static Region Find( Point3D point3D, BaseMap baseMap )
        //{
        //    //if ( baseMap == null )
        //    //    return BaseMap.Internal.DefaultRegion;

        //    Sector l_Sector = baseMap.GetSector( point3D );
        //    List<RegionRect> l_List = l_Sector.RegionRects;

        //    for ( int iIndex = 0; iIndex < l_List.Count; ++iIndex )
        //    {
        //        RegionRect regRect = l_List[iIndex];

        //        if ( regRect.Contains( point3D ) )
        //            return regRect.Region;
        //    }

        //    return baseMap.DefaultRegion;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rectangle2D"></param>
        /// <returns></returns>
        public static Rectangle3D ConvertTo3D( Rectangle2D rectangle2D )
        {
            return new Rectangle3D( new Point3D( rectangle2D.Start, Region.MinZ ), new Point3D( rectangle2D.End, Region.MaxZ ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rectangle2D"></param>
        /// <returns></returns>
        public static Rectangle3D[] ConvertTo3D( Rectangle2D[] rectangle2D )
        {
            Rectangle3D[] l_Rectangle3D = new Rectangle3D[rectangle2D.Length];

            for ( int iIndex = 0; iIndex < l_Rectangle3D.Length; iIndex++ )
                l_Rectangle3D[iIndex] = ConvertTo3D( rectangle2D[iIndex] );

            return l_Rectangle3D;
        }
        #endregion
    }
}
#endregion

