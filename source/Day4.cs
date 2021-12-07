using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adventofcode.source
{
    public class Cell
    {
        public int value;
        public bool set;
    }

    public class Board
    {
        public Cell[][] board;

        public Board(string[] lines)
        {
            board = new Cell[lines.Length][];
            for (int i = 0; i < lines.Length; ++i)
            {
                string[] line = lines[i].Split(' ')
                    .Select(p => p.Trim())
                    .Where(p => !string.IsNullOrWhiteSpace(p))
                    .ToArray();

                int[] items = Array.ConvertAll(line, s => int.Parse(s));

                Cell[] newBoard = items.Select(x => new Cell
                {
                    value = x,
                    set = false
                }).ToArray();

                board[i] = newBoard;
            }            
        }

        public void ScoreOff(int number)
        {
            for (int i = 0; i < board.Length; ++i)
            {
                for (int c = 0; c < board[i].Length; ++c)
                {
                    if (board[i][c].value == number) 
                        board[i][c].set = true;
                }
            }
        }

        public bool HasWon()
        {
            for (int i = 0; i < board.Length; ++i)
            {
                for (int c = 0; c < board[i].Length; ++c)
                {
                    if (!board[i][c].set) break;

                    if (c >= board[i].Length - 1) return true;
                }
            }

            for (int i = 0, c = 0; i < board.Length; ++i)
            {
                for (; c < board[i].Length; ++c)
                {
                    if (!board[c][i].set) break;

                    if (c >= board[i].Length - 1) return true;
                }

                c = 0;
            }

            return false;
        }

        public int BoardScore(int winningNumber)
        {
            int score = 0;
            for (int i = 0; i < board.Length; ++i)
            {
                for (int c = 0; c < board[i].Length; ++c)
                {
                    if (!board[i][c].set) score += board[i][c].value;
                }
            }

            return score * winningNumber;
        }
    }

    public static class Day4
    {
        public static string Part1(string[] data)
        {
            int[] randSeq = data[0].Split(",").Select(x => int.Parse(x)).ToArray();

            string[] board = new string[5];
            List<Board> boardCollection = new List<Board>();

            for (int i = 2, l = 0; i < data.Length; ++i, ++l)
            {
                if (string.IsNullOrWhiteSpace(data[i]))
                {
                    boardCollection.Add(new Board(board));
                    l = -1;
                    continue;
                }

                board[l] = data[i];
            }

            for (int i = 0; i < randSeq.Length; ++i)
            {
                foreach(Board b in boardCollection)
                {
                    b.ScoreOff(randSeq[i]);
                    if (b.HasWon())
                    {

                        return b.BoardScore(randSeq[i]).ToString();
                    }
                }
            }

            return "";
        }

        public static string Part2(string[] data)
        {
            int[] randSeq = data[0].Split(",").Select(x => int.Parse(x)).ToArray();

            string[] board = new string[5];
            List<Board> boardCollection = new List<Board>();
            
            for (int i = 2, l = 0; i < data.Length; ++i, ++l)
            {
                if (string.IsNullOrWhiteSpace(data[i]))
                {
                    boardCollection.Add(new Board(board));
                    l = -1;
                    continue;
                }

                board[l] = data[i];
            }

            for (int i = 0; i < randSeq.Length; ++i)
            {
                for (int j = boardCollection.Count-1; j >= 0; --j)
                {
                    Board b = boardCollection[j];
                    b.ScoreOff(randSeq[i]);
                    if (b.HasWon())
                    {
                        if (boardCollection.Count == 1) return b.BoardScore(randSeq[i]).ToString();

                        boardCollection.Remove(b);
                    }
                }
            }

            return "";
        }
    }
}
