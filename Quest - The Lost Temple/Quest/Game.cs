using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    internal class Game
    {
        private Chest chest;
        private Main_Player player;
        private Puzzle puzzle;
        private Trap trap;
        private Spider spider;


        //пока конвёртед и инренж не будет тру, пользователь не сможет продолжить
        static int GetIntInRange(int optionsNumber)
        {
            string input = Console.ReadLine();
            int number = -1;
            bool isConverted = int.TryParse(input, out number);
            bool isInRange = number >= 1 && number <= optionsNumber;

            while (!isConverted || !isInRange)
            {
                Console.WriteLine("Неверная опция, попробуй ещё раз");
                input = Console.ReadLine();
                isConverted = int.TryParse(input, out number);
                isInRange = number >= 1 && number <= optionsNumber;
            }

            return number;
        }

        public void Start()
        {
            chest = new Chest();
            player = new Main_Player();
            puzzle = new Puzzle();
            trap = new Trap();
            spider = new Spider();

            Console.WriteLine("Вы зашли в храм. Вам нужно найти сокровище.");
            Console.WriteLine("Вы находитесь в первой комнате. В комнате есть две двери, слева и справа, и левая дверь излучает странный свет. \nВыберите дверь: налево (1) или направо (2)?");
            int input = GetIntInRange(2);

            if (input == 1)
            {
                Console.WriteLine("В комнате был светящийся камень, на котором высечены цифры 1738\nКомната выглядит пустой, вы можете изучить ее(1) или уйти(2)");
                input = GetIntInRange(2);

                

                if (input == 1)
                {
                    Console.WriteLine("Вы нашли ключ! После вы вышли из комнаты, так как больше ничего не нашли");
                    player.HasKey = true;
                }
                else
                {
                    Console.WriteLine("Вы просто ушли из комнаты");
                }
            }

            Console.WriteLine("Вы зашли в левую комнату, полную ловушек, и дверь за вами закрылась. Вы больше не можете ее открыть, но на стене вы увидели странные кирпичи с числами 32 11 53 10 21, которые можно нажимать\nПопытаться решить головоломку(1) или попробовать сразу пройти ловушки(2)?");
            input = GetIntInRange(2);

            if (input == 1)
            {
                Console.WriteLine("Решение нужно вводить так: ** ** ** ** **");
                string iinput = Console.ReadLine();

                if (puzzle.Solve(iinput))
                {
                    trap.IsDisabled = true;
                    Console.WriteLine("Похоже, что ловушки отключились! Вы можете пройти дальше.");
                }
                else
                {
                    trap.IsDisabled = false;
                    Console.WriteLine("Кирпичи перестали нажиматься, похоже, придется пройти дальше через ловушки.");
                }
            }

            if (!trap.IsDisabled)
            {
                trap.Pass();
                player.Health = trap.Health;

                if (player.Health == "full")
                {
                    Console.WriteLine("Вы прошли ловушки и не получили никакого урона.");
                }
                else if (player.Health == "mid")
                {
                    Console.WriteLine("Вы прошли ловушки с ранением.");
                }
                else if (player.Health == "low")
                {
                    Console.WriteLine("К сожалению, вы не прошли ловушки и погибли.");
                    return;
                }
            }

            Console.WriteLine("В следующей комнате вы нашли сундук с кодовым 4-хзначным замком\nВвести код(1) или пойти дальше(2)?");
            input = GetIntInRange(2);

            if (input == 1)
            {
                Console.WriteLine("Введите код");
                string ninput = Console.ReadLine();

                if (chest.Unlock(ninput))
                {
                    Console.WriteLine("Код верный! Внутри лежало противоядие.");
                    player.HasAntidote = true;
                }
                else
                {
                    Console.WriteLine("Вы ввели неверный код, после чего внутри замка что-то щелкнуло, и барабаны с цифрами перестали двигаться.");
                    player.HasAntidote = false;
                }
            }

            Console.WriteLine("В следующей комнате было снова 2 двери, но одну охранял огромный паук\nСразиться с пауком(1) или пойти в другую дверь(2)?");
            input = GetIntInRange(2);

            if (input == 1)
            {
                if (spider.Fight(player.HasAntidote, player.Health))
                {
                    Console.WriteLine("Вы победили паука и зашли в комнату. Там вы нашли веревку и вернулись обратно.");
                    player.HasRope = true;
                }
                else
                {
                    Console.WriteLine("Паук убил вас.");
                    return;
                }
            }

            Console.WriteLine("Когда вы зашли в следующую комнату, проход обратно засыпало камнями. Сама же комната была заполнена зыбучим песком, но на потолке виднелся крюк\nЕсли вы не нашли веревку, то у вас почти нет шансов пройти дальше.");
            int chance = new Random().Next(100);

            if (!player.HasRope)
            {
                if (chance < 5)
                {
                    Console.WriteLine("Вам невероятно повезло, вы прошли это испытание.");
                }
                else
                {
                    Console.WriteLine("Вы не прошли испытание и остались заперты в комнате.");
                    return;
                }
            }

            Console.WriteLine("Следующая комната оказалась последней, в ней был сундук с сокровищем и выход наружу.");

            if (player.HasKey)
            {
                Console.WriteLine("Так как вы нашли ключ, вы открыли замок и вышли из храма с сокровищем. Победа!");
            }
            else
            {
                Console.WriteLine("Вы не нашли способ открыть сундук и ушли из храма с пустыми руками, но живым.");
            }
        }
    }
}
