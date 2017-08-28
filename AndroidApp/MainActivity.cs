using Android.App;
using Android.Widget;
using Android.OS;
using SumaLibrary;
using System;

namespace AndroidApp
{
    [Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        SumaLibrary.MyLib SumaLib = new MyLib();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.BtnCalcular);

            TextView textView = FindViewById<TextView>(Resource.Id.textResultado);
            EditText numberA = FindViewById<EditText>(Resource.Id.Number_A);
            EditText numberB = FindViewById<EditText>(Resource.Id.Number_B);

            SumaLib.DivisionPorCero += (x,y) =>
            {
                textView.Text = $"Division por cero entre {x} y {y}\n";
            };

            button.Click += delegate {
                //
                textView.Text = "";
                var A = Convert.ToInt32(numberA.Text);
                var B = Convert.ToInt32(numberB.Text);
                var result = SumaLib.Divide(A, B);
                textView.Text += $"Resultado : {result.ToString()}";
            };
        }
    }
}