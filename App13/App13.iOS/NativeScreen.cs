using App13.iOS;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(NativeScreen))]
namespace App13.iOS
{
    class NativeScreen : INativeScreen
    {
        public void OpenNativeScreen()
        {
            var tipViewController = new TipViewController();
            UIApplication.SharedApplication.
                KeyWindow.RootViewController
                .PresentViewController(tipViewController, true, null);
        }
    }
}