﻿using Notiz.Models;
using Notiz.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestNotiz
{
	[TestFixture]
	public class MainPageModelTest
	{
		// 2 Notes added and one removed after.
		[Test]
		public void DeleteNoteAfterAddedTest()
		{
			var vm = new MainViewModel();
			NoteObj item = new NoteObj
			{
				Note = "Note 1"
			};
			NoteObj item2 = new NoteObj
			{
				Note = "Main Incubator"
			};
			vm.NotizEntries.Add(item);
			vm.NotizEntries.Add(item2);
			vm.DeleteNoteCommand.Execute(item);
			Assert.AreEqual(1, vm.NotizEntries.Count);
		}

		// Check if the list have 1 element added.
		[Test]
		public void NoteAddedFromUITest()
		{
			var vm = new MainViewModel();
			vm.NoteEntry = "Main Incubator";
			vm.AddNoteInternalAsync().Wait();
			Assert.AreEqual(1, vm.NotizEntries.Count);
		}

	}
}
