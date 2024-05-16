using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Input;
using System;
using Avalonia.Markup.Xaml;
using liba;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using cursach.ViewModels;
namespace cursach.Views;
public partial class Settings : Window 
{
	SettingsViewModel vm = new();
	public Settings()
	{
		InitializeComponent();
		this.DataContext = vm;
	}

 	public void ExitClick(object sender, RoutedEventArgs args) 
 	{
		this.Close();
 	}
}
