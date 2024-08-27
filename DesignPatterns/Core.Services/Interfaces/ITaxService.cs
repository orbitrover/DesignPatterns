using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ITaxService
    {
        double GetTaxByState(string state);
        void ApplyTax(int cartID, double taxPercent);
    }
}
