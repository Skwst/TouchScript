﻿using System;
using System.Runtime.InteropServices;

namespace TouchScript.InputSources.Interop
{
    sealed class NativePointerHandler : IDisposable
    {
        private const string UnityWindowClassName = "UnityWndClass";
        
        #region Native Methods
        
        [DllImport("WindowsTouchEx")]
        private static extern Result PointerHandler_Create(ref IntPtr handle);
        [DllImport("WindowsTouchEx")]
        private static extern Result PointerHandler_Destroy(IntPtr handle);
        [DllImport("WindowsTouchEx")]
        private static extern Result PointerHandler_Initialize(IntPtr handle, MessageCallback messageCallback,
            TOUCH_API api, IntPtr windowHandle, PointerCallback pointerCallback);
        [DllImport("WindowsTouchEx")]
        private static extern Result PointerHandler_SetScreenParams(IntPtr handle, MessageCallback messageCallback,
            int width, int height, float offsetX, float offsetY, float scaleX, float scaleY);
        
        #endregion

        private IntPtr handle;

        internal NativePointerHandler()
        {
            // Create native resources
            handle = new IntPtr();
            var result = PointerHandler_Create(ref handle);
            if (result != Result.Ok)
            {
                handle = IntPtr.Zero;
                ResultHelper.CheckResult(result);
            }
        }

        ~NativePointerHandler()
        {
            Dispose(false);
        }
        
        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Free managed resources
            }

            // Free native resources
            if (handle != IntPtr.Zero)
            {
                PointerHandler_Destroy(handle);
                handle = IntPtr.Zero;
            }
        }

        internal void Initialize(MessageCallback messageCallback, TOUCH_API api, IntPtr hWindow, PointerCallback pointerCallback)
        {
            
        }

        internal void SetScreenParams(MessageCallback messageCallback, int width, int height, float offsetX, float offsetY, float scaleX, float scaleY)
        {
            
        }
    }
}