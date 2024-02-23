//Makes the button enlarge upon clicking

using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace Treefrog.Behaviors
{
    public class ImageButtonAnimationBehavior : Behavior<ImageButton>
    {
        protected override void OnAttachedTo(ImageButton bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Clicked += OnImageButtonClicked;
        }

        protected override void OnDetachingFrom(ImageButton bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Clicked -= OnImageButtonClicked;
        }

        private async void OnImageButtonClicked(object sender, System.EventArgs e)
        {
            var imageButton = sender as ImageButton;
            if (imageButton != null)
            {
                await imageButton.ScaleTo(1.2, 250); 
                await imageButton.ScaleTo(1.0, 250); 
            }
        }
    }
}
