namespace Csharp_Task5_16.Task
{
    public class FloorLamp : Lamp
    {
        public string Model { get; set; }
        public int Height { get; set; }

        public FloorLamp(string model) : base()
        {
            Model = model;
            Height = 140;
            Power = 50;
        }

        public override string TurnOff()
        {
            if (IsLampOn)
            {
                IsLampOn = false;
                return "Торшер выключен";
            }
            else
            {
                return "Торшер уже выключен";
            }
        }

        public override string TurnOn()
        {
            if (!IsLampOn)
            {
                IsLampOn = true;
                return "Торшер включен";
            }
            else
            {
                return "Торшер уже включен";
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

        public string GetHeight()
        {
            return Height.ToString();
        }
    }
}
