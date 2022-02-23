﻿using System;

namespace TicTacToe
{
    // Large class
    public class Game
    {
        private char _lastSymbol = ' ';
        private Board _board = new Board();
        
        // Maybe too long
        public void Play(char symbol, int x, int y)
        {
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
        public char Winner()
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

            return ' ';
        }

        private char GetSymbol(int x, int y)
        {
            return _board.TileAt(x,y).Symbol;
        }

        private void UpdateGameState(char symbol, int x, int y)
        {
            _lastSymbol = symbol;
            _board.TileAt(x, y).Symbol = symbol;
        }

        private bool IsAlreadyPlayedTile(int x, int y)
        {
            return _board.TileAt(x, y).Symbol != ' ';
        }

        private bool IsRepeatedMove(char symbol)
        {
            return symbol == _lastSymbol;
        }

        private static bool IsPlayerO(char symbol)
        {
            return symbol == 'O';
        }

        private bool IsFirstMove()
        {
            return _lastSymbol == ' ';
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
            return _board.TileAt(row, 0).Symbol != ' ' &&
                           _board.TileAt(row, 1).Symbol != ' ' &&
                           _board.TileAt(row, 2).Symbol != ' ';
        }
    }
}