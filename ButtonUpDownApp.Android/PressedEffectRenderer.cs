using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ButtonUpDownApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("MyApp")]
[assembly: ExportEffect(typeof(PressedEffectRenderer), "PressedEffect")]
namespace ButtonUpDownApp.Droid
{
    public class PressedEffectRenderer : PlatformEffect
    {
        private bool _attached;
        public PressedEffectRenderer()
        {
        }

        protected override void OnAttached()
        {
            if (!_attached)
            {
                if (Control != null)
                {
                    Control.LongClickable = true;
                    Control.Touch += Control_Touch;
                    Control.Click += Control_Click;
                }
                else
                {
                    Container.LongClickable = true;
                    Container.Touch += Control_Touch;
                    Container.Click += Control_Click;
                }
                _attached = true;
            }
        }

        private void Control_Click(object sender, EventArgs e)
        {
            var command = PressedEffect.GetTapCommand(Element);
            command?.Execute(PressedEffect.GetTapParameter(Element));
        }

        private void Control_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                var command = PressedEffect.GetLongPressedCommand(Element);
                command?.Execute(PressedEffect.GetLongParameter(Element));
            }
            else if (e.Event.Action == MotionEventActions.Up)
            {
                var command = PressedEffect.GetLongReleasedCommand(Element);
                command?.Execute(PressedEffect.GetLongParameter(Element));
            }
        }


        protected override void OnDetached()
        {
            if (_attached)
            {
                if (Control != null)
                {
                    Control.LongClickable = true;
                    Control.Touch -= Control_Touch;
                    Control.Click -= Control_Click;
                }
                else
                {
                    Container.LongClickable = true;
                    Container.Touch -= Control_Touch;
                    Container.Click -= Control_Click;
                }
                _attached = false;
            }
        }
    }
}