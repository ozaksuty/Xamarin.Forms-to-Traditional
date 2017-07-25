using Foundation;
using UIKit;

namespace App13.iOS
{
    [Register("TipViewController")]
    public class TipViewController : UIViewController
    {
        public TipViewController()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            UITextField myText = new UITextField(
                new CoreGraphics.CGRect(0, 28,
                View.Bounds.Width, 35))
            {
                KeyboardType = UIKeyboardType.Default,
                BorderStyle = UITextBorderStyle.RoundedRect,
                Placeholder = "Tip"
            };

            UIButton myButton = new UIButton(UIButtonType.Custom)
            {
                Frame = new CoreGraphics.CGRect(0, 70, View.Bounds.Width, 45),
                BackgroundColor = UIColor.Red,

            };
            myButton.SetTitle("CALCULATE", UIControlState.Normal);

            UILabel myLabel = new UILabel(new CoreGraphics.CGRect(20, 145, 100, 20))
            {
                TextColor = UIColor.Black
            };

            myButton.TouchUpInside += (s, e) =>
            {
                double bill;

                if (double.TryParse(myText.Text, out bill))
                {
                    var tip = bill * 0.15;
                    var total = bill + tip;

                    var _tip = new Tip
                    {
                        tip = tip,
                        total = total
                    };

                    DismissViewController(false, () =>
                    {
                        Xamarin.Forms.MessagingCenter.Send<App, Tip>
                            ((App)Xamarin.Forms.Application.Current,
                            "tip", _tip);
                    });
                }
            };

            View.AddSubviews(myText, myButton, myLabel);
        }
    }
}