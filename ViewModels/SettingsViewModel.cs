using System.Collections.ObjectModel;
using liba;
using System;
using Microsoft.Data.Sqlite;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Input;
using Avalonia;
namespace cursach.ViewModels;

public class SettingsViewModel : ViewModelBase
{
 public ObservableCollection<Solution> SolutionList {get; set;}
 public SettingsViewModel()
 {
  SolutionList = new ObservableCollection<Solution>();
  string sqlExpression = "SELECT * FROM Answers";
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
      var keyWord = reader.GetValue(2);
      var problem = reader.GetValue(3);
      Solution item = new Solution(id.ToString(), textSolution.ToString(), problem.ToString(), keyWord.ToString());
      SolutionList.Add(item);
     }
    }
   }

  }
 }
}
