using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.DBC
{
    public class SpellEntry : ILoad<SpellEntry>
    {
        public uint m_SpellID;                    // 0
        public uint ID
        {
            get { return m_SpellID; }
        }

        public uint m_School;                               // 1
        public uint m_Category;                             // 2
        public uint m_Unknown3;                             // 3
        public uint m_DispelType;                           // 4
        public uint m_MechanicsType;                        // 5
        public uint m_Attributes;                           // 6
        public uint m_AttributesEx;                         // 7
        public uint m_Unknown8;                             // 8
        public uint m_Unknown9;                             // 9
        public uint m_Unknown10;                            // 10
        public uint m_Unknown11;                            // 11
        public uint m_Unknown12;                            // 12
        public uint m_Unknown13;                            // 13
        public uint m_Unknown14;                            // 14
        public uint m_Unknown15;                            // 15
        public uint m_Unknown16;                            // 16
        public uint m_Unknown17;                            // 17
        public uint m_Unknown18;                            // 18
        public uint m_Unknown19;                            // 19
        public uint m_Unknown20;                            // 20
        public uint m_Unknown21;                            // 21
        public uint m_Unknown22;                            // 22
        public uint m_Unknown23;                            // 23
        public uint m_Unknown24;                            // 24
        public uint m_Unknown25;                            // 25
        public uint m_Unknown26;                            // 26
        public uint m_Unknown27;                            // 27
        public uint m_Unknown28;                            // 28
        public uint m_Unknown29;                            // 29
        public uint m_Unknown30;                            // 30
        public uint m_Unknown31;                            // 31
        public uint m_Unknown32;                            // 32
        public uint m_Unknown33;                            // 33
        public uint m_Unknown34;                            // 34
        public uint m_Unknown35;                            // 35
        public uint m_Unknown36;                            // 36
        public uint m_Unknown37;                            // 37
        public uint m_Unknown38;                            // 38
        public uint m_Unknown39;                            // 39
        public uint m_Unknown40;                            // 40
        public uint m_Unknown41;                            // 41
        public uint m_Unknown42;                            // 42
        public uint m_Unknown43;                            // 43
        public uint m_Unknown44;                            // 44
        public uint m_Unknown45;                            // 45
        public uint m_Unknown46;                            // 46
        public uint m_Unknown47;                            // 47
        public uint m_Unknown48;                            // 48
        public uint m_Unknown49;                            // 49
        public uint m_Unknown50;                            // 50
        public uint m_Unknown51;                            // 51
        public uint m_Unknown52;                            // 52
        public uint m_Unknown53;                            // 53
        public uint m_Unknown54;                            // 54
        public uint m_Unknown55;                            // 55
        public uint m_Unknown56;                            // 56
        public uint m_Unknown57;                            // 57
        public uint m_Unknown58;                            // 58
        public uint m_Unknown59;                            // 59
        public uint m_Unknown60;                            // 60
        public uint m_Unknown61;                            // 61
        public uint m_Unknown62;                            // 62
        public uint m_Unknown63;                            // 63
        public uint m_Unknown64;                            // 64
        public uint m_Unknown65;                            // 65
        public uint m_Unknown66;                            // 66
        public uint m_Unknown67;                            // 67
        public uint m_Unknown68;                            // 68
        public uint m_Unknown69;                            // 69
        public uint m_Unknown70;                            // 70
        public uint m_Unknown71;                            // 71
        public uint m_Unknown72;                            // 72
        public uint m_Unknown73;                            // 73
        public uint m_Unknown74;                            // 74
        public uint m_Unknown75;                            // 75
        public uint m_Unknown76;                            // 76
        public uint m_Unknown77;                            // 77
        public uint m_Unknown78;                            // 78
        public uint m_Unknown79;                            // 79
        public uint m_Unknown80;                            // 80
        public uint m_Unknown81;                            // 81
        public uint m_Unknown82;                            // 82
        public uint m_Unknown83;                            // 83
        public uint m_Unknown84;                            // 84
        public uint m_Unknown85;                            // 85
        public uint m_Unknown86;                            // 86
        public uint m_Unknown87;                            // 87
        public uint m_Unknown88;                            // 88
        public uint m_Unknown89;                            // 89
        public uint m_Unknown90;                            // 90
        public uint m_Unknown91;                            // 91
        public uint m_Unknown92;                            // 92
        public uint m_Unknown93;                            // 93
        public uint m_Unknown94;                            // 94
        public uint m_Unknown95;                            // 95
        public uint m_Unknown96;                            // 96
        public uint m_Unknown97;                            // 97
        public uint m_Unknown98;                            // 98
        public uint m_Unknown99;                            // 99
        public uint m_Unknown100;                           // 100
        public uint m_Unknown101;                           // 101
        public uint m_Unknown102;                           // 102
        public uint m_Unknown103;                           // 103
        public uint m_Unknown104;                           // 104
        public uint m_Unknown105;                           // 105
        public uint m_Unknown106;                           // 106
        public uint m_Unknown107;                           // 107
        public uint m_Unknown108;                           // 108
        public uint m_Unknown109;                           // 109
        public uint m_Unknown110;                           // 110
        public uint m_Unknown111;                           // 111
        public uint m_Unknown112;                           // 112
        public uint m_Unknown113;                           // 113
        public uint m_Unknown114;                           // 114
        public uint m_Unknown115;                           // 115
        public uint m_Unknown116;                           // 116
        public uint m_Unknown117;                           // 117
        public uint m_Unknown118;                           // 118
        public uint m_Unknown119;                           // 119
        public uint m_Unknown120;                           // 120
        public uint m_Unknown121;                           // 121
        public uint m_Unknown122;                           // 122
        public uint m_Unknown123;                           // 123
        public uint m_Unknown124;                           // 124
        public uint m_Unknown125;                           // 125
        public uint m_Unknown126;                           // 126
        public uint m_Unknown127;                           // 127
        public uint m_Unknown128;                           // 128
        public uint m_Unknown129;                           // 129
        public uint m_Unknown130;                           // 130
        public uint m_Unknown131;                           // 131
        public uint m_Unknown132;                           // 132
        public uint m_Unknown133;                           // 133
        public uint m_Unknown134;                           // 134
        public uint m_Unknown135;                           // 135
        public uint m_Unknown136;                           // 136
        public uint m_Unknown137;                           // 137
        public uint m_Unknown138;                           // 138
        public uint m_Unknown139;                           // 139
        public uint m_Unknown140;                           // 140
        public uint m_Unknown141;                           // 141
        public uint m_Unknown142;                           // 142
        public uint m_Unknown143;                           // 143
        public uint m_Unknown144;                           // 144
        public uint m_Unknown145;                           // 145
        public uint m_Unknown146;                           // 146
        public uint m_Unknown147;                           // 147
        public uint m_Unknown148;                           // 148
        public uint m_Unknown149;                           // 149
        public uint m_Unknown150;                           // 150
        public uint m_Unknown151;                           // 151
        public uint m_Unknown152;                           // 152
        public uint m_Unknown153;                           // 153
        public uint m_Unknown154;                           // 154
        public uint m_Unknown155;                           // 155
        public uint m_Unknown156;                           // 156
        public uint m_Unknown157;                           // 157
        public uint m_Unknown158;                           // 158
        public uint m_Unknown159;                           // 159
        public uint m_Unknown160;                           // 160
        public uint m_Unknown161;                           // 161
        public uint m_Unknown162;                           // 162
        public uint m_Unknown163;                           // 163
        public uint m_Unknown164;                           // 164
        public uint m_Unknown165;                           // 165
        public uint m_Unknown166;                           // 166
        public uint m_Unknown167;                           // 167
        public uint m_Unknown168;                           // 168
        public uint m_Unknown169;                           // 169
        public uint m_Unknown170;                           // 170
        public uint m_Unknown171;                           // 171
        public uint m_Unknown172;                           // 172
        public uint m_Unknown173;                           // 173
        public uint m_Unknown174;                           // 174
        public uint m_Unknown175;                           // 175
        public uint m_Unknown176;                           // 176
        public uint m_Unknown177;                           // 177
        public uint m_Unknown178;                           // 178
        public uint m_Unknown179;                           // 179
        public uint m_Unknown180;                           // 180
        public uint m_Unknown181;                           // 181
        public uint m_Unknown182;                           // 182
        public uint m_Unknown183;                           // 183
        public uint m_Unknown184;                           // 184
        public uint m_Unknown185;                           // 185
        public uint m_Unknown186;                           // 186
        public uint m_Unknown187;                           // 187
        public uint m_Unknown188;                           // 188
        public uint m_Unknown189;                           // 189
        public uint m_Unknown190;                           // 190
        public uint m_Unknown191;                           // 191
        public uint m_Unknown192;                           // 192
        public uint m_Unknown193;                           // 193
        public uint m_Unknown194;                           // 194
        public uint m_Unknown195;                           // 195
        public uint m_Unknown196;                           // 196
        public uint m_Unknown197;                           // 197
        public uint m_Unknown198;                           // 198
        public uint m_Unknown199;                           // 199
        public uint m_Unknown200;                           // 200
        public uint m_Unknown201;                           // 201
        public uint m_Unknown202;                           // 202
        public uint m_Unknown203;                           // 203
        public uint m_Unknown204;                           // 204
        public uint m_Unknown205;                           // 205
        public uint m_Unknown206;                           // 206
        public uint m_Unknown207;                           // 207
        public uint m_Unknown208;                           // 208
        public uint m_Unknown209;                           // 209
        public uint m_Unknown210;                           // 210


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_SpellID = dbcRecord.GetUInt( 0 );
            this.m_School = dbcRecord.GetUInt( 1 );
            this.m_Category = dbcRecord.GetUInt( 2 );
            this.m_Unknown3 = dbcRecord.GetUInt( 3 );
            this.m_DispelType = dbcRecord.GetUInt( 4 );
            this.m_MechanicsType = dbcRecord.GetUInt( 5 );
            this.m_Attributes = dbcRecord.GetUInt( 6 );
            this.m_AttributesEx = dbcRecord.GetUInt( 7 );
            this.m_Unknown8 = dbcRecord.GetUInt( 8 );
            this.m_Unknown9 = dbcRecord.GetUInt( 9 );
            this.m_Unknown10 = dbcRecord.GetUInt( 10 );
            this.m_Unknown11 = dbcRecord.GetUInt( 11 );
            this.m_Unknown12 = dbcRecord.GetUInt( 12 );
            this.m_Unknown13 = dbcRecord.GetUInt( 13 );
            this.m_Unknown14 = dbcRecord.GetUInt( 14 );
            this.m_Unknown15 = dbcRecord.GetUInt( 15 );
            this.m_Unknown16 = dbcRecord.GetUInt( 16 );
            this.m_Unknown17 = dbcRecord.GetUInt( 17 );
            this.m_Unknown18 = dbcRecord.GetUInt( 18 );
            this.m_Unknown19 = dbcRecord.GetUInt( 19 );
            this.m_Unknown20 = dbcRecord.GetUInt( 20 );
            this.m_Unknown21 = dbcRecord.GetUInt( 21 );
            this.m_Unknown22 = dbcRecord.GetUInt( 22 );
            this.m_Unknown23 = dbcRecord.GetUInt( 23 );
            this.m_Unknown24 = dbcRecord.GetUInt( 24 );
            this.m_Unknown25 = dbcRecord.GetUInt( 25 );
            this.m_Unknown26 = dbcRecord.GetUInt( 26 );
            this.m_Unknown27 = dbcRecord.GetUInt( 27 );
            this.m_Unknown28 = dbcRecord.GetUInt( 28 );
            this.m_Unknown29 = dbcRecord.GetUInt( 29 );
            this.m_Unknown30 = dbcRecord.GetUInt( 30 );
            this.m_Unknown31 = dbcRecord.GetUInt( 31 );
            this.m_Unknown32 = dbcRecord.GetUInt( 32 );
            this.m_Unknown33 = dbcRecord.GetUInt( 33 );
            this.m_Unknown34 = dbcRecord.GetUInt( 34 );
            this.m_Unknown35 = dbcRecord.GetUInt( 35 );
            this.m_Unknown36 = dbcRecord.GetUInt( 36 );
            this.m_Unknown37 = dbcRecord.GetUInt( 37 );
            this.m_Unknown38 = dbcRecord.GetUInt( 38 );
            this.m_Unknown39 = dbcRecord.GetUInt( 39 );
            this.m_Unknown40 = dbcRecord.GetUInt( 40 );
            this.m_Unknown41 = dbcRecord.GetUInt( 41 );
            this.m_Unknown42 = dbcRecord.GetUInt( 42 );
            this.m_Unknown43 = dbcRecord.GetUInt( 43 );
            this.m_Unknown44 = dbcRecord.GetUInt( 44 );
            this.m_Unknown45 = dbcRecord.GetUInt( 45 );
            this.m_Unknown46 = dbcRecord.GetUInt( 46 );
            this.m_Unknown47 = dbcRecord.GetUInt( 47 );
            this.m_Unknown48 = dbcRecord.GetUInt( 48 );
            this.m_Unknown49 = dbcRecord.GetUInt( 49 );
            this.m_Unknown50 = dbcRecord.GetUInt( 50 );
            this.m_Unknown51 = dbcRecord.GetUInt( 51 );
            this.m_Unknown52 = dbcRecord.GetUInt( 52 );
            this.m_Unknown53 = dbcRecord.GetUInt( 53 );
            this.m_Unknown54 = dbcRecord.GetUInt( 54 );
            this.m_Unknown55 = dbcRecord.GetUInt( 55 );
            this.m_Unknown56 = dbcRecord.GetUInt( 56 );
            this.m_Unknown57 = dbcRecord.GetUInt( 57 );
            this.m_Unknown58 = dbcRecord.GetUInt( 58 );
            this.m_Unknown59 = dbcRecord.GetUInt( 59 );
            this.m_Unknown60 = dbcRecord.GetUInt( 60 );
            this.m_Unknown61 = dbcRecord.GetUInt( 61 );
            this.m_Unknown62 = dbcRecord.GetUInt( 62 );
            this.m_Unknown63 = dbcRecord.GetUInt( 63 );
            this.m_Unknown64 = dbcRecord.GetUInt( 64 );
            this.m_Unknown65 = dbcRecord.GetUInt( 65 );
            this.m_Unknown66 = dbcRecord.GetUInt( 66 );
            this.m_Unknown67 = dbcRecord.GetUInt( 67 );
            this.m_Unknown68 = dbcRecord.GetUInt( 68 );
            this.m_Unknown69 = dbcRecord.GetUInt( 69 );
            this.m_Unknown70 = dbcRecord.GetUInt( 70 );
            this.m_Unknown71 = dbcRecord.GetUInt( 71 );
            this.m_Unknown72 = dbcRecord.GetUInt( 72 );
            this.m_Unknown73 = dbcRecord.GetUInt( 73 );
            this.m_Unknown74 = dbcRecord.GetUInt( 74 );
            this.m_Unknown75 = dbcRecord.GetUInt( 75 );
            this.m_Unknown76 = dbcRecord.GetUInt( 76 );
            this.m_Unknown77 = dbcRecord.GetUInt( 77 );
            this.m_Unknown78 = dbcRecord.GetUInt( 78 );
            this.m_Unknown79 = dbcRecord.GetUInt( 79 );
            this.m_Unknown80 = dbcRecord.GetUInt( 80 );
            this.m_Unknown81 = dbcRecord.GetUInt( 81 );
            this.m_Unknown82 = dbcRecord.GetUInt( 82 );
            this.m_Unknown83 = dbcRecord.GetUInt( 83 );
            this.m_Unknown84 = dbcRecord.GetUInt( 84 );
            this.m_Unknown85 = dbcRecord.GetUInt( 85 );
            this.m_Unknown86 = dbcRecord.GetUInt( 86 );
            this.m_Unknown87 = dbcRecord.GetUInt( 87 );
            this.m_Unknown88 = dbcRecord.GetUInt( 88 );
            this.m_Unknown89 = dbcRecord.GetUInt( 89 );
            this.m_Unknown90 = dbcRecord.GetUInt( 90 );
            this.m_Unknown91 = dbcRecord.GetUInt( 91 );
            this.m_Unknown92 = dbcRecord.GetUInt( 92 );
            this.m_Unknown93 = dbcRecord.GetUInt( 93 );
            this.m_Unknown94 = dbcRecord.GetUInt( 94 );
            this.m_Unknown95 = dbcRecord.GetUInt( 95 );
            this.m_Unknown96 = dbcRecord.GetUInt( 96 );
            this.m_Unknown97 = dbcRecord.GetUInt( 97 );
            this.m_Unknown98 = dbcRecord.GetUInt( 98 );
            this.m_Unknown99 = dbcRecord.GetUInt( 99 );
            this.m_Unknown100 = dbcRecord.GetUInt( 100 );
            this.m_Unknown101 = dbcRecord.GetUInt( 101 );
            this.m_Unknown102 = dbcRecord.GetUInt( 102 );
            this.m_Unknown103 = dbcRecord.GetUInt( 103 );
            this.m_Unknown104 = dbcRecord.GetUInt( 104 );
            this.m_Unknown105 = dbcRecord.GetUInt( 105 );
            this.m_Unknown106 = dbcRecord.GetUInt( 106 );
            this.m_Unknown107 = dbcRecord.GetUInt( 107 );
            this.m_Unknown108 = dbcRecord.GetUInt( 108 );
            this.m_Unknown109 = dbcRecord.GetUInt( 109 );
            this.m_Unknown110 = dbcRecord.GetUInt( 110 );
            this.m_Unknown111 = dbcRecord.GetUInt( 111 );
            this.m_Unknown112 = dbcRecord.GetUInt( 112 );
            this.m_Unknown113 = dbcRecord.GetUInt( 113 );
            this.m_Unknown114 = dbcRecord.GetUInt( 114 );
            this.m_Unknown115 = dbcRecord.GetUInt( 115 );
            this.m_Unknown116 = dbcRecord.GetUInt( 116 );
            this.m_Unknown117 = dbcRecord.GetUInt( 117 );
            this.m_Unknown118 = dbcRecord.GetUInt( 118 );
            this.m_Unknown119 = dbcRecord.GetUInt( 119 );
            this.m_Unknown120 = dbcRecord.GetUInt( 120 );
            this.m_Unknown121 = dbcRecord.GetUInt( 121 );
            this.m_Unknown122 = dbcRecord.GetUInt( 122 );
            this.m_Unknown123 = dbcRecord.GetUInt( 123 );
            this.m_Unknown124 = dbcRecord.GetUInt( 124 );
            this.m_Unknown125 = dbcRecord.GetUInt( 125 );
            this.m_Unknown126 = dbcRecord.GetUInt( 126 );
            this.m_Unknown127 = dbcRecord.GetUInt( 127 );
            this.m_Unknown128 = dbcRecord.GetUInt( 128 );
            this.m_Unknown129 = dbcRecord.GetUInt( 129 );
            this.m_Unknown130 = dbcRecord.GetUInt( 130 );
            this.m_Unknown131 = dbcRecord.GetUInt( 131 );
            this.m_Unknown132 = dbcRecord.GetUInt( 132 );
            this.m_Unknown133 = dbcRecord.GetUInt( 133 );
            this.m_Unknown134 = dbcRecord.GetUInt( 134 );
            this.m_Unknown135 = dbcRecord.GetUInt( 135 );
            this.m_Unknown136 = dbcRecord.GetUInt( 136 );
            this.m_Unknown137 = dbcRecord.GetUInt( 137 );
            this.m_Unknown138 = dbcRecord.GetUInt( 138 );
            this.m_Unknown139 = dbcRecord.GetUInt( 139 );
            this.m_Unknown140 = dbcRecord.GetUInt( 140 );
            this.m_Unknown141 = dbcRecord.GetUInt( 141 );
            this.m_Unknown142 = dbcRecord.GetUInt( 142 );
            this.m_Unknown143 = dbcRecord.GetUInt( 143 );
            this.m_Unknown144 = dbcRecord.GetUInt( 144 );
            this.m_Unknown145 = dbcRecord.GetUInt( 145 );
            this.m_Unknown146 = dbcRecord.GetUInt( 146 );
            this.m_Unknown147 = dbcRecord.GetUInt( 147 );
            this.m_Unknown148 = dbcRecord.GetUInt( 148 );
            this.m_Unknown149 = dbcRecord.GetUInt( 149 );
            this.m_Unknown150 = dbcRecord.GetUInt( 150 );
            this.m_Unknown151 = dbcRecord.GetUInt( 151 );
            this.m_Unknown152 = dbcRecord.GetUInt( 152 );
            this.m_Unknown153 = dbcRecord.GetUInt( 153 );
            this.m_Unknown154 = dbcRecord.GetUInt( 154 );
            this.m_Unknown155 = dbcRecord.GetUInt( 155 );
            this.m_Unknown156 = dbcRecord.GetUInt( 156 );
            this.m_Unknown157 = dbcRecord.GetUInt( 157 );
            this.m_Unknown158 = dbcRecord.GetUInt( 158 );
            this.m_Unknown159 = dbcRecord.GetUInt( 159 );
            this.m_Unknown160 = dbcRecord.GetUInt( 160 );
            this.m_Unknown161 = dbcRecord.GetUInt( 161 );
            this.m_Unknown162 = dbcRecord.GetUInt( 162 );
            this.m_Unknown163 = dbcRecord.GetUInt( 163 );
            this.m_Unknown164 = dbcRecord.GetUInt( 164 );
            this.m_Unknown165 = dbcRecord.GetUInt( 165 );
            this.m_Unknown166 = dbcRecord.GetUInt( 166 );
            this.m_Unknown167 = dbcRecord.GetUInt( 167 );
            this.m_Unknown168 = dbcRecord.GetUInt( 168 );
            this.m_Unknown169 = dbcRecord.GetUInt( 169 );
            this.m_Unknown170 = dbcRecord.GetUInt( 170 );
            this.m_Unknown171 = dbcRecord.GetUInt( 171 );
            this.m_Unknown172 = dbcRecord.GetUInt( 172 );
            this.m_Unknown173 = dbcRecord.GetUInt( 173 );
            this.m_Unknown174 = dbcRecord.GetUInt( 174 );
            this.m_Unknown175 = dbcRecord.GetUInt( 175 );
            this.m_Unknown176 = dbcRecord.GetUInt( 176 );
            this.m_Unknown177 = dbcRecord.GetUInt( 177 );
            this.m_Unknown178 = dbcRecord.GetUInt( 178 );
            this.m_Unknown179 = dbcRecord.GetUInt( 179 );
            this.m_Unknown180 = dbcRecord.GetUInt( 180 );
            this.m_Unknown181 = dbcRecord.GetUInt( 181 );
            this.m_Unknown182 = dbcRecord.GetUInt( 182 );
            this.m_Unknown183 = dbcRecord.GetUInt( 183 );
            this.m_Unknown184 = dbcRecord.GetUInt( 184 );
            this.m_Unknown185 = dbcRecord.GetUInt( 185 );
            this.m_Unknown186 = dbcRecord.GetUInt( 186 );
            this.m_Unknown187 = dbcRecord.GetUInt( 187 );
            this.m_Unknown188 = dbcRecord.GetUInt( 188 );
            this.m_Unknown189 = dbcRecord.GetUInt( 189 );
            this.m_Unknown190 = dbcRecord.GetUInt( 190 );
            this.m_Unknown191 = dbcRecord.GetUInt( 191 );
            this.m_Unknown192 = dbcRecord.GetUInt( 192 );
            this.m_Unknown193 = dbcRecord.GetUInt( 193 );
            this.m_Unknown194 = dbcRecord.GetUInt( 194 );
            this.m_Unknown195 = dbcRecord.GetUInt( 195 );
            this.m_Unknown196 = dbcRecord.GetUInt( 196 );
            this.m_Unknown197 = dbcRecord.GetUInt( 197 );
            this.m_Unknown198 = dbcRecord.GetUInt( 198 );
            this.m_Unknown199 = dbcRecord.GetUInt( 199 );
            this.m_Unknown200 = dbcRecord.GetUInt( 200 );
            this.m_Unknown201 = dbcRecord.GetUInt( 201 );
            this.m_Unknown202 = dbcRecord.GetUInt( 202 );
            this.m_Unknown203 = dbcRecord.GetUInt( 203 );
            this.m_Unknown204 = dbcRecord.GetUInt( 204 );
            this.m_Unknown205 = dbcRecord.GetUInt( 205 );
            this.m_Unknown206 = dbcRecord.GetUInt( 206 );
            this.m_Unknown207 = dbcRecord.GetUInt( 207 );
            this.m_Unknown208 = dbcRecord.GetUInt( 208 );
            this.m_Unknown209 = dbcRecord.GetUInt( 209 );
            this.m_Unknown210 = dbcRecord.GetUInt( 210 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_SpellID );

            return true;
        }
    }

    //// Struct for the entry in Spell.dbc
    //internal struct SpellEntry
    //{
    //    public uint Id;							  //1
    //    public uint School;						  //2
    //    public uint Category;						//3
    //    public uint field4;						  //4 something like spelltype 0: general spells 1: Pet spells 2: Disguise / transormation spells 3: enchantment spells
    //    public uint DispelType;					  //5
    //    public uint MechanicsType;				   //6
    //    public uint Attributes;					  //7
    //    public uint AttributesEx;					//8
    //    public uint Flags3;						  //9
    //    public uint field10;						 //10 // Flags to
    //    public uint field11;						 //11 // Flags....
    //    public uint unk201_1;						//12 // Flags 2.0.1 unknown one
    //    public uint RequiredShapeShift;			  //13 // Flags BitMask for shapeshift spells
    //    public uint UNK14;						   //14-> this is wrong // Flags BitMask for which shapeshift forms this spell can NOT be used in.
    //    public uint Targets;						 //15 - N / M
    //    public uint TargetCreatureType;			  //16
    //    public uint RequiresSpellFocus;			  //17
    //    public uint CasterAuraState;				 //18
    //    public uint TargetAuraState;				 //19
    //    public uint unk201_2;						//20 2.0.1 unknown two
    //    public uint unk201_3;						//21 2.0.1 unknown three
    //    public uint CastingTimeIndex;				//22
    //    public uint RecoveryTime;					//23
    //    public uint CategoryRecoveryTime;			//24 recoverytime
    //    public uint InterruptFlags;				  //25
    //    public uint AuraInterruptFlags;			  //26
    //    public uint ChannelInterruptFlags;		   //27
    //    public uint procFlags;					   //28
    //    public uint procChance;					  //29
    //    public int procCharges;					 //30
    //    public uint maxLevel;						//31
    //    public uint baseLevel;					   //32
    //    public uint spellLevel;					  //33
    //    public uint DurationIndex;				   //34
    //    public uint powerType;					   //35
    //    public uint manaCost;						//36
    //    public uint manaCostPerlevel;				//37
    //    public uint manaPerSecond;				   //38
    //    public uint manaPerSecondPerLevel;		   //39
    //    public uint rangeIndex;					  //40
    //    public float speed;						   //41
    //    public uint modalNextSpell;				  //42
    //    public uint maxstack;						//43
    //    public uint[] Totem;						//44 - 45
    //    public uint[] Reagent;					  //46 - 53
    //    public uint[] ReagentCount;				 //54 - 61
    //    public uint EquippedItemClass;			   //62
    //    public uint EquippedItemSubClass;			//63
    //    public uint RequiredItemFlags;			   //64
    //    public uint[] Effect;					   //65 - 67
    //    public uint[] EffectDieSides;			   //68 - 70
    //    public uint[] EffectBaseDice;			   //71 - 73
    //    public float[] EffectDicePerLevel;		   //74 - 76
    //    public float[] EffectRealPointsPerLevel;	 //77 - 79
    //    public int[] EffectBasePoints;			 //80 - 82
    //    public int[] EffectMechanic;			   //83 - 85	   Related to SpellMechanic.dbc
    //    public uint[] EffectImplicitTargetA;		//86 - 88
    //    public uint[] EffectImplicitTargetB;		//89 - 91
    //    public uint[] EffectRadiusIndex;			//92 - 94
    //    public uint[] EffectApplyAuraName;		  //95 - 97
    //    public uint[] EffectAmplitude;			  //98 - 100
    //    public float[] Effectunknown;				//101 - 103	 This value is the $ value from description
    //    public uint[] EffectChainTarget;			//104 - 106
    //    public uint[] EffectSpellGroupRelation;	 //107 - 109	 Not sure maybe we should rename it. its the relation to field: SpellGroupType
    //    public uint[] EffectMiscValue;			  //110 - 112
    //    public uint[] EffectTriggerSpell;		   //113 - 115
    //    public float[] EffectPointsPerComboPoint;	//116 - 118
    //    public uint SpellVisual;					 //119
    //    public uint field114;						//120
    //    public uint dummy;						   //121
    //    public uint CoSpell;						 //122   activeIconID;
    //    public uint spellPriority;				   //123
    //    public uint Name;							//124
    //    public uint NameAlt1;						//125
    //    public uint NameAlt2;						//126
    //    public uint NameAlt3;						//127
    //    public uint NameAlt4;						//128
    //    public uint NameAlt5;						//129
    //    public uint NameAlt6;						//130
    //    public uint NameAlt7;						//131
    //    public uint NameAlt8;						//132
    //    public uint NameAlt9;						//133
    //    public uint NameAlt10;					   //134
    //    public uint NameAlt11;					   //135
    //    public uint NameAlt12;					   //136
    //    public uint NameAlt13;					   //137
    //    public uint NameAlt14;					   //138
    //    public uint NameAlt15;					   //139
    //    public uint NameFlags;					   //140
    //    public uint Rank;							//141
    //    public uint RankAlt1;						//142
    //    public uint RankAlt2;						//143
    //    public uint RankAlt3;						//144
    //    public uint RankAlt4;						//145
    //    public uint RankAlt5;						//146
    //    public uint RankAlt6;						//147
    //    public uint RankAlt7;						//148
    //    public uint RankAlt8;						//149
    //    public uint RankAlt9;						//150
    //    public uint RankAlt10;					   //151
    //    public uint RankAlt11;					   //152
    //    public uint RankAlt12;					   //153
    //    public uint RankAlt13;					   //154
    //    public uint RankAlt14;					   //155
    //    public uint RankAlt15;					   //156
    //    public uint RankFlags;					   //157
    //    public uint Description;					 //158
    //    public uint DescriptionAlt1;				 //159
    //    public uint DescriptionAlt2;				 //160
    //    public uint DescriptionAlt3;				 //161
    //    public uint DescriptionAlt4;				 //162
    //    public uint DescriptionAlt5;				 //163
    //    public uint DescriptionAlt6;				 //164
    //    public uint DescriptionAlt7;				 //165
    //    public uint DescriptionAlt8;				 //166
    //    public uint DescriptionAlt9;				 //167
    //    public uint DescriptionAlt10;				//168
    //    public uint DescriptionAlt11;				//169
    //    public uint DescriptionAlt12;				//170
    //    public uint DescriptionAlt13;				//171
    //    public uint DescriptionAlt14;				//172
    //    public uint DescriptionAlt15;				//173
    //    public uint DescriptionFlags;				//174
    //    public uint BuffDescription;				 //175
    //    public uint BuffDescriptionAlt1;			 //176
    //    public uint BuffDescriptionAlt2;			 //177
    //    public uint BuffDescriptionAlt3;			 //178
    //    public uint BuffDescriptionAlt4;			 //179
    //    public uint BuffDescriptionAlt5;			 //180
    //    public uint BuffDescriptionAlt6;			 //181
    //    public uint BuffDescriptionAlt7;			 //182
    //    public uint BuffDescriptionAlt8;			 //183
    //    public uint BuffDescriptionAlt9;			 //184
    //    public uint BuffDescriptionAlt10;			//185
    //    public uint BuffDescriptionAlt11;			//186
    //    public uint BuffDescriptionAlt12;			//187
    //    public uint BuffDescriptionAlt13;			//188
    //    public uint BuffDescriptionAlt14;			//189
    //    public uint BuffDescriptionAlt15;			//190
    //    public uint buffdescflags;				   //191
    //    public uint ManaCostPercentage;			  //192
    //    public uint unkflags;						//193 
    //    public uint StartRecoveryTime;			   //194
    //    public uint StartRecoveryCategory;		   //195
    //    public uint SpellFamilyName;				 //196
    //    public uint SpellGroupType;				  //197   flags 
    //    public uint unkne;						   //198   flags hackwow=shit 
    //    public uint MaxTargets;					  //199 
    //    public uint Spell_Dmg_Type;				  //200   dmg_class Integer	  0=None, 1=Magic, 2=Melee, 3=Ranged
    //    public uint FG;							  //201   0,1,2 related to Spell_Dmg_Type I think
    //    public int FH;							   //202   related to paladin aura's 
    //    public float[] dmg_multiplier;				//203 - 205   if the name is correct I dono
    //    public uint FL;							  //206   only one spellid:6994 has this value = 369
    //    public uint FM;							  //207   only one spellid:6994 has this value = 4
    //    //uint FN;							  //208   only one spellid:26869  has this flag = 1

    //    // soz guys, gotta use these 3 vars :p
    //    //uint unk201_4; // these are related to creating a item through a spell
    //    //uint unk201_5;
    //    //uint unk201_6; // related to custom spells, summon spell quest related spells

    //    // custom shit
    //    public uint buffType;						//209

    //    // this protects players from having >1 rank of a spell
    //    public uint RankNumber;					  //210
    //    public uint NameHash;						//211

    //    public uint DiminishStatus;

    //    public SpellEntry Load()
    //    {
    //        SpellEntry spellEntry = new SpellEntry();

    //        spellEntry.Id = 0;							  //1
    //        spellEntry.School = 0;						  //2
    //        spellEntry.Category = 0;						//3
    //        spellEntry.field4 = 0;						  //4 something like spelltype 0: general spells 1: Pet spells 2: Disguise / transormation spells 3: enchantment spells
    //        spellEntry.DispelType = 0;					  //5
    //        spellEntry.MechanicsType = 0;				   //6
    //        spellEntry.Attributes = 0;					  //7
    //        spellEntry.AttributesEx = 0;					//8
    //        spellEntry.Flags3 = 0;						  //9
    //        spellEntry.field10 = 0;						 //10 // Flags to
    //        spellEntry.field11 = 0;						 //11 // Flags....
    //        spellEntry.unk201_1 = 0;						//12 // Flags 2.0.1 unknown one
    //        spellEntry.RequiredShapeShift = 0;			  //13 // Flags BitMask for shapeshift spells
    //        spellEntry.UNK14 = 0;						   //14-> this is wrong // Flags BitMask for which shapeshift forms this spell can NOT be used in.
    //        spellEntry.Targets = 0;						 //15 - N / M
    //        spellEntry.TargetCreatureType = 0;			  //16
    //        spellEntry.RequiresSpellFocus = 0;			  //17
    //        spellEntry.CasterAuraState = 0;				 //18
    //        spellEntry.TargetAuraState = 0;				 //19
    //        spellEntry.unk201_2 = 0;						//20 2.0.1 unknown two
    //        spellEntry.unk201_3 = 0;						//21 2.0.1 unknown three
    //        spellEntry.CastingTimeIndex = 0;				//22
    //        spellEntry.RecoveryTime = 0;					//23
    //        spellEntry.CategoryRecoveryTime = 0;			//24 recoverytime
    //        spellEntry.InterruptFlags = 0;				  //25
    //        spellEntry.AuraInterruptFlags = 0;			  //26
    //        spellEntry.ChannelInterruptFlags = 0;		   //27
    //        spellEntry.procFlags = 0;					   //28
    //        spellEntry.procChance = 0;					  //29
    //        spellEntry.procCharges = 0;					 //30
    //        spellEntry.maxLevel = 0;						//31
    //        spellEntry.baseLevel = 0;					   //32
    //        spellEntry.spellLevel = 0;					  //33
    //        spellEntry.DurationIndex = 0;				   //34
    //        spellEntry.powerType = 0;					   //35
    //        spellEntry.manaCost = 0;						//36
    //        spellEntry.manaCostPerlevel = 0;				//37
    //        spellEntry.manaPerSecond = 0;				   //38
    //        spellEntry.manaPerSecondPerLevel = 0;		   //39
    //        spellEntry.rangeIndex = 0;					  //40
    //        spellEntry.speed = 0;						   //41
    //        spellEntry.modalNextSpell = 0;				  //42
    //        spellEntry.maxstack = 0;						//43
    //        spellEntry.Totem = new uint[2];						//44 - 45
    //        spellEntry.Reagent = new uint[8];					  //46 - 53
    //        spellEntry.ReagentCount = new uint[8];				 //54 - 61
    //        spellEntry.EquippedItemClass = 0;			   //62
    //        spellEntry.EquippedItemSubClass = 0;			//63
    //        spellEntry.RequiredItemFlags = 0;			   //64
    //        spellEntry.Effect = new uint[3];					   //65 - 67
    //        spellEntry.EffectDieSides = new uint[3];			   //68 - 70
    //        spellEntry.EffectBaseDice = new uint[3];			   //71 - 73
    //        spellEntry.EffectDicePerLevel = new float[3];		   //74 - 76
    //        spellEntry.EffectRealPointsPerLevel = new float[3];	 //77 - 79
    //        spellEntry.EffectBasePoints = new int[3];			 //80 - 82
    //        spellEntry.EffectMechanic = new int[3];			   //83 - 85	   Related to SpellMechanic.dbc
    //        spellEntry.EffectImplicitTargetA = new uint[3];		//86 - 88
    //        spellEntry.EffectImplicitTargetB = new uint[3];		//89 - 91
    //        spellEntry.EffectRadiusIndex = new uint[3];			//92 - 94
    //        spellEntry.EffectApplyAuraName = new uint[3];		  //95 - 97
    //        spellEntry.EffectAmplitude = new uint[3];			  //98 - 100
    //        spellEntry.Effectunknown = new float[3];				//101 - 103	 This value is the $ value from description
    //        spellEntry.EffectChainTarget = new uint[3];			//104 - 106
    //        spellEntry.EffectSpellGroupRelation = new uint[3];	 //107 - 109	 Not sure maybe we should rename it. its the relation to field: SpellGroupType
    //        spellEntry.EffectMiscValue = new uint[3];			  //110 - 112
    //        spellEntry.EffectTriggerSpell = new uint[3];		   //113 - 115
    //        spellEntry.EffectPointsPerComboPoint = new float[3];	//116 - 118
    //        spellEntry.SpellVisual = 0;					 //119
    //        spellEntry.field114 = 0;						//120
    //        spellEntry.dummy = 0;						   //121
    //        spellEntry.CoSpell = 0;						 //122   activeIconID;
    //        spellEntry.spellPriority = 0;				   //123
    //        spellEntry.Name = 0;							//124
    //        spellEntry.NameAlt1 = 0;						//125
    //        spellEntry.NameAlt2 = 0;						//126
    //        spellEntry.NameAlt3 = 0;						//127
    //        spellEntry.NameAlt4 = 0;						//128
    //        spellEntry.NameAlt5 = 0;						//129
    //        spellEntry.NameAlt6 = 0;						//130
    //        spellEntry.NameAlt7 = 0;						//131
    //        spellEntry.NameAlt8 = 0;						//132
    //        spellEntry.NameAlt9 = 9;						//133
    //        spellEntry.NameAlt10 = 0;					   //134
    //        spellEntry.NameAlt11 = 0;					   //135
    //        spellEntry.NameAlt12 = 0;					   //136
    //        spellEntry.NameAlt13 = 0;					   //137
    //        spellEntry.NameAlt14 = 0;					   //138
    //        spellEntry.NameAlt15 = 0;					   //139
    //        spellEntry.NameFlags = 0;					   //140
    //        spellEntry.Rank = 0;							//141
    //        spellEntry.RankAlt1 = 0;						//142
    //        spellEntry.RankAlt2 = 0;						//143
    //        spellEntry.RankAlt3 = 0;						//144
    //        spellEntry.RankAlt4 = 0;						//145
    //        spellEntry.RankAlt5 = 0;						//146
    //        spellEntry.RankAlt6 = 0;						//147
    //        spellEntry.RankAlt7 = 0;						//148
    //        spellEntry.RankAlt8 = 0;						//149
    //        spellEntry.RankAlt9 = 0;						//150
    //        spellEntry.RankAlt10 = 0;					   //151
    //        spellEntry.RankAlt11 = 0;					   //152
    //        spellEntry.RankAlt12 = 0;					   //153
    //        spellEntry.RankAlt13 = 0;					   //154
    //        spellEntry.RankAlt14 = 0;					   //155
    //        spellEntry.RankAlt15 = 0;					   //156
    //        spellEntry.RankFlags = 0;					   //157
    //        spellEntry.Description = 0;					 //158
    //        spellEntry.DescriptionAlt1 = 0;				 //159
    //        spellEntry.DescriptionAlt2 = 0;				 //160
    //        spellEntry.DescriptionAlt3 = 0;				 //161
    //        spellEntry.DescriptionAlt4 = 0;				 //162
    //        spellEntry.DescriptionAlt5 = 0;				 //163
    //        spellEntry.DescriptionAlt6 = 0;				 //164
    //        spellEntry.DescriptionAlt7 = 0;				 //165
    //        spellEntry.DescriptionAlt8 = 0;				 //166
    //        spellEntry.DescriptionAlt9 = 0;				 //167
    //        spellEntry.DescriptionAlt10 = 0;				//168
    //        spellEntry.DescriptionAlt11 = 0;				//169
    //        spellEntry.DescriptionAlt12 = 0;				//170
    //        spellEntry.DescriptionAlt13 = 0;				//171
    //        spellEntry.DescriptionAlt14 = 0;				//172
    //        spellEntry.DescriptionAlt15 = 0;				//173
    //        spellEntry.DescriptionFlags = 0;				//174
    //        spellEntry.BuffDescription = 0;				 //175
    //        spellEntry.BuffDescriptionAlt1 = 0;			 //176
    //        spellEntry.BuffDescriptionAlt2 = 0;			 //177
    //        spellEntry.BuffDescriptionAlt3 = 0;			 //178
    //        spellEntry.BuffDescriptionAlt4 = 0;			 //179
    //        spellEntry.BuffDescriptionAlt5 = 0;			 //180
    //        spellEntry.BuffDescriptionAlt6 = 0;			 //181
    //        spellEntry.BuffDescriptionAlt7 = 0;			 //182
    //        spellEntry.BuffDescriptionAlt8 = 0;			 //183
    //        spellEntry.BuffDescriptionAlt9 = 0;			 //184
    //        spellEntry.BuffDescriptionAlt10 = 0;			//185
    //        spellEntry.BuffDescriptionAlt11 = 0;			//186
    //        spellEntry.BuffDescriptionAlt12 = 0;			//187
    //        spellEntry.BuffDescriptionAlt13 = 0;			//188
    //        spellEntry.BuffDescriptionAlt14 = 0;			//189
    //        spellEntry.BuffDescriptionAlt15 = 0;			//190
    //        spellEntry.buffdescflags = 0;				   //191
    //        spellEntry.ManaCostPercentage = 0;			  //192
    //        spellEntry.unkflags = 0;						//193 
    //        spellEntry.StartRecoveryTime = 0;			   //194
    //        spellEntry.StartRecoveryCategory = 0;		   //195
    //        spellEntry.SpellFamilyName = 0;				 //196
    //        spellEntry.SpellGroupType = 0;				  //197   flags 
    //        spellEntry.unkne = 0;						   //198   flags hackwow=shit 
    //        spellEntry.MaxTargets = 0;					  //199 
    //        spellEntry.Spell_Dmg_Type = 0;				  //200   dmg_class Integer	  0=None, 1=Magic, 2=Melee, 3=Ranged
    //        spellEntry.FG = 0;							  //201   0,1,2 related to Spell_Dmg_Type I think
    //        spellEntry.FH = 0;							   //202   related to paladin aura's 
    //        spellEntry.dmg_multiplier = new float[3];				//203 - 205   if the name is correct I dono
    //        spellEntry.FL = 0;							  //206   only one spellid:6994 has this value = 369
    //        spellEntry.FM = 0;							  //207   only one spellid:6994 has this value = 4
    //        //spellEntry.FN;							  //208   only one spellid:26869  has this flag = 1

    //        // soz guys, gotta use these 3 vars :p
    //        //spellEntry.unk201_4; // these are related to creating a item through a spell
    //        //spellEntry.unk201_5;
    //        //spellEntry.unk201_6; // related to custom spells, summon spell quest related spells

    //        // custom shit
    //        spellEntry.buffType = 0;						//209

    //        // this protects players from having >1 rank of a spell
    //        spellEntry.RankNumber = 0;					  //210
    //        spellEntry.NameHash = 0;						//211

    //        spellEntry.DiminishStatus = 0;

    //        return spellEntry;
    //    }
    //}

}
