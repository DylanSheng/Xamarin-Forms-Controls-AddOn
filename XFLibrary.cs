using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XFLibrary
{
	public class XFLibrary : ContentPage
	{
		private int _age;
		public int Age
		{
			get;set;
		}
		public XFLibrary ()
		{
			var button = new Button {
				Text = "Click Me!",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			int clicked = 0;
			button.Clicked += (s, e) => button.Text = "Clicked: " + clicked++;

			Content = button;
		}

		public string concatee(string x, string y) {
			return x + y;
		}
	}
}
