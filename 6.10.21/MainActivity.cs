using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System.IO;
using System.Text;
using Java.IO;
using Android.Content;
using System;
using Android.Graphics;
using System.Collections.Generic;
using Android.App;

namespace _6._10._21
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView name, age, grade1, grade2;
        Button dsn,atl,dlv,tp;
        public static List<Student> lst = new List<Student>();
        StudentAdapter adapter;
        ListView lv;
        Student s;
        string studNames;
        char migdar;
        LinearLayout custom_layout;
        RadioButton girl, boy;
        Button plus;
        ImageView img;
        Bitmap img2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            lst.Add(new Student("rotem", 5, 50, 50,'b', BitmapFactory.DecodeResource(Resources, Resource.Drawable.boy)));
            lst.Add(new Student("rrr", 6, 70, 60,'b', BitmapFactory.DecodeResource(Resources, Resource.Drawable.boy))) ;
            lst.Add(new Student("rrrr", 7, 60, 70,'g', BitmapFactory.DecodeResource(Resources, Resource.Drawable.girl)));
            name = (TextView)FindViewById(Resource.Id.name);
            age = (TextView)FindViewById(Resource.Id.age);
            grade1 = (TextView)FindViewById(Resource.Id.grade1);
            grade2 = (TextView)FindViewById(Resource.Id.grade2);
            dsn = (Button)FindViewById(Resource.Id.DisplayStudentsNames);
            atl = (Button)FindViewById(Resource.Id.addToList);
            dlv = (Button)FindViewById(Resource.Id.DisplayListView);
            girl = (RadioButton)FindViewById(Resource.Id.girl);
            boy = (RadioButton)FindViewById(Resource.Id.boy);
            tp = (Button)FindViewById(Resource.Id.tp);
            img = (ImageView)FindViewById(Resource.Id.img);
            plus = (Button)FindViewById(Resource.Id.plus);
            atl.Click += Atl_Click;
            dsn.Click += dsn_Click;
            dlv.Click += Dlv_Click;
            boy.Click += Boy_Click;
            girl.Click += Girl_Click;
            tp.Click += Tp_Click;
            plus.Click += Plus_Click;
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(enActivity));
            StartActivity(intent);
        }

        private void Dlv_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this,typeof(DisplayActivity));
            StartActivity(intent);
        }

        private void Tp_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Android.Provider.MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 1);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode==1)
            {
                if (resultCode==Result.Ok)
                {
                    img2 = (Bitmap)data.Extras.Get("data");
                    img.SetImageBitmap(img2);

                }
            }
        }

        private void Girl_Click(object sender, EventArgs e)
        {
            migdar = 'g';
        }

        private void Boy_Click(object sender, EventArgs e)
        {
            migdar = 'b';
        }
        private void Atl_Click(object sender, EventArgs e)
        {
            if (img2==null)
            {
                if (migdar.Equals('b'))
                {
                    img2 = BitmapFactory.DecodeResource(Resources, Resource.Drawable.boy);
                }
                else
                {
                    img2 = BitmapFactory.DecodeResource(Resources, Resource.Drawable.girl);
                }
            }
            s = new Student(name.Text, Convert.ToInt32(age.Text), Convert.ToInt32(grade1.Text), Convert.ToInt32(grade2.Text),migdar,img2);
            img2 = null;
            lst.Add(s);
            img = null;

            name.Text="";
            age.Text="";
            grade1.Text="";
            grade2.Text="";
            Toast.MakeText(this, "there are "+lst.Count +" students", ToastLength.Long).Show();
        }

        private void dsn_Click(object sender, EventArgs e)
        {
            studNames="";
            for (int i=0;i<lst.Count;i++)
            {
                studNames=studNames+lst[i].getName()+" ";
            }
            Toast.MakeText(this,studNames, ToastLength.Long).Show();
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void onResume()
        {
            if (adapter!=null)
            {
                adapter.NotifyDataSetChanged();
            }
        }
    }
}