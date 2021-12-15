namespace Csharp_Task5_16.Task
{
    public class Chandelier : Lamp
    {
        public string Model { get; set; }
        public int NumberOfBulbs { get; set; }

        public Chandelier(string model) : base()
        {
            Model = model;
            NumberOfBulbs = 6;
            Power = 60;
        }

        public override string TurnOff()
        {
            if (IsLampOn)
            {
                IsLampOn = false;
                return "Люстра выключена";
            }
            else
            {
                return "Люстра уже выключена";
            }
        }

        public override string TurnOn()
        {
            if (!IsLampOn)
            {
                IsLampOn = true;
                return "Люстра включена";
            }
            else
            {
                return "Люстра уже включена";
            }
        }

        public string GetModel()
        {
            return Model;
        }

        public string SetModel(string model)
        {
            Model = model;
            return "Название модели изменено на " + model;
        }

        public string GetNumberOfBulbs()
        {
            return NumberOfBulbs.ToString();
        }

        public string SetNumberOfBulbs(int numberOfBulbs)
        {
            NumberOfBulbs = numberOfBulbs;
            return "Теперь вкручены " + numberOfBulbs + " лампочек";
        }
    }
}
