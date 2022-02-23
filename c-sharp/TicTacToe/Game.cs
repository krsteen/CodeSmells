﻿using System;

namespace TicTacToe
{
    // Data class
    public class Tile
    {
        // Data clump
        public int X {get; set; }
        // Data clump, turn into one object
        public int Y {get; set;}
        public char Symbol {get; set;}
    }

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

            // update game state
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
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

        // Method too long
        // Feature envy
        // Duplicated code
        public char Winner()
        {   
            if (IsRowTaken(0))
            {
                if (IsRowSameSymbol(0))
                {
                    return _board.TileAt(0, 0).Symbol;
                }
            }

            if (IsRowTaken(1))
            {
                if (IsRowSameSymbol(1))
                {
                    return _board.TileAt(1, 0).Symbol;
                }
            }

            if (IsRowTaken(2))
            {
                //if middle row is full with same symbol
                if (_board.TileAt(2, 0).Symbol ==
                    _board.TileAt(2, 1).Symbol &&
                    _board.TileAt(2, 2).Symbol ==
                    _board.TileAt(2, 1).Symbol)
                {
                    return _board.TileAt(2, 0).Symbol;
                }
            }

            return ' ';
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