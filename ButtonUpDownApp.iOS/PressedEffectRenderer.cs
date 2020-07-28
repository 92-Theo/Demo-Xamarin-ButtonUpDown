using ButtonUpDownApp.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: ResolutionGroupName("MyApp")]
[assembly: ExportEffect(typeof(PressedEffectRenderer), "PressedEffect")]
namespace ButtonUpDownApp.iOS
{
    public class PressedEffectRenderer : Xamarin.Forms.Platform.iOS.PlatformEffect
    {
        private bool _attached;
        private readonly UILongPressGestureRecognizer _longPressRecognizer;
        private readonly UITapGestureRecognizer _tapRecognizer;
        public PressedEffectRenderer()
        {
            _longPressRecognizer = new UILongPressGestureRecognizer(HandleLongClick);
            _tapRecognizer = new UITapGestureRecognizer(HandleClick);
        }

        protected override void OnAttached()
        {
            if (!_attached)
            {
                if (Control != null)
                {
                    Control.AddGestureRecognizer(_longPressRecognizer);
                    Control.UserInteractionEnabled = true;
                }
                else
                {
                    Container.AddGestureRecognizer(_longPressRecognizer);
                }
                _attached = true;
            }
        }

        private void HandleClick()
        {
            var command = PressedEffect.GetTapCommand(Element);
            command?.Execute(PressedEffect.GetTapParameter(Element));
        }

        private void HandleLongClick(UILongPressGestureRecognizer recognizer)
        {
            if (recognizer.State == UIGestureRecognizerState.Began)
            {
                var command = PressedEffect.GetLongPressedCommand(Element);
                command?.Execute(PressedEffect.GetLongParameter(Element));
            }
            else if (recognizer.State == UIGestureRecognizerState.Ended)
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
                    Control.RemoveGestureRecognizer(_longPressRecognizer);
                    Control.RemoveGestureRecognizer(_tapRecognizer);
                }
                else
                {
                    Container.RemoveGestureRecognizer(_longPressRecognizer);
                    Container.RemoveGestureRecognizer(_tapRecognizer);
                }
                _attached = false;
            }
        }
    }
}