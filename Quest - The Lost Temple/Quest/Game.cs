using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    public class Game
    {
        private Chest chest;
        private Main_Player player;
        private Puzzle puzzle;
        private Trap trap;
        private Spider spider;
        static bool hasTreasure = false;
        static int roomNumber = 1;

        public void Start() //Запуск квеста
        {
            chest = new Chest();
            player = new Main_Player();
            puzzle = new Puzzle();
            trap = new Trap();
            spider = new Spider();

            Console.WriteLine("                                             ,--,  ,.-.\n               ,                   \\,       '-,-`,'-.' | ._\n              /|           \\    ,   |\\         }  )/  / `-,',\n              [ ,          |\\  /|   | |        /  \\|  |/`  ,`\n              | |       ,.`  `,` `, | |  _,...(   (      .',\n              \\  \\  __ ,-` `  ,  , `/ |,'      Y     (   /_L\\\n               \\  \\_\\,``,   ` , ,  /  |         )         _,/\n                \\  '  `  ,_ _`_,-,<._.<        /         /\n                 ', `>.,`  `  `   ,., |_      |         /\n                   \\/`  `,   `   ,`  | /__,.-`    _,   `\\\n               -,-..\\  _  \\  `  /  ,  / `._) _,-\\`       \\\n                \\_,,.) /\\    ` /  / ) (-,, ``    ,        |\n               ,` )  | \\_\\       '-`  |  `(               \\\n              /  /```(   , --, ,' \\   |`<`    ,            |\n             /  /_,--`\\   <\\  V /> ,` )<_/)  | \\      _____)\n       ,-, ,`   `   (_,\\ \\    |   /) / __/  /   `----`\n      (-, \\           ) \\ ('_.-._)/ /,`    /\n      | /  `          `/ \\\\ V   V, /`     /\n   ,--\\(        ,     <_/`\\\\     ||      /\n  (   ,``-     \\/|         \\-A.A-`|     /\n ,>,_ )_,..(    )\\          -,,_-`  _--`\n(_ \\|`   _,/_  /  \\_            ,--`\n \\( `   <.,../`     `-.._   _,-`\n");
            Console.WriteLine("\n████████╗██╗░░██╗███████╗  ██╗░░░░░░█████╗░░██████╗████████╗  ████████╗███████╗███╗░░░███╗██████╗░██╗░░░░░███████╗\n╚══██╔══╝██║░░██║██╔════╝  ██║░░░░░██╔══██╗██╔════╝╚══██╔══╝  ╚══██╔══╝██╔════╝████╗░████║██╔══██╗██║░░░░░██╔════╝\n░░░██║░░░███████║█████╗░░  ██║░░░░░██║░░██║╚█████╗░░░░██║░░░  ░░░██║░░░█████╗░░██╔████╔██║██████╔╝██║░░░░░█████╗░░\n░░░██║░░░██╔══██║██╔══╝░░  ██║░░░░░██║░░██║░╚═══██╗░░░██║░░░  ░░░██║░░░██╔══╝░░██║╚██╔╝██║██╔═══╝░██║░░░░░██╔══╝░░\n░░░██║░░░██║░░██║███████╗  ███████╗╚█████╔╝██████╔╝░░░██║░░░  ░░░██║░░░███████╗██║░╚═╝░██║██║░░░░░███████╗███████╗\n░░░╚═╝░░░╚═╝░░╚═╝╚══════╝  ╚══════╝░╚════╝░╚═════╝░░░░╚═╝░░░  ░░░╚═╝░░░╚══════╝╚═╝░░░░░╚═╝╚═╝░░░░░╚══════╝╚══════╝\n");

            Introduction();

            //Запуск действия сцен
            while (true)
            {
                if      (roomNumber == 1)  ActionTempleHall();
                else if (roomNumber == 2) ActionTempleRoom2();
                else if (roomNumber == 3) ActionTempleRoom3();
                else if (roomNumber == 4) ActionTempleRoom4();
                else if (roomNumber == 5) ActionTempleRoom5();
                else if (roomNumber == 6) ActionTempleRoom6();
            }
        }

        //Вступление
        static void Introduction()
        {
            Console.WriteLine("Ты смутно помнишь где ты. .. даже кто ты...");
            Console.ReadLine();
            Console.WriteLine("Тело сдавлено, однако твой мозг уже подает сигналы к жизни.");
            Console.WriteLine("Он говорить, ремень...");
            Console.ReadLine();
            Console.WriteLine("Давит не все тело, а именно грудная клетка, машинально ты бьешь куда-то ниже бедра..");
            Console.WriteLine("Щелчок и ты летишь куда-то вниз. ..");
            Console.ReadLine();
            Console.WriteLine("Небольшой удар о землю, да после такой встряски твой мозг точно начал работать");
            Console.WriteLine("Со скоростью молнии ты вспоминаешь последние 24 часа, хотя тебе и не хочется вспоминать.");
            Console.ReadLine();
            Console.WriteLine("Вы в составе 3-ей экспедиции были отправлены изучение нового континента");
            Console.WriteLine("Обычное исследование, последние 2 года все дни были практически одинаковые");
            Console.WriteLine("Разве что менялось это виды... хотя что интересного в них можно увидеть");
            Console.ReadLine();
            Console.WriteLine("Ваша экспедиция стояла на удалении пары десятков сотен километров от берега моря");
            Console.WriteLine("Внезапно ты заметил, что зеленый холм вдалеке стал больше и он увеличивается...");
            Console.WriteLine("Нет, он стоит на месте, это просто вашу группу тянет к нему, будто сильным магнитом");
            Console.ReadLine();
            Console.WriteLine("Последние 10 минут, что ты помнишь - это то как тщетно пытался выбраться из этого потока");
            Console.WriteLine("Однако... теперь ты здесь... и судя по всему приземлился ты не очень...");
            Console.WriteLine("Разбираться с тем, что произошло будем потом, сейчас перед тобой предстал храм, что вы искали последние два года");
            Console.WriteLine("В любом случае нужно хотя бы осмотреть его.");
            Console.ReadLine();
            Console.WriteLine("Когда ты заходишь внутрь храма, двери захлопываются, и перед тобой появляется ветхая деревянная табличка:\n");
            Console.ReadLine();

        }

        //Завершение игры
        static void Conclusion()
        {
            Console.WriteLine("\n████████╗██╗░░██╗███████╗  ███████╗███╗░░██╗██████╗░\n╚══██╔══╝██║░░██║██╔════╝  ██╔════╝████╗░██║██╔══██╗\n░░░██║░░░███████║█████╗░░  █████╗░░██╔██╗██║██║░░██║\n░░░██║░░░██╔══██║██╔══╝░░  ██╔══╝░░██║╚████║██║░░██║\n░░░██║░░░██║░░██║███████╗  ███████╗██║░╚███║██████╔╝\n░░░╚═╝░░░╚═╝░░╚═╝╚══════╝  ╚══════╝╚═╝░░╚══╝╚═════╝░");
            Console.WriteLine("Конец игры, вы выбрались из храма");
            Console.ReadLine();
            Environment.Exit(0);
        }

        //Игровые сцены внутри храма
        public static void ActionTempleHall() //1
        {
            Console.Clear();
            Console.WriteLine("Вы зашли в храм. Вам нужно найти сокровище, чтобы открыть двери храма.");
            Console.WriteLine("Вы находитесь в первой комнате. В комнате есть две двери, слева и справа, и левая дверь излучает странный свет.");
            Console.WriteLine("Доступные действия:");
            Console.WriteLine("1. Пойти налево");
            Console.WriteLine("2. Пойти направо");
            int option;

            if (hasTreasure)
            {
                Console.WriteLine("Вы видите углубление, сильно похожее на форму сокровища. Может нужно приложить его и двери поддадуться?");
                Console.WriteLine("3. Свалить из храма");
                option = GetIntInRange(3);
                Console.ReadLine();
                Conclusion();
            }
            else option = GetIntInRange(2);

            if(option == 1)
            {
                Console.WriteLine("Ты входишь в дверь со странным свечением");
                Console.ReadLine();
                roomNumber = 2;
            }

            else if (option == 2)
            {
                Console.WriteLine("Ты  проходишь внутрь зловещей комнаты");
                Console.ReadLine();
                roomNumber = 3;
            }

            else if (option == 3)
            {
                Conclusion();
            }
        }

        public void ActionTempleRoom2() //2
        {
            Console.Clear();
            Console.WriteLine("Ты находишься в пространстве каменного зала");
            Console.WriteLine("Перед тобой монумент из-за которой выглядывает свет");
            Console.WriteLine("Вы заглядываете за него");
            Console.WriteLine($"В комнате был светящийся камень, на котором высечены цифры {Chest._code}. Желательно их запомнить, наверняка пригодятся.\nКомната выглядит пустой.");
            Console.WriteLine("Доступные действия: ");
            Console.WriteLine("1. Изучить комнату");
            Console.WriteLine("2. Вернуться назад");
            int option = GetIntInRange(2);

            if (option == 1)
            {
                Console.WriteLine("Вы нашли ключ! Нок сожалению вы больше ничего не нашли");
                player.HasKey = true;
                Console.ReadLine();
                roomNumber = 2;
            }

            else if (option == 2)
            {
                Console.WriteLine("Вы вернулись в просторный холл");
                Console.ReadLine();
                roomNumber = 1;
            }

        }

        public void ActionTempleRoom3() //3
        {
            Console.Clear();
            Console.WriteLine("Открыв дверь ты попал в маленькое помещение, будто чулан");
            Console.WriteLine("Хотя здесь точно недавно кто-то был, ведь горит каменный камин");
            Console.WriteLine("Здесь будто недавно кто-то был. ..");
            Console.WriteLine("* а раз кто-то здесь был, то здесь наверняка есть что-то интересное");
            Console.WriteLine("Дверь за вами закрылась. Вы больше не можете ее открыть, но на стене вы увидели странные кирпичи с числами 32 11 53 10 21, которые можно нажимать.");
            Console.WriteLine("Впереди вы замечаете ловушки.");
            Console.WriteLine("Доступные действия: ");
            Console.WriteLine("1. Попытаться решить головоломку");
            Console.WriteLine("2. Попробовать сразу пройти ловушки");
            int option = GetIntInRange(2);

            if (option == 1)
            {
                Console.WriteLine("Решение нужно вводить так: ** ** ** ** **");
                string input = Console.ReadLine();

                if (puzzle.Solve(input))
                {
                    trap.IsDisabled = true;
                    Console.WriteLine("Похоже, что ловушки отключились! Вы можете пройти дальше.");
                    roomNumber = 4;
                    Console.ReadLine();
                }
                else
                {
                    trap.IsDisabled = false;
                    Console.WriteLine("Кирпичи перестали нажиматься, похоже, придется пройти дальше через ловушки.");
                    Console.ReadLine();
                }
            }

            if (!trap.IsDisabled)
            {
                trap.Pass();
                player.Health = trap.Health;

                if (player.Health == "full")
                {
                    Console.WriteLine("Вы прошли ловушки и не получили никакого урона.");
                    roomNumber = 4;
                    Console.ReadLine();
                }
                else if (player.Health == "mid")
                {
                    Console.WriteLine("Вы прошли ловушки с ранением.");
                    roomNumber = 4;
                    Console.ReadLine();
                }
                else if (player.Health == "low")
                {
                    Console.WriteLine("К сожалению, вы не прошли ловушки и погибли.\n");
                    Console.WriteLine("\n░██╗░░░░░░░██╗░█████╗░░██████╗████████╗███████╗██████╗░\n░██║░░██╗░░██║██╔══██╗██╔════╝╚══██╔══╝██╔════╝██╔══██╗\n░╚██╗████╗██╔╝███████║╚█████╗░░░░██║░░░█████╗░░██║░░██║\n░░████╔═████║░██╔══██║░╚═══██╗░░░██║░░░██╔══╝░░██║░░██║\n░░╚██╔╝░╚██╔╝░██║░░██║██████╔╝░░░██║░░░███████╗██████╔╝\n░░░╚═╝░░░╚═╝░░╚═╝░░╚═╝╚═════╝░░░░╚═╝░░░╚══════╝╚═════╝░");
                    Console.ReadLine();
                    Death();
                    return;
                }
            }
        }

        public void ActionTempleRoom4() //4
        {
            Console.Clear();
            Console.WriteLine("В этой комнате все украшено древними жуткими орнаментами");
            Console.WriteLine("Отсюда хочется поскорее сбежать, все твое нутро тебе говорит об этом");
            Console.WriteLine("В центре комнаты стоит краство украшенный сундук");
            Console.WriteLine("Доступные действия:");
            Console.WriteLine("1. Обследовать сундук");
            Console.WriteLine("2. Пройти мимо");
           
            
            int option = GetIntInRange(2);

            if (option == 1)
            {
                Console.WriteLine("Вы нашли сундук с кодовым 4-хзначным замком");
                Console.WriteLine("Введите код");
                string ninput = Console.ReadLine();

                if (chest.Unlock(ninput))
                {
                    Console.WriteLine("Код верный! Внутри лежало противоядие.");
                    player.HasAntidote = true;
                    Console.ReadLine();
                    roomNumber = 5;
                }
                else
                {
                    Console.WriteLine("Вы ввели неверный код, после чего внутри замка что-то щелкнуло, и барабаны с цифрами перестали двигаться.");
                    player.HasAntidote = false;
                    Console.ReadLine();
                    roomNumber = 5;
                }
            }

            else if (option == 2)
            {
                Console.WriteLine("Вы спокойно проходите в следующую комнату.");
                roomNumber = 5;
                Console.ReadLine();
            }
        }

        public void ActionTempleRoom5() //5
        {
            Console.Clear();
            Console.WriteLine("Как только ты вошел в комнату, ты сразу почувствовал себя неуютно");
            Console.WriteLine("Отсюда хочется поскорее сбежать, все твое нутро тебе говорит об этом");
            Console.WriteLine("В этом помещении очень темно, однако ты будто бы видишь вдалеке слева луч света");
            Console.WriteLine("Доступные действия:");
            Console.WriteLine("1. Обследовать темные углы этого помещения");
            Console.WriteLine("2. Добежать до света");
            Console.WriteLine("3. Вернуться обратно в каменный зал");



            
            
            int option = GetIntInRange(2);

            if (option == 1)
            {
                Console.WriteLine("В углу притаился огромный паук, он набросился на вас.");
                if (spider.Fight(player.HasAntidote, player.Health))
                {
                    Console.WriteLine("Вы победили паука, за ним вы нашли веревку и пошли дальше.");
                    player.HasRope = true;
                    Console.ReadLine();
                    roomNumber = 6;
                }
                else
                {
                    Console.WriteLine("Паук убил вас.\n");
                    Console.WriteLine("\n░██╗░░░░░░░██╗░█████╗░░██████╗████████╗███████╗██████╗░\n░██║░░██╗░░██║██╔══██╗██╔════╝╚══██╔══╝██╔════╝██╔══██╗\n░╚██╗████╗██╔╝███████║╚█████╗░░░░██║░░░█████╗░░██║░░██║\n░░████╔═████║░██╔══██║░╚═══██╗░░░██║░░░██╔══╝░░██║░░██║\n░░╚██╔╝░╚██╔╝░██║░░██║██████╔╝░░░██║░░░███████╗██████╔╝\n░░░╚═╝░░░╚═╝░░╚═╝░░╚═╝╚═════╝░░░░╚═╝░░░╚══════╝╚═════╝░");
                    Console.ReadLine();
                    Death();
                    return;
                }
            }

            else if (option == 2)
            {
                Console.WriteLine("Вы спокойно проходите в следующую комнату.");
                roomNumber = 6;
                Console.ReadLine();
            }
                
        }

        public void ActionTempleRoom6() //6
        {
            Console.Clear();

            Thread.Sleep(1000);

            Console.WriteLine("Когда вы зашли в следующую комнату, проход обратно засыпало камнями. Сама же комната была заполнена зыбучим песком, но на потолке виднелся крюк\nЕсли вы не нашли веревку, то у вас почти нет шансов пройти дальше.");
            int chance = new Random().Next(100);

            Thread.Sleep(1000);

            if (!player.HasRope)
            {
                if (chance < 5)
                {
                    Console.WriteLine("Вам невероятно повезло, вы прошли это испытание.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Вы не прошли испытание и утанули в песках.\n");
                    Console.WriteLine("\n░██╗░░░░░░░██╗░█████╗░░██████╗████████╗███████╗██████╗░\n░██║░░██╗░░██║██╔══██╗██╔════╝╚══██╔══╝██╔════╝██╔══██╗\n░╚██╗████╗██╔╝███████║╚█████╗░░░░██║░░░█████╗░░██║░░██║\n░░████╔═████║░██╔══██║░╚═══██╗░░░██║░░░██╔══╝░░██║░░██║\n░░╚██╔╝░╚██╔╝░██║░░██║██████╔╝░░░██║░░░███████╗██████╔╝\n░░░╚═╝░░░╚═╝░░╚═╝░░╚═╝╚═════╝░░░░╚═╝░░░╚══════╝╚═════╝░");
                    Console.ReadLine();
                    Death();
                    return;
                }
            }

            Thread.Sleep(1000);

            Console.WriteLine("Следующая комната оказалась последней, в ней был сундук с сокровищем.");

            Thread.Sleep(1000);

            if (player.HasKey)
            {
                Console.WriteLine("Так как вы нашли ключ, вы открыли замок и получили сокровище!\n");
                hasTreasure = true;
                Console.WriteLine("Вы видите проход, который появился после открытия сундука, похоже он ведет в самое начало\n");
                roomNumber = 1;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Вы не нашли способ открыть сундук и остались запертыми в храме.\n");
                Console.WriteLine("\n██████╗░░█████╗░██████╗░██╗███╗░░██╗░██████╗░  ██████╗░███████╗░█████╗░████████╗██╗░░██╗\n██╔══██╗██╔══██╗██╔══██╗██║████╗░██║██╔════╝░  ██╔══██╗██╔════╝██╔══██╗╚══██╔══╝██║░░██║\n██████╦╝██║░░██║██████╔╝██║██╔██╗██║██║░░██╗░  ██║░░██║█████╗░░███████║░░░██║░░░███████║\n██╔══██╗██║░░██║██╔══██╗██║██║╚████║██║░░╚██╗  ██║░░██║██╔══╝░░██╔══██║░░░██║░░░██╔══██║\n██████╦╝╚█████╔╝██║░░██║██║██║░╚███║╚██████╔╝  ██████╔╝███████╗██║░░██║░░░██║░░░██║░░██║\n╚═════╝░░╚════╝░╚═╝░░╚═╝╚═╝╚═╝░░╚══╝░╚═════╝░  ╚═════╝░╚══════╝╚═╝░░╚═╝░░░╚═╝░░░╚═╝░░╚═╝");
                Death();
            }
        }

        //Функция для завершения игры в следствие смерти
        static void Death()
        {
            Console.WriteLine("\n████████╗██╗░░██╗███████╗  ███████╗███╗░░██╗██████╗░\n╚══██╔══╝██║░░██║██╔════╝  ██╔════╝████╗░██║██╔══██╗\n░░░██║░░░███████║█████╗░░  █████╗░░██╔██╗██║██║░░██║\n░░░██║░░░██╔══██║██╔══╝░░  ██╔══╝░░██║╚████║██║░░██║\n░░░██║░░░██║░░██║███████╗  ███████╗██║░╚███║██████╔╝\n░░░╚═╝░░░╚═╝░░╚═╝╚══════╝  ╚══════╝╚═╝░░╚══╝╚═════╝░");
            Console.WriteLine("В сложившихся обстоятельствах, вы не можете более продолжать игру.");
            Console.ReadLine();
            Environment.Exit(0);
        }

        //Проверка на неправильный ввод. Пока конвёртед и инренж не будет тру, пользователь не сможет продолжить
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
    }
}
