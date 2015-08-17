using System;
using Android.Graphics;

namespace MLearning.Droid
{
	public class Configuration
	{
		public static int DIMENSION_DESING_WIDTH= 640;
		public static int DIMENSION_DESING_HEIGHT= 1136; 
		public static int WIDTH_PIXEL;
		public static int HEIGHT_PIXEL;

		public static int getHeight(int value){

			return (HEIGHT_PIXEL)*((value*100)/DIMENSION_DESING_HEIGHT)/100;
		}

		public static int getWidth(int value){
			return (WIDTH_PIXEL)*((value*100)/DIMENSION_DESING_WIDTH)/100;
		}

		public static void setWidthPixel(int value){
			WIDTH_PIXEL=value;
		}

		public static void setHeigthPixel(int value){
			HEIGHT_PIXEL=value;
		}

		public static Bitmap getRoundedShape(Bitmap scaleBitmapImage, int targetWidth, int targetHeight)
		{
			Bitmap targetBitmap = Bitmap.CreateBitmap(targetWidth,
				targetHeight, Bitmap.Config.Argb8888);

			Canvas canvas = new Canvas(targetBitmap);
			Android.Graphics.Path path = new Android.Graphics.Path();
			path.AddCircle(((float)targetWidth - 1) / 2,
				((float)targetHeight - 1) / 2,
				(Math.Min(((float)targetWidth),
					((float)targetHeight)) / 2),
				Android.Graphics.Path.Direction.Ccw);

			canvas.ClipPath(path);
			Bitmap sourceBitmap = scaleBitmapImage;
			canvas.DrawBitmap(sourceBitmap,
				new Rect(0, 0, sourceBitmap.Width,
					sourceBitmap.Height),
				new Rect(0, 0, targetWidth, targetHeight), null);
			return targetBitmap;
		}
	}
}

