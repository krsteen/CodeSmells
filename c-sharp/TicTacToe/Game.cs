using System;

namespace TicTacToe
{
    // Large class
    public class Game
    {
        private Symbol _lastSymbol = Symbol.Empty;
        private Board _board = new Board();
        
        // Maybe too long
        public void Play(char intputSymbol, int x, int y)
        {

            var symbol = ConvertInputToSymbol(intputSymbol);
            
            if (IsFirstMove() && IsPlayerO(symbol))
            {
                throw new Exception("Invalid first player");
            }

            if (!IsFirstMove() && IsRepeatedMove(symbol))
            {
                throw new Exception("Invalid next player");
            }

            if (!IsFirstMove() && IsAlreadyPlayedTile(x, y))
            {
                throw new Exception("Invalid position");
            }

            UpdateGameState(symbol, x, y);
        }

        // Feature envy
        // Duplicated code
        private Symbol GetWinner()
        {
            if (IsRowTaken(0) && IsRowSameSymbol(0))
            {
                return GetSymbol(0, 0);
            }

            if (IsRowTaken(1) && IsRowSameSymbol(1))
            {
                return GetSymbol(1, 0);
            }

            if (IsRowTaken(2) && IsRowSameSymbol(2))
            {
                return GetSymbol(2, 0);
            }

            return Symbol.Empty;
        }

        public char Winner()
        {
            return GetWinner().ToString()[0];
        }

        private static Symbol ConvertInputToSymbol(char input)
        {
            if (input == 'X') return Symbol.X;
            if (input == 'O') return Symbol.O;
            return Symbol.Empty;
        }

        private Symbol GetSymbol(int x, int y)
        {
            return _board.TileAt(x,y).Symbol;
        }

        private void UpdateGameState(Symbol symbol, int x, int y)
        {
            _lastSymbol = symbol;
            _board.TileAt(x, y).Symbol = symbol;
        }

        private bool IsAlreadyPlayedTile(int x, int y)
        {
            return _board.TileAt(x, y).Symbol != Symbol.Empty;
        }

        private bool IsRepeatedMove(Symbol symbol)
        {
            return symbol == _lastSymbol;
        }

        private static bool IsPlayerO(Symbol symbol)
        {
            return symbol == Symbol.O;
        }

        private bool IsFirstMove()
        {
            return _lastSymbol == Symbol.Empty;
        }

        private bool IsRowSameSymbol(int row)
        {
            return _board.TileAt(row, 0).Symbol ==
                                _board.TileAt(row, 1).Symbol &&
                                _board.TileAt(row, 2).Symbol ==
                                _board.TileAt(row, 1).Symbol;
        }

        private bool IsRowTaken(int row)
        {
            return _board.TileAt(row, 0).Symbol != Symbol.Empty &&
                           _board.TileAt(row, 1).Symbol != Symbol.Empty &&
                           _board.TileAt(row, 2).Symbol != Symbol.Empty;
        }
    }
}