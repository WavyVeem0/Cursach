namespace cursach.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
	private ViewModelBase _contentViewModel;

        //this has a dependency on the ToDoListService

        public MainWindowViewModel()
        {
         //   var service = new ToDoListService();
         //   ToDoList = new ToDoListViewModel(service.GetItems());
         //   _contentViewModel = ToDoList;
        }

        /* public ToDoListViewModel ToDoList { get; }
        
        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        public void AddItem()
        {
            ContentViewModel = new AddItemViewModel();
        }
	*/
   
}
