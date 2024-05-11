using System.Collections.Generic;
using System.Collections.ObjectModel;
using liba;
using System;
using Avalonia;
using Avalonia.Interactivity;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using Avalonia.Markup.Xaml;
using ReactiveUI.Fody;
using Avalonia.Controls;
using Avalonia.Input;

namespace cursach.ViewModels;

public class SettingsViewModel : ViewModelBase
{
	public ObservableCollection<Solution> SolutionList {get; set;}
	public SettingsViewModel()
	{
		string sqlExpression = "SELECT * FROM Answers";
		List<Solution> Solutions = new List<Solution>();
		using (var connection = new SqliteConnection("Data Source=userdata.db"))
		{
			connection.Open();
			SqliteCommand command = new SqliteCommand(sqlExpression, connection);
			using (SqliteDataReader reader = command.ExecuteReader())
			{
				if(reader.HasRows)
				{
					while (reader.Read())
					{
						var id = reader.GetValue(0);
						var textSolution = reader.GetValue(1);
						var likes = reader.GetValue(2);
						Console.WriteLine(id.ToString() + " " + textSolution + " " + likes.ToString());
						Solution item = new Solution("1111", "2222", "3333");
						SolutionList.Add(item);
					}
				}
			}

		}
		SolutionList = new ObservableCollection<Solution>(SolutionList);
		SolutionList.Add(new Solution("1111", "22", "3333"));
	}



}
