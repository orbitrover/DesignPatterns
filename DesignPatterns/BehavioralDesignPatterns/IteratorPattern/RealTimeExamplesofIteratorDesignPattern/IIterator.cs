using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.RealTimeExamplesofIteratorDesignPattern
{
    public interface INextPreviousIterator<T> : INextIterator<T> , IPreviousIterator<T>
    {
    }
    //Define the Iterator and Aggregate interfaces
    public interface INextIterator<T> 
    {
        bool HasNext();
        T Next();
    }
    public interface IPreviousIterator<T>
    {
        bool HasPrevious();
        T Previous();
    }
}
