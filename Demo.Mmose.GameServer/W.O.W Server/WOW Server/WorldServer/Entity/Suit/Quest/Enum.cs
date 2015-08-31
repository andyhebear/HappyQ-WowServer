using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace Demo.Wow.WorldServer.Quest
{

    public enum Emote
    {
        EMOTE_ONESHOT_NONE = 0,
        EMOTE_ONESHOT_TALK = 1,
        EMOTE_ONESHOT_BOW = 2,
        EMOTE_ONESHOT_WAVE = 3,
        EMOTE_ONESHOT_CHEER = 4,
        EMOTE_ONESHOT_EXCLAMATION = 5,
        EMOTE_ONESHOT_QUESTION = 6,
        EMOTE_ONESHOT_EAT = 7,
        EMOTE_STATE_DANCE = 10,
        EMOTE_ONESHOT_LAUGH = 11,
        EMOTE_STATE_SLEEP = 12,
        EMOTE_STATE_SIT = 13,
        EMOTE_ONESHOT_RUDE = 14,
        EMOTE_ONESHOT_ROAR = 15,
        EMOTE_ONESHOT_KNEEL = 16,
        EMOTE_ONESHOT_KISS = 17,
        EMOTE_ONESHOT_CRY = 18,
        EMOTE_ONESHOT_CHICKEN = 19,
        EMOTE_ONESHOT_BEG = 20,
        EMOTE_ONESHOT_APPLAUD = 21,
        EMOTE_ONESHOT_SHOUT = 22,
        EMOTE_ONESHOT_FLEX = 23,
        EMOTE_ONESHOT_SHY = 24,
        EMOTE_ONESHOT_POINT = 25,
        EMOTE_STATE_STAND = 26,
        EMOTE_STATE_READYUNARMED = 27,
        EMOTE_STATE_WORK = 28,
        EMOTE_STATE_POINT = 29,
        EMOTE_STATE_NONE = 30,
        EMOTE_ONESHOT_WOUND = 33,
        EMOTE_ONESHOT_WOUNDCRITICAL = 34,
        EMOTE_ONESHOT_ATTACKUNARMED = 35,
        EMOTE_ONESHOT_ATTACK1H = 36,
        EMOTE_ONESHOT_ATTACK2HTIGHT = 37,
        EMOTE_ONESHOT_ATTACK2HLOOSE = 38,
        EMOTE_ONESHOT_PARRYUNARMED = 39,
        EMOTE_ONESHOT_PARRYSHIELD = 43,
        EMOTE_ONESHOT_READYUNARMED = 44,
        EMOTE_ONESHOT_READY1H = 45,
        EMOTE_ONESHOT_READYBOW = 48,
        EMOTE_ONESHOT_SPELLPRECAST = 50,
        EMOTE_ONESHOT_SPELLCAST = 51,
        EMOTE_ONESHOT_BATTLEROAR = 53,
        EMOTE_ONESHOT_SPECIALATTACK1H = 54,
        EMOTE_ONESHOT_KICK = 60,
        EMOTE_ONESHOT_ATTACKTHROWN = 61,
        EMOTE_STATE_STUN = 64,
        EMOTE_STATE_DEAD = 65,
        EMOTE_ONESHOT_SALUTE = 66,
        EMOTE_STATE_KNEEL = 68,
        EMOTE_STATE_USESTANDING = 69,
        EMOTE_ONESHOT_WAVE_NOSHEATHE = 70,
        EMOTE_ONESHOT_CHEER_NOSHEATHE = 71,
        EMOTE_ONESHOT_EAT_NOSHEATHE = 92,
        EMOTE_STATE_STUN_NOSHEATHE = 93,
        EMOTE_ONESHOT_DANCE = 94,
        EMOTE_ONESHOT_SALUTE_NOSHEATH = 113,
        EMOTE_STATE_USESTANDING_NOSHEATHE = 133,
        EMOTE_ONESHOT_LAUGH_NOSHEATHE = 153,
        EMOTE_STATE_WORK_NOSHEATHE = 173,
        EMOTE_STATE_SPELLPRECAST = 193,
        EMOTE_ONESHOT_READYRIFLE = 213,
        EMOTE_STATE_READYRIFLE = 214,
        EMOTE_STATE_WORK_NOSHEATHE_MINING = 233,
        EMOTE_STATE_WORK_NOSHEATHE_CHOPWOOD = 234,
        EMOTE_zzOLDONESHOT_LIFTOFF = 253,
        EMOTE_ONESHOT_LIFTOFF = 254,
        EMOTE_ONESHOT_YES = 273,
        EMOTE_ONESHOT_NO = 274,
        EMOTE_ONESHOT_TRAIN = 275,
        EMOTE_ONESHOT_LAND = 293,
        EMOTE_STATE_AT_EASE = 313,
        EMOTE_STATE_READY1H = 333,
        EMOTE_STATE_SPELLKNEELSTART = 353,
        EMOTE_STATE_SUBMERGED = 373,
        EMOTE_ONESHOT_SUBMERGE = 374,
        EMOTE_STATE_READY2H = 375,
        EMOTE_STATE_READYBOW = 376,
        EMOTE_ONESHOT_MOUNTSPECIAL = 377,
        EMOTE_STATE_TALK = 378,
        EMOTE_STATE_FISHING = 379,
        EMOTE_ONESHOT_FISHING = 380,
        EMOTE_ONESHOT_LOOT = 381,
        EMOTE_STATE_WHIRLWIND = 382,
        EMOTE_STATE_DROWNED = 383,
        EMOTE_STATE_HOLD_BOW = 384,
        EMOTE_STATE_HOLD_RIFLE = 385,
        EMOTE_STATE_HOLD_THROWN = 386,
        EMOTE_ONESHOT_DROWN = 387,
        EMOTE_ONESHOT_STOMP = 388,
        EMOTE_ONESHOT_ATTACKOFF = 389,
        EMOTE_ONESHOT_ATTACKOFFPIERCE = 390,
        EMOTE_STATE_ROAR = 391,
        EMOTE_STATE_LAUGH = 392,
        EMOTE_ONESHOT_CREATURE_SPECIAL = 393
    }

    #region Ã¶¾Ù

    #region DialogStatus
    /// <summary>
    /// Dialog status
    /// </summary>
    public enum DialogStatus : byte
    {								 // Symbol,	Color,	Chat,	Number
        ChatUnAvailable = 0,         // x,		x,		no,		num = 0
        QuestUnAvailable = 1,        // !,		White,	no,		num = 1
        ChatAvailable = 2,           // x,		x,		yes,	num = 2
        QuestUnComplete = 3,         // ?,		White,	no,		num = 3
        RepeatQuestComplete = 4,     // ?,		Blue,	yes,	num = 4
        SingleQuestAvailable = 5,    // !,		Gold,	yes,	num = 5
        SingleQuestComplete = 6,     // ?,		Gold,	yes,	num = 6 and 7 (equal)
        None = 0
    }
    #endregion

    #region Races, Classes, Skills
 

    public enum qHordeRaces
    {
        // Fields
        Orc = 2,
        Tauren = 6,
        Troll = 8,
        Undead = 5
    }

    public enum qAllianceRaces
    {
        // Fields
        Dwarf = 3,
        Gnome = 7,
        Human = 1,
        NightElf = 4
    }
    #endregion

    #region QuestType, TypeNpcObj


    /// <summary>
    /// Type of NPCObjective
    /// </summary>
    public enum TypeNpcObj : byte
    {
        Mobile, GameObject
    }
    #endregion

    #endregion

    public enum QuestSpecialFlags
    {								 // Symbol,	Color,	Chat,	Number
        QUEST_SPECIAL_FLAGS_NONE = 0,
        QUEST_SPECIAL_FLAGS_DELIVER = 1,
        QUEST_SPECIAL_FLAGS_EXPLORATION = 2,
        QUEST_SPECIAL_FLAGS_SPEAKTO = 4,
        QUEST_SPECIAL_FLAGS_KILL_OR_CAST = 8,
        QUEST_SPECIAL_FLAGS_TIMED = 16,
        QUEST_SPECIAL_FLAGS_REPUTATION = 64,
    }




    #region DiscoveryAreaArray, SkillsArray
    /// <summary>
    /// Array for correct use Discovery quests
    /// </summary>
    public class DiscoveryAreaArray
    {
        // Methods
        public DiscoveryAreaArray()
        {
            this._items = new ArrayList();
        }

        public void Add( int areaTriggerId )
        {
            if ( !this._items.Contains( areaTriggerId ) )
            {
                this._items.Add( areaTriggerId );
            }
        }

        public bool Contains( int val )
        {
            return this._items.Contains( val );
        }


        // Properties
        public int Count
        {
            get
            {
                return this._items.Count;
            }
        }

        public int[] Items
        {
            get
            {
                return (int[])this._items.ToArray( typeof( int ) );
            }
        }


        // Fields
        private ArrayList _items;
    }
    #endregion

    #region Reward, BaseRewardArray, RewardArray, RewardChoiceArray
    /// <summary>
    /// Reward Item only
    /// now support only Item
    /// </summary>
    public class Reward
    {
        int _amount;
        int _id;
        //int _model;
        /// <summary>
        /// Item id and amount
        /// </summary>
        public Reward( int id, int amount )
        {
            _id = id;
            _amount = amount;
        }

        ///// <summary>
        ///// create one Item by Id number
        ///// </summary>
        //public Item Create()
        //{
        //    return World.CreateItemInPoolById( _id );
        //}

        /// <summary>
        /// Amount of items
        /// </summary>
        public int Amount
        {
            get { return _amount; }
        }

        /// <summary>
        /// Item.Id
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Item.Model 
        /// </summary>
        public int Model
        {
            get
            {
                //if ( _model == 0 )
                //{
                //    //Item i = Create();
                //    //_model = ( i != null ? i.Model : 0 );//safe check
                //}
                //return _model;
                return 0;
            }
        }

        ///// <summary>
        ///// only for Item
        ///// </summary>
        //public bool ExistsInWorld
        //{
        //    get { return Create() != null; }
        //}

        ///// <summary>
        ///// Create Item
        ///// </summary>
        //public Item CreateItem()
        //{
        //    return World.CreateItemInPoolById( _id );
        //}
    }

    /// <summary>
    /// base class for rewards
    /// work only after overloads with
    /// +RewardArray
    /// +RewardChoiceArray
    /// </summary>
    public class BaseRewardArray
    {
        private ArrayList _items = new ArrayList();
        private int _max = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseRewardArray( int max ) { _max = max; }

        ///// <summary>
        ///// Add new Reward [Item]
        ///// </summary>
        //public void Add( Reward r )
        //{
        //    if ( r.ExistsInWorld )
        //    {
        //        if ( CanAdd ) _items.Add( r );
        //    }

        //    else BadIdList.AddItemId( r.Id );
        //}

        ///// <summary>
        ///// Add Reward [Item]
        ///// </summary>
        //public void Add( int id, int amount )
        //{
        //    Add( new Reward( id, amount ) );
        //}

        /// <summary>
        /// Check for normal writed amount of objectives
        /// </summary>
        private bool CanAdd
        {
            get { return Count < _max; }
        }

        /// <summary>
        /// amount in array
        /// </summary>
        public int Count
        {
            get { return _items.Count; }
        }

        /// <summary>
        /// get array items
        /// </summary>
        public Reward[] Items
        {
            get { return (Reward[])_items.ToArray( typeof( Reward ) ); }
        }

        ///// <summary>
        ///// Create Reward item
        ///// </summary>
        //public Item RewardItem( int sel )
        //{
        //    Reward r = (Reward)_items[sel];
        //    return ( r != null ) ? r.CreateItem() : null;
        //}

        /// <summary>
        /// get Reward amount
        /// </summary>
        public int RewardAmount( int sel )
        {
            Reward r = (Reward)_items[sel];
            return ( r != null ) ? r.Amount : 0;
        }
    }

    /// <summary>
    /// Correct class for Reward Items
    /// </summary>
    public class RewardArray : BaseRewardArray
    {
        public RewardArray() : base( 4 ) { }
    }

    /// <summary>
    /// Correct class for needed Reward Choice Items
    /// </summary>
    public class RewardChoiceArray : BaseRewardArray
    {
        public RewardChoiceArray() : base( 6 ) { }
    }
    #endregion

    #region NPCObjective, NPCObjectiveArray
    /// <summary>
    /// Npc objective
    /// now support Mobile and GameObjects(not full)
    /// </summary>
    public class NPCObjective
    {
        private int _amount;
        private int _id;
        private string _descr = null;
        private TypeNpcObj _type = TypeNpcObj.Mobile;

        /// <summary>
        /// only for Mobiles
        /// </summary>
        public NPCObjective( int id, int amount )
        {
            this._descr = null;
            this._type = TypeNpcObj.Mobile;
            this._id = id;
            this._amount = amount;
        }
        /// <summary>
        /// for Mobiles/GameObj
        /// </summary>
        public NPCObjective( int id, int amount, TypeNpcObj typeObj, string description )
        {
            this._descr = null;
            this._type = TypeNpcObj.Mobile;
            this._id = id;
            this._amount = amount;
            this._type = typeObj;
            this._descr = description;
        }
        /// <summary>
        /// amount of objectives
        /// </summary>
        public int Amount
        {
            get { return _amount; }
        }
        /// <summary>
        /// mobile/go id number
        /// support only mobiles
        /// </summary>
        public int Id
        {
            get
            {
                if ( this._type != TypeNpcObj.Mobile )
                {
                    return ( this._id | -2147483648 );
                }
                return this._id;
            }
        }
        /// <summary>
        /// real id number
        /// </summary>
        public int Id2
        {
            get { return _id; }
        }

        ///// <summary>
        ///// Mobile exists in world
        ///// </summary>
        //public bool ExistsInWorld
        //{
        //    get { return World.MobilesPool[_id] != null; } // ?
        //}

        /// <summary>
        /// Description for current mob/go
        /// </summary>
        public string Descr
        {
            get
            {
                if ( _descr == null )
                {
                    //if ( _type == TypeNpcObj.Mobile )
                    //{
                    //    Mobile m = (Mobile)World.MobilePool( _id ).Invoke( null );
                    //    _descr = m.Name;
                    //}
                    //else
                    //{
                    //    _descr = string.Format( "gameobject:{0}", _id );
                    //}
                }
                return _descr;
            }
        }
        /// <summary>
        /// Current type of objectives
        /// </summary>
        public TypeNpcObj TypeObj
        {
            get { return _type; }
        }
    }

    /// <summary>
    /// Correct class for NPC Objectives
    /// </summary>
    public class NPCObjectiveArray
    {
        private static int _max = 4;
        private ArrayList _items = new ArrayList();

        /// <summary>
        /// Constructor
        /// </summary>
        public NPCObjectiveArray() { }
        /// <summary>
        /// Add new NPC Objective
        /// </summary>
        public void Add( NPCObjective npco )
        {
            //if ( npco.TypeObj == TypeNpcObj.Mobile )
            //{//if Mobile
            //    if ( npco.ExistsInWorld )
            //    {// exists in world
            //        if ( CanAdd )//can be added
            //            _items.Add( npco );
            //    }
            //    else BadIdList.AddMobileId( npco.Id );//add to bad statistic list
            //}
            //else // GameObject objective (not supported yet)
            //{
            //}
        }
        /// <summary>
        /// only Mobiles
        /// </summary>
        public void Add( int id, int amount )
        {
            Add( new NPCObjective( id, amount ) );
        }
        /// <summary>
        /// any type of objectives
        /// </summary>
        public void Add( int id, int amount, TypeNpcObj typeObj, string description )
        {
            Add( new NPCObjective( id, amount, typeObj, description ) );
        }
        /// <summary>
        /// Check for normal writed amount of objectives
        /// </summary>
        private bool CanAdd
        {
            get { return Count < _max; }
        }
        /// <summary>
        /// Count
        /// </summary>
        public int Count
        {
            get { return _items.Count; }
        }
        /// <summary>
        /// NPC Objectives Mobiles and/or Gameobjects
        /// </summary>
        public NPCObjective[] Items
        {
            get { return (NPCObjective[])_items.ToArray( typeof( NPCObjective ) ); }
        }
        /// <summary>
        /// NPC Objective by id if exist
        /// </summary>
        public NPCObjective GetById( int id )
        {
            NPCObjective result = null;
            foreach ( NPCObjective npc in _items )
            {
                if ( npc.Id2 == id ) { result = npc; break; }
            }
            return result;
        }
    }
    #endregion

    #region DeliveryObjective, DeliveryObjectiveArray
    /// <summary>
    /// Delivery item Objective
    /// now support only Item
    /// </summary>
    public class DeliveryObjective
    {
        int _amount;
        int _id;
        public DeliveryObjective( int id, int amount )
        {
            _id = id;
            _amount = amount;
        }
        public int Amount
        {
            get { return _amount; }
        }
        public int Id
        {
            get { return _id; }
        }

        //public bool ExistsInWorld
        //{
        //    get { return World.ItemsPool[_id] != null; }// ?
        //}
    }

    /// <summary>
    /// base class for rewards
    /// </summary>
    public class DeliveryObjectiveArray
    {
        private static int _max = 4;
        private ArrayList _items = new ArrayList();

        /// <summary>
        /// Constructor
        /// </summary>
        public DeliveryObjectiveArray() { }

        ///// <summary>
        ///// Add new DeliveryObjective (Item)
        ///// </summary>
        //public void Add( int id, int amount )
        //{
        //    Add( new DeliveryObjective( id, amount ) );
        //}

        /// <summary>
        /// Check for normal writed amount of objectives
        /// </summary>
        private bool CanAdd
        {
            get { return Count < _max; }
        }
        /// <summary>
        /// Count in array
        /// </summary>
        public int Count
        {
            get { return _items.Count; }
        }
        /// <summary>
        /// Objectives Array
        /// </summary>
        public DeliveryObjective[] Items
        {
            get { return (DeliveryObjective[])_items.ToArray( typeof( DeliveryObjective ) ); }
        }
        /// <summary>
        /// Delivery Objective by id if exist
        /// </summary>
        public DeliveryObjective GetById( int id )
        {
            DeliveryObjective result = null;
            foreach ( DeliveryObjective d in _items )
            {
                if ( d.Id == id ) { result = d; break; }
            }
            return result;
        }
    }
    #endregion
}
