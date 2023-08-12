using System;
using System.Collections.Generic;
using System.Text;

namespace Detail_Tool
{
    /*
     * Globals - Global type variables available to all forms.
     */

    class Globals
    {
        // Constants
        public const int MAXMATERIALFILES = 2048;
        public const int MAXMATERIALTEXTURES = 131072;
        public const int MAXTEXTURES = 16384;

        public const int MAXMATERIALS = 64;
        public const int MAXKEYS = 16;

        public const int FILETYPE_USERDATA = 0;
        public const int FILETYPE_MATLIST = 1;

        public const string CONTROLDELIMITER = ": ";

        public const string TEXTURESPATHTEXT = "Textures folder";
        public const string MATERIALSPATHTEXT = "Materials folder";

        public const string ALLOWEDCHARACTERS = "QWERTYUIOPASDFGHJKLZXCVBNM";

        public const string USERDATAFILENAME = "userdata.udf";
        public const string MATERIALDATAFILENAME = "matlist.mld";

        // Extensions
        public static string[] g_szFormats =
        { 
          ".DDS", 
          ".TGA", 
          ".BMP", 
          ".TXT" 
        };

        // Material info variables
        public static string[] g_szMaterialFiles;
        public static int g_iNumMaterialFiles;

        public static string[] g_szMaterialTextures;
        public static int g_iNumMaterialTextures;

        public static string[] g_szTextureFiles;
        public static int g_iNumTextureFiles;

        // User data array list
        public static List<string> g_szUserData;

        // Detail textures script data
        public static List<string> g_szScriptData;

        // Unrecognized material keys
        public static List<string> g_szUndefinedMaterialKeys;

        // List index selection
        public static int g_iCurIndex;

        // Unused material keys
        public static string g_szUsableKeys;

        // Material data array
        public static string[,] g_szMaterials;

        // Number of recognized materials
        public static int g_iNumMaterials;

        // User config data file directorty
        public static string g_szUserDataDir;

        //==============================
        // Startup()
        // Fill important variables and arrays prior to use
        //==============================
        public static void Startup()
        {
            g_szMaterials = new string[MAXMATERIALS, 3];

            g_iNumMaterials = 0;

            g_iCurIndex = 0;

            g_szUsableKeys = "";
        }
    }
}
