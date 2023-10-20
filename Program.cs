using System;
using System.Collections.Generic;

namespace Xn0
{
    internal class Program
    {
        private static char checkWin(List<char> board)
        {
            List<List<int>> winCoords = new List<List<int>>
            {
                new List<int> { 0, 1, 2 },
                new List<int> { 3, 4, 5 },
                new List<int> { 6, 7, 8 },
                new List<int> { 0, 3, 6 },
                new List<int> { 1, 4, 7 },
                new List<int> { 2, 5, 8 },
                new List<int> { 0, 4, 8 },
                new List<int> { 2, 4, 6 }
            };
            foreach (List<int> each in winCoords)
            {
                if (board[each[0]] == board[each[1]] && board[each[0]] == board[each[2]])
                {
                    return board[each[0]];
                }
            }
            return ' ';
        }

        private static void takeInput(List<char> board, char playerToken)
        {
            bool valid = false;
            while (!valid)
            {
                try
                {
                    Console.WriteLine($"Куда поставим {playerToken}? ");
                    int playerAnswer = Convert.ToInt32(Console.ReadLine());
                    if (playerAnswer >= 1 && playerAnswer <= 9)
                    {
                        if (board[playerAnswer - 1] != 'x' && board[playerAnswer - 1] != 'o')
                        {
                            board[playerAnswer - 1] = playerToken;
                            valid = true;
                        }
                        else { Console.WriteLine("Некорректный ввод! Эта клеточка уже занята."); }
                    }
                    else { Console.WriteLine("Некорректный ввод! Введите число от 1 до 9 чтобы походить."); }
                }
                catch { Console.WriteLine("Некорректный ввод! Вы уверены, что ввели число?"); }
            }
        }

        private static void drawBoard(List<char> board)
        {
            Console.WriteLine("-------------");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"| {board[i * 3]} | {board[1 + i * 3]} | {board[2 + i * 3]} |\n-------------");
            }
        }

        static void Main(string[] args)
        {
            List<char> board = new List<char> {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
            int counter = 0;
            bool win = false;
            while (!win)
            {
                drawBoard(board);
                if   (counter % 2 == 0) { takeInput(board, 'x'); }
                else                    { takeInput(board, 'o'); }
                counter++;
                if (counter > 4)
                {
                    char winner = checkWin(board);
                    if (winner != ' ')
                    {
                        Console.WriteLine($"\n\n{winner} выйграл!");
                        win = true;
                        break;
                    }
                }
                if (counter == 9)
                {
                    Console.WriteLine("\n\nНичья!");
                    break;
                }
            }
            drawBoard(board);
            Console.ReadKey();
        }
    }
}
