namespace Csharp_Task5_16.Task
{
    public class DeskLamp : Lamp
    {
        public string Model { get; set; }
        public int PercentOfBrightness { get; set; }

        public DeskLamp(string model) : base()
        {
            Model = model;
            PercentOfBrightness = 100;
            BaseType = LampBase.MONOLITHIC;
            Power = 20;
        }

        public override string TurnOff()
        {
            if (IsLampOn)
            {
                IsLampOn = false;
                return "Настольная лампа выключена";
            }
            else
            {
                return "Настольная лампа уже выключена";
            }
        }

        public override string TurnOn()
        {
            if (!IsLampOn)
            {
                IsLampOn = true;
                return "Настольная лампа включена";
            }
            else
            {
                return "Настольная лампа уже включена";
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

        public string GetPercentOfBrightness()
        {
            return PercentOfBrightness.ToString();
        }

        public string SetPercentOfBrightness(int percent)
        {
            if (percent <= 100 && percent >= 0)
            {
                PercentOfBrightness = percent;
                return "Яркость выставлена на " + percent + "%";
            }
            else
            {
                return "Ошибка! Значение должно быть от 0 до 100";
            }
        }
    }
}
