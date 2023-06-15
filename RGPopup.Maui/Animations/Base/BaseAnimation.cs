﻿using RGPopup.Maui.Converters.TypeConverters;
using RGPopup.Maui.Interfaces.Animations;
using RGPopup.Maui.Pages;
using System.ComponentModel;
using EasingTypeConverter = RGPopup.Maui.Converters.TypeConverters.EasingTypeConverter;

namespace RGPopup.Maui.Animations.Base
{
    public abstract class BaseAnimation : IPopupAnimation
    {
        private const uint DefaultDuration = 200;

        [TypeConverter(typeof(UintTypeConverter))]
        public uint DurationIn { get; set; } = DefaultDuration;

        [TypeConverter(typeof(UintTypeConverter))]
        public uint DurationOut { get; set; } = DefaultDuration;

        [TypeConverter(typeof(EasingTypeConverter))]
        public Easing EasingIn { get; set; } = Easing.Linear;

        [TypeConverter(typeof(EasingTypeConverter))]
        public Easing EasingOut { get; set; } = Easing.Linear;

        public abstract void Preparing(View content, PopupPage page);

        public abstract void Disposing(View content, PopupPage page);

        public abstract Task Appearing(View content, PopupPage page);

        public abstract Task Disappearing(View content, PopupPage page);

        protected virtual int GetTopOffset(View content, Page page)
        {
            return (int)(content.Height + page.Height) / 2;
        }

        protected virtual int GetLeftOffset(View content, Page page)
        {
            return (int)(content.Width + page.Width) / 2;
        }

        /// <summary>
        /// Use this method for avoiding the problem with blinking animation on iOS
        /// See https://github.com/rotorgames/Rg.Plugins.Popup/issues/404
        /// </summary>
        /// <param name="page">Page.</param>
        protected virtual void HidePage(Page page)
        {
            page.IsVisible = false;
        }

        /// <summary>
        /// Use this method for avoiding the problem with blinking animation on iOS
        /// See https://github.com/rotorgames/Rg.Plugins.Popup/
        /// </summary>
        /// <param name="page">Page.</param>
        protected virtual void ShowPage(Page page)
        {
            //Fix: #404
            MainThread.BeginInvokeOnMainThread(() => page.IsVisible = true);
        }
    }
}
