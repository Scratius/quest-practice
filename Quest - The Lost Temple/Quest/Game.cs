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

        public void Start()
        {
            chest = new Chest();
            player = new Main_Player();
            puzzle = new Puzzle();
            trap = new Trap();
            spider = new Spider();

            Console.WriteLine("Вы зашли в храм. Вам нужно найти сокровище."); //Начало
            Console.WriteLine("Вы находитесь в первой комнате. В комнате есть две двери, слева и справа, и левая дверь излучает странный свет. \nВыберите дверь:\n 1) Слева\n 2) Справа"); //Выбор ответа 1

            string input = Console.ReadLine();

            if (input == "1") //Идем налево
            {
                Console.WriteLine($"В комнате был светящийся камень, на котором высечены цифры {Chest._code}. Комната выглядит пустой.\n 1) Изучить ее\n 2) Уйти");
                input = Console.ReadLine();

                if (input == "1") //Изучаем комнату
                {
                    Console.WriteLine("Вы нашли ключ! Интересно, от чего он?\nПосле вы вышли из комнаты, так как больше ничего не нашли");
                    player.HasKey = true;
                }
                else if (input == "2") //Уходим из комнаты
                {
                    Console.WriteLine("Вы просто ушли из комнаты");
                }
            }
            else if (input == "2")  //Идем направо
            {
                Console.WriteLine("Вы зашли в комнату справа, полную ловушек, и дверь за вами закрылась. Вы больше не можете ее открыть, но на стене вы увидели странные кирпичи с числами 32 11 53 10 21, которые можно нажимать.\n 1) Попытаться решить головоломку\n 2) Попробовать сразу пройти ловушки"); //Выбор ответа 2
                input = Console.ReadLine();

                if (input == "1")  //Пробуем решить головоломку
                {
                    Console.WriteLine("Решение нужно вводить так: ** ** ** ** **");
                    input = Console.ReadLine();

                    if (puzzle.Solve(input))
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

            }


            Console.WriteLine("В следующей комнате вы нашли сундук с кодовым 4-хзначным замком\n 1) Ввести код\n 2) Пойти дальше"); //Выбор ответа 3
            input = Console.ReadLine();

            if (input == "1") //Вводим 4-значный код
            {
                Console.WriteLine("Введите код");
                input = Console.ReadLine();

                if (chest.Unlock(input))
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

            Console.WriteLine("Вы пошли дальше. В следующей комнате было снова 2 двери, но одну охранял огромный паук\n 1) Сразиться с пауком\n 2) Пойти в другую дверь"); //Выбор ответа 4
            input = Console.ReadLine();

            if (input == "1") //Сражаемся с пауком
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

            Console.WriteLine("Когда вы зашли в следующую комнату, проход обратно засыпало камнями. Сама же комната была заполнена зыбучим песком, но на потолке виднелся крюк");

            if (player.HasRope)
            {
                Console.WriteLine("Как хорошо, что вы нашли веревку!");
                Console.WriteLine("Вам невероятно повезло, вы прошли это испытание и выбрались из комнаты.\n Вы пошли в следующую дверь.");
                Console.WriteLine("Следующая комната оказалась последней, в ней был сундук с сокровищем и выход наружу.");

                if (player.HasKey) //Хорошая концовка
                {
                    Console.WriteLine("Так как вы нашли ключ, вы открыли замок и вышли из храма с сокровищем. Победа!");
                }
                else  //Средняя концовка
                {
                    Console.WriteLine("Вы не нашли способ открыть сундук и ушли из храма с пустыми руками, но живым.");
                }
            }
            else  //Плохая концовка
            {
                Console.WriteLine("Как жаль, что вы не можете за него зацепиться.");
                Console.WriteLine("Вы не прошли испытание и остались заперты в комнате.");
                return;
            }
        }
    }   
}
