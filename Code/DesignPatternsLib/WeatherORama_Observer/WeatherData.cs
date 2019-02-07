using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.WeatherORama_Observer
{
    public class WeatherData : Subject
    {
        private List<Observer> Observers { get; set; }
        private float Temperature { get; set; }
        private float Humidity { get; set; }
        private float Pressure { get; set; }

        public WeatherData()
        {
            Observers = new List<Observer>();
        }
        public void CheckOpenWeatherMapAPI()
        {
            string url = @"api.openweathermap.org/data/2.5/weather?q=KansasCity,USA";


        }
        public void GetTemperature()
        {

        }
        public void GetHumidity()
        {

        }
        public void GetPressure()
        {

        }
        public void MeasurementsChanged()
        {
            NotifyObservers();
        }
        public void RegisterObserver(Observer observer)
        {
            Observers.Add(observer);
        }
        public void RemoveObserver(Observer observer)
        {
            Observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            foreach(Observer observer in Observers)
            {
                observer.Update(Temperature, Humidity, Pressure);
            }
        }
    }
}
