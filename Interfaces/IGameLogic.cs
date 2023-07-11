using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameCleanCode2023.Interfaces
{
    public interface IGameLogic
    {
        void PlayGame();

        int TotalGuesses {  get; }

        void RegisterObserver(IGameResultObserver observer);
    }
}
