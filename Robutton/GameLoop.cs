using System.Timers;
using System.Windows.Forms;

namespace Robutton
{
    class GameLoop : System.Timers.Timer
    {
        private SplitterPanel table;
        private Game game;

        public GameLoop(Game game, SplitterPanel table)
        {
            this.game = game;
            this.table = table;
            this.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            game.Next();
            table.Invalidate();
        }
    }
}
