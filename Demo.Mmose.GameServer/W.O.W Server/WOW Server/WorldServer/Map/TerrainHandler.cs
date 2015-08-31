using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Util;

namespace Demo.Wow.WorldServer.Map
{
    class TerrainHandler
    {
        static byte TilesCount = 64;
        static float TileSize = 533.33333F;

        static float MinX = ( -TilesCount * TileSize / 2 );
        static float MinY = ( -TilesCount * TileSize / 2 );

        static float MaxX = ( TilesCount * TileSize / 2 );
        static float MaxY = ( TilesCount * TileSize / 2 );
        
        static byte CellsPerTile = 8;
        static float CellSize = ( TileSize / CellsPerTile );

        static int SizeX = ( TilesCount * CellsPerTile ); // size [512]
        static int SizeY = ( TilesCount * CellsPerTile ); // size [512]

        static float GetRelatCoord(float fCoord, int iCellCoord)
        {
            return ( MaxX - fCoord ) - iCellCoord * CellSize;
        }

        static int TERRAIN_HEADER_SIZE = SizeX * SizeY * 4;	 // size of [512][512] (uint) array.
        static int MAP_RESOLUTION = 256;


        /// <summary>
        /// MapPath contains the location of all mapfiles.
        /// </summary>
        string m_strMapFilePath;

        /// <summary>
        /// 
        /// </summary>
        string m_strMapName;

        /// <summary>
        /// Map ID
        /// </summary>
        uint m_iMapId;

        /// <summary>
        /// Are we an instance?
        /// </summary>
        bool Instance;

        /// <summary>
        /// We don't want to be reading from a file from more than one thread at once
        /// </summary>
        //object mutex;

        /// <summary>
        /// Our main file descriptor for accessing the binary terrain file.
        /// </summary>
        FileStream m_FileDescriptor;

        /// <summary>
        /// This holds the offsets of the cell information for each cell.
        /// </summary>
        uint[,] m_CellOffsets = new uint[SizeX, SizeY];

        /// <summary>
        /// Our storage array. This contains pointers to all allocated CellInfo's.
        /// </summary>
        TerrainInfo[,] m_CellInformation = new TerrainInfo[SizeX, SizeY];

        /// <summary>
        /// Initializes the terrain interface, allocates all required arrays, and sets all variables.
        /// </summary>
        /// <param name="strMapPath">The path to the packed map files.</param>
        /// <param name="MapId">The map that we'll be retrieving information from.</param>
        /// <param name="Instanced">Controls whether the map will unload information when it's not in use.</param>
        TerrainHandler( string strMapPath, string strMapName, uint MapId, bool Instanced )
        {
            m_strMapFilePath = strMapPath;
            m_strMapName = strMapName;
            m_iMapId = MapId;
            Instance = Instanced;

            // Load the file.
            if ( LoadTerrainHeader() == false )
            {
                return;
            }
        }

        /// <summary>
        /// Initializes the file descriptor and readys it for data retreival.
        /// </summary>
        /// <returns>Returns true if the index was read successfully, false if not.</returns>
        bool LoadTerrainHeader()
        {
            // Create the path
            string strFileName = string.Format( "{0}/{1}[{2}].map", m_strMapFilePath, m_strMapName, m_iMapId );

            m_FileDescriptor = File.Open( strFileName, FileMode.Open, FileAccess.Read );

            if ( m_FileDescriptor == null )
            {
                //sLog.outError( "Could not load map file header for %s.", File );
                return false;
            }

            // Read in the header.
            byte[] byteHeader = new byte[TERRAIN_HEADER_SIZE];
            m_FileDescriptor.Read( byteHeader, 0, TERRAIN_HEADER_SIZE );

            for ( int iIndex = 0; iIndex < SizeX; iIndex++ )
                for ( int iIndex2 = 0; iIndex2 < SizeY; iIndex2++ )
                    m_CellOffsets[iIndex, iIndex2] = byteHeader[( iIndex * SizeY ) + iIndex2];

            return true;
        }

        /// <summary>
        /// Retrieves the cell data for the specified co-ordinates from the file and sets it in the CellInformation array.
        /// </summary>
        /// <param name="x">x co-ordinate of the cell information to load.</param>
        /// <param name="y">y co-ordinate of the cell information to load.</param>
        /// <returns>Returns true if the cell information exists and was loaded, false if not.</returns>
        bool LoadCellInformation( uint x, uint y )
        {
            // Make sure that we're not already loaded.
            if ( m_CellInformation[x, y] != null )
                return true;

            // Find our offset in our cached header.
            uint Offset = m_CellOffsets[x, y];

            // If our offset = 0, it means we don't have cell information for 
            // these coords.
            if ( Offset == 0 )
                return false;

            // Lock the mutex to prevent double reading.
            //mutex.Acquire();

            // Check that we haven't been loaded by another thread.
            if ( m_CellInformation[x, y] != null )
            {
                //mutex.Release();
                return true;
            }

            // Seek to our specified offset.
            m_FileDescriptor.Seek( Offset, SeekOrigin.Begin );
            {
                // Allocate the cell information.
                m_CellInformation[x, y] = new TerrainInfo();

                // Read from our file into this newly created struct.
                byte[] byteArray = new byte[( 2 * 2 * 2 ) + ( 2 * 2 * 1 ) + ( 2 * 2 * 4 ) + ( 32 * 32 * 4 )];
                m_FileDescriptor.Read( byteArray, 0, byteArray.Length );

                int iIndexArray = 0;
                for ( int iIndex = 0; iIndex < 2; iIndex++ )
                {
                    for ( int iIndex2 = 0; iIndex2 < 2; iIndex2++ )
                    {
                        m_CellInformation[x, y].AreaID[iIndex, iIndex2] = (ushort)( byteArray[iIndexArray] | byteArray[++iIndexArray] << 8 );
                        iIndexArray++;
                    }
                }

                for ( int iIndex = 0; iIndex < 2; iIndex++ )
                {
                    for ( int iIndex2 = 0; iIndex2 < 2; iIndex2++ )
                    {
                        m_CellInformation[x, y].LiquidType[iIndex, iIndex2] = byteArray[iIndexArray];
                        iIndexArray++;
                    }
                }

                for ( int iIndex = 0; iIndex < 2; iIndex++ )
                {
                    for ( int iIndex2 = 0; iIndex2 < 2; iIndex2++ )
                    {
                        CONVERT_FLOAT_INT_UINT convert = new CONVERT_FLOAT_INT_UINT();
                        convert.uiUint = (uint)( byteArray[iIndexArray] | byteArray[++iIndexArray] << 8 | byteArray[++iIndexArray] << 16 | byteArray[++iIndexArray] << 24 );
                        iIndexArray++;

                        m_CellInformation[x, y].LiquidLevel[iIndex, iIndex2] = convert.fFloat;
                    }
                }

                for ( int iIndex = 0; iIndex < 32; iIndex++ )
                {
                    for ( int iIndex2 = 0; iIndex2 < 32; iIndex2++ )
                    {
                        CONVERT_FLOAT_INT_UINT convert = new CONVERT_FLOAT_INT_UINT();
                        convert.uiUint = (uint)( byteArray[iIndexArray] | byteArray[++iIndexArray] << 8 | byteArray[++iIndexArray] << 16 | byteArray[++iIndexArray] << 24 );
                        iIndexArray++;

                        m_CellInformation[x, y].Z[iIndex, iIndex2] = convert.fFloat;
                    }
                }
            }

            // Release the mutex.
            //mutex.Release();

            // If we don't equal 0, it means the load was successful.
            if ( m_CellInformation[x, y] != null )
                return true;
            else
                return false;
        }

        /// <summary>
        /// Unloads the cell data at the specified co-ordinates and frees the memory.
        /// </summary>
        /// <param name="x">x co-ordinate of the cell information to free.</param>
        /// <param name="y">y co-ordinate of the cell information to free.</param>
        /// <returns>Returns true if the free was successful, otherwise false.</returns>
        bool UnloadCellInformation( uint x, uint y )
        {
            m_CellInformation[x, y] = null;
            return true;
        }

        /// <summary>
        /// If we're a non-instanced map, we'll unload the cell information as it's not needed.
        /// </summary>
        /// <param name="x">The x co-ordinate of the cell that's gone idle.</param>
        /// <param name="y">The y co-ordinate of the cell that's gone idle.</param>
        void CellGoneIdle( uint x, uint y )
        {
            // If we're not an instance, unload our cell info.
            if ( Instance == false && CellInformationLoaded( x, y ) == true /*&& sWorld.UnloadMapFiles*/ )
                UnloadCellInformation( x, y );
        }

        /// <summary>
        /// Loads the cell information if it has not already been loaded.
        /// </summary>
        /// <param name="x">The x co-ordinate of the cell that's gone active.</param>
        /// <param name="y">The y co-ordinate of the cell that's gone active.</param>
        void CellGoneActive( uint x, uint y )
        {
            // Load cell information if it's not already loaded.
            if ( CellInformationLoaded( x, y ) == false )
                LoadCellInformation( x, y );
        }

        /// <summary>
        /// Information retrieval functions
        /// These functions all take the same input values, an x and y global co-ordinate.
        /// They will all return 0 if the cell information is not loaded or does not exist,
        /// apart from the water function which will return '-999999.0'.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        float GetLandHeight( float x, float y )
        {
            if ( !AreCoordinatesValid( x, y ) )
                return 0.0f;

            // Convert the co-ordinates to cells.
            uint CellX = ConvertGlobalXCoordinate( x );
            uint CellY = ConvertGlobalYCoordinate( y );

            if ( !CellInformationLoaded( CellX, CellY ) )
                return 0.0f;

            // Convert the co-ordinates to cell's internal
            // system.
            float IntX = ConvertInternalXCoordinate( x, CellX );
            float IntY = ConvertInternalYCoordinate( y, CellY );

            // Find the offset in the 2d array.
            return GetCellInformation(CellX, CellY).LiquidLevel[ConvertTo2dArray( IntX ), ConvertTo2dArray( IntY )];
        }

        float GetWaterHeight( float x, float y )
        {
            if ( !AreCoordinatesValid( x, y ) )
                return 0.0f;

            // Convert the co-ordinates to cells.
            uint CellX = ConvertGlobalXCoordinate( x );
            uint CellY = ConvertGlobalYCoordinate( y );

            if ( !CellInformationLoaded( CellX, CellY ) )
                return 0.0f;

            // Convert the co-ordinates to cell's internal
            // system.
            float IntX = ConvertInternalXCoordinate( x, CellX );
            float IntY = ConvertInternalYCoordinate( y, CellY );

            // Find the offset in the 2d array.
            return GetCellInformation(CellX, CellY).LiquidLevel[ConvertTo2dArray( IntX ), ConvertTo2dArray( IntY )];
        }

        byte GetWaterType( float x, float y )
        {
            if ( !AreCoordinatesValid( x, y ) )
                return 0;

            // Convert the co-ordinates to cells.
            uint CellX = ConvertGlobalXCoordinate( x );
            uint CellY = ConvertGlobalYCoordinate( y );

            if ( !CellInformationLoaded( CellX, CellY ) )
                return 0;

            // Convert the co-ordinates to cell's internal
            // system.
            float IntX = ConvertInternalXCoordinate( x, CellX );
            float IntY = ConvertInternalYCoordinate( y, CellY );

            // Find the offset in the 2d array.
            return GetCellInformation(CellX, CellY).LiquidType[ConvertTo2dArray( IntX ), ConvertTo2dArray( IntY )];
        }

        byte GetWalkableState( float x, float y )
        {
            // This has to be implemented.
            return 1;
        }

        ushort GetAreaID( float x, float y )
        {
            if ( !AreCoordinatesValid( x, y ) )
                return 0;

            // Convert the co-ordinates to cells.
            uint CellX = ConvertGlobalXCoordinate( x );
            uint CellY = ConvertGlobalYCoordinate( y );

            if ( !CellInformationLoaded( CellX, CellY ) && !LoadCellInformation( CellX, CellY ) )
                return 0;

            // Convert the co-ordinates to cell's internal
            // system.
            float IntX = ConvertInternalXCoordinate( x, CellX );
            float IntY = ConvertInternalYCoordinate( y, CellY );

            // Find the offset in the 2d array.
            return GetCellInformation(CellX, CellY).AreaID[ConvertTo2dArray( IntX ), ConvertTo2dArray( IntY )];
        }


        /// <summary>
        /// Gets the offset for the specified cell from the cached offset index.
        /// </summary>
        /// <param name="x">cell x co-ordinate.</param>
        /// <param name="y">cell y co-ordinate.</param>
        /// <returns>Returns the offset in bytes of that cell's information, or 0 if it doesn't exist.</returns>
        uint GetCellInformationOffset( uint x, uint y )
        {
            return m_CellOffsets[x,y];
        }

        /// <summary>
        /// Gets a cell information pointer so that another function can access its data.
        /// </summary>
        /// <param name="x">cell x co-ordinate.</param>
        /// <param name="y">cell y co-ordinate.</param>
        /// <returns>Returns the memory address of the information for that cell.</returns>
        TerrainInfo GetCellInformation( uint x, uint y )
        {
            return m_CellInformation[x,y];
        }

        /// <summary>
        /// Converts a global x co-ordinate into a cell x co-ordinate.
        /// </summary>
        /// <param name="x">global x co-ordinate.</param>
        /// <returns>Returns the cell x co-ordinate.</returns>
        uint ConvertGlobalXCoordinate( float x )
        {
            return (uint)( ( MaxX - x ) / CellSize );
        }

        /// <summary>
        /// Converts a global y co-ordinate into a cell y co-ordinate.
        /// </summary>
        /// <param name="y">global y co-ordinate.</param>
        /// <returns>Returns the cell y co-ordinate.</returns>
        uint ConvertGlobalYCoordinate( float y )
        {
            return (uint)( ( MaxY - y ) / CellSize );
        }

        /// <summary>
        /// Converts a global x co-ordinate into a INTERNAL cell x co-ordinate.
        /// </summary>
        /// <param name="x">global x co-ordinate.</param>
        /// <param name="cellx">the cell x co-ordinate.</param>
        /// <returns>Returns the internal x co-ordinate.</returns>
        float ConvertInternalXCoordinate( float x, uint cellx )
        {
            float X = ( MaxX - x );
            X -= ( cellx * CellSize );
            return X;
        }

        /// <summary>
        /// Converts a global y co-ordinate into a INTERNAL cell y co-ordinate.
        /// </summary>
        /// <param name="y">global y co-ordinate.</param>
        /// <param name="celly">the cell y co-ordinate.</param>
        /// <returns>Returns the internal y co-ordinate.</returns>
        float ConvertInternalYCoordinate( float y, uint celly )
        {
            float Y = ( MaxY - y );
            Y -= ( celly * CellSize );
            return Y;
        }

        /// <summary>
        /// Checks whether a cell information is loaded or not.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool CellInformationLoaded( uint x, uint y )
        {
            if ( m_CellInformation[x,y] != null )
                return true;
            else
                return false;
        }

        /// <summary>
        /// Converts the internal co-ordinate to an index in the 2 dimension areaid, or liquid type arrays.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        uint ConvertTo2dArray( float c )
        {
            return (uint)( c * ( 16 / CellsPerTile / CellSize ) );
        }

        /// <summary>
        /// Checks that the co-ordinates are within range.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool AreCoordinatesValid( float x, float y )
        {
            if ( x > MaxX || x < MinX )
                return false;
            if ( y > MaxY || y < MinY )
                return false;
            return true;
        }
    }
}
