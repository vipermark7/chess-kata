using System;

namespace Chess.Domain
{
    public class Pawn : IPiece
    {
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

        public Pawn(PieceColor pieceColor)
        {
            _pieceColor = pieceColor;
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
            bool MovingBack = newY <= YCoordinate;
            bool MovingLeftOrRight = newX != XCoordinate;
            bool MaxTwoUnitsForward = newY - YCoordinate <= 2;

            bool ForwardDiagonal =
                (newX == XCoordinate + 1 || newX == XCoordinate - 1)
                 &&
                 newY == YCoordinate + 1;

            if (MovementType.Move == moveType)
            {
                return !(MovingBack || MovingLeftOrRight) && MaxTwoUnitsForward;
            }

            return ForwardDiagonal;
        }

        public override string ToString()
        {
            return string.Format(
                "Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}",
                Environment.NewLine,
                XCoordinate,
                YCoordinate,
                PieceColor);
        }
    }
}
