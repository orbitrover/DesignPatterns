using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.RealTimeExamplesofIteratorDesignPattern
{
    public interface INextPreviousAggregate<T>
    {
        INextPreviousIterator<T> CreateIterator();
    }
    public interface INextAggregate<T>
    {
        INextIterator<T> CreateIterator();
    }
    public interface IPreviousAggregate<T>
    {
        IPreviousIterator<T> CreateIterator();
    }
}
