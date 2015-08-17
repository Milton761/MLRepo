﻿
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
	public class LOContainerView : RelativeLayout
	{
		RelativeLayout mainLayout;
		LinearLayout linearImageLO;
		LinearLayout linearLike;

		TextView txtNameLO;
		TextView txtChapter;
		TextView txtAuthor;
		TextView txtLike;

		int widthInDp;
		int heightInDp;

		ImageView imgHeart; 


		LinearLayout linearTextLO;
		LinearLayout linearUsers;
		LinearLayout linearContainer;
		LinearLayout linearItemUSer;

		ListView commentList;
		List<CommentDataRow> _mCommentData;


		Context context;

		public LOContainerView (Context context) :
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
			iniImageUser ();

		}

		private void ini(){
			mainLayout = new RelativeLayout (context);
			mainLayout.LayoutParameters = new RelativeLayout.LayoutParams (-1,-1);	
			mainLayout.SetBackgroundColor(Color.ParseColor("#ffffff"));

			linearContainer = new LinearLayout (context);
			linearImageLO = new LinearLayout (context);
			linearTextLO = new LinearLayout (context);
			linearLike = new LinearLayout (context);

			linearUsers = new LinearLayout (context);

			txtAuthor = new TextView (context);
			txtChapter= new TextView (context);
			txtNameLO = new TextView (context);
			txtLike = new TextView (context);



			imgHeart= new ImageView (context);

			commentList = new ListView (context);

			linearContainer.LayoutParameters = new LinearLayout.LayoutParams (-1, -1);
			linearImageLO.LayoutParameters = new LinearLayout.LayoutParams (-1,Configuration.getHeight(372));
			linearTextLO.LayoutParameters = new LinearLayout.LayoutParams (-1, Configuration.getHeight(250));
			linearLike.LayoutParameters = new LinearLayout.LayoutParams (Configuration.getWidth(120), Configuration.getHeight(80));
			linearUsers.LayoutParameters = new LinearLayout.LayoutParams (-1,-2);

			linearTextLO.Orientation = Orientation.Vertical;
			linearTextLO.SetGravity(GravityFlags.Right);

			linearLike.Orientation = Orientation.Vertical;
			linearLike.SetGravity (GravityFlags.Center);

			linearUsers.Orientation = Orientation.Horizontal;
			linearUsers.SetGravity (GravityFlags.Center);

			linearContainer.Orientation = Orientation.Vertical;
			//linearContainer.SetGravity (GravityFlags.Center);

			Drawable d = new BitmapDrawable (Bitmap.CreateScaledBitmap (getBitmapFromAsset ("images/fondounidad.png"), 480, 640, true));
			linearImageLO.SetBackgroundDrawable (d);

			imgHeart.SetImageBitmap (Bitmap.CreateScaledBitmap (getBitmapFromAsset ("images/like.png"), Configuration.getWidth(43), Configuration.getHeight(43), true));






			txtAuthor.Text = "Author : David Spencer";
			txtChapter.Text = "Flora y Fauna";
			txtNameLO.Text = "Camino Inca";
			txtLike.Text = "10";

			txtAuthor.SetTextColor (Color.ParseColor("#ffffff"));
			txtChapter.SetTextColor (Color.ParseColor("#ffffff"));
			txtNameLO.SetTextColor (Color.ParseColor("#ffffff"));
			txtLike.SetTextColor (Color.ParseColor("#ffffff"));

			txtAuthor.Gravity = GravityFlags.Right;
			txtChapter.Gravity = GravityFlags.Right;
			txtNameLO.Gravity = GravityFlags.Right;
			txtLike.Gravity = GravityFlags.Center;

			linearTextLO.AddView (txtNameLO);
			linearTextLO.AddView (txtChapter);
			linearTextLO.AddView (txtAuthor);

			linearLike.AddView (imgHeart);
			linearLike.AddView (txtLike);


			_mCommentData = new List<CommentDataRow> ();
			_mCommentData.Add (new CommentDataRow (){im_profile="images/e1.jpg" , name="Ryan Elliot", date = "10:00pm", comment = "Esto es un comentario" });
			_mCommentData.Add (new CommentDataRow (){im_profile="images/e1.jpg" , name="Ryan Elliot", date = "10:00pm", comment = "Esto es un comentario" });
			_mCommentData.Add (new CommentDataRow (){im_profile="images/e1.jpg" , name="Ryan Elliot", date = "10:00pm", comment = "Esto es un comentario" });
			_mCommentData.Add (new CommentDataRow (){im_profile="images/e1.jpg" , name="Ryan Elliot", date = "10:00pm", comment = "Esto es un comentario" });
			_mCommentData.Add (new CommentDataRow (){im_profile="images/e1.jpg" , name="Ryan Elliot", date = "10:00pm", comment = "Esto es un comentario" });
			_mCommentData.Add (new CommentDataRow (){im_profile="images/e1.jpg" , name="Ryan Elliot", date = "10:00pm", comment = "Esto es un comentario" });
			_mCommentData.Add (new CommentDataRow (){im_profile="images/e1.jpg" , name="Ryan Elliot", date = "10:00pm", comment = "Esto es un comentario" });
			_mCommentData.Add (new CommentDataRow (){im_profile="images/e1.jpg" , name="Ryan Elliot", date = "10:00pm", comment = "Esto es un comentario" });

			commentList.Adapter = new CommentListViewAdapter (context, _mCommentData);
			commentList.LayoutParameters = new LinearLayout.LayoutParams (-1, 800);


			commentList.SetX (0);commentList.SetY (Configuration.getHeight (530));

			linearTextLO.SetX (0); linearTextLO.SetY (Configuration.getHeight(250));
			//linearImageLO.SetX (0); linearImageLO.SetY (0);
			linearLike.SetX (0); linearLike.SetY (Configuration.getHeight(256));
			linearContainer.SetX (0); linearContainer.SetY (0);

			linearContainer.AddView (linearImageLO);
			linearContainer.AddView (linearUsers);
			mainLayout.AddView (linearContainer);

			//mainLayout.AddView (linearImageLO);
			mainLayout.AddView (linearTextLO);

			mainLayout.AddView (linearLike);
			mainLayout.AddView (commentList);

			this.AddView (mainLayout);


		}

		private void iniImageUser(){
			linearUsers.RemoveAllViews ();

			ItemUser item1 = new ItemUser (context, "images/e1.jpg");
			item1.NameUser = "Jason";

			ItemUser item2 = new ItemUser (context, "images/e2.jpg");
			item2.NameUser = "Davidson";

			ItemUser item3 = new ItemUser (context, "images/e3.jpg");
			item3.NameUser = "Jeremy";

			ItemUser item4 = new ItemUser (context, "images/e4.jpg");
			item4.NameUser = "katherine";

			ItemUser item5 = new ItemUser (context, "images/e5.jpg");
			item5.NameUser = "Kate";


			linearUsers.AddView (item1);
			linearUsers.AddView (item2);
			linearUsers.AddView (item3);
			linearUsers.AddView (item4);
			linearUsers.AddView (item5);


		}


		public Bitmap getBitmapFromAsset( String filePath) {
			System.IO.Stream s =context.Assets.Open (filePath);
			Bitmap bitmap = BitmapFactory.DecodeStream (s);

			return bitmap;
		}
	}
}

