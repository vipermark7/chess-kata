namespace Chess.Domain
{
    public interface IPiece
    {
        int XCoordinate
        {
            get; set;
        }
        int YCoordinate
        {
            get; set;
        }
        PieceColor PieceColor
        {
            get; set;
        }
        void Move(MovementType moveType, int newX, int newY);
        bool IsLegalMove(MovementType moveType, int newX, int newY);


    }
}