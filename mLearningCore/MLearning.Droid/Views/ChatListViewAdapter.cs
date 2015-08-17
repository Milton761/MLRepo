using System;
using Android.Widget;
using System.Collections.Generic;
using Android.Views;
using Android.Content;
using Android.Graphics;

namespace MLearning.Droid
{
	public class ChatListViewAdapter:BaseAdapter<ChatDataRow>
	{


		public List<ChatDataRow> mItems;
		private Context mContext;

		public ChatListViewAdapter (Context context, List<ChatDataRow> items)
		{
			mItems = items;
			mContext = context;
		}

		public override int Count
		{
			get {return mItems.Count; } 
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override ChatDataRow this[int position]
		{
			get{ return mItems [position];}
		}


		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View row = convertView;

			if (row == null) 
			{
				row = LayoutInflater.From (mContext).Inflate (Resource.Layout.row_chat_list, parent, false);
			}

			ImageView row_image = row.FindViewById<ImageView> (Resource.Id.imageView_Row_CL);
			row_image.SetX (Configuration.getWidth (75));

			//row_image.SetImageResource (Resource.Id.icon);

			LinearLayout ln_chat_row = row.FindViewById<LinearLayout> (Resource.Id.info_Row_CL);
			ln_chat_row.SetX (Configuration.getWidth(74));

			TextView name = row.FindViewById<TextView> (Resource.Id.textView_name_CL);
			name.Text = mItems [position].name;


			TextView state = row.FindViewById<TextView> (Resource.Id.textView_status_CL);
			ImageView imProfile = row.FindViewById<ImageView> (Resource.Id.imageView_Row_CL);

			imProfile.SetImageBitmap (Bitmap.CreateScaledBitmap (getBitmapFromAsset(mItems[position].imageProfile),Configuration.getWidth (52), Configuration.getHeight (52),true));
			imProfile.SetX (Configuration.getHeight (75));


			if (mItems [position].state == "online") 
			{
				state.SetTextColor (Color.ParseColor ("#2ECCFA"));
			}
			if (mItems [position].state == "offline") 
			{
				state.SetTextColor (Color.ParseColor ("#A4A4A4"));
			}

			state.Text = mItems [position].state;





			return row;

		}

		public Bitmap getBitmapFromAsset( String filePath) {
			System.IO.Stream s = mContext.Assets.Open (filePath);
			Bitmap bitmap = BitmapFactory.DecodeStream (s);

			return bitmap;
		}


	}
}

