using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Android.Widget;
using Android.Graphics;
using Android.Views;
using Core.ViewModels;
using System;
using Android.Graphics.Drawables;
using Android.Views.Animations;
using Android.Text;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace MLearning.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class LoginView : MvxActivity
    {

		RelativeLayout mainLayout;

		//VIEWS FOR SINGUP
		RelativeLayout relSingup;
		RelativeLayout relLogin;
		ImageButton btnLogin;
		ImageButton btnSingUp;
		ImageButton btnFacebook;
		ImageView imgLogo;
		CheckBox chkLogin;
		TextView txtLicencia_a;
		TextView txtLicencia_b;
		LinearLayout linearLogo;
		LinearLayout linearLicencia;
		LinearLayout linearLogin;
		LinearLayout linearSingup;
		int widthInDp;
		int heightInDp;

		TextView txtlogin_a1;
		TextView txtlogin_a2;
		TextView txtlogin_b1;
		TextView txtlogin_b2;
		TextView txtlogin_c1;
		TextView txtlogin_c2;

		LinearLayout linearTxta;
		LinearLayout linearTxtb;
		LinearLayout linearTxtc;
		LinearLayout linearContentText;

		// VIEWS FOR LOGIN
		EditText etxtUser;
		EditText etxtPassword;
		ImageButton btnLoginInto;
		TextView txtLogin_a;
		TextView txtLogin_b;
		TextView txtInicioSesion;

		LinearLayout linearButtonLogin;
		LinearLayout linearEditTextLogin;
		LinearLayout linearTextLogin;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			var metrics = Resources.DisplayMetrics;
			widthInDp = ((int)metrics.WidthPixels);
			heightInDp = ((int)metrics.HeightPixels);
			Configuration.setWidthPixel (widthInDp);
			Configuration.setHeigthPixel (heightInDp);


			Console.WriteLine ("DIMESIONES DEL DEVICEEEEEEEEEEEE WIDTH= "+ widthInDp + " HEIGHT = "+heightInDp);

			init ();


			var set = this.CreateBindingSet<LoginView, LoginViewModel>();
			set.Bind(etxtUser).To(vm => vm.Username);
			set.Bind (etxtPassword).To (vm => vm.Password); 
			set.Apply();       


			SetContentView (mainLayout);
            //SetContentView(Resource.Layout.LoginView);
        }

		public void init(){
			var textFormat = Android.Util.ComplexUnitType.Px;


			mainLayout = new RelativeLayout (this);
			relSingup = new RelativeLayout (this);
			relLogin = new RelativeLayout (this);
			linearLicencia = new LinearLayout (this);
			linearLogin = new LinearLayout (this);
			linearSingup = new LinearLayout (this);
			linearLogo = new LinearLayout (this);

			imgLogo = new ImageView (this);
			btnLogin = new ImageButton (this);
			btnSingUp = new ImageButton (this);
			btnFacebook = new ImageButton (this);
			chkLogin = new CheckBox (this);
			txtLicencia_a = new TextView (this);
			txtLicencia_b = new TextView (this);

			txtlogin_a1 = new TextView (this);
			txtlogin_a2 = new TextView (this);
			txtlogin_b1 = new TextView (this);
			txtlogin_b2 = new TextView (this);
			txtlogin_c1 = new TextView (this);
			txtlogin_c2 = new TextView (this);


			initText (txtlogin_a1, "Connect ", "#00c6ff");
			initText (txtlogin_a2, " width yout classmates ", "#ffffff");
			initText (txtlogin_b1, "Get help ", "#00c6ff");
			initText (txtlogin_b2, " on homework ", "#ffffff");
			initText (txtlogin_c1, "Get better graces ", "#00c6ff");
			initText (txtlogin_c2, " for real", "#ffffff");

			linearTxta = new LinearLayout (this);
			linearTxtb = new LinearLayout (this);
			linearTxtc = new LinearLayout (this);
			linearContentText = new LinearLayout (this);

			linearTxta.LayoutParameters = new LinearLayout.LayoutParams (-1, -2);
			linearTxtb.LayoutParameters = new LinearLayout.LayoutParams (-1, -2);
			linearTxtc.LayoutParameters = new LinearLayout.LayoutParams (-1, -2);
			linearContentText.LayoutParameters = new LinearLayout.LayoutParams (-1, -2);

			linearTxta.Orientation = Orientation.Horizontal;
			linearTxta.SetGravity (GravityFlags.Center);
			linearTxtb.Orientation = Orientation.Horizontal;
			linearTxtb.SetGravity (GravityFlags.Center);
			linearTxtc.Orientation = Orientation.Horizontal;
			linearTxtc.SetGravity (GravityFlags.Center);

			linearContentText.Orientation = Orientation.Vertical;
			linearContentText.SetGravity (GravityFlags.Center);


			linearTxta.AddView (txtlogin_a1); linearTxta.AddView (txtlogin_a2);
			linearTxtb.AddView (txtlogin_b1); linearTxtb.AddView (txtlogin_b2);
			linearTxtc.AddView (txtlogin_c1); linearTxtc.AddView (txtlogin_c2);

			linearContentText.AddView (linearTxta);
			linearContentText.AddView (linearTxtb);
			linearContentText.AddView (linearTxtc);


			mainLayout.LayoutParameters = new RelativeLayout.LayoutParams (-1, -1);
			Drawable d = new BitmapDrawable (Bitmap.CreateScaledBitmap (getBitmapFromAsset ("icons/afondo.png"), 768, 1024, true));
			mainLayout.SetBackgroundDrawable (d);

			relSingup.LayoutParameters = new RelativeLayout.LayoutParams (-1,-1);
			relLogin.LayoutParameters = new RelativeLayout.LayoutParams (-1,-1);


			linearLicencia.LayoutParameters = new LinearLayout.LayoutParams (-1, LinearLayout.LayoutParams.WrapContent);
			linearLicencia.Orientation = Orientation.Horizontal;
			linearLicencia.SetGravity (GravityFlags.Center);

			linearLogin.LayoutParameters = new LinearLayout.LayoutParams (-1, LinearLayout.LayoutParams.WrapContent);
			linearLogin.Orientation = Orientation.Horizontal;
			linearLogin.SetGravity (GravityFlags.Right);

			linearSingup.LayoutParameters = new LinearLayout.LayoutParams (-1, LinearLayout.LayoutParams.WrapContent);
			linearSingup.Orientation = Orientation.Vertical;
			linearSingup.SetGravity (GravityFlags.Center);


			linearLogo.LayoutParameters = new LinearLayout.LayoutParams (-1, LinearLayout.LayoutParams.WrapContent);
			linearLogo.Orientation = Orientation.Vertical;
			linearLogo.SetGravity (GravityFlags.Center);



			txtLicencia_a.Text = "TO REGISTER, ACCEPT THE";
			txtLicencia_a.SetTextSize(textFormat,Configuration.getHeight(30));
			txtLicencia_a.SetTextColor (Color.ParseColor ("#ffffff"));
			txtLicencia_b.Text = " TERMS OF USE";
			txtLicencia_b.SetTextSize(textFormat,Configuration.getHeight(30));
			txtLicencia_b.SetTextColor (Color.ParseColor ("#00c6ff"));
			chkLogin.Checked = false;

			imgLogo.SetImageBitmap(Bitmap.CreateScaledBitmap (getBitmapFromAsset("icons/logo.png"), Configuration.getWidth(317), Configuration.getHeight(64),true));
			btnLogin.SetImageBitmap(Bitmap.CreateScaledBitmap (getBitmapFromAsset("icons/login.png"), Configuration.getWidth(207), Configuration.getHeight(56),true));
			btnFacebook.SetImageBitmap(Bitmap.CreateScaledBitmap (getBitmapFromAsset("icons/signupface.png"), Configuration.getWidth(507), Configuration.getHeight(78),true));
			btnSingUp.SetImageBitmap(Bitmap.CreateScaledBitmap (getBitmapFromAsset("icons/signupnolisto.png"), Configuration.getWidth(507), Configuration.getHeight(78),true));

			btnSingUp.Click+= delegate {
				var com = ((LoginViewModel)this.DataContext).SignUpCommand;
				com.Execute(null);
			};

			initButtonColor (btnLogin);
			initButtonColor (btnFacebook);
			initButtonColor (btnSingUp);
			linearLicencia.AddView (chkLogin);
			linearLicencia.AddView (txtLicencia_a);
			linearLicencia.AddView (txtLicencia_b);

			linearLogin.AddView (btnLogin);
			linearSingup.AddView (linearLicencia);
			linearSingup.AddView (btnSingUp);
			linearSingup.AddView (btnFacebook);

			linearLogo.AddView (imgLogo);

			linearLogo.SetX (0); linearLogo.SetY (Configuration.getHeight(447));
			linearContentText.SetX (0); linearContentText.SetY (Configuration.getHeight(557));
			linearLogin.SetX (0); linearLogin.SetY (Configuration.getHeight(30));
			linearSingup.SetX (0); linearSingup.SetY (Configuration.getHeight(782));

			relSingup.AddView (linearLogo);
			relSingup.AddView (linearContentText);
			relSingup.AddView (linearLogin);
			relSingup.AddView (linearSingup);
			mainLayout.AddView (relSingup);


			btnLogin.Click+= BtnLogin_Click;
			btnFacebook.Click += delegate {
				var com = ((LoginViewModel)this.DataContext).FacebookLoginCommand;
				com.Execute(null);
			};

			chkLogin.CheckedChange += delegate {
			//	btnSingUp.SetImageBitmap(Bitmap.CreateScaledBitmap (getBitmapFromAsset("icons/signuplisto.png"), 600, 100,true));
			};
		}

		void BtnLogin_Click (object sender, EventArgs e)
		{
			AlphaAnimation animation = new AlphaAnimation(1.0f,0.0f);
			animation.Duration = 350;
			animation.AnimationEnd+= Animation_AnimationEnd;               

			relSingup.StartAnimation(animation);     
		}

		void Animation_AnimationEnd (object sender, Animation.AnimationEndEventArgs e)
		{
			relSingup.Alpha = 0.0f;
			setItemLogin ();
			//setItemsContentRegister();

		}

		public void setItemLogin(){

			var txtFormat = Android.Util.ComplexUnitType.Px;

			linearButtonLogin = new LinearLayout (this);
			linearEditTextLogin = new LinearLayout (this);
			linearTextLogin = new LinearLayout (this);



			etxtUser = new EditText (this);
			etxtPassword = new EditText (this);
			btnLoginInto = new ImageButton (this);
			txtLogin_a = new TextView (this);
			txtLogin_b = new TextView (this);
			txtInicioSesion = new TextView (this);

			linearButtonLogin.LayoutParameters = new LinearLayout.LayoutParams (-1, LinearLayout.LayoutParams.WrapContent);
			linearEditTextLogin.LayoutParameters = new LinearLayout.LayoutParams (-1, LinearLayout.LayoutParams.WrapContent);
			linearTextLogin.LayoutParameters = new LinearLayout.LayoutParams (LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);

			etxtUser.LayoutParameters = new ViewGroup.LayoutParams (Configuration.getWidth (507), Configuration.getHeight (78));
			etxtPassword.LayoutParameters = new ViewGroup.LayoutParams (Configuration.getWidth (507), Configuration.getHeight (78));


			linearButtonLogin.Orientation = Orientation.Horizontal;
			linearButtonLogin.SetGravity (GravityFlags.Center);
			linearEditTextLogin.Orientation = Orientation.Vertical;
			linearEditTextLogin.SetGravity (GravityFlags.Center);
			linearTextLogin.Orientation = Orientation.Vertical;
			linearTextLogin.SetGravity (GravityFlags.Center);



			etxtUser.Hint = "Usuario"; 
			etxtPassword.Hint = "Contraseña";
			txtLogin_a.Text = "FORGOT PASSWORD?";
			txtLogin_b.Text = "            CHANGE";

			txtLogin_a.SetTextSize (txtFormat,Configuration.getHeight(30));
			txtLogin_b.SetTextSize (txtFormat, Configuration.getHeight (30));


			txtInicioSesion.Text = "Iniciar Sesión";
			txtInicioSesion.SetTextColor (Color.ParseColor("#ffffff"));
			btnLoginInto.SetImageBitmap (Bitmap.CreateScaledBitmap (getBitmapFromAsset("icons/otherlogin.png"),Configuration.getWidth (243), Configuration.getHeight (78),true));
			etxtUser.SetTextColor (Color.ParseColor ("#ffffff"));
			etxtPassword.SetTextColor (Color.ParseColor ("#ffffff"));

			btnLoginInto.Click += delegate {
				var com = ((LoginViewModel)this.DataContext).LoginCommand;
				com.Execute(null);
			};

			initButtonColor (btnLoginInto);
				
			etxtPassword.InputType = InputTypes.TextVariationVisiblePassword;
			etxtPassword.TransformationMethod = Android.Text.Method.PasswordTransformationMethod.Instance;

			txtLogin_a.SetTextColor (Color.ParseColor ("#ffffff"));
			txtLogin_b.SetTextColor (Color.ParseColor ("#00c6ff"));


			Drawable drawableEditText = new BitmapDrawable (Bitmap.CreateScaledBitmap (getBitmapFromAsset ("icons/cajatexto.png"), Configuration.getWidth(507), Configuration.getHeight(78), true));
			etxtUser.SetBackgroundDrawable (drawableEditText);
			etxtPassword.SetBackgroundDrawable (drawableEditText);

			etxtUser.SetSingleLine (true);
			etxtPassword.SetSingleLine (true);


			linearTextLogin.AddView (txtLogin_a);
			linearTextLogin.AddView (txtLogin_b);

			linearButtonLogin.AddView (btnLoginInto);
			linearButtonLogin.AddView (linearTextLogin);

			linearEditTextLogin.AddView (etxtUser);
			linearEditTextLogin.AddView (etxtPassword);


			txtInicioSesion.SetX (Configuration.getWidth(64)); txtInicioSesion.SetY (Configuration.getHeight(687));
			linearEditTextLogin.SetX (0); linearEditTextLogin.SetY (Configuration.getHeight(741));
			linearButtonLogin.SetX (0); linearButtonLogin.SetY (Configuration.getHeight(978));

			relLogin.AddView (txtInicioSesion);
			relLogin.AddView (linearEditTextLogin);
			relLogin.AddView (linearButtonLogin);

			mainLayout.AddView (relLogin);
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

		public void initText(TextView txt, String texto, String colores){

			var txtf = Android.Util.ComplexUnitType.Px;
		
			txt.Text = texto;
			txt.SetTextColor(Color.ParseColor(colores));
		    txt.SetTextSize(txtf,Configuration.getHeight(30));	
		}

	
    }
}