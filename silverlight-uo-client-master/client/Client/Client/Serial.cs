using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Client
{
    public struct Serial : IComparable, IComparable<Serial>
    {
        private int _value;
        
        public static readonly Serial MinusOne = new Serial(-1);
        public static readonly Serial Zero = new Serial(0);

        private Serial(int value)
        {
            _value = value;
        }

        public int Value
        {
            get { return _value; }
        }

        public bool IsMobile
        {
            get { return (_value > 0 && _value < 0x40000000); }
        }

        public bool IsItem
        {
            get { return (_value >= 0x40000000 && _value <= 0x7FFFFFFF); }
        }

        public bool IsValid
        {
            get { return (_value > 0); }
        }

        public override int GetHashCode()
        {
            return _value;
        }

        public int CompareTo(Serial other)
        {
            return _value.CompareTo(other._value);
        }

        public int CompareTo(object other)
        {
            if (other is Serial)
                return this.CompareTo((Serial)other);
            else if (other == null)
                return -1;

            throw new ArgumentException();
        }

        public override bool Equals(object o)
        {
            if (o == null || !(o is Serial)) return false;

            return ((Serial)o)._value == _value;
        }

        public static bool operator ==(Serial l, Serial r)
        {
            return l._value == r._value;
        }

        public static bool operator !=(Serial l, Serial r)
        {
            return l._value != r._value;
        }

        public static bool operator >(Serial l, Serial r)
        {
            return l._value > r._value;
        }

        public static bool operator <(Serial l, Serial r)
        {
            return l._value < r._value;
        }

        public static bool operator >=(Serial l, Serial r)
        {
            return l._value >= r._value;
        }

        public static bool operator <=(Serial l, Serial r)
        {
            return l._value <= r._value;
        }

        /*public static Serial operator ++ ( Serial l )
        {
            return new Serial( l + 1 );
        }*/

        public override string ToString()
        {
            return String.Format("0x{0:X8}", _value);
        }

        public static implicit operator int(Serial a)
        {
            return a._value;
        }

        public static implicit operator Serial(int a)
        {
            return new Serial(a);
        }
    }
}
