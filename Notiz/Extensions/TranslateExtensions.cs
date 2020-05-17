using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notiz.Extensions
{
	[ContentProperty("Text")]
	public class TranslateExtension : IMarkupExtension
	{
		private const string ResourceId = "Notiz.Strings.Text";
		private readonly ResourceManager resourceManager;

		public string Text { get; set; }

		public TranslateExtension()
		{
			this.resourceManager = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);
		}

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			string localized = resourceManager.GetString(Text, CultureInfo.CurrentCulture);
			return localized;
		}
	}
}
