using System;
using System.Collections.Generic;
using System.Reflection;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Csharp_Task5_16.Task;

namespace Csharp_Task5_16.Views
{
    public partial class MainWindow : Window
    {
        private List<ILightSource> lamps;
        private ILightSource? enabledClass;
        private int enabledIndexMethod;
        private List<TextBox> enabledTBs;

        public MainWindow()
        {
            lamps = new List<ILightSource>();
            enabledClass = null;
            enabledTBs = new List<TextBox>();
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void RenderClasses()
        {
            var textBox = this.FindControl<Grid>("GridListClasses");
            textBox.Children.Clear();
            int index = 0;
            foreach (var lamp in lamps)
            {
                Button btn = new Button
                {
                    Content = lamp.ToString()
                };
                btn.Click += ButtonEnableClass;
                btn.CommandParameter = index;
                Grid.SetRow(btn, index);
                Grid.SetColumn(btn, 0);
                index++;
                textBox.Children.Add(btn);
            }
        }

        public void ButtonAddDeskLamp(object sender, RoutedEventArgs e)
        {
            var textBox = this.FindControl<TextBox>("TBAddDeskLamp");
            lamps.Add(new DeskLamp(textBox.Text));
            RenderClasses();
        }
        public void ButtonAddChandelier(object sender, RoutedEventArgs e)
        {
            var textBox = this.FindControl<TextBox>("TBAddChandelier");
            lamps.Add(new Chandelier(textBox.Text));
            RenderClasses();
        }

        public void ButtonAddFloorLamp(object sender, RoutedEventArgs e)
        {
            var textBox = this.FindControl<TextBox>("TBAddFloorLamp");
            lamps.Add(new FloorLamp(textBox.Text));
            RenderClasses();
        }

        private void ButtonSubmitMethod(object sender, RoutedEventArgs e) //������� ������ "���������"
        {
            if (enabledClass is null)
            {
                return;
            }
            Type typeClass = enabledClass.GetType();
            var typeMethod = typeClass.GetMethods()[(int)enabledIndexMethod];
            ParameterInfo[] parameters = typeMethod.GetParameters();
            object[] args = new object[parameters.Length];
            int index = 0;
            /* � ����� ���� ���������� ���������� � textbox string ��������� � ������� ���� ���������.
             * � ������ ����������, ������ ���������� � ������� ����� � ������� Convert.ChangeType, ���� ����������
             * � enum ���� ������ LampBase. ��� ��������� �������� �� ������������ ���������� ��������� ������ ����� �����������
             * � ��������������� � textbox
             */
            foreach (var textbox in enabledTBs)
            {
                if (parameters[index].ParameterType == typeof(LampBase)) 
                {
                    if (Enum.IsDefined(typeof(LampBase), textbox.Text))
                    {
                        args[index] = Enum.Parse(typeof(LampBase), textbox.Text);
                        index++;
                    }
                    else
                    {
                        var textOut = this.FindControl<TextBox>("TextBlockStat");
                        textOut.Text = "����������! ������� ������ �� ���������� � ������ �������";
                        return;
                    }
                }
                else
                {
                    args[index] = Convert.ChangeType(textbox.Text, parameters[index].ParameterType);
                    index++;
                }
            }
            var ret = typeMethod.Invoke(enabledClass, args);
            var textBlockOut = this.FindControl<TextBox>("TextBlockStat");
            textBlockOut.Text = "�������! \n" + ret;
        }

        private void ButtonEnableClass(object? sender, RoutedEventArgs e) //������� ������ ���������� ������
        {
            var thisButton = (Button)sender!;
            var lamp = (Lamp)lamps[(int)thisButton.CommandParameter];
            enabledClass = lamp;
            var textBlock = this.FindControl<TextBox>("TextBlockStat");
            string outString = "������ ����� ������:\n";
            foreach (var prop in lamp.GetType().GetProperties())
            {
                outString += prop.Name + " = " + prop.GetValue(lamp, null) + "\n";
            }
            textBlock.Text = outString;
            var textBox = this.FindControl<Grid>("GridMethods");
            textBox.Children.Clear();
            int index = 0;
            foreach (var method in lamp.GetType().GetMethods())
            {
                Button btn = new Button
                {
                    Content = method
                };
                btn.Click += ButtonEnableMethod;
                btn.CommandParameter = index;
                Grid.SetRow(btn, index);
                Grid.SetColumn(btn, 0);
                textBox.Children.Add(btn);
                index++;
            }
        }

        private void ButtonEnableMethod(object sender, RoutedEventArgs e) //������� ������ ������
        {
            var senderBtn = (Button)sender!;
            var indexMethod = senderBtn.CommandParameter;
            enabledIndexMethod = (int)indexMethod;
            Type typeClass = enabledClass.GetType();
            var typeMethod = typeClass.GetMethods()[(int)indexMethod];
            ParameterInfo[] parameters = typeMethod.GetParameters();
            var grid = this.FindControl<Grid>("GridCompleteMethod");
            grid.Children.Clear();
            enabledTBs.Clear();
            for (int i = 0; i < parameters.Length; i++)
            {
                TextBox tb = new TextBox();
                tb.Name = parameters[i].Name;
                tb.Watermark = parameters[i].ParameterType.Name + " " + parameters[i].Name;
                Grid.SetRow(tb, i);
                Grid.SetColumn(tb, 0);
                grid.Children.Add(tb);
                enabledTBs.Add(tb);
            }
        }
    }
}
