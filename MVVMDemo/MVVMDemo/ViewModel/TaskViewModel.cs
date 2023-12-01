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

        ICommand Get { set; get; }
        ICommand Save { set; get; }

        public TaskViewModel()
        {
            taskTemp = new List<TaskModel>();

            Save = new Command(x =>
            {
                taskTemp.Add(new TaskModel {
                
                Title=this.Title,
                Description=this.title
                });

            });


            Get = new Command(x =>
            {
                Tasks = new ObservableCollection<TaskModel>(taskTemp);

            });
        }


    }


}
