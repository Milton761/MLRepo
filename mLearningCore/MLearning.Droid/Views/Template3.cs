using System;
using Android.Widget;
using Android.Content;
using Android.Graphics;
using System.Collections.Generic;

namespace MLearning.Droid
{
	public class Template3: RelativeLayout
	{

		RelativeLayout mainLayout;
		LinearLayout contenLayout;


		int widthInDp;
		int heightInDp;


		Context context;
		ListView contentList;

		public Template3 (Context context) :
		base (context)
		{
			this.context = context;
			Initialize ();
		}

		void Initialize ()
		{
			var metrics = Resources.DisplayMetrics;
			widthInDp = ((int)metrics.WidthPixels);
			heightInDp = ((int)metrics.HeightPixels);
			Configuration.setWidthPixel (widthInDp);
			Configuration.setHeigthPixel (heightInDp);

			ini ();

			this.AddView (mainLayout);

			Console.WriteLine ("DONE initialize");

		}


		public Bitmap getBitmapFromAsset( String filePath) {
			System.IO.Stream s = context.Assets.Open (filePath);
			Bitmap bitmap = BitmapFactory.DecodeStream (s);

			return bitmap;
		}

		public void ini(){

			mainLayout = new RelativeLayout (context);
			mainLayout.LayoutParameters = new RelativeLayout.LayoutParams (-1,-1);

			contenLayout = new LinearLayout (context);
			contenLayout.LayoutParameters = new LinearLayout.LayoutParams (-2, -2);
			contenLayout.Orientation = Orientation.Vertical;

			contentList = new ListView (context);




			List<ImageGallery> _dataImageItem = new List<ImageGallery> ();

			ImageGallery row_item1 = new ImageGallery();

			row_item1.new_item ("images/e1.jpg");
			row_item1.new_item ("images/e2.jpg");

			ImageGallery row_item2 = new ImageGallery();
			row_item2.new_item ("images/e3.jpg");
			row_item2.new_item ("images/e4.jpg");


			ImageGallery row_item3 = new ImageGallery();
			row_item3.new_item ("images/e5.jpg");
			row_item3.new_item ("images/e5.jpg");
			row_item3.new_item ("images/fondounidad.png");



			_dataImageItem.Add (row_item1);
			_dataImageItem.Add (row_item2);
			_dataImageItem.Add (row_item3);
			contentList.Adapter = new ImageAdapter (context, _dataImageItem);
			//contentList.DividerHeight = Configuration.getWidth (10);
			contentList.SetBackgroundColor (Color.White);

			Console.WriteLine ("DONE ADAPTER");


			contenLayout.AddView (contentList);


			mainLayout.AddView (contenLayout);

			Console.WriteLine ("DONE ini");

		}


	}
}

