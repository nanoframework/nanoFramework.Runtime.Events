//
// Copyright (c) 2019 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.Runtime.Events
{
    /// <summary>
    /// Contains argument values for custom events.
    /// </summary>
    public class CustomEventArgs : EventArgs
    {
#pragma warning disable IDE0032 // nanoFramework doesn't support auto-properties
        private readonly uint _data1;
        private readonly uint _data2;
#pragma warning restore IDE0032 // nanoFramework doesn't support auto-properties

        internal CustomEventArgs(uint data1, uint data2)
        {
            _data1 = data1;
            _data2 = data2;
        }

        /// <summary>
        /// Value of 1st field in event.
        /// </summary>
        public uint Data1 { get => _data1; }

        /// <summary>
        /// Value of 1st field in event.
        /// </summary>
        public uint Data2 { get => _data2; }
    }

    /// <summary>
    /// Provides an event handler that is called when a custom event is posted.
    /// </summary>
    /// <param name="sender">Specifies the object that sent the custom event. </param>
    /// <param name="e">Contains the custom event arguments. </param>
    public delegate void CustomEventPostedEventHandler(Object sender, CustomEventArgs e);

    /// <summary>
    /// Provides handling for custom native events. 
    /// </summary>
    public static class CustomEvent
    {

        internal class CustomEventInternal : BaseEvent
        {
            public uint Data1;
            public uint Data2;
            public DateTime Time;
        }

        internal class CustomEventListener : IEventListener, IEventProcessor
        {
            public void InitializeForEventSource()
            {
                // Method intentionally left empty.
            }

            public BaseEvent ProcessEvent(uint data1, uint data2, DateTime time)
            {
                CustomEventInternal customEvent = new CustomEventInternal
                {
                    Data1 = data1,
                    Data2 = data2,
                    Time = time
                };

                return customEvent;
            }

            public bool OnEvent(BaseEvent ev)
            {
                if (ev is CustomEventInternal)
                {
                    OnCustomEventFiredCallback((CustomEventInternal)ev);
                }

                return true;
            }
        }

        /// <summary>
        /// Event occurs when a custom event is posted.
        /// </summary>
        /// <remarks>
        /// The <see cref="CustomEvent"/> class raises <see cref="CustomEventPosted"/> event when a custom event is posted. 
        /// 
        /// To have a <see cref="CustomEvent"/> object call an event-handling method when a <see cref="CustomEventPosted"/> event occurs, 
        /// you must associate the method with a <see cref="CustomEventPostedEventHandler"/> delegate, and add this delegate to this event. 
        /// </remarks>
        public static event CustomEventPostedEventHandler CustomEventPosted;

        static CustomEvent()
        {
            CustomEventListener customEventListener = new CustomEventListener();

            EventSink.AddEventProcessor(EventCategory.Custom, customEventListener);
            EventSink.AddEventListener(EventCategory.Custom, customEventListener);
        }

        internal static void OnCustomEventFiredCallback(CustomEventInternal ev)
        {
            CustomEventPosted(null, new CustomEventArgs(ev.Data1, ev.Data2));
        }
    }
}
