using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Input;
using System;
using Avalonia.Threading;
using Avalonia.Markup.Xaml;
using System.IO;
using liba;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
namespace cursach.Views;
public partial class Writing : Window 
{
	
	private DispatcherTimer progressBarTimer = null;
	private Solution curr_solution;
	public Writing(Solution curr_solution)
	{
		InitializeComponent();
		this.curr_solution = curr_solution; 

		CurrentProb.Text = "Текущая проблема: " + curr_solution.Problem;
		progressBarTimer = new DispatcherTimer();
		progressBarTimer.Tick += new EventHandler(timerTick);
		progressBarTimer.Interval = new TimeSpan(0,0,0,0,500);
		progressBarTimer.Start();
	}
	private void timerTick(object sender, EventArgs e)
	{
		Time.Value--;
		if (Time.Value == 0)
		{
			progressBarTimer.Stop();
			SaveChanges();
			this.Close();
		}

	}
	public void ExitClickButton(object sender, RoutedEventArgs args) 
	{
		SaveChanges();
		SaveToDB();
		this.Close();
	}
	public void SaveChanges()
	{
		StreamWriter sw = new StreamWriter("Result.txt");
		sw.Write(curr_solution.Problem + "\n");
		sw.Write(InputBox.Text);
		sw.Close();
	}
	public void SaveToDB()
	{
		string connectionString = "Data Source=userdata.db";
		using (var connection = new SqliteConnection(connectionString))
		{
			connection.Open();
			try 
			{
				SqliteCommand command = connection.CreateCommand();
				command.Connection = connection;

				command.CommandText = "CREATE TABLE Answers(_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Solution TEXT, Likes INTEGER)";
				command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				Console.WriteLine("Failed to Create Table");
			}

			SqliteCommand addElement = connection.CreateCommand();
			addElement.Connection = connection;
			addElement.CommandText = $"INSERT INTO Answers (Solution, Likes) VALUES (\"{InputBox.Text}\", 0)";
			addElement.ExecuteNonQuery();

		}
	}



}
