using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ButtonUpDownApp
{
    public class PressedEffect : RoutingEffect
    {
        public PressedEffect() : base("MyApp.PressedEffect")
        {
        }

        public static readonly BindableProperty LongPressedCommandProperty = BindableProperty.CreateAttached("LongPressedCommand", typeof(ICommand), typeof(PressedEffect), (object)null);
        public static ICommand GetLongPressedCommand(BindableObject view)
        {
            return (ICommand)view.GetValue(LongPressedCommandProperty);
        }

        public static void SetLongPressedCommand(BindableObject view, ICommand value)
        {
            view.SetValue(LongPressedCommandProperty, value);
        }


        public static readonly BindableProperty LongParameterProperty = BindableProperty.CreateAttached("LongParameter", typeof(object), typeof(PressedEffect), (object)null);
        public static object GetLongParameter(BindableObject view)
        {
            return view.GetValue(LongParameterProperty);
        }

        public static void SetLongParameter(BindableObject view, object value)
        {
            view.SetValue(LongParameterProperty, value);
        }

        public static readonly BindableProperty LongReleasedCommandProperty = BindableProperty.CreateAttached("LongReleasedCommand", typeof(ICommand), typeof(PressedEffect), (object)null);
        public static ICommand GetLongReleasedCommand(BindableObject view)
        {
            return (ICommand)view.GetValue(LongReleasedCommandProperty);
        }

        public static void SetLongReleasedCommand(BindableObject view, ICommand value)
        {
            view.SetValue(LongReleasedCommandProperty, value);
        }

        public static readonly BindableProperty TapCommandProperty = BindableProperty.CreateAttached("TapCommand", typeof(ICommand), typeof(PressedEffect), (object)null);
        public static ICommand GetTapCommand(BindableObject view)
        {
            return (ICommand)view.GetValue(TapCommandProperty);
        }

        public static void SetTapCommand(BindableObject view, ICommand value)
        {
            view.SetValue(TapCommandProperty, value);
        }

        public static readonly BindableProperty TapParameterProperty = BindableProperty.CreateAttached("TapParameter", typeof(object), typeof(PressedEffect), (object)null);
        public static object GetTapParameter(BindableObject view)
        {
            return view.GetValue(TapParameterProperty);
        }

        public static void SetTapParameter(BindableObject view, object value)
        {
            view.SetValue(TapParameterProperty, value);
        }
    }
}
