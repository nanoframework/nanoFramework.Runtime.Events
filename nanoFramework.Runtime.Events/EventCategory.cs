//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Runtime.Events
{
    /// <summary>
    /// Defines the categories events are classified into.
    /// </summary>
    public enum EventCategory
    {
        /////////////////////////////////////////////////////////////////////////////////
        // !!! KEEP IN SYNC WITH #defines EVENT_nnnn in nanoHAL_v2.h (native code) !!! //
        /////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Specifies an unknown event type.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Specifies a programmer-defined event.
        /// </summary>
        Custom = 10,

        /// <summary>
        /// Specifies a GPIO event.
        /// </summary>
        Gpio = 20,
        
        /// <summary>
        /// Specifies a SerialDevice event.
        /// </summary>
        SerialDevice = 30,
        
        /// <summary>
        /// Specifies a Network event.
        /// </summary>
        Network = 40,
        
        /// <summary>
        /// Specifies a WiFi event.
        /// </summary>
        WiFi = 50,
        
        /// <summary>
        /// Specifies a CAN event.
        /// </summary>
        Can = 60,
        
        /// <summary>
        /// Specifies a Storage event.
        /// </summary>
        Storage = 70,

        /// <summary>
        /// Specifies a Radio event.
        /// </summary>
        Radio = 80,

        /// <summary>
        /// Specifies a HighResolutionTimer event.
        /// </summary>
        HighResolutionTimer = 90,

    }
}
