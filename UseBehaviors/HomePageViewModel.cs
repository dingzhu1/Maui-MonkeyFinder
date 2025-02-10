using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UseBehaviors
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Person> People { get; private set; }

        public ICommand OutputAgeCommand { get; private set; }

        public string SelectedItemText { get; private set; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public HomePageViewModel()
        {
            People = new ObservableCollection<Person>
            {
                new Person ("Steve", 21),
                new Person ("John", 37),
                new Person ("Tom", 42),
                new Person ("Lucas", 29),
                new Person ("Tariq", 39),
                new Person ("Jane", 30)
            };
            OutputAgeCommand = new Command<Person>(OutputAge);
        }

        private void OutputAge(Person person)
        {
            SelectedItemText = string.Format("{0} is {1} years old.", person.Name, person.Age);
            OnPropertyChanged("SelectedItemText");
        }
    }
}
