using NUnit.Framework;

namespace Chess.Domain
{
    public class RookSpecs
    {
        [TestFixture]
        public class When_creating_a_chess_board
        {
            private ChessBoard _chessBoard;

            [SetUp]
            public void SetUp()
            {
                _chessBoard = new ChessBoard();
            }

            [Test]
            public void _001_the_playing_board_should_have_a_Max_Board_Width_of_7()
            {
                Assert.That(ChessBoard.MaxBoardWidth, Is.EqualTo(7));
            }

            [Test]
            public void _002_the_playing_board_should_have_a_Max_Board_Height_of_7()
            {
                Assert.That(ChessBoard.MaxBoardHeight, Is.EqualTo(7));
            }

            [Test]
            public void _005_the_playing_board_should_know_that_X_equals_0_and_Y_equals_0_is_a_valid_board_position()
            {
                var isValidPosition = ChessBoard.IsLegalBoardPosition(0, 0);
                Assert.That(isValidPosition, Is.True);
            }

            [Test]
            public void _006_the_playing_board_should_know_that_X_equals_5_and_Y_equals_5_is_a_valid_board_position()
            {
                var isValidPosition = ChessBoard.IsLegalBoardPosition(5, 5);
                Assert.That(isValidPosition, Is.True);
            }

            [Test]
            public void _010_the_playing_board_should_know_that_X_equals_11_and_Y_equals_5_is_an_invalid_board_position()
            {
                var isValidPosition = ChessBoard.IsLegalBoardPosition(11, 5);
                Assert.That(isValidPosition, Is.False);
            }

            [Test]
            public void _011_the_playing_board_should_know_that_X_equals_0_and_Y_equals_8_is_an_invalid_board_position()
            {
                // changed y to 8 instead of 9 to match the test
                var isValidPosition = ChessBoard.IsLegalBoardPosition(0, 8);
                Assert.That(isValidPosition, Is.False);
            }

            [Test]
            public void _011_the_playing_board_should_know_that_X_equals_11_and_Y_equals_0_is_an_invalid_board_position()
            {
                var isValidPosition = ChessBoard.IsLegalBoardPosition(11, 0);
                Assert.That(isValidPosition, Is.False);
            }

            [Test]
            public void _012_the_playing_board_should_know_that_X_equals_minus_1_and_Y_equals_5_is_an_invalid_board_position()
            {
                var isValidPosition = ChessBoard.IsLegalBoardPosition(-1, 5);
                Assert.That(isValidPosition, Is.False);
            }

            [Test]
            public void _012_the_playing_board_should_know_that_X_equals_5_and_Y_equals_minus_1_is_an_invalid_board_position()
            {
                var isValidPosition = ChessBoard.IsLegalBoardPosition(5, -1);
                Assert.That(isValidPosition, Is.False);
            }
        }
        [TestFixture]
        public class When_using_a_black_pawn_and
        {
            private ChessBoard _chessBoard;
            private Pawn _pawn;

            [SetUp]
            public void SetUp()
            {
                _chessBoard = new ChessBoard();
                _pawn = new Pawn(PieceColor.Black);
            }

            [Test]
            public void _01_placing_the_black_pawn_on_X_equals_6_and_Y_equals_3_should_place_the_black_pawn_on_that_place_on_the_board()
            {
                _chessBoard.Add(_pawn, 6, 3, PieceColor.Black);
                Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
                Assert.That(_pawn.YCoordinate, Is.EqualTo(3));
            }

            [Test]
            public void _10_rook_should_not_be_able_to_move_diagonally_forwards()
            {
                _chessBoard.Add(_pawn, 6, 3, PieceColor.Black);
                _pawn.Move(MovementType.Move, 8, 5);
                Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
                Assert.That(_pawn.YCoordinate, Is.EqualTo(3));

                _pawn.Move(MovementType.Move, 4, 1);
                Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
                Assert.That(_pawn.YCoordinate, Is.EqualTo(3));
            }

            public void _10_rook_should_not_be_able_to_move_diagonally_backwards()
            {
                _chessBoard.Add(_pawn, 6, 3, PieceColor.Black);
                _pawn.Move(MovementType.Move, 4, 1);
                Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
                Assert.That(_pawn.YCoordinate, Is.EqualTo(3));
            }
        }
    }
}
