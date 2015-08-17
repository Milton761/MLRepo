
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace MLearning.Droid
{
	public class ItemUser : LinearLayout
	{

		Context context;

		ImageView img;
		TextView txtName;
		String path;
		public ItemUser (Context context, String path) :base (context)
		{
			this.context = context;
			this.path = path;
			Initialize ();
		}


		void Initialize ()
		{
			this.LayoutParameters = new LinearLayout.LayoutParams(Configuration.WIDTH_PIXEL/6,Configuration.getHeight(148));
			this.Orientation = Orientation.Vertical;
			this.SetGravity (GravityFlags.Center);

			img = new ImageView (context);
			txtName = new TextView (context);

			txtName.Gravity = GravityFlags.Center;

			iniUserList(img,path);
			txtName.SetTextColor (Color.ParseColor("#3d3d3d"));
			txtName.Text = "";

			this.AddView (img);
			this.AddView (txtName);

			//this.SetBackgroundColor (Color.Red);

		}

		String _nameUser;
		public String NameUser{
			get{ return _nameUser;}
			set{_nameUser = value;
				txtName.Text = _nameUser;
			}

		}

		private void iniUserList(ImageView imguserlist,String path){		


			Bitmap newbm = Configuration.getRoundedShape(Bitmap.CreateScaledBitmap(getBitmapFromAsset (path), Configuration.getWidth(200), Configuration.getHeight(200), true)
				,Configuration.getWidth(85),Configuration.getHeight(85));

			imguserlist.SetImageBitmap (newbm);

		}

		public Bitmap getBitmapFromAsset( String filePath) {
			System.IO.Stream s =context.Assets.Open (filePath);
			Bitmap bitmap = BitmapFactory.DecodeStream (s);

			return bitmap;
		}
	}
}

