using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace DockingDemo
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>

	public partial class App : Application
	{

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">
        /// More than one instance of the <see cref="T:System.Windows.Application"/> class is created per <see cref="T:System.AppDomain"/>.
        /// </exception>
		public App()
		{
			InitializeComponent();
		}

	}
}