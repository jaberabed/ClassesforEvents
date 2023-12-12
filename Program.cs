namespace FinalTest1
{
   internal class Program
   {
      private static void Main(string[] args)
      {
         Console.WriteLine("Hello, World!");
         TemperatureSensor sensor = new TemperatureSensor();
         // show temperature changes
         sensor.CurrentTemperature = 25.5;
         sensor.CurrentTemperature = 28.0;
      }

      public class TemperatureChangedEventArgs : EventArgs
      {
         public double NewTemperature { get; }

         public TemperatureChangedEventArgs(double newTemperature)
         {
            NewTemperature = newTemperature;
         }
      }

      public delegate void TemperatureChangedEventHandler(object sender, TemperatureChangedEventArgs e);

      public class TemperatureSensor
      {
         public event TemperatureChangedEventHandler? TemperatureChanged;

         private double currentTemperature;

         public double CurrentTemperature
         {
            get { return currentTemperature; }
            set
            {
               if (currentTemperature != value)
               {
                  currentTemperature = value;
                  OnTemperatureChanged(new TemperatureChangedEventArgs(value));
               }
            }
         }

         protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
         {
            TemperatureChanged?.Invoke(this, e);
         }
      }
   }
}