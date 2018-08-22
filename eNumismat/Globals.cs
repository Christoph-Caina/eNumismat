using System;
using System.Reflection;

namespace eNumismat
{
    class Globals
    {
        //=====================================================================================================================================================================
        public static string UICulture { get; set; }

        //  The default Path for Application Data (cfg, logs, etc.pp)
        //=====================================================================================================================================================================
        public static string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + Assembly.GetCallingAssembly().EntryPoint.DeclaringType.Namespace;

        // Get the DB File we want to work during the whole Runtime...
        //=====================================================================================================================================================================
        public static string DBFile { get; set; }

        //=====================================================================================================================================================================
        public static string DBFilePath { get; set; }

        //=====================================================================================================================================================================
        public static bool BackupDBOnAppClose { get; set; }

        //=====================================================================================================================================================================
        public static bool CompressDBBeforeBackup { get; set; }

        //=====================================================================================================================================================================
        public static bool MinimizeToTray { get; set; }

        //=====================================================================================================================================================================
        public static bool UseAutoFillOnCities { get; set; }

        //=====================================================================================================================================================================
        public static bool UseAutoFillOnFederalStates { get; set; }

        //=====================================================================================================================================================================
        public static bool ValidateNames { get; set; }

        //=====================================================================================================================================================================
        public static bool ValidateEmail { get; set; }

        //=====================================================================================================================================================================
        public static bool ValidateAddressData { get; set; }

        /// <summary>
            /// Definition of Log Levels

            /// DEBUG
            /// Fine-grained information about what is going on within the system.

            /// INFO
            /// Announcements about the normal operation of the system - scheduled jobs running, services starting and stopping, significant user-triggered processes

            /// WARN
            /// Any condition that, while not an error in itself, may indicate that the system is running sub-optimally

            /// ERROR
            /// A condition that indicates something has gone wrong with the system
        /// </summary>
        //=====================================================================================================================================================================
        public static string LogLevel { get; set; }
    }
}
