using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Domain
{
    internal class Rook : IPiece
    {
        public Rook()
        {
        }
        private int _xCoordinate;
        private int _yCoordinate;
        private PieceColor _pieceColor;

        public int XCoordinate
        {
            get { return _xCoordinate; }
            set { _xCoordinate = value; }
        }

        public int YCoordinate
        {
            get { return _yCoordinate; }
            set { _yCoordinate = value; }
        }

        public PieceColor PieceColor
        {
            get { return _pieceColor; }
            set { _pieceColor = value; }
        }

        public void Move(MovementType moveType, int newX, int newY)
        {
            if (IsLegalMove(moveType, newX, newY) && ChessBoard.IsLegalBoardPosition(newX, newY))
            {
                XCoordinate = newX;
                YCoordinate = newY;
            }
        }

        public bool IsLegalMove(MovementType moveType, int newX, int newY)
        {
            bool MovingHorizontally = newX != XCoordinate && YCoordinate == newY;
            bool MovingVertically = newX == XCoordinate && YCoordinate != newY;
            
            return MovingHorizontally || MovingVertically;
        }
    }
}
