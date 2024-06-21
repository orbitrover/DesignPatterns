using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.RealTimeExamplesofIteratorDesignPattern
{
    /// <summary>
    /// Client Code
    /// </summary>
    public static class RadioStationService
    {
        public static void Run()
        {
            RadioStation myStation = new RadioStation();
            myStation.AddChannel(new Channel(89.1, "Classic Rock"));
            myStation.AddChannel(new Channel(102.2, "Pop Hits"));
            myStation.AddChannel(new Channel(98.7, "News Channel"));
            INextPreviousIterator<Channel> iterator = myStation.GetIterator();
            Console.WriteLine("Forward:");
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next().Name);
            }
            Console.WriteLine("Backward:");
            while (iterator.HasPrevious())
            {
                Console.WriteLine(iterator.Previous().Name);
            }
            
        }
    }
    //Define Channel and RadioStation
    public class Channel
    {
        public double Frequency { get; private set; }
        public string Name { get; private set; }
        public Channel(double frequency, string name)
        {
            Frequency = frequency;
            Name = name;
        }
    }
    public class RadioStation
    {
        private List<Channel> _channels = new List<Channel>();
        public void AddChannel(Channel channel)
        {
            _channels.Add(channel);
        }
        public INextPreviousIterator<Channel> GetIterator()
        {
            return new RadioIterator(_channels);
        }
    }
    //Define Iterator and Concrete Iterator
    
    public class RadioIterator : INextPreviousIterator<Channel>
    {
        private List<Channel> _channels;
        private int _position = 0;
        public RadioIterator(List<Channel> channels)
        {
            _channels = channels;
        }
        public bool HasNext()
        {
            return _position < _channels.Count;
        }
        public Channel Next()
        {
            if (HasNext())
            {
                return _channels[_position++];
            }
            return null;
        }
        public bool HasPrevious()
        {
            return _position > 0;
        }
        public Channel Previous()
        {
            if (HasPrevious())
            {
                return _channels[--_position];
            }
            return null;
        }
    }
}
