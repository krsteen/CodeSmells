using System.Linq;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        private List<Tile> _tiles = new List<Tile>();

        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _tiles.Add(new Tile { X = i, Y = j, Symbol = ' ' }); //primitve obsession symbol wrapped constant
                }
            }
        }
        public Tile TileAt(int x, int y)// primitive obsession
        {
            return _tiles.Single(tile => tile.X == x && tile.Y == y);
        }

        public void AddTileAt(char symbol, int x, int y) // long parameter list
        {
            TileAt(x,y).Symbol = symbol; // message chain
        }
    }
}