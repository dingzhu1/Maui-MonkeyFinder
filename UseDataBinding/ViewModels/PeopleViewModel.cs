using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UseDataBinding.Models;

namespace UseDataBinding.ViewModels
{
  public  class PeopleViewModel
    {
        public ObservableCollection<Person> Employees { get; set; }

        public ICommand DeleteEmployeeCommand { get; private set; }

        public PeopleViewModel()
        {
            DeleteEmployeeCommand = new Command((employee) =>
            {
                Employees.Remove(employee as Person);
            });
        }
    }
}
