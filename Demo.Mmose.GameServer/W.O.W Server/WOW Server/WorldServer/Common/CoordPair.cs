using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.WorldServer.WorldServer.Common
{
    public class CoordPair
    {
        //CoordPair(uint32 x=0, uint32 y=0) : x_coord(x), y_coord(y) {}
        //CoordPair(const CoordPair<LIMIT> &obj) : x_coord(obj.x_coord), y_coord(obj.y_coord) {}

        //bool operator==(const CoordPair<LIMIT> &obj) const { return (obj.x_coord == x_coord && obj.y_coord == y_coord); }
        //bool operator!=(const CoordPair<LIMIT> &obj) const { return !operator==(obj); }

        //CoordPair<LIMIT>& operator=(const CoordPair<LIMIT> &obj)
        //{
        //    this->~CoordPair<LIMIT>();
        //    new (this) CoordPair<LIMIT>(obj);
        //    return *this;
        //}

        //void operator<<(const uint32 val)
        //{
        //    if( x_coord >= val )
        //        x_coord -= val;
        //}

        //void operator>>(const uint32 val)
        //{
        //    if( x_coord+val < LIMIT )
        //        x_coord += val;
        //}

        //void operator-=(const uint32 val)
        //{
        //    if( y_coord >= val )
        //        y_coord -= val;
        //}

        //void operator+=(const uint32 val)
        //{
        //    if( y_coord+val < LIMIT )
        //        y_coord += val;
        //}

        //uint x_coord;
        //uint y_coord;
    }
}
