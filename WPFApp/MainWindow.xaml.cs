﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateTask();
        }


        void AddMessage(string message)
        {
            int CurrrentThreadId = Thread.CurrentThread.ManagedThreadId;
            this.Dispatcher.Invoke(() =>
            {
                Messages.Content +=
                $"Mensaje: {message}, " +
                $"Hilo actual: {Thread.CurrentThread.ManagedThreadId}\n";

            });
            
        }

        void CreateTask()
        {
            Task T;
            // ¿Que es un delegado? Apuntador a funciones
            // Por ejemplo: Action y Func
            Action Code = new Action(ShowMesage);
            T = new Task(Code);
            Task T2 = new Task(delegate
            {
                MessageBox.Show("Ejecucion una tarea en un metodo anonimo");
            });
            Task T3A = new Task(ShowMesage);
            Task T3 = new Task(
                () => ShowMesage());
                
            
            //Expresion Lambda:
            //(Parametros de entrada) => Expresion 
            // () =>  Expresion
            //El operador lambda (=>) se lee como "va hacia"

            Task T4 = new Task( () => MessageBox.Show("Ejecucion la tarea 4"));
            
            Task T5 = new Task(() => 
            {
                DateTime CurrentDate = DateTime.Today;
                DateTime StarDate = CurrentDate.AddDays(30);
                MessageBox.Show($"Tare 5. Fecha Calculada: {StarDate}");
            });

            Task T6 = new Task((message) =>
            MessageBox.Show(message.ToString()), "Expresion lambda con parametros.");

            Task T7 = new Task(() => AddMessage("Ejecucion la tarea."));
            T7.Start();
            AddMessage("En el Hilo principal");
        }

        void ShowMesage()
        {
            MessageBox.Show("Ejecucion el metodo ShowMessage");
        }
    }
}