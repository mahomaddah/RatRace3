using RatRace3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RatRace3.Models;


namespace RatRace3.ViewModel
{
    public class SunburstViewModel
    {
        public ObservableCollection<SunburstModel> DataSource { get; set; }

        public SunburstViewModel()
        {
            this.DataSource = new ObservableCollection<SunburstModel>
            {
                new SunburstModel {Country= "USA", JobGroup = "Sales",JobDescription = "Executive", EmployeesCount = 50 },
                new SunburstModel {Country= "USA", JobGroup =  "Sales",JobDescription = "Analyst",   EmployeesCount =40 },
                new SunburstModel {Country= "USA", JobGroup =  "Marketing",   EmployeesCount =40 },
                new SunburstModel {Country= "USA", JobGroup =  "Technical", JobDescription ="Testers",   EmployeesCount =35 },
                new SunburstModel {Country= "USA", JobGroup =  "Technical",JobDescription = "Developers",  EmployeesCount = 175 },
                new SunburstModel {Country= "USA", JobGroup =  "Technical",JobDescription = "Developers",  EmployeesCount = 70 },
                new SunburstModel {Country= "USA", JobGroup =  "Management",   EmployeesCount =40 },
                new SunburstModel {Country= "USA", JobGroup =  "Accounts",  EmployeesCount = 60 },
                new SunburstModel {Country= "Iran", JobGroup =  "Technical",JobDescription = "Testers",  EmployeesCount = 33 },
                new SunburstModel {Country= "Iran", JobGroup =  "Technical",JobDescription = "Developers",  EmployeesCount = 125 },
                new SunburstModel {Country= "Turkey", JobGroup =  "Technical",JobDescription = "Developers", EmployeesCount =  60 },
                new SunburstModel {Country= "Turkey",  JobGroup = "HR Executives",  EmployeesCount = 70 },
                new SunburstModel {Country= "Turkey", JobGroup =  "Accounts",  EmployeesCount = 45 },
                new SunburstModel {Country= "Germany", JobGroup =  "Sales", JobDescription ="Executive",  EmployeesCount = 30 },
                new SunburstModel {Country= "Germany", JobGroup =  "Sales",JobDescription = "Analyst",  EmployeesCount = 40 },
                new SunburstModel {Country= "Germany", JobGroup =  "Marketing",  EmployeesCount = 50 },
                new SunburstModel {Country= "Germany", JobGroup =  "Technical", JobDescription ="Testers",  EmployeesCount = 40 },
                new SunburstModel {Country= "Germany", JobGroup =  "Technical", JobDescription ="Developers",  EmployeesCount = 60 },
                new SunburstModel {Country= "Germany", JobGroup =  "Technical", JobDescription ="Developers",  EmployeesCount = 27 },
                new SunburstModel {Country= "Germany", JobGroup =  "Management",  EmployeesCount = 40 },
                new SunburstModel {Country= "Germany", JobGroup =  "Accounts",  EmployeesCount = 55 },
                new SunburstModel {Country= "UK", JobGroup =  "Technical",JobDescription = "Testers",  EmployeesCount = 96 },
                new SunburstModel {Country= "UK", JobGroup =  "Technical",JobDescription = "Developers", EmployeesCount =  55 },
                new SunburstModel {Country= "UK", JobGroup =  "HR Executives",   EmployeesCount =60 },
                new SunburstModel {Country= "UK", JobGroup =  "Accounts", EmployeesCount =  45 }
            };
        }
    }
}
