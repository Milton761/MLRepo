
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using Android.Graphics;
using Android.Graphics.Drawables;
using MLearning.Core;
using Core.ViewModels;

namespace MLearning.Droid
{
	[Activity(Label = "View for CameraViewModel")]		
	public class CameraView : MvxActivity
	{
		RelativeLayout mainLayout;

		ImageView imgCamera;
		ImageView imgLineal;
		ImageButton btnCamera;
		ImageButton btnRepository;
		TextView txtCamera;
		Button boton;

		LinearLayout linearButtons;
		LinearLayout linearImageCamera;
		LinearLayout LinearTextCamera;
		LinearLayout LinearImageText;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			init ();

			SetContentView (mainLayout);

			// Create your application here
		}
		public void init(){
			mainLayout = new RelativeLayout (this);
			mainLayout.LayoutParameters = new RelativeLayout.LayoutParams (-1, -1);
			linearButtons = new LinearLayout (this);
			linearImageCamera = new LinearLayout (this);
			LinearImageText = new LinearLayout (this);
			LinearTextCamera = new LinearLayout (this);

			linearButtons.LayoutParameters = new LinearLayout.LayoutParams (-1, LinearLayout.LayoutParams.WrapContent);
			linearImageCamera.LayoutParameters = new LinearLayout.LayoutParams (-1, LinearLayout.LayoutParams.WrapContent);
			LinearImageText.LayoutParameters = new LinearLayout.LayoutParams (-1, LinearLayout.LayoutParams.WrapContent);
			LinearTextCamera.LayoutParameters = new LinearLayout.LayoutParams (-1, LinearLayout.LayoutParams.WrapContent);

			linearButtons.Orientation = Orientation.Horizontal;
			linearImageCamera.Orientation = Orientation.Horizontal;
			LinearImageText.Orientation = Orientation.Horizontal;
			LinearTextCamera.Orientation = Orientation.Vertical;

			linearButtons.SetGravity (GravityFlags.Center);
			linearImageCamera.SetGravity (GravityFlags.Center);
			LinearImageText.SetGravity (GravityFlags.Center);
			LinearTextCamera.SetGravity (GravityFlags.Center);

			Drawable dr = new BitmapDrawable (Bitmap.CreateScaledBitmap (getBitmapFromAsset ("icons/bfondo.png"), 1024, 768, true));
			mainLayout.SetBackgroundDrawable (dr);
			 
			imgCamera = new ImageView (this);
			imgLineal = new ImageView (this);
			btnCamera = new ImageButton (this);
			btnRepository = new ImageButton (this);
			txtCamera = new TextView (this);

			txtCamera.Text = "CHOOSE A PICTURE AND \n        SELECT A COLOUR"; 
			txtCamera.SetTextSize(Android.Util.ComplexUnitType.Px,Configuration.getHeight(30));

			imgCamera.SetImageBitmap (Bitmap.CreateScaledBitmap (getBitmapFromAsset("icons/camara.png"), Configuration.getWidth(164),Configuration.getHeight(164),true));
			//imgLineal.SetImageBitmap (Bitmap.CreateScaledBitmap (getBitmapFromAsset("icons/camara.png"), 400, 100,true));
			btnCamera.SetImageBitmap (Bitmap.CreateScaledBitmap (getBitmapFromAsset("icons/loadcamara.png"), Configuration.getWidth(58),Configuration.getHeight(50),true));
			btnRepository.SetImageBitmap (Bitmap.CreateScaledBitmap (getBitmapFromAsset("icons/loadbiblioteca.png"), Configuration.getWidth(58),Configuration.getHeight(50),true));

			linearButtons.AddView (btnCamera);
			linearButtons.AddView (btnRepository);


			linearImageCamera.AddView (imgCamera);
			LinearImageText.AddView (txtCamera);


			LinearTextCamera.AddView (linearImageCamera);
			LinearTextCamera.AddView (LinearImageText);

			LinearTextCamera.SetX (0); LinearTextCamera.SetY (Configuration.getHeight(282));
			linearButtons.SetX (0); linearButtons.SetY (Configuration.getHeight(926));

			mainLayout.AddView (LinearTextCamera);
			mainLayout.AddView (linearButtons);
			initButtonColor (btnCamera);
			initButtonColor (btnRepository);

			btnCamera.Click += delegate {
				var com = ((CameraViewModel)this.DataContext).TakePictureCommand;
				com.Execute(null);
			};

			btnRepository.Click += delegate {
				var com = ((CameraViewModel)this.DataContext).ChoosePictureCommand;
				com.Execute(null);
			};


			Bitmap bm;
			var vm = this.ViewModel as CameraViewModel;
			if (vm.Bytes != null)
			{
				bm= BitmapFactory.DecodeByteArray(vm.Bytes, 0, vm.Bytes.Length);
				imgCamera.SetImageBitmap (bm); 

			}

			vm.PropertyChanged += Vm_PropertyChanged;

			boton = new Button (this);
			boton.Text ="Registro";

			boton.Click += delegate {
				var com = ((CameraViewModel)this.DataContext).RegisterCommand;
				com.Execute(null);
			};

			boton.SetX (0); boton.SetY (0);
			mainLayout.AddView (boton);

		}

		void Vm_PropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{

			var vm = this.ViewModel as CameraViewModel;

			string property = e.PropertyName;
			switch (property) {

			case "Bytes":
				if (vm.Bytes != null) {
					Bitmap bm = BitmapFactory.DecodeByteArray (vm.Bytes, 0, vm.Bytes.Length);
					imgCamera.SetImageBitmap (bm);
					//Bitmap newbm = Utilities.getRoundedShape (bm);
					//imgUser.SetImageBitmap (newbm);
				}

				break;
			}
		}



		public Bitmap getBitmapFromAsset( String filePath) {
			System.IO.Stream s =this.Assets.Open (filePath);
			Bitmap bitmap = BitmapFactory.DecodeStream (s);

			return bitmap;
		}
		public  void initButtonColor(ImageButton btn){
			btn.Alpha = 255;
			//btn.SetAlpha(255);
			btn.SetBackgroundColor(Color.Transparent);
		}

	}
}

