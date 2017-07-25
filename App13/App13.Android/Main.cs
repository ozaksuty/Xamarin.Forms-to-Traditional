using Android.App;
using Android.OS;
using Android.Widget;
using System;

namespace App13.Droid
{
    [Activity(Label = "Main")]
    public class Main : Activity
    {
        EditText inputBill;
        Button calculateButton;
        TextView outputTip;
        TextView outputTotal;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            inputBill = FindViewById<EditText>(Resource.Id.inputBill);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            outputTip = FindViewById<TextView>(Resource.Id.outputTip);
            outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);

            calculateButton.Click += OnCalculateClick;
        }
        void OnCalculateClick(object sender, EventArgs e)
        {
            string text = inputBill.Text;

            double bill;

            if (double.TryParse(text, out bill))
            {
                var tip = bill * 0.15;
                var total = bill + tip;

                var _tip = new Tip
                {
                    tip = tip,
                    total = total
                };

                Xamarin.Forms.MessagingCenter.Send<App, Tip>
                    ((App)Xamarin.Forms.Application.Current,
                    "tip", _tip);

                Finish();
                //outputTip.Text = tip.ToString("C");
                //outputTotal.Text = total.ToString("C");
            }
        }
    }
}