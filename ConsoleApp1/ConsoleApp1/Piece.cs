using  System;

namespace SimpleChess
{
    
        public abstract class Piece
        {
            public string Symbol { get; set; }


            protected Piece(string symbol)
            {

                Symbol = symbol;
            }

            protected Piece()
            {
            }

            public abstract bool Move(string fromPosition, string toPosition);
        }
    }


