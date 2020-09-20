using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.CounterUseCase
{
    public class CounterState
    {
        public int ClickCount { get; }
        
        public CounterState(int clickCount)
        {
            ClickCount = clickCount;
        }

    }
}
