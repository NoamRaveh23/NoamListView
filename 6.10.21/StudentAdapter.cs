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
using Android.Views;

namespace _6._10._21
{
    public class StudentAdapter :BaseAdapter<Student>
    {
        Context context;
        List<Student> objects;

        public StudentAdapter(Context context, List<Student> objects)
        {
            this.context = context;
            this.objects = objects;
        }

        public List<Student>GetList()
        {
            return this.objects;
        }

        public override long GetItemId(int position)
        {
            return position;
        }


        public override int Count
        {
            get { return this.objects.Count; }
        }

        public override Student this[int position]
        {
            get { return this.objects[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater layoutInflater = ((DisplayActivity)context).LayoutInflater;
            View view = layoutInflater.Inflate(Resource.Layout.XMLFile1, parent, false);
            TextView name = view.FindViewById<TextView>(Resource.Id.name2);
            TextView age = view.FindViewById<TextView>(Resource.Id.age2);
            TextView gr2 = view.FindViewById<TextView>(Resource.Id.grade3);
            ImageView img = view.FindViewById<ImageView>(Resource.Id.im);
            Student temp = (objects[position]);
            if (temp!=null)
            {
                name.Text = "" + temp.getName();
                age.Text = "Age: " + temp.getAge();
                gr2.Text = "Grade: " + (temp.getGrade2()+temp.getGrade1())/2;
                img.SetImageBitmap(temp.getBm());
            }
            return view;
        }
    }
}