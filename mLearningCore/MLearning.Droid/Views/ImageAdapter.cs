using System;
using Android.Widget;
using Android.Content;
using System.Collections.Generic;
using Android.Graphics;


namespace MLearning.Droid
{
	public class ImageAdapter:BaseAdapter<ImageGallery>
	{

		Context context;
		List<ImageGallery> list;

		public ImageAdapter (Context context, List<ImageGallery> list):base()
		{
			this.context = context;
			this.list = list;
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override ImageGallery this[int position]{
			get{ return list [position];}
		}

		public override int Count {
			get {
				return list.Count;
			}
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			
			var metrics = context.Resources.DisplayMetrics;
			float  widthInDp = ((int)metrics.WidthPixels);
			float heightInDp = ((float)metrics.HeightPixels);

			LinearLayout view = new LinearLayout (context);

			LinearLayout contentLayout = new LinearLayout (context);
			contentLayout.Orientation = Orientation.Horizontal;
			contentLayout.LayoutParameters = new LinearLayout.LayoutParams (-2, -2);


			int tam_row  = list [position].imageItem.Count;

			List<ImageView> row_images = new List<ImageView>();
			List<Bitmap> bimage = new List<Bitmap>();
			List<float> hs = new List<float> ();
			List<float> ws = new List<float> ();

			for (int i = 0; i < tam_row; i++) {
				bimage.Add(getBitmapFromAsset (list [position].imageItem [i]));
				hs.Add (bimage [i].Height);
				ws.Add (bimage [i].Width);

				Console.WriteLine ("ADDING SIZES: " + ws[i]+" "+hs[i]);


			}

			float max = hs [0];
			Console.WriteLine ("MAX " + hs[0]);

			List<float> rstam = new List<float> ();

			float sum = 0;

			for (int i = 0; i < tam_row; i++) {

				rstam.Add (max / hs [i]);
				hs [i] = hs [i] * rstam [i];
				ws [i] = ws [i] * rstam [i];
				sum += ws [i];
				Console.WriteLine ("rsTAM = "+ rstam[i] + " HS = " + hs[i] + " WS = "+ws[i] + " sum = " + sum);
			}

			float resWidth = Configuration.DIMENSION_DESING_WIDTH / sum;

			//resizing
			for (int i = 0; i < tam_row; i++) 
			{
				hs [i] = hs [i] * resWidth;
				ws [i] = ws [i] * resWidth;
			}

			int pad_size = Configuration.getWidth (5);
			for (int i = 0; i < tam_row; i++) {




				//Console.WriteLine (bimage.Width + " __________ " + bimage.Height + Configuration.WIDTH_PIXEL + " " + Configuration.HEIGHT_PIXEL);


				row_images.Add(new ImageView(context));
				row_images[i].SetImageBitmap (Bitmap.CreateScaledBitmap (bimage[i], Configuration.getWidth ((int)ws[i]), Configuration.getHeight ((int)hs[i]), true));
				row_images[i].SetPadding(pad_size,pad_size,pad_size,pad_size);
				contentLayout.AddView (row_images [i]);

			

			}

			//row_images [tam_row - 1].SetPadding (0, 0, pad_size,0);
			contentLayout.SetBackgroundColor(Color.White);

			view.AddView (contentLayout);

			return view;
		}

		public Bitmap getBitmapFromAsset( String filePath) {
			System.IO.Stream s =context.Assets.Open (filePath);
			Bitmap bitmap = BitmapFactory.DecodeStream (s);

			return bitmap;
		}


	}
}

