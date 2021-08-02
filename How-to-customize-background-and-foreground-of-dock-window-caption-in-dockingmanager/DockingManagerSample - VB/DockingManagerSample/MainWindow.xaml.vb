Imports Syncfusion.Windows.Shared
Imports Syncfusion.Windows.Tools.Controls
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace DockingManagerSample
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
			'set docking window header backcolor
			dockingmanager.HeaderBackground = Brushes.Gray
			'set selected docking window header backcolor
			dockingmanager.SelectedHeaderBackground = Brushes.Green
			'set docking window header for hovering
			dockingmanager.HeaderMouseOverBackground = Brushes.Yellow
			'set docking window Header foreground color
			dockingmanager.HeaderForeground = Brushes.Red
			'set selected docking window header fore color 
			dockingmanager.HeaderForegroundSelected = Brushes.Yellow

		End Sub
	End Class
End Namespace
