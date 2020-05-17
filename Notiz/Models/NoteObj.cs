using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Notiz.Models
{
	public class NoteObj
	{
		public string Note { get; set; }
		public ImageSource Source { get; set; }

		public NoteObj() { }
		public NoteObj(string note, ImageSource source)
		{
			Note = note;
			Source = source;
		}
	}
}
