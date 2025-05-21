namespace Task13_2
{
    //Делегат
    public delegate void DeviceStateChanged(string device, string state);

    //Класс
    public class SmartHomeSystem
    {
        public string Device1;
        public string Device2;
        public string Device3;
        public event DeviceStateChanged StateChanged;

        public SmartHomeSystem(string device1, string device2, string device3)
        {
            Device1 = device1;
            Device2 = device2;
            Device3 = device3;
        }

        //Метод включить свет
        public void TurnOnLight()
        {
            StateChanged?.Invoke($"{Device1}", "Включен");
        }

        //Метод выключить свет
        public void TurnOffLight()
        {
            StateChanged?.Invoke($"{Device1}", "Выключен");
        }

        //Метод установить температуру
        public void SetTemperature(int temperature)
        {
            StateChanged?.Invoke($"{Device2}", $"Температура изменена на {temperature}°C");
        }

        //Метод заблокировать дверь
        public void LockDoor()
        {
            StateChanged?.Invoke($"{Device3}", "Заблокирована");
        }

        //Метод разблокировать дверь
        public void UnlockDoor()
        {
            StateChanged?.Invoke($"{Device3}", "Разблокирована");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var smartHome = new SmartHomeSystem("Light", "Thermostat", "Door");

            smartHome.StateChanged += (device, state) =>
            {
                Console.WriteLine($"[{DateTime.Now:HH.mm.ss}] {device}: {state}");
            };

            Console.WriteLine($"Список подключенных устройств: {smartHome.Device1}, {smartHome.Device2}, {smartHome.Device3}");
            Console.WriteLine();
            smartHome.TurnOnLight();
            smartHome.TurnOffLight();
            smartHome.SetTemperature(23);
            smartHome.LockDoor();
            smartHome.UnlockDoor();

            Console.ReadKey();
        }
    }
}
