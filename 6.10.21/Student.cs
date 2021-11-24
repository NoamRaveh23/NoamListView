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
    public class Student
    {
        private string name;
        private int age;
        private int grade1;
        private int grade2;
        private Bitmap bm;
        private char migdar;

        public Student(string name,int age,int grade1,int grade2,char migdar,Bitmap bm)
        {
            this.name = name;
            this.age = age;
            this.grade1 = grade1;
            this.grade2 = grade2;
            this.migdar = migdar;
            this.bm = bm;
        }

        public string getName()
        {
            return this.name;
        }

        public Bitmap getBm()
        {
            return this.bm;
        }

        public char getMigdar()
        {
            return this.migdar;
        }
        public int getAge()
        {
            return this.age;
        }

        public int getGrade1()
        {
            return this.grade1;

        }

        public int getGrade2()
        {
            return this.grade2;
        }

    }
}