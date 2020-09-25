//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.Runtime.Events
{
    /// <summary>
    /// Creates an instance of the <see cref="GenericEvent"/> class.
    /// </summary>
    public class GenericEvent : BaseEvent
    {
        /// <summary>
        /// Specifies the event category.
        /// </summary>
        public byte Category;

        /// <summary>
        /// Contains the data associated with the event.
        /// </summary>
        public uint Data;

        /// <summary>
        /// Holds the event's time stamp.
        /// </summary>
        public DateTime Time;
    }
}
