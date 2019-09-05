﻿//
// Copyright (c) 2017 The nanoFramework project contributors
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
        /// Specifies a Touch Event
        /// </summary>
        Touch = 80,

        /// <summary>
        /// Specifies a Gesture Event
        /// </summary>
        Gesture = 90

    }
}
