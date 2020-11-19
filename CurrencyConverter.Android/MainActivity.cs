using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Portable;

namespace CurrencyConverter.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var rView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            var layoutManager = new LinearLayoutManager(this) { Orientation = LinearLayoutManager.Vertical };
            rView.SetLayoutManager(layoutManager);
            rView.HasFixedSize = true;
            
            // Plug in my adapter:
            var adapter = new MyAdapter(this, rView, CurrencyKeyData.Data);
            rView.SetAdapter(adapter);
        }
        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}