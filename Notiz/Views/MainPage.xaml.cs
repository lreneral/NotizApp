using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notiz.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void ImageButton_Clicked(object sender, EventArgs e)
		{
			ImageButton context = (sender as ImageButton);
			var note = context.BindingContext as Notiz.Models.NoteObj;
			if (note != null)
			{
				(BindingContext as ViewModels.MainViewModel).DeleteNoteCommand.Execute(note);
			}
		}
	}
}