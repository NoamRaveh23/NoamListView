using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6._10._21
{
    [Activity(Label = "DisplayActivity")]
    public class DisplayActivity : Activity
    {
        ListView lv;
        Button b1;
        StudentAdapter adapter;
        Boolean b = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.display);
            // Create your application here
            lv = (ListView)FindViewById(Resource.Id.lv);
            b1 = (Button)FindViewById(Resource.Id.back);
            b1.Click += B_Click;
            adapter = new StudentAdapter(this, MainActivity.lst);
            lv.Adapter = adapter;
            lv.ItemClick += Lv_ItemClick;
            lv.ItemLongClick += Lv_ItemLongClick;

        }

        private void Lv_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
            builder.SetTitle("remove?");
            builder.SetMessage("do yo want to remove?");
            builder.SetCancelable(true);
            builder.SetPositiveButton("yes", okAction);
            builder.SetNegativeButton("no", CancelAction);
            Android.App.AlertDialog dialog = builder.Create();
            dialog.Show();
            if (b)
            {
                int position = e.Position;
                MainActivity.lst.RemoveAt(position);
                adapter.NotifyDataSetChanged();
                b = false;
            }
        }

        private void CancelAction(object sender, DialogClickEventArgs e)
        {
            b = false;
        }

        private void okAction(object sender, DialogClickEventArgs e)
        {
            b = true;
        }

        private void Lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int pos = e.Position;
            var second = new Intent(this, typeof(enActivity));
            second.PutExtra("fn", pos);
            StartActivity(second);
            OnResume();
        }
        private void B_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}