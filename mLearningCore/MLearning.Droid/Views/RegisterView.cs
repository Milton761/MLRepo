
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
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Text;

namespace MLearning.Droid
{
	[Activity(Label = "View for FirstViewModel")]	
	public class RegisterView : MvxActivity
	{


		RelativeLayout mainLayout;
		TextView txtRegister;
		EditText etxtUser;
		EditText etxtEmail;
		EditText etxtPassword;
		ImageButton btnCreateAccount;

		LinearLayout linearRegister;
		LinearLayout linearButtonRegister;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			init ();
			SetContentView (mainLayout);
			// Create your application here
		}

		public void init(){
			mainLayout = new RelativeLayout (this);
			txtRegister = new TextView (this);
			etxtEmail = new EditText (this);
			etxtUser = new EditText (this);
			etxtPassword = new EditText (this);
			btnCreateAccount = new ImageButton (this);
			linearButtonRegister = new LinearLayout (this);
			linearRegister = new LinearLayout (this);

			linearButtonRegister.LayoutParameters = new LinearLayout.LayoutParams (-1,LinearLayout.LayoutParams.WrapContent);
			linearRegister.LayoutParameters = new LinearLayout.LayoutParams (-1,LinearLayout.LayoutParams.WrapContent);
			linearButtonRegister.Orientation = Orientation.Horizontal;
			linearRegister.Orientation = Orientation.Vertical;
			linearButtonRegister.SetGravity (GravityFlags.Center);
			linearRegister.SetGravity (GravityFlags.Center);

			etxtUser.LayoutParameters = new ViewGroup.LayoutParams (Configuration.getWidth (507), Configuration.getHeight (78));
			etxtPassword.LayoutParameters = new ViewGroup.LayoutParams (Configuration.getWidth (507), Configuration.getHeight (78));
			etxtEmail.LayoutParameters = new ViewGroup.LayoutParams (Configuration.getWidth (507), Configuration.getHeight (78));



			mainLayout.LayoutParameters = new RelativeLayout.LayoutParams (-1, -1);
			Drawable drawableBackground = new BitmapDrawable (Bitmap.CreateScaledBitmap (getBitmapFromAsset ("icons/cfondo.png"), 768, 1024, true));
			mainLayout.SetBackgroundDrawable (drawableBackground);

			txtRegister.Text = "Registro";
			etxtUser.Hint ="Nombre de usuario";
			etxtEmail.Hint = "Dirección de correo";
			etxtPassword.Hint ="Contraeña";
			Drawable drawableEditText = new BitmapDrawable (Bitmap.CreateScaledBitmap (getBitmapFromAsset ("icons/cajatexto.png"), Configuration.getWidth (507), Configuration.getHeight (78), true));

			etxtUser.SetBackgroundDrawable (drawableEditText);
			etxtPassword.SetBackgroundDrawable (drawableEditText);
			etxtEmail.SetBackgroundDrawable (drawableEditText);

			etxtUser.SetTextColor (Color.ParseColor ("#ffffff"));
			etxtUser.SetSingleLine (true);
			etxtPassword.SetTextColor (Color.ParseColor ("#ffffff"));
			etxtPassword.SetSingleLine (true);
			etxtEmail.SetTextColor (Color.ParseColor ("#ffffff"));
			etxtEmail.SetSingleLine (true);

			etxtPassword.InputType = InputTypes.TextVariationVisiblePassword;
			etxtPassword.TransformationMethod = Android.Text.Method.PasswordTransformationMethod.Instance;

			btnCreateAccount.SetImageBitmap (Bitmap.CreateScaledBitmap (getBitmapFromAsset ("icons/crearcuenta.png"), Configuration.getWidth (507), Configuration.getHeight (78), true));
			btnCreateAccount.Alpha = 255;
			//btn.SetAlpha(255);
			btnCreateAccount.SetBackgroundColor(Color.Transparent);


			linearRegister.AddView (etxtUser);
			linearRegister.AddView (etxtEmail);
			linearRegister.AddView (etxtPassword);

			linearButtonRegister.AddView (btnCreateAccount);

			txtRegister.SetX (Configuration.getWidth(68)); txtRegister.SetY (Configuration.getHeight(550));
			linearRegister.SetX (0); linearRegister.SetY (Configuration.getHeight(592));
			linearButtonRegister.SetX (0); linearButtonRegister.SetY (Configuration.getHeight(975));
			mainLayout.AddView (txtRegister);
			mainLayout.AddView (linearRegister);
			mainLayout.AddView (linearButtonRegister);


		}

		public Bitmap getBitmapFromAsset( String filePath) {
			System.IO.Stream s =this.Assets.Open (filePath);
			Bitmap bitmap = BitmapFactory.DecodeStream (s);

			return bitmap;
		}
	}
}

