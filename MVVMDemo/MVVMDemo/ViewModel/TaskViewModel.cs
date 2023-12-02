using MVVMDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMDemo.ViewModel
{
    public class TaskViewModel : ViewModelBase
    {

        int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged();
                }
            }
        }
        string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged();
                }
            }
        }
        
        ObservableCollection<TaskModel> tasks;
        public ObservableCollection<TaskModel> Tasks
        {
            get { return tasks; }
            set
            {
                if (tasks != value)
                {
                    tasks = value;
                    OnPropertyChanged();
                }
            }
        }

        private List<TaskModel> taskTemp;

        public ICommand Get { set; get; }
        public ICommand Save { set; get; }

        public TaskViewModel()
        {
            taskTemp = new List<TaskModel>();

            Save = new Command(x =>
            {
                taskTemp.Add(new TaskModel {
                
                Id=this.Id,
                Title=this.Title,
                Description=this.Description,
                });

            });


            Get = new Command(x =>
            {
                Tasks = new ObservableCollection<TaskModel>(taskTemp);

            });
        }


    }


}
