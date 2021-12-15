namespace Csharp_Task5_16.Task
{
    public abstract class Lamp : ILightSource
    {
        public string LightColor { get; set; }
        public bool IsLampOn { get; set; }
        public LampBase BaseType { get; set; }
        public int Power { get; set; }

        public Lamp()
        {
            LightColor = "White";
            IsLampOn = false;
            BaseType = LampBase.E26;
            Power = 50;
        }

        public virtual string TurnOff()
        {
            if (IsLampOn)
            {
                IsLampOn = false;
                return "Лампа выключена";
            }
            else
            {
                return "Лампа уже выключена";
            }
        }

        public virtual string TurnOn()
        {
            if (!IsLampOn)
            {
                IsLampOn = true;
                return "Лампа включена";
            }
            else
            {
                return "Лампа уже включена";
            }
        }

        public string GetBaseTypeString()
        {
            return BaseType.ToString();
        }

        public string GetPower()
        {
            return Power.ToString();
        }

        public void SetLightColor(string color)
        {
            LightColor = color;
        }
    }
}
