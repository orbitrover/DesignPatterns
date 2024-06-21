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
    public static class TVChannelService
    {
        public static void Run()
        {
            var channelsCollection = new ChannelCollection();
            channelsCollection.AddChannel(new TVChannels(98.5, ChannelType.News));
            channelsCollection.AddChannel(new TVChannels(99.2, ChannelType.Music));
            channelsCollection.AddChannel(new TVChannels(100.7, ChannelType.Sports));
            var iterator = channelsCollection.GetIterator();
            while (iterator.HasNext())
            {
                TVChannels c = iterator.Next();
                Console.WriteLine($"Frequency: {c.Frequency}, Type: {c.Type}");
            }
            
        }
    }
    //Channel and ChannelType
    public enum ChannelType
    {
        News,
        Sports,
        Movies,
        Music
    }
    public class TVChannels
    {
        public double Frequency { get; private set; }
        public ChannelType Type { get; private set; }
        public TVChannels(double frequency, ChannelType type)
        {
            Frequency = frequency;
            Type = type;
        }
    }
    
    //Collection Interface
    public interface IChannelCollection
    {
        void AddChannel(TVChannels c);
        void RemoveChannel(TVChannels c);
        INextIterator<TVChannels> GetIterator();
    }
    //Concrete Collection and Iterator
    public class ChannelCollection : IChannelCollection
    {
        private List<TVChannels> _channelsList;
        public ChannelCollection()
        {
            _channelsList = new List<TVChannels>();
        }
        public void AddChannel(TVChannels c)
        {
            _channelsList.Add(c);
        }
        public void RemoveChannel(TVChannels c)
        {
            _channelsList.Remove(c);
        }
        public INextIterator<TVChannels> GetIterator()
        {
            return new ChannelIterator(_channelsList);
        }
        private class ChannelIterator : INextIterator<TVChannels>
        {
            private readonly List<TVChannels> _channels;
            private int _position;
            public ChannelIterator(List<TVChannels> channels)
            {
                _channels = channels;
            }
            public bool HasNext()
            {
                return _position < _channels.Count;
            }
            public TVChannels Next()
            {
                TVChannels channel = _channels[_position];
                _position++;
                return channel;
            }
        }
    }
}
