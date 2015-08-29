
using System;
using System.Collections.Generic;
using Android.Content;
using Android.Util;
using Android.Widget;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace MLearning.Droid
{
	public class WallView: RelativeLayout
	{

		RelativeLayout _mainLayout;
		LinearLayout _fondo2;


		//section_1
		RelativeLayout _contentRLayout_S1;
		TextView _txtTitle_S1;
		TextView _txtAuthor_S1;
		ImageView _imAuthor_S1;
		TextView _txtChapter_S1;

		LinearLayout _itemsLayout_S1;
		List<ImageView> _imItem_S1;
		List<TextView> _txtItem_S1;

		List<ImageLOView> _ListLOImages_S2;



		string _title;
		public string Title{
			set{_title = value;
				_txtTitle_S1.Text = _title;}
		}

		string _author;
		public string Author{
			set{_author = value;
				_txtAuthor_S1.Text = _author;}
		}

		string _chapter;
		public string Chapter{
			set{_chapter = value;
				_txtChapter_S1.Text = _chapter;}
		}

		Bitmap _imageAuthor;
		public Bitmap ImageAuthor {
			set{_imageAuthor = value;
				_imAuthor_S1.SetImageBitmap (_imageAuthor);}
		
		}

		string _info1;
		public string Info1{
			set{_info1 = value;
				_txtInfo1_S3.Text = _info1;}
		}

		string _info2;
		public string Info2{
			set{_info2 = value;
				_txtInfo2_S3.Text = _info2;}
		}
		string _info3;
		public string Info3{
			set{_info3 = value;
				_txtInfo3_S3.Text = _info3;}
		}


		public List<ImageLOView> ListImages{
			set{ _ListLOImages_S2 = value;
			
				for (int i = 0; i < _ListLOImages_S2.Count; i++) {

					_images_S2.AddView (_ListLOImages_S2[i]);
					_ListLOImages_S2 [i].Click += delegate {
						Drawable dr = new BitmapDrawable (_ListLOImages_S2 [i].ImageBitmap);
						_fondo2.SetBackgroundDrawable (dr);
						_txtTitle_S1.Text = _ListLOImages_S2 [i].Title;
						_txtChapter_S1.Text = _ListLOImages_S2 [i].Chapter;
						_txtAuthor_S1.Text = _ListLOImages_S2 [i].Author;
					};
				}
			}
		}

		public ImageView OpenUnits{
			get{return _imItems_S4 [0]; }
		}

		public ImageView OpenComments{
			get{return _imItems_S4 [1]; }
		}

		public ImageView OpenLO{
			get{return _imItems_S4 [2]; }
		}

		public ImageView OpenChat{
			get{return _imItems_S4 [3]; }
		}

		public ImageView OpenTasks{
			get{return _imItems_S4 [4]; }
		}
		//section_2


		HorizontalScrollView _contentScrollView_S2;
		LinearLayout _images_S2;


		private void imLoClick(object sender, EventArgs eventArgs)
		{
			ImageLOView imView = sender as ImageLOView;
			Drawable imf = new BitmapDrawable(imView.ImageBitmap);
			_fondo2.SetBackgroundDrawable(imf);

			//actualizar titulo, nombreAuthor, capitulo, imAuthor
			_txtTitle_S1.Text = imView.Title;
			_txtAuthor_S1.Text = imView.Author;
			_txtChapter_S1.Text = imView.Chapter;
			_imAuthor_S1.SetImageBitmap (imView.ImagenUsuario);
		}

		//section_3

		LinearLayout _contentLLayout_S3;
		TextView _txtInfo1_S3;
		TextView _txtInfo2_S3;
		TextView _txtInfo3_S3;

		//section_4

		LinearLayout _contentLLayout_S4;
		List<ImageView> _imItems_S4;


		int widthInDp;
		int heightInDp;


		Context context;

		public WallView (Context context) :
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

			this.AddView (_mainLayout);



		}


		public Bitmap getBitmapFromAsset( String filePath) {
			System.IO.Stream s = context.Assets.Open (filePath);
			Bitmap bitmap = BitmapFactory.DecodeStream (s);

			return bitmap;
		}

		public void ini(){

			_mainLayout = new RelativeLayout (context);

			var textFormat = Android.Util.ComplexUnitType.Px;

			_mainLayout.LayoutParameters = new RelativeLayout.LayoutParams (-1, -1);

			_fondo2 = new LinearLayout (context);
			_fondo2.LayoutParameters = new LinearLayout.LayoutParams (-1, Configuration.getHeight (934));
			_fondo2.SetY (Configuration.getHeight (109));

			Drawable dr1 = new BitmapDrawable (getBitmapFromAsset("icons/fondoselec.png"));
			_fondo2.SetBackgroundDrawable (dr1);

			_mainLayout.AddView (_fondo2);

			//section1-----------------------------------------------
			_contentRLayout_S1 = new RelativeLayout(context);
			_txtTitle_S1 = new TextView (context);
			_txtAuthor_S1 = new TextView (context);
			_imAuthor_S1 = new ImageView (context);
			_txtChapter_S1 = new TextView (context);

			_itemsLayout_S1 = new LinearLayout (context);//not used
			_imItem_S1 = new List<ImageView> ();
			_txtItem_S1 = new List<TextView>();





			//_mainLayout.AddView (_txtTitle_S1);
			//_mainLayout.AddView (_txtAuthor_S1);
			_mainLayout.AddView (_imAuthor_S1);

			//_mainLayout.AddView (_txtChapter_S1);







			_contentRLayout_S1.LayoutParameters = new RelativeLayout.LayoutParams (-1, Configuration.getHeight (480));


			LinearLayout _linearTitle = new LinearLayout (context);
			_linearTitle.LayoutParameters = new LinearLayout.LayoutParams (-1, -2);
			_linearTitle.SetGravity (Android.Views.GravityFlags.Center);
			_linearTitle.AddView (_txtTitle_S1);
			_linearTitle.SetY (Configuration.getHeight (60));
			_mainLayout.AddView (_linearTitle);

			//_txtTitle_S1.SetX (Configuration.getWidth (245));_txtTitle_S1.SetY (Configuration.getHeight (60));

			Bitmap newbm = Configuration.getRoundedShape(Bitmap.CreateScaledBitmap( getBitmapFromAsset("icons/imgautor.png"), Configuration.getWidth(170), Configuration.getWidth(170), true),Configuration.getWidth(170),Configuration.getHeight(170));
			

		//	Bitmap test = Configuration.GetRoundedCornerBitmap (getBitmapFromAsset("icons/imgc.png"));


			_imAuthor_S1.SetImageBitmap (newbm);

			_imAuthor_S1.SetX (Configuration.getWidth (240));_imAuthor_S1.SetY (Configuration.getHeight (189));

			LinearLayout _linearAuthor = new LinearLayout (context);
			_linearAuthor.LayoutParameters = new LinearLayout.LayoutParams (-1, -2);
			_linearAuthor.SetGravity (Android.Views.GravityFlags.Center);
			_linearAuthor.AddView (_txtAuthor_S1);
			_linearAuthor.SetY (Configuration.getHeight (378));
			_mainLayout.AddView (_linearAuthor);

			//_txtAuthor_S1.SetX (Configuration.getWidth (228));_txtAuthor_S1.SetY (Configuration.getHeight (378));

			LinearLayout _linearChapter = new LinearLayout (context);
			_linearChapter.LayoutParameters = new LinearLayout.LayoutParams (-1, -2);
			_linearChapter.SetGravity (Android.Views.GravityFlags.Center);
			_linearChapter.AddView (_txtChapter_S1);
			_linearChapter.SetY (Configuration.getHeight (502));
			_mainLayout.AddView (_linearChapter);


			//_txtChapter_S1.SetX (Configuration.getWidth (191));_txtChapter_S1.SetY (Configuration.getHeight (502));






			_txtTitle_S1.Text = "Camino Inca";
			_txtTitle_S1.SetTextColor (Color.White);
			_txtTitle_S1.Typeface =  Typeface.CreateFromAsset(context.Assets, "fonts/HelveticaNeue.ttf");
			_txtTitle_S1.SetTextSize (textFormat,Configuration.getHeight(30));

			_txtAuthor_S1.Text = "David Spencer";
			_txtAuthor_S1.SetTextColor (Color.White);
			_txtAuthor_S1.Typeface =  Typeface.CreateFromAsset(context.Assets, "fonts/HelveticaNeue.ttf");
			_txtAuthor_S1.SetTextSize (textFormat,Configuration.getHeight(30));

			_txtChapter_S1.Text = "FLORA Y FAUNA";
			_txtChapter_S1.SetTextColor (Color.White);
			_txtChapter_S1.Typeface =  Typeface.CreateFromAsset(context.Assets, "fonts/HelveticaNeue.ttf");
			_txtChapter_S1.SetTextSize (textFormat,Configuration.getHeight(35));


			List<string> item_path = new List<string> ();
			item_path.Add ("icons/icona.png");
			item_path.Add ("icons/iconb.png");
			item_path.Add ("icons/iconc.png");
			item_path.Add ("icons/icond.png");
			item_path.Add ("icons/icone.png");
			item_path.Add ("icons/iconf.png");
			item_path.Add ("icons/icong.png");


			int inixItemIM = Configuration.getWidth (33);
			int crecIM = Configuration.getWidth (90);

			int inixItemTXT = Configuration.getWidth (42);
			int crecTXT = Configuration.getWidth (90);
			int inixLinea = Configuration.getWidth (93);

			for (int i = 0; i < item_path.Count; i++) {
				
				_imItem_S1.Add(new ImageView(context));
				_imItem_S1[i].SetImageBitmap(Bitmap.CreateScaledBitmap (getBitmapFromAsset(item_path[i]), Configuration.getWidth (30), Configuration.getWidth (30), true));
				_mainLayout.AddView (_imItem_S1 [i]);
				_imItem_S1 [i].SetX (inixItemIM+(i*crecIM));_imItem_S1 [i].SetY (Configuration.getHeight(602));


				if (i != item_path.Count - 1) {
					ImageView linea = new ImageView (context);
					linea.SetImageBitmap (Bitmap.CreateScaledBitmap (getBitmapFromAsset ("icons/lineatareas.png"), 1, Configuration.getHeight (68), true));
					_mainLayout.AddView (linea);
					linea.SetX (inixLinea + (i * crecIM));
					linea.SetY (Configuration.getHeight (605));
				}



				_txtItem_S1.Add (new TextView (context));
				_txtItem_S1 [i].Text = "0";
				_txtItem_S1 [i].SetTextColor (Color.ParseColor ("#2E9AFE"));
				_txtItem_S1[i].Typeface =  Typeface.CreateFromAsset(context.Assets, "fonts/HelveticaNeue.ttf");
				_txtItem_S1[i].SetTextSize (textFormat,Configuration.getHeight(30));
				_mainLayout.AddView (_txtItem_S1 [i]);
				_txtItem_S1 [i].SetX (inixItemTXT+(i*crecTXT));_txtItem_S1 [i].SetY (Configuration.getHeight(640));
			}



			//-------------------------------------------------------


			//section2------------------------------------------------

			_contentScrollView_S2 = new HorizontalScrollView (context);
			_contentScrollView_S2.LayoutParameters = new HorizontalScrollView.LayoutParams (-1, Configuration.getWidth(160));
			_contentScrollView_S2.HorizontalScrollBarEnabled = false;

			_images_S2 = new LinearLayout (context);
			_images_S2.Orientation = Orientation.Horizontal;
			_images_S2.LayoutParameters = new LinearLayout.LayoutParams(-2,-1);

			_contentScrollView_S2.SetX (0);
			_contentScrollView_S2.SetY (Configuration.getHeight (700));


			ImageView im1 = new ImageView (context);
			im1.SetBackgroundColor (Color.White);
			im1.SetImageBitmap (Bitmap.CreateScaledBitmap (getBitmapFromAsset("icons/imga.png"), Configuration.getWidth (160), Configuration.getWidth (160), true));
			_images_S2.AddView (im1);

			ImageView im2 = new ImageView (context);
			im2.SetImageBitmap (Bitmap.CreateScaledBitmap (getBitmapFromAsset("icons/imgb.png"), Configuration.getWidth (160), Configuration.getWidth (160), true));
			_images_S2.AddView (im2);

			ImageView im3 = new ImageView (context);
			im3.SetImageBitmap (Bitmap.CreateScaledBitmap (getBitmapFromAsset("icons/imgc.png"), Configuration.getWidth (160), Configuration.getWidth (160), true));
			_images_S2.AddView (im3);

			ImageView im4 = new ImageView (context);
			im4.SetImageBitmap (Bitmap.CreateScaledBitmap (getBitmapFromAsset("icons/imgd.png"), Configuration.getWidth (160), Configuration.getWidth (160), true));
			_images_S2.AddView (im4);
		
			ImageLOView im5 = new ImageLOView (context);
			im5.ImageBitmap = getBitmapFromAsset ("icons/imga.png");
			_images_S2.AddView (im5);

			ImageLOView im6 = new ImageLOView (context);
			im6.ImageBitmap = getBitmapFromAsset ("icons/imgb.png");
			_images_S2.AddView (im6);

			im5.Click += imLoClick;
			im6.Click += imLoClick;

			_contentScrollView_S2.AddView (_images_S2);

			//----------------------------------------------------------

			//section3------------------------------------------------

			_contentLLayout_S3 = new LinearLayout (context);
			_contentLLayout_S3.Orientation = Orientation.Vertical;
			_contentLLayout_S3.LayoutParameters = new LinearLayout.LayoutParams (-1, Configuration.getHeight (160));
			_contentLLayout_S3.SetX (0);_contentLLayout_S3.SetY (Configuration.getHeight(875));
			_contentLLayout_S3.SetGravity (Android.Views.GravityFlags.Center);


			_txtInfo1_S3 = new TextView (context);
			_txtInfo2_S3 = new TextView (context);
			_txtInfo3_S3 = new TextView (context);

			_txtInfo1_S3.Text = "Duración: 05 dias / 04 noches ";
			_txtInfo2_S3.Text = "Distancia: 65km";
			_txtInfo3_S3.Text = "Punto mas elevado: 4,6386 msnm (Salkantay)";

			_txtInfo1_S3.Gravity = Android.Views.GravityFlags.CenterHorizontal;
			_txtInfo2_S3.Gravity = Android.Views.GravityFlags.CenterHorizontal;
			_txtInfo3_S3.Gravity = Android.Views.GravityFlags.CenterHorizontal;


			_txtInfo1_S3.Typeface =  Typeface.CreateFromAsset(context.Assets, "fonts/HelveticaNeue.ttf");
			_txtInfo2_S3.Typeface =  Typeface.CreateFromAsset(context.Assets, "fonts/HelveticaNeue.ttf");
			_txtInfo3_S3.Typeface =  Typeface.CreateFromAsset(context.Assets, "fonts/HelveticaNeue.ttf");

			_txtInfo1_S3.SetTextSize (textFormat,Configuration.getHeight(30));
			_txtInfo2_S3.SetTextSize (textFormat,Configuration.getHeight(30));
			_txtInfo3_S3.SetTextSize (textFormat,Configuration.getHeight(30));

			_txtInfo1_S3.SetTextColor (Color.White);
			_txtInfo2_S3.SetTextColor (Color.White);
			_txtInfo3_S3.SetTextColor (Color.White);


			_contentLLayout_S3.AddView (_txtInfo1_S3);
			_contentLLayout_S3.AddView (_txtInfo2_S3);
			_contentLLayout_S3.AddView (_txtInfo3_S3);

			//Drawable dr3 = new BitmapDrawable (getBitmapFromAsset("icons/fondonotif.png"));
			//_contentLLayout_S3.SetBackgroundDrawable(dr3);
			_contentLLayout_S3.SetBackgroundColor(Color.ParseColor("#80000000"));
			_mainLayout.AddView (_contentLLayout_S3);
			_mainLayout.AddView (_contentScrollView_S2);

			//----------------------------------------------------------

			//section4------------------------------------------------
			_imItems_S4 = new List<ImageView>();


			List<string> botton_icon_path = new List<string> ();
			botton_icon_path.Add ("icons/btnunidadesazul.png");
			botton_icon_path.Add ("icons/btncomentariosazul.png");
			botton_icon_path.Add ("icons/btncontenidoazul.png");
			botton_icon_path.Add ("icons/btnchatazul.png");
			botton_icon_path.Add ("icons/btntareasazul.png");

			_imItems_S4.Add (new ImageView (context));
			_imItems_S4[0].SetImageBitmap(Bitmap.CreateScaledBitmap (getBitmapFromAsset(botton_icon_path[0]), Configuration.getWidth (60), Configuration.getWidth (54), true));
			_mainLayout.AddView (_imItems_S4[0]);
			_imItems_S4[0].SetX (Configuration.getWidth(58));_imItems_S4[0].SetY (Configuration.getHeight(1069));

			_imItems_S4.Add (new ImageView (context));
			_imItems_S4[1].SetImageBitmap(Bitmap.CreateScaledBitmap (getBitmapFromAsset(botton_icon_path[1]), Configuration.getWidth (78), Configuration.getWidth (55), true));
			_mainLayout.AddView (_imItems_S4[1]);
			_imItems_S4[1].SetX (Configuration.getWidth(169));_imItems_S4[1].SetY (Configuration.getHeight(1069));



			_imItems_S4.Add (new ImageView (context));
			_imItems_S4[2].SetImageBitmap(Bitmap.CreateScaledBitmap (getBitmapFromAsset(botton_icon_path[2]), Configuration.getWidth (60), Configuration.getWidth (60), true));
			_mainLayout.AddView (_imItems_S4 [2]);
			_imItems_S4[2].SetX (Configuration.getWidth(297));_imItems_S4[2].SetY (Configuration.getHeight(1069));



			_imItems_S4.Add (new ImageView (context));
			_imItems_S4[3].SetImageBitmap(Bitmap.CreateScaledBitmap (getBitmapFromAsset(botton_icon_path[3]), Configuration.getWidth (30), Configuration.getWidth (51), true));
			_mainLayout.AddView (_imItems_S4[3]);
			_imItems_S4[3].SetX (Configuration.getWidth(421));_imItems_S4[3].SetY (Configuration.getHeight(1069));


			_imItems_S4.Add (new ImageView (context));
			_imItems_S4[4].SetImageBitmap(Bitmap.CreateScaledBitmap (getBitmapFromAsset(botton_icon_path[4]), Configuration.getWidth (41), Configuration.getWidth (50), true));
			_mainLayout.AddView (_imItems_S4 [4]);
			_imItems_S4[4].SetX (Configuration.getWidth(540));_imItems_S4[4].SetY (Configuration.getHeight(1069));

			//----------------------------------------------------------



			Drawable dr = new BitmapDrawable (getBitmapFromAsset("icons/fondo.png"));
			_mainLayout.SetBackgroundDrawable (dr);
		
		}


	}
}

