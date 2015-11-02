using System.Collections.Generic;

namespace PrimeTables.Code.Interfaces
{
    public interface IPrimeGenerator
    {
        IList<int> GenerateNumberOfPrimes(int count);
    }
}