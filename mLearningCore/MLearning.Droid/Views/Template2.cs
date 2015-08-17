
using System;
using System.Collections.Generic;
using System.Linq;
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
using Android.Text;
using Android.Widget;

namespace MLearning.Droid
{
	public class Template2 : RelativeLayout
	{
		RelativeLayout mainLayout;
		LinearLayout contenLayout;


		TextView titleHeader;
		TextView content;

		int widthInDp;
		int heightInDp;

		Context context;


		LinearLayout contentListLayout;
		TextView titleHeaderList;
		ListView contentList;
		ImageView imBorderList;


		public Template2 (Context context) :
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
			ini2();
			this.AddView (mainLayout);

		}


		public Bitmap getBitmapFromAsset( String filePath) {
			System.IO.Stream s = context.Assets.Open (filePath);
			Bitmap bitmap = BitmapFactory.DecodeStream (s);

			return bitmap;
		}

		public void ini(){

			int desviacion = 0;

			var textFormat = Android.Util.ComplexUnitType.Px;

			mainLayout = new RelativeLayout (context);
			mainLayout.LayoutParameters = new RelativeLayout.LayoutParams (-1,-1);


			contenLayout = new LinearLayout (context);
			contenLayout.LayoutParameters = new LinearLayout.LayoutParams (-2, -2);
			contenLayout.Orientation = Orientation.Vertical;

			titleHeader = new TextView (context);
			content = new TextView (context);


			titleHeader.Text = "El Perú cuenta con mas de 357000 tipos de aves";
			//titleHeader.SetTextColor (Color.ParseColor ("#FF0080"));
			titleHeader.SetTypeface(null,TypefaceStyle.Bold);
			titleHeader.SetTextSize (textFormat, Configuration.getHeight (52));
			titleHeader.SetMaxWidth (Configuration.getWidth (583));
			//titleHeader.SetMaxHeight (Configuration.getHeight (160));
			//titleHeader.SetX (Configuration.getHeight (28));titleHeader.SetY (Configuration.getWidth (12-desviacion));
			//titleHeader.Ellipsize = TextUtils.TruncateAt.End;
			//titleHeader.SetMaxLines(3);


			content.Text = "Los factores geográficos, climáticos y evolutivos  convierten al Perú en el mejor lugar para realizar la observacion de aves(birthwaching) Tiene 1830 especies de pájaros(segun la lista oficial del SACC/CRAP), tambien es considerado el";
			content.SetTextSize (textFormat, Configuration.getHeight (26));
			content.SetMaxWidth (Configuration.getWidth(583));
			//content.SetX (Configuration.getHeight (28));content.SetY (Configuration.getWidth (211-desviacion));
			//content.Ellipsize = TextUtils.TruncateAt.End;
			//content.SetMaxLines(5);

			contenLayout.AddView (titleHeader);
			contenLayout.AddView(content);

			contenLayout.SetX (Configuration.getHeight (28));contenLayout.SetY (Configuration.getWidth (12-desviacion));


			//LIST

			contentListLayout = new LinearLayout (context);
			contentListLayout.LayoutParameters = new LinearLayout.LayoutParams (Configuration.getWidth(583),-2);
			contentListLayout.Orientation = Orientation.Vertical;
			titleHeaderList = new TextView (context);
			contentList = new ListView (context);


			titleHeaderList.Text = "Tipos de Aves";
			titleHeaderList.SetTextColor (Color.ParseColor ("#FF0080"));
			//titleHeader.SetTypeface(null,TypefaceStyle.Bold);
			titleHeaderList.SetTextSize (textFormat, Configuration.getHeight (38));
			titleHeaderList.SetMaxWidth (Configuration.getWidth (510));
			//titleHeader.SetMaxHeight (Configuration.getHeight (160));
			//titleHeader.SetX (Configuration.getHeight (28));titleHeader.SetY (Configuration.getWidth (12-desviacion));

			//titleHeaderList.Ellipsize = TextUtils.TruncateAt.End;
			//titleHeaderList.SetMaxLines(1);


			contentListLayout.SetBackgroundResource (Resource.Drawable.border);



			contentListLayout.AddView (titleHeaderList);
			contentListLayout.AddView (contentList);


			contentListLayout.SetX (Configuration.getHeight (25));contentListLayout.SetY (Configuration.getWidth (450-desviacion));


			//ENDLIST

			imBorderList = new ImageView (context);

			//mainLayout.AddView (titleHeader); 
			//mainLayout.AddView (content);
			mainLayout.AddView(contenLayout);
			mainLayout.AddView (contentListLayout);
		}

		public void ini2()
		{
			


			String icon = "icons/circulob.png";

			List<TemplateItem> _dataTemplateItem = new List<TemplateItem> ();
			_dataTemplateItem.Add (new TemplateItem (){ im_vinheta = icon, content = "Aves oriundas de la zona sur" });
			_dataTemplateItem.Add (new TemplateItem (){ im_vinheta = icon, content = "Aves oriundas de la zona sur" });
			_dataTemplateItem.Add (new TemplateItem (){ im_vinheta = icon, content = "Aves oriundas de la zona sur" });
			_dataTemplateItem.Add (new TemplateItem (){ im_vinheta = icon, content = "Aves oriundas de la zona sur" });
			_dataTemplateItem.Add (new TemplateItem (){ im_vinheta = icon, content = "Aves oriundas de la zona sur" });
			_dataTemplateItem.Add (new TemplateItem (){ im_vinheta = icon, content = "Aves oriundas de la zona sur" });
			_dataTemplateItem.Add (new TemplateItem (){ im_vinheta = icon, content = "Aves oriundas de la zona sur" });
			_dataTemplateItem.Add (new TemplateItem (){ im_vinheta = icon, content = "Aves oriundas de la zona sur" });
			_dataTemplateItem.Add (new TemplateItem (){ im_vinheta = icon, content = "Aves oriundas de la zona sur" });
			_dataTemplateItem.Add (new TemplateItem (){ im_vinheta = icon, content = "Aves oriundas de la zona sur" });
			_dataTemplateItem.Add (new TemplateItem (){ im_vinheta = icon, content = "Aves oriundas de la zona sur" });
			_dataTemplateItem.Add (new TemplateItem (){ im_vinheta = icon, content = "Aves oriundas de la zona sur" });
			_dataTemplateItem.Add (new TemplateItem (){ im_vinheta = icon, content = "Aves oriundas de la zona sur" });

			contentList.Adapter = new TemplateAdapter (context, _dataTemplateItem);
			contentList.SetBackgroundColor (Color.White);
			contentList.DividerHeight = 0;
			contentList.Clickable = false;
			contentList.ChoiceMode = ChoiceMode.None;



		}
	}
}


