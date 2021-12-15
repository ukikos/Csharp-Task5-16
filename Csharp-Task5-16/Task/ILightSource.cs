namespace Csharp_Task5_16.Task
{
    public interface ILightSource
    {
        string LightColor
        {
            get;
            set;
        }

        string TurnOn();

        string TurnOff();
    }
}
