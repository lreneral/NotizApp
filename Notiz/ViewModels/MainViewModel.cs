using Notiz.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Notiz.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		public const string IMAGE_URL = "https://picsum.photos/200";
		private ObservableCollection<NoteObj> _notizEntries;
		private string _noteEntry;
		private readonly HttpClient httpClient;
		public string NoteEntry
		{
			get { return _noteEntry; }
			set
			{
				_noteEntry = value;
				OnPropertyChanged(nameof(NoteEntry));
			}
		}
		public ICommand SaveNoteCommand => new Command(AddNoteToListAsync);
		public ICommand DeleteNoteCommand => new Command<NoteObj>(RemoveItemfromList);

		public ObservableCollection<NoteObj> NotizEntries
		{
			get { return _notizEntries; }
			set
			{
				_notizEntries = value;
				OnPropertyChanged(nameof(NotizEntries));
			}
		}

		public MainViewModel()
		{
			Title = Strings.Text.NoteTxt;
			NotizEntries = new ObservableCollection<NoteObj>();
			httpClient = new HttpClient();
		}
		//Remove the selected Note to The Observable List.
		private void RemoveItemfromList(NoteObj obj)
		{
			NotizEntries.Remove(obj);
		}
		// Add the Note to the Observable List.
		private async void AddNoteToListAsync()
		{
			await AddNoteInternalAsync();
		}

		// This method check if the entry is empty or whiteSpace and add it to the observableList.
		public async Task AddNoteInternalAsync()
		{
			if (!String.IsNullOrWhiteSpace(NoteEntry))
			{
				NoteObj item = new NoteObj
				{
					Note = NoteEntry
				};
				var stream = await httpClient.GetStreamAsync(IMAGE_URL);
				item.Source = ImageSource.FromStream(() => stream);
				NotizEntries.Add(item);
				NoteEntry = String.Empty;
			}
		}


	}
}
