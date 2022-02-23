using System;

namespace TicTacToe
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }
    }

    public class Game
    {
        private char _lastSymbol = ' ';
        private Board _board = new Board();
        private const char player1 = 'O';

        public void Play(char symbol, int x, int y)// Data clump 
        {
            //if first move 
            if (IsFirstMove())
            {
                //if player is X
                if (symbol == player1) //primitive obsession //comment is unclear to what code does
                {
                    throw new Exception("Invalid first player");
                }
            }
            //if not first move but player repeated
            else if (symbol == _lastSymbol)
            {
                throw new Exception("Invalid next player");
            }

            else if (IsTileTaken(x, y))
            {
                throw new Exception("Invalid position");
            }

            // update game state
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);// Data clump 
        }

        private bool IsTileTaken(int x, int y)
        {
            return GetSymbol(x, y) != ' ';
        }

        private char GetSymbol(int x, int y)
        {
            return _board.TileAt(x, y).Symbol;
        }

        private bool IsFirstMove()
        {
            return _lastSymbol == ' ';
        }

        public char Winner() // Duplicate code // Feature envy //symbol wrapped constant 
        {
            for (int rowNumber = 0; rowNumber <= 2; rowNumber++)
            {
                if (IsRowTaken(rowNumber) && RowIsFullWithSameSymbol(rowNumber))
                {
                    return GetSymbol(rowNumber, 0);
                }
            }
            return ' ';
        }



        private bool RowIsFullWithSameSymbol(int rowNumber)
        {
            return GetSymbol(rowNumber, 0) ==
                                GetSymbol(rowNumber,1) &&
                                GetSymbol(rowNumber, 2) ==
                                GetSymbol(rowNumber, 1);
        }

        private bool IsRowTaken(int rowNumber)
        {
            return IsTileTaken(rowNumber,0) &&
                           IsTileTaken(rowNumber, 1) &&
                           IsTileTaken(rowNumber, 2);
        }
    }
}