using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using card.Bl;

namespace card
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            do
            {
                Console.WriteLine("Enter 1 to play the game. ");
                Console.WriteLine("Enter 2 to EXIT the game. ");
                option = int.Parse(Console.ReadLine());
                Console.Clear();
                if (option == 1)
                {
                    bool gameRunning = true;
                    int score = 0;
                    Deck obj = new Deck();
                    obj.Shuffle();
                    Card card1 = obj.dealCard();
                    while (gameRunning)
                    {
                        int remain_check = obj.cardsLeft();
                        Card card2 = obj.dealCard();
                        Console.WriteLine("****************************************");
                        Console.WriteLine(card1.toString());
                        Console.WriteLine("");
                        Console.WriteLine("*** Remaining Cards ***" + remain_check);
                        Console.WriteLine("Enter 1 if the next card is higher ");
                        Console.WriteLine("Enter 2 if the next card is lower  ");
                        int card_check = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (card_check == 1)
                        {
                            if (card2.getValue() >= card1.getValue())
                            {
                                score++;
                                card1 = card2;
                            }
                            else
                            {
                                gameRunning = false;
                                Console.WriteLine("Sorry you loose. Press any key to continue. ");
                                Console.WriteLine("The card was" + card2.toString());
                                Console.WriteLine("Your score is: " + score);
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        if (card_check == 2)
                        {
                            if (card2.getValue() < card1.getValue())
                            {
                                score++;
                                card1 = card2;
                            }
                            else
                            {
                                gameRunning = false;
                                Console.WriteLine("Sorry you loose. Press any key to continue. ");
                                Console.WriteLine("The card was" + card2.toString());
                                Console.WriteLine("Your score is: " + score);
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        if (obj.cardsLeft() == 0 && card2 == null)
                        {
                            gameRunning = false;
                            Console.WriteLine("Congrats you have scored maximun");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    }
                }
            } while (option != 2);

        }
    }
}
