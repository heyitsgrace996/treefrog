using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace Treefrog.Behaviors
{
    public class ButtonAnimationBehavior : Behavior<Button>
    {
        protected override void OnAttachedTo(Button bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Clicked += OnButtonClicked;
        }

        protected override void OnDetachingFrom(Button bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Clicked -= OnButtonClicked;
        }

        private async void OnButtonClicked(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                await button.ScaleTo(1.2, 250); // Scale up
                await button.ScaleTo(1.0, 250); // Scale down
            }
        }
    }
}
