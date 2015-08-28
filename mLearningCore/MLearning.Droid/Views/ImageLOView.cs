
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
using Android.Graphics.Drawables;

namespace MLearning.Droid
{
	public class ImageLOView : LinearLayout
	{
		Context context;

		LinearLayout mainContent;

		Bitmap imLO;

		string sTitle;

		string sAuthor;
		string sChapter;

		public string Title{
			get{return sTitle;	}
			set{sTitle = value;	}
		}

		public string Author{
			get{return sAuthor;	}
			set{sAuthor = value;	}
		}

		public string Chapter{
			get{return sChapter;	}
			set{sChapter = value;	}
		}


		Bitmap bmUser;

		public Bitmap ImagenUsuario{
			get{ return bmUser;}
			set{ bmUser = value;}
		}


		public ImageLOView (Context context) :
		base (context)
		{
			this.context = context;
			Initialize ();
		}


		void Initialize ()
		{
			
			this.LayoutParameters = new LinearLayout.LayoutParams (Configuration.getHeight (180), Configuration.getHeight (180));
			//this.SetBackgroundDrawable (imLO);

		}



		private Bitmap _imageBitmap;
		public Bitmap ImageBitmap{
			get{ return _imageBitmap;}
			set{ _imageBitmap = value;			

				Drawable dr = new BitmapDrawable (Bitmap.CreateScaledBitmap (_imageBitmap, Configuration.getWidth (180), Configuration.getHeight (180), true));
				this.SetBackgroundDrawable (dr);
			}

		}



	}
}

