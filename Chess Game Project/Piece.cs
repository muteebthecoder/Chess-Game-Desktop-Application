using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game_Project
{
    public class Move
    {
        int count = 0;
        public int rownumber { get; set; }
        public int columnnumber { get; set; }
    }
    public class EmptyPiece : Piece
    {
        public EmptyPiece(Image img, int row, int column, PieceType t, PieceColor c) : base(img, row, column, t, c)
        {
        }

        public override List<Move> GetAllMoves()
        {
            return new List<Move>();
        }
    }

    public abstract class Piece
    {
        public Image image;
        public int row, column;
        public enum PieceType { Rook, Knight, Bishop, Queen, King, Pawn, Empty }
        public PieceType piece;
        public enum PieceColor { White, Black, None }
        public PieceColor color;
        public Piece(Image image, int row, int column, PieceType t, PieceColor c)
        {
            this.image = image;
            this.row = row;
            this.column = column;
            this.piece = t;
            this.color = c;
        }

        public abstract List<Move> GetAllMoves();
        //   public abstract List<Move> AvailableMoves(int row, int col);

        public bool IsEmpty => piece == PieceType.Empty;
        public bool IsKing => piece == PieceType.King;
        public bool IsQueen => piece == PieceType.Queen;
        public bool IsBishop => piece == PieceType.Bishop;
        public bool IsKnight => piece == PieceType.Knight;
        public bool IsRook => piece == PieceType.Rook;
        public bool IsPawn => piece == PieceType.Pawn;

    }
    public class Pawn : Piece
    {
        public Pawn(Image img, int row, int column, PieceType t, PieceColor c) : base(img, row, column, t, c)
        {

        }
        public override List<Move> GetAllMoves()
        {
            return new List<Move>() {
                new Move { rownumber = row + 1, columnnumber = column },
                new Move { rownumber = row - 1, columnnumber = column },
                new Move { rownumber = row + 1, columnnumber = column + 1 },
                new Move { rownumber = row + 1, columnnumber = column - 1 },
                new Move { rownumber = row - 1, columnnumber = column - 1 },
                new Move { rownumber = row - 1, columnnumber = column + 1 },
                new Move { rownumber = row - 2, columnnumber = column },
                new Move { rownumber = row + 2, columnnumber = column }
            };
        }

    }
    public class King : Piece
    {
        public King(Image img, int row, int column, PieceType t, PieceColor c) : base(img, row, column, t, c)
        {

        }
        public override List<Move> GetAllMoves()
        {
            return new List<Move>() {
                new Move { rownumber = row + 1, columnnumber = column + 1 },
                new Move { rownumber = row + 1, columnnumber = column },
                new Move { rownumber = row + 1, columnnumber = column - 1 },
                new Move { rownumber = row, columnnumber = column - 1 },
                new Move { rownumber = row, columnnumber = column + 1 },
                new Move { rownumber = row - 1, columnnumber = column + 1 },
                new Move { rownumber = row - 1, columnnumber = column },
                new Move { rownumber = row - 1, columnnumber = column - 1 }
            };
        }
    }
    public class Queen : Piece
    {
        public Queen(Image img, int row, int column, PieceType t, PieceColor c) : base(img, row, column, t, c)
        {

        }
        public override List<Move> GetAllMoves()
        {
            return new List<Move>() {
                new Move { rownumber = row + 1, columnnumber = column },
                new Move { rownumber = row + 2, columnnumber = column },
                new Move { rownumber = row + 3, columnnumber = column },
                new Move { rownumber = row + 4, columnnumber = column },
                new Move { rownumber = row + 5, columnnumber = column },
                new Move { rownumber = row + 6, columnnumber = column },
                new Move { rownumber = row + 7, columnnumber = column },
                new Move { rownumber = row, columnnumber = column + 1 },
                new Move { rownumber = row, columnnumber = column + 2 },
                new Move { rownumber = row, columnnumber = column + 3 },
                new Move { rownumber = row, columnnumber = column + 4 },
                new Move { rownumber = row, columnnumber = column + 5 },
                new Move { rownumber = row, columnnumber = column + 6 },
                new Move { rownumber = row, columnnumber = column + 7 },
                new Move { rownumber = row - 1, columnnumber = column },
                new Move { rownumber = row - 2, columnnumber = column },
                new Move { rownumber = row - 3, columnnumber = column },
                new Move { rownumber = row - 4, columnnumber = column },
                new Move { rownumber = row - 5, columnnumber = column },
                new Move { rownumber = row - 6, columnnumber = column },
                new Move { rownumber = row - 7, columnnumber = column },
                new Move { rownumber = row, columnnumber = column - 1 },
                new Move { rownumber = row, columnnumber = column - 2 },
                new Move { rownumber = row, columnnumber = column - 3 },
                new Move { rownumber = row, columnnumber = column - 4 },
                new Move { rownumber = row, columnnumber = column - 5 },
                new Move { rownumber = row, columnnumber = column - 6 },
                new Move { rownumber = row, columnnumber = column - 7 },
                new Move { rownumber = row + 1, columnnumber = column + 1 },
                new Move { rownumber = row + 2, columnnumber = column + 2 },
                new Move { rownumber = row + 3, columnnumber = column + 3 },
                new Move { rownumber = row + 4, columnnumber = column + 4 },
                new Move { rownumber = row + 5, columnnumber = column + 5 },
                new Move { rownumber = row + 6, columnnumber = column + 6 },
                new Move { rownumber = row + 7, columnnumber = column + 7 },
                new Move { rownumber = row + 1, columnnumber = column - 1 },
                new Move { rownumber = row + 2, columnnumber = column - 2 },
                new Move { rownumber = row + 3, columnnumber = column - 3 },
                new Move { rownumber = row + 4, columnnumber = column - 4 },
                new Move { rownumber = row + 5, columnnumber = column - 5 },
                new Move { rownumber = row + 6, columnnumber = column - 6 },
                new Move { rownumber = row + 7, columnnumber = column - 7 },
                new Move { rownumber = row - 1, columnnumber = column - 1 },
                new Move { rownumber = row - 2, columnnumber = column - 2 },
                new Move { rownumber = row - 3, columnnumber = column - 3 },
                new Move { rownumber = row - 4, columnnumber = column - 4 },
                new Move { rownumber = row - 5, columnnumber = column - 5 },
                new Move { rownumber = row - 6, columnnumber = column - 6 },
                new Move { rownumber = row - 7, columnnumber = column - 7 },
                new Move { rownumber = row - 1, columnnumber = column + 1 },
                new Move { rownumber = row - 2, columnnumber = column + 2 },
                new Move { rownumber = row - 3, columnnumber = column + 3 },
                new Move { rownumber = row - 4, columnnumber = column + 4 },
                new Move { rownumber = row - 5, columnnumber = column + 5 },
                new Move { rownumber = row - 6, columnnumber = column + 6 },
                new Move { rownumber = row - 7, columnnumber = column + 7 }
            };
        }
    }

    public class Rook : Piece
    {
        public Rook(Image img, int row, int column, PieceType t, PieceColor c) : base(img, row, column, t, c)
        {

        }

        public override List<Move> GetAllMoves()
        {
            //Move m = new Move() { rownumber = row + 1, columnnumber = column };
            //return new List<Move>() { m };
            return new List<Move>() {
                new Move { rownumber = row + 1, columnnumber = column },
                new Move { rownumber = row + 2, columnnumber = column },
                new Move { rownumber = row + 3, columnnumber = column },
                new Move { rownumber = row + 4, columnnumber = column },
                new Move { rownumber = row + 5, columnnumber = column },
                new Move { rownumber = row + 6, columnnumber = column },
                new Move { rownumber = row + 7, columnnumber = column },
                new Move { rownumber = row, columnnumber = column + 1 },
                new Move { rownumber = row, columnnumber = column + 2 },
                new Move { rownumber = row, columnnumber = column + 3 },
                new Move { rownumber = row, columnnumber = column + 4 },
                new Move { rownumber = row, columnnumber = column + 5 },
                new Move { rownumber = row, columnnumber = column + 6 },
                new Move { rownumber = row, columnnumber = column + 7 },
                new Move { rownumber = row - 1, columnnumber = column },
                new Move { rownumber = row - 2, columnnumber = column },
                new Move { rownumber = row - 3, columnnumber = column },
                new Move { rownumber = row - 4, columnnumber = column },
                new Move { rownumber = row - 5, columnnumber = column },
                new Move { rownumber = row - 6, columnnumber = column },
                new Move { rownumber = row - 7, columnnumber = column },
                new Move { rownumber = row, columnnumber = column - 1 },
                new Move { rownumber = row, columnnumber = column - 2 },
                new Move { rownumber = row, columnnumber = column - 3 },
                new Move { rownumber = row, columnnumber = column - 4 },
                new Move { rownumber = row, columnnumber = column - 5 },
                new Move { rownumber = row, columnnumber = column - 6 },
                new Move { rownumber = row, columnnumber = column - 7 }
            };
        }
    }
    public class Bishop : Piece
    {
        public Bishop(Image img, int row, int column, PieceType t, PieceColor c) : base(img, row, column, t, c)
        {

        }

        public override List<Move> GetAllMoves()
        {
            return new List<Move>() {
                new Move { rownumber = row + 1, columnnumber = column + 1 },
                new Move { rownumber = row + 2, columnnumber = column + 2 },
                new Move { rownumber = row + 3, columnnumber = column + 3 },
                new Move { rownumber = row + 4, columnnumber = column + 4 },
                new Move { rownumber = row + 5, columnnumber = column + 5 },
                new Move { rownumber = row + 6, columnnumber = column + 6 },
                new Move { rownumber = row + 7, columnnumber = column + 7 },
                new Move { rownumber = row + 1, columnnumber = column - 1 },
                new Move { rownumber = row + 2, columnnumber = column - 2 },
                new Move { rownumber = row + 3, columnnumber = column - 3 },
                new Move { rownumber = row + 4, columnnumber = column - 4 },
                new Move { rownumber = row + 5, columnnumber = column - 5 },
                new Move { rownumber = row + 6, columnnumber = column - 6 },
                new Move { rownumber = row + 7, columnnumber = column - 7 },
                new Move { rownumber = row - 1, columnnumber = column - 1 },
                new Move { rownumber = row - 2, columnnumber = column - 2 },
                new Move { rownumber = row - 3, columnnumber = column - 3 },
                new Move { rownumber = row - 4, columnnumber = column - 4 },
                new Move { rownumber = row - 5, columnnumber = column - 5 },
                new Move { rownumber = row - 6, columnnumber = column - 6 },
                new Move { rownumber = row - 7, columnnumber = column - 7 },
                new Move { rownumber = row - 1, columnnumber = column + 1 },
                new Move { rownumber = row - 2, columnnumber = column + 2 },
                new Move { rownumber = row - 3, columnnumber = column + 3 },
                new Move { rownumber = row - 4, columnnumber = column + 4 },
                new Move { rownumber = row - 5, columnnumber = column + 5 },
                new Move { rownumber = row - 6, columnnumber = column + 6 },
                new Move { rownumber = row - 7, columnnumber = column + 7 }
            };
        }
    }
    public class Knight : Piece
    {
        public Knight(Image img, int row, int column, PieceType t, PieceColor c) : base(img, row, column, t, c)
        {

        }
        public override List<Move> GetAllMoves()
        {
            return new List<Move>() {
                new Move { rownumber = row + 2, columnnumber = column - 1 },
                new Move { rownumber = row + 2, columnnumber = column + 1 },
                new Move { rownumber = row + 1, columnnumber = column + 2 },
                new Move { rownumber = row + 1, columnnumber = column - 2 },
                new Move { rownumber = row - 2, columnnumber = column - 1 },
                new Move { rownumber = row - 2, columnnumber = column + 1 },
                new Move { rownumber = row - 1, columnnumber = column + 2 },
                new Move { rownumber = row - 1, columnnumber = column - 2 }
            };
        }
    }
}