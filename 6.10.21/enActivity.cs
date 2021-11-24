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
using Android.Graphics;

namespace _6._10._21
{
    [Activity(Label = "enActivity")]
    public class enActivity : Activity
    {
        EditText nm, ag, gr;
        Button b;
        Student s,temp;
        RadioButton girl, boy;
        ImageView img;
        Bitmap img2;
        char migdar;
        Button tp;
        int pos;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.editstud);
            // Create your application here
            pos = Intent.GetIntExtra("fn",-1);
            img = (ImageView)FindViewById(Resource.Id.img);
            nm = (EditText)FindViewById(Resource.Id.nm);
            ag= (EditText)FindViewById(Resource.Id.ag);
            gr = (EditText)FindViewById(Resource.Id.gr);
            b = (Button)FindViewById(Resource.Id.save);
            girl = (RadioButton)FindViewById(Resource.Id.girl);
            boy = (RadioButton)FindViewById(Resource.Id.boy);
            tp = (Button)FindViewById(Resource.Id.tp);
            tp.Click += Tp_Click;
            boy.Click += Boy_Click;
            girl.Click += Girl_Click;
            if (pos != -1)
            {
                s = MainActivity.lst[pos];
                nm.Text = s.getName();
                ag.Text = Convert.ToString(s.getAge());
                gr.Text = Convert.ToString((s.getGrade1() + s.getGrade2()) / 2);
                img.SetImageBitmap(s.getBm());
                img2 = s.getBm();
                if (s.getMigdar()=='b')
                {
                    boy.Checked = true;
                }
                else
                {
                    girl.Checked = true;
                }
            }
            b.Click += B_Click;

        }


        private void B_Click(object sender, EventArgs e)
        {
            if (pos != -1)
            {
                temp = new Student(nm.Text, Convert.ToInt32(ag.Text), Convert.ToInt32(gr.Text), Convert.ToInt32(gr.Text), s.getMigdar(), img2);
                MainActivity.lst[pos] = temp;
            }
            else
            {
                ad();
            }
            Finish();

        }


        private void Tp_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Android.Provider.MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 1);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 1)
            {
                if (resultCode == Result.Ok)
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
        private void ad()
        {
            if (img2 == null)
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
            s = new Student(nm.Text, Convert.ToInt32(ag.Text), Convert.ToInt32(gr.Text), Convert.ToInt32(gr.Text), migdar, img2);
            img2 = null;
            MainActivity.lst.Add(s);
            img = null;

            nm.Text = "";
            ag.Text = "";
            gr.Text = "";
        }
    }
}