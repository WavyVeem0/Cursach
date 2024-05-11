using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Controls;
using Avalonia.Input;
using System.IO;
using System;
using liba;
namespace cursach.Views;

public partial class MainWindow : Window
{
    private Label somestr;
    public Solution CurrentSolution;
    public MainWindow()
    {
        InitializeComponent();

    }
    


    private void OnButtonClick(object sender,RoutedEventArgs args)
    {
	    if (Problem.Text == null || Problem.Text.Length == 0)
	    {
		Title.Content = "Строка пуста, введите проблему!";
	    }
	    else 
	    {
		Solution Curr_Solution = new Solution(Problem.Text);
    		this.CurrentSolution = Curr_Solution;
    		var dialog = new Writing(this.CurrentSolution);
    		dialog.ShowDialog(this);
	    }
    }
    private void OpenSettingsClick(object sender, RoutedEventArgs args)
    {
	    this.Close();
    }
    private void OpenResultsClick(object sender, RoutedEventArgs args)
    {
	    var dialog = new Settings();
	    dialog.ShowDialog(this);
    }

    private void OnBoxType(object sender, KeyEventArgs args)
    {
	StreamWriter sw = new StreamWriter("logs.txt", true);
	sw.Write(args.Key);
    	sw.Close();
    }
}

