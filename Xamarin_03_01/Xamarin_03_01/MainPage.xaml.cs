using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin_03_01
{
    public partial class MainPage : ContentPage
    {

        public ObservableCollection<Student> Students { get; set; }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }

        public MainPage()
        {
            InitializeComponent();
            Students = new ObservableCollection<Student>();
            AddCommand = new Command(AddItem);
            RemoveCommand = new Command(RemoveItem);

            this.BindingContext = this;
        }
        private void AddItem()
        {
            Students.Add(
                new Student(surnameEntry.Text, Convert.ToInt32(physicPointEntry.Text),
                    Convert.ToInt32(mathPointEntry.Text), Convert.ToInt32(infPointEntry.Text)));

            surnameEntry.Text = physicPointEntry.Text = mathPointEntry.Text = infPointEntry.Text = "";
        }

        private void RemoveItem()
        {
            Student student = studentList.SelectedItem as Student;
            if (student != null)
            {
                Students.Remove(student);
                studentList.SelectedItem = null;
            }
        }
    }

    public class Student 
    {
        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (value.Length > 0)
                    _surname = value;
            }
        }

        private int _physicScore;
        public int PhysicScore
        {
            get { return _physicScore; }
            set
            {
                if (value > 2 && value <= 5)
                    _physicScore = value;
            }
        }

        private int _mathScore;
        public int MathScore
        {
            get { return _mathScore; }
            set
            {
                if (value > 2 && value <= 5)
                    _mathScore = value;
            }
        }

        private int _infScore;
        public int InfScore
        {
            get { return _infScore; }
            set
            {
                if (value > 2 && value <= 5)
                    _infScore = value;
            }
        }

        public Student(string surname, int physicScore, int mathScore, int infScore)
        {
            Surname = surname;
            PhysicScore = physicScore;
            MathScore = mathScore;
            InfScore = infScore;
        }

     
        public override string ToString()
        {
            return "Прізвище : " + Surname + "\n Оцінки: \n" +
                " Фізика = " + PhysicScore + ", Математика = " +
                MathScore + ", Інформатика = " + InfScore;
        }



    }
}
