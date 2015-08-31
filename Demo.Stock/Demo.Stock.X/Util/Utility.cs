using System;

namespace Demo.Stock.X.Util
{
    public static class Utility
    {
        public static int HexToDecimal( string strHexString )
        {
            char[] hexColor = strHexString.ToCharArray();
            int iDecimalColor = 0;
            int iLength = hexColor.Length - 1;
            int iDecimalNumber;

            foreach ( char cHexValue in hexColor )
            {
                if ( char.IsNumber( cHexValue ) )
                    int.TryParse( cHexValue.ToString(), out iDecimalNumber );
                else
                    iDecimalNumber = Convert.ToInt32( cHexValue ) - 55;

                iDecimalColor += iDecimalNumber * ( Convert.ToInt32( Math.Pow( 16, iLength ) ) );
                iLength--;
            }

            return iDecimalColor;
        }
    }
}
