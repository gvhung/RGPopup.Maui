﻿using Android.Views;

namespace RGPopup.Maui.Droid.Gestures
{
    internal class RgGestureDetectorListener : GestureDetector.SimpleOnGestureListener
    {
        public event EventHandler<MotionEvent> Clicked;

        public override bool OnSingleTapUp(MotionEvent e)
        {
            if (e != null) Clicked?.Invoke(this, e);

            return false;
        }
    }
}
