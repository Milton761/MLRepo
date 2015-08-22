using Android.App;
using Android.OS;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Views;
using Core.Repositories;
using Gcm.Client;
using Microsoft.WindowsAzure.MobileServices;
using MLearning.Core.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Android.Widget;
using Android.Graphics;
using Android.Views;
using System.Collections.Generic;
using Android.Support.V4.View;
using DataSource;
using System.Collections.ObjectModel;
using Android.Content.PM;

namespace MLearning.Droid.Views
{
	[Activity(Label = "View for LOViewModel", ScreenOrientation = ScreenOrientation.Portrait)]
	public class LOView : MvxActivity, VerticalScrollView.ScrollViewListener, VerticalScrollViewPager.ScrollViewListenerPager
    {

		ProgressDialog _progresD;
		LinearLayout layoutPanelScroll;
		RelativeLayout mainLayout;
		RelativeLayout mainLayoutIndice;
		RelativeLayout mainLayoutPages;
		int widthInDp;
		int heightInDp;
		List<FrontContainerView> listFront = new List<FrontContainerView> ();
		VerticalScrollView scrollVertical;
		bool ISLOADED= false;
		int IndiceSection=0;

		List<VerticalScrollViewPager> listaScroll = new List<VerticalScrollViewPager>();

		ViewPager viewPager;
		async protected  override  void OnCreate(Bundle bundle)
        {
			this.Window.AddFlags(WindowManagerFlags.Fullscreen);
            base.OnCreate(bundle);
			var metrics = Resources.DisplayMetrics;
			widthInDp = ((int)metrics.WidthPixels);
			heightInDp = ((int)metrics.HeightPixels);
			Configuration.setWidthPixel (widthInDp);
			Configuration.setHeigthPixel (heightInDp);
			await ini();
			//LoadPagesDataSource ();

			SetContentView (mainLayout);
        } 




		async Task  ini(){
			
			mainLayout = new RelativeLayout (this);

			_progresD = new ProgressDialog (this);
			_progresD.SetCancelable (false);
			_progresD.SetMessage ("Wait please..");

			mainLayout.LayoutParameters = new RelativeLayout.LayoutParams (-1,-1);	
			mainLayout.SetBackgroundColor(Color.ParseColor("#ffffff"));

			mainLayoutIndice = new RelativeLayout (this);
			mainLayoutIndice.LayoutParameters = new RelativeLayout.LayoutParams (-1,-1);	
			mainLayoutIndice.SetBackgroundColor(Color.ParseColor("#ffffff"));

			mainLayoutPages = new RelativeLayout (this);
			mainLayoutPages.LayoutParameters = new RelativeLayout.LayoutParams (-1,-1);	
			mainLayoutPages.SetBackgroundColor(Color.ParseColor("#ffffff"));
			viewPager = new ViewPager (this);


			layoutPanelScroll = new LinearLayout (this);
			layoutPanelScroll.LayoutParameters = new LinearLayout.LayoutParams (-1,-2);	
			layoutPanelScroll.SetBackgroundColor(Color.ParseColor("#ffffff"));
			layoutPanelScroll.Orientation = Orientation.Vertical;

			scrollVertical = new VerticalScrollView (this);
			scrollVertical.setOnScrollViewListener (this); 
			scrollVertical.LayoutParameters = new ViewGroup.LayoutParams (-1, -1);

			scrollVertical.SetX (0); scrollVertical.SetY (0);					


			scrollVertical.AddView (layoutPanelScroll);
			mainLayoutIndice.AddView (scrollVertical);
			mainLayoutIndice.SetX (0); mainLayoutIndice.SetY (0);
			mainLayout.AddView (mainLayoutIndice);
			//mainLayout.AddView (scrollVertical);

			var vm = this.ViewModel as LOViewModel;
		
			await vm.InitLoad();
			loadLOsInCircle(0);

			vm.PropertyChanged += Vm_PropertyChanged;


		}

		void Vm_PropertyChanged (object sender, PropertyChangedEventArgs e)
		{

			var vm = this.ViewModel as LOViewModel;
			if (e.PropertyName == "LOsInCircle")
			if (vm.LOsInCircle != null) {
			}
				vm.LOsInCircle.CollectionChanged+= Vm_LOsInCircle_CollectionChanged;
		}

		void Vm_LOsInCircle_CollectionChanged (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{

			loadLOsInCircle (e.NewStartingIndex);		

		}

		void loadLOsInCircle(int index){
			
			var vm = this.ViewModel as LOViewModel;
			if (vm.LOsInCircle != null) {

				for (int i = 0; i < vm.LOsInCircle.Count; i++) {

					if(Configuration.IndiceActual==i){
						FrontContainerView front = new FrontContainerView (this);
						front.Author = vm.LOsInCircle [i].lo.name + " " + vm.LOsInCircle [i].lo.lastname;
						front.Chapter = vm.LOsInCircle [i].lo.description;
						front.NameLO = vm.LOsInCircle [i].lo.title;
						front.Like = "10";
						listFront.Add (front);

								if (vm.LOsInCircle [i].background_bytes != null) {
								Bitmap bm = BitmapFactory.DecodeByteArray (vm.LOsInCircle [i].background_bytes, 0, vm.LOsInCircle [i].background_bytes.Length);
									front.ImageChapterBitmap = bm;
								
								}

								vm.LOsInCircle[i].PropertyChanged += (s1, e1) =>
								{
									if (e1.PropertyName == "background_bytes")
									{
										Bitmap bm = BitmapFactory.DecodeByteArray (vm.LOsInCircle [i].background_bytes, 0, vm.LOsInCircle [i].background_bytes.Length);
										front.ImageChapterBitmap = bm;

									}
								};								
				
					layoutPanelScroll.AddView (front);
				
					if (vm.LOsInCircle [i].stack.IsLoaded) {				
						var s_list = vm.LOsInCircle [i].stack.StacksList;
							int indice = 0;
						for (int j = 0; j < s_list.Count; j++) {
					
								//ChapterContainerView section = new ChapterContainerView (this);

							for (int k = 0; k < s_list [j].PagesList.Count; k++) {
								//var page = new PageDataSource();
								//if(s_list[j].PagesList[k].page)
								ChapterContainerView section = new ChapterContainerView (this);
								
								section.Author = vm.LOsInCircle [i].lo.name + " " + vm.LOsInCircle [i].lo.lastname;
								//section.Title = s_list[j].TagName;
									//if (s_list [j].PagesList.Count<2 ) {
										section.Title = s_list [j].PagesList [k].page.title;
										section.Container = s_list [j].PagesList [k].page.description;
									//}
								section.ColorText = Configuration.ListaColores [indice % 6];
								if (s_list [j].PagesList [k].cover_bytes != null) {
										Bitmap bm = BitmapFactory.DecodeByteArray (s_list [j].PagesList [k].cover_bytes, 0, s_list [j].PagesList[k].cover_bytes.Length);
									section.ImageBitmap = bm;

								}
									section.Indice = indice;

									//Console.WriteLine ("VALOR DE KKKKKKKK" + k);
								
									section.Click += delegate {
									//	_progresD.Show();
										IndiceSection = section.Indice; 
										//Console.WriteLine ("TOQUEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEee  INDICEEEEE "+ IndiceSection);
										mainLayoutIndice.Visibility = ViewStates.Invisible;		
										if (ISLOADED == false) {		
											 LoadPagesDataSource();
										} else {
											
											viewPager.CurrentItem= IndiceSection;
											mainLayoutPages.Visibility = ViewStates.Visible;
											mainLayoutIndice.Visibility = ViewStates.Invisible;
										}
									};
									layoutPanelScroll.AddView (section);
									indice++;
							}
								//layoutPanelScroll.AddView (section);
						}
					} else {

						vm.LOsInCircle [i].stack.PropertyChanged+= (s3, e3) => {

							var s_list = vm.LOsInCircle[i].stack.StacksList;
							for(int j=0; j<s_list.Count; j++){

								//SectionDataSoource
								//stackalloc.ComponentName
								for(int k=0; k<s_list[j].PagesList.Count; k++){							
									//PageDatasource page
									ChapterContainerView section = new ChapterContainerView (this);

									section.Author = vm.LOsInCircle [i].lo.name + " " + vm.LOsInCircle [i].lo.lastname;

									section.Title = s_list [j].PagesList [k].page.title;
									section.Container = s_list [j].PagesList [k].page.description;
									section.ColorText = Configuration.ListaColores [j % 6];
										if (s_list [j].PagesList [k].cover_bytes != null) {
											Bitmap bm = BitmapFactory.DecodeByteArray (s_list [j].PagesList [k].cover_bytes, 0, s_list [j].PagesList [k].cover_bytes.Length);
											section.ImageBitmap = bm;

										}
										//section.Image = s_list[j].PagesList[k].page
									section.Click+= Section_Click;
									layoutPanelScroll.AddView (section);
								}
							}
						};

					}
					}
				}
			}

		}

		void Section_Click (object sender, EventArgs e)
		{
			//Console.WriteLine ("TOQUEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEee");
			mainLayoutIndice.Visibility = ViewStates.Invisible;
			//mainLayoutIndice.Alpha = 0;
			if (ISLOADED == false) {
				loadPages ();
			} else {
				mainLayoutPages.Visibility = ViewStates.Visible;
				mainLayoutIndice.Visibility = ViewStates.Invisible;
			}


		}



		async void LoadPagesDataSource()
		{
			var vm = ViewModel as LOViewModel;
			//var styles = new StyleConstants();
			int scroll_index = 0;

			//for styles
			bool white_style = false, is_main = true;

			for (int i = 0; i < vm.LOsInCircle.Count; i++)
			{
				var s_list = vm.LOsInCircle[i].stack.StacksList;
				if (Configuration.IndiceActual == i) {
					int indice = 0;
					for (int j = 0; j < s_list.Count; j++) {						

							

							for (int k = 0; k < s_list [j].PagesList.Count; k++) {
							VerticalScrollViewPager scrollPager = new VerticalScrollViewPager (this);
							scrollPager.setOnScrollViewListener (this); 
							LinearLayout linearScroll = new LinearLayout (this);
							linearScroll.LayoutParameters = new LinearLayout.LayoutParams (-1, -2);
							linearScroll.Orientation = Orientation.Vertical;
								//LOPageSource page = new LOPageSource();
								var content = s_list [j].PagesList [k].content;
								FrontContainerViewPager front = new FrontContainerViewPager (this);

								Bitmap bm = BitmapFactory.DecodeByteArray (s_list [j].PagesList [k].cover_bytes, 0, s_list [j].PagesList [k].cover_bytes.Length);
								front.ImageChapterBitmap = bm;
								front.Title = s_list [j].PagesList [k].page.title;
								front.Description =  s_list [j].PagesList [k].page.description;
								var slides = s_list [j].PagesList [k].content.lopage.loslide;
							//var slides2 = s_list [j].PagesList [k].content.lopage.loslide.
								linearScroll.AddView (front);
								//vm.OpenPageCommand.Execute(s_list[j].PagesList[k]);
								var currentpage = s_list [j].PagesList [k];
							//var pagerr = s_list[j].PagesList[k].content.lopage.loslide

									for (int m = 1; m < slides.Count; m++) {
										LOSlideSource slidesource = new LOSlideSource(this);

										var _id_ = vm.LOsInCircle [i].lo.color_id;
										is_main = !is_main;
										//Console.WriteLine ("TIPOOOOOOOOOO = " + slides [m].lotype);	

										slidesource.ColorS = Configuration.ListaColores [indice % 6];
							
										slidesource.Type = slides[m].lotype;
										if (slides[m].lotitle != null) slidesource.Title = slides[m].lotitle;
										if (slides[m].loparagraph != null) slidesource.Paragraph = slides[m].loparagraph;
										if (slides[m].loimage != null) slidesource.ImageUrl = slides[m].loimage;
										if (slides[m].lotext != null) slidesource.Paragraph = slides[m].lotext;
										if (slides[m].loauthor != null) slidesource.Author = slides[m].loauthor;
										if (slides[m].lovideo != null) slidesource.VideoUrl = slides[m].lovideo;
										if (slides[m].image_bytes != null) slidesource.ImageBytes = slides[m].image_bytes; 

										var c_slide = slides[m];
										c_slide.PropertyChanged+=(s,e)=>{
											if (e.PropertyName == "image_bytes" && c_slide.image_bytes != null)
												slidesource.ImageBytes = c_slide.image_bytes; 
										};
										if (c_slide.loitemize != null){
													slidesource.Itemize = new ObservableCollection<LOItemSource>();
													var items = c_slide.loitemize.loitem;
													for (int n = 0; n < items.Count; n++){ 
														LOItemSource item = new LOItemSource();
														if (items[n].loimage != null) item.ImageUrl = items[n].loimage;
														if (items[n].lotext != null) item.Text = items[n].lotext;
														//imagebytes
														if (items[n].image_bytes != null) item.ImageBytes = items[n].image_bytes; 

														var c_item_ize = items[n];
														c_item_ize.PropertyChanged += (s1, e1) =>{
															if (e1.PropertyName == "image_bytes" && c_item_ize.image_bytes != null)
																item.ImageBytes = c_item_ize.image_bytes; 
														};
														slidesource.Itemize.Add(item);
													}
										}

								linearScroll.AddView (slidesource.getViewSlide());

									} 
							scrollPager.AddView (linearScroll);
							listaScroll.Add (scrollPager);
							indice++;
							}


						//}

					}
					mainLayoutPages.RemoveAllViews ();
					//_progresD.Hide ();
					mainLayoutPages.AddView (viewPager);
					mainLayoutPages.SetX (0);
					mainLayoutPages.SetY (0);
					mainLayout.AddView (mainLayoutPages);
					LOViewAdapter adapter = new LOViewAdapter (this, listaScroll);
					viewPager.Adapter = adapter;
					viewPager.CurrentItem = IndiceSection;
				}

			}

			//add pages
			//_readerview.Source = pagelistsource;
			//Canvas.SetZIndex(_readerview, 10);
		}



		void loadPages(){



				for (int j = 0; j < 6; j++) {
					VerticalScrollViewPager scroll = new VerticalScrollViewPager (this);
					scroll.setOnScrollViewListener (this); 
					LinearLayout la = new LinearLayout (this);
					la.LayoutParameters = new LinearLayout.LayoutParams (-1, -2);
					la.Orientation = Orientation.Vertical;

					for (int i = 0; i < 20; i++) {
						Button btn = new Button (this);
						btn.Text = "HOLA MUNDOOOOOOOOOOO";
						la.AddView (btn);
					}
					scroll.AddView (la);
					listaScroll.Add (scroll);

				}
				mainLayoutPages.AddView (viewPager);
				mainLayoutPages.SetX (0);
				mainLayoutPages.SetY (0);
				mainLayout.AddView (mainLayoutPages);
				LOViewAdapter adapter = new LOViewAdapter (this, listaScroll);

				viewPager.Adapter = adapter;

		}

		public void  OnScrollChanged(VerticalScrollView scrollView, int l, int t, int oldl, int oldt) {

			listFront[0].Imagen.SetY (scrollView.ScrollY / 2);
		//	listFront[0].Imagen.ScaleX =scrollView.ScrollY / 10;
		//	listFront[0].Imagen.ScaleY =scrollView.ScrollY / 10;

		}

		public void OnScrollChangedPager(VerticalScrollViewPager scrollView, int l, int t, int oldl, int oldt) {
			var view=(LinearLayout)scrollView.GetChildAt (0);
			var pagerrr =  (FrontContainerViewPager)view.GetChildAt (0);
			pagerrr.Imagen.SetY (scrollView.ScrollY / 2);
			//Console.WriteLine("SCROLLEOOO LOS PAGERRRRRRRRRRRRR "+ scrollView.ScrollY);

		}




		private void iniContentLOs (){
			/*FrontContainerView front = new FrontContainerView (this);

			front.NameLO = "Camino Inca";
			front.Author = "Author: David Spencer";
			front.Chapter = "Flora y Faurna";
			front.Like = "10";
			ChapterContainerView chapter = new ChapterContainerView (this,Configuration.TYPE_TEXT);
			chapter.Title="Fauna Amazoníca";
			chapter.Author = "Author: Roger Valencia";
			chapter.Container="You, can everyone in the Internet group pelase shoot me an email. I";
			chapter.ColorText=Configuration.lila;

			MenuDownView menu = new MenuDownView (this);
			menu.Title ="Rutas Alternativas";

			ChapterContainerView chapter1 = new ChapterContainerView (this,Configuration.TYPE_IMAGE);
			chapter1.Title="Fauna Amazoníca";
			chapter1.Author = "Author: Patrick Lags";

			chapter1.Image = "images/paisaje1.jpg";
			chapter1.Image = "images/paisaje2.jpg";
			chapter1.Image = "images/paisaje3.jpg";
			chapter1.Image = "images/paisaje4.jpg";
			chapter1.Image = "images/paisaje5.jpg";
			//chapter1.Container="You, can everyone in the Internet group pelase shoot me an email. I";
			chapter1.ColorText=Configuration.verde;

			ChapterContainerView chapter2 = new ChapterContainerView (this,Configuration.TYPE_TEXT);
			chapter2.Title="Fauna Amazoníca";
			chapter2.Author = "Author: David Spencer";
			chapter2.Container="You, can everyone in the Internet group pelase shoot me an email. I";
			chapter2.ColorText=Configuration.azul;

			ChapterContainerView chapter3 = new ChapterContainerView (this, Configuration.TYPE_IMAGE);
			chapter3.Title="Fauna Amazoníca";
			chapter3.Author = "Author: David Spencer";
			//chapter3.Container="You, can everyone in the Internet group pelase shoot me an email. I";
			chapter3.ColorText=Configuration.amarillo;

			chapter3.Image = "images/paisaje1.jpg";
			chapter3.Image = "images/paisaje2.jpg";
			chapter3.Image = "images/paisaje3.jpg";
			chapter3.Image = "images/paisaje4.jpg";
			chapter3.Image = "images/paisaje5.jpg";


			ChapterContainerView chapter4 = new ChapterContainerView (this,Configuration.TYPE_TEXT);
			chapter4.Title="Fauna Amazoníca";
			chapter4.Author = "Author: David Spencer";
			chapter4.Container="You, can everyone in the Internet group pelase shoot me an email. I";
			chapter4.ColorText=Configuration.naranja;

			MenuDownView menu1 = new MenuDownView (this);
			menu1.Title ="Rutas Machu Picchu";

			ChapterContainerView chapter5 = new ChapterContainerView (this, Configuration.TYPE_TEXT);
			chapter5.Title="Fauna Amazoníca";
			chapter5.Author = "Author: David Spencer";
			chapter5.Container="You, can everyone in the Internet group pelase shoot me an email. I";
			chapter5.ColorText=Configuration.rosa;

			ChapterContainerView chapter6 = new ChapterContainerView (this, Configuration.TYPE_TEXT);
			chapter6.Title="Fauna Amazoníca";
			chapter6.Author = "Author: David Spencer";
			chapter6.Container="You, can everyone in the Internet group pelase shoot me an email. I";
			chapter6.ColorText=Configuration.lila;



			layoutPanelScroll.AddView (front);
			layoutPanelScroll.AddView (chapter);
			layoutPanelScroll.AddView (chapter1);
			layoutPanelScroll.AddView (menu);
			layoutPanelScroll.AddView (chapter2);
			layoutPanelScroll.AddView (chapter3);
			layoutPanelScroll.AddView (chapter4);
			layoutPanelScroll.AddView (menu1);
			layoutPanelScroll.AddView (chapter5);
			layoutPanelScroll.AddView (chapter6);

*/
		}


		public Bitmap getBitmapFromAsset( String filePath) {
			System.IO.Stream s =this.Assets.Open (filePath);
			Bitmap bitmap = BitmapFactory.DecodeStream (s);

			return bitmap;
		}
		//System.Collections.ObjectModel.ObservableCollection<LOViewModel.page_collection_wrapper> s_list;

		public override void OnBackPressed ()
		{
			if (mainLayoutIndice.Visibility == ViewStates.Visible) {
				base.OnBackPressed ();
			}
			ISLOADED = true;
			mainLayoutIndice.Visibility = ViewStates.Visible;
			mainLayoutPages.Visibility = ViewStates.Invisible;


			//

		}

    }
}