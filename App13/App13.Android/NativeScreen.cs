using Android.Content;
using App13.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(NativeScreen))]
namespace App13.Droid
{
    class NativeScreen : INativeScreen
    {
        public void OpenNativeScreen()
        {
            Intent intent = new Intent(Forms.Context,
                typeof(Main));
            Forms.Context.StartActivity(intent);
        }
    }
}