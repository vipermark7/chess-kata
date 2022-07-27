using System;

namespace Chess.Domain
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;
        private Pawn[,] pieces;

        public ChessBoard()
        {
            pieces = new Pawn[MaxBoardWidth, MaxBoardHeight];
        }

        public void Add(Pawn pawn, int xCoordinate, int yCoordinate, PieceColor pieceColor)
        {
            if (IsLegalBoardPosition(xCoordinate, yCoordinate))
            {
                pawn.XCoordinate = xCoordinate;
                pawn.YCoordinate = yCoordinate;
                pawn.PieceColor = pieceColor;
                pieces[xCoordinate, yCoordinate] = pawn;

            }

            else
                // keep pawn in the same place
                pieces[pawn.XCoordinate, pawn.YCoordinate] = pawn;

        }

        public static bool IsLegalBoardPosition(int xCoord, int yCoord)
        {
            return
                xCoord <= MaxBoardWidth && xCoord >= 0
                &&
                yCoord <= MaxBoardHeight && yCoord >= 0;
        }
    }
}
