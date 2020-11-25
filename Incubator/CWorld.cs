using System;
using System.Collections.Generic;
using System.Text;

namespace Incubator
{
    /// <summary>
    /// Класс игрового мира
    /// </summary>
    class CWorld
    {
        /// <summary>
        /// Максимальная длина одного сезона 
        /// </summary>
        const int SEASON_MAX = 10;


        /// <summary>
        /// Признак пустоты в ячейке
        /// </summary>
        const int W_EMPTY = -1;

        /// <summary>
        /// Максимальное количество комманд за тик
        /// </summary>
        const int MAX_COMMANDS = 15;

        /// <summary>
        /// Текущий сезон
        /// </summary>
        public Seasons CurrentSeason = Seasons.Summer;

        /// <summary>
        /// Текущее время сезона
        /// </summary>
        int CurrentSeasonTime = 0;

        /// <summary>
        /// Флаг выполнения игрового цикла
        /// </summary>
        private bool stop = false;

        /// <summary>
        /// Массив ботов
        /// </summary>
        CBot[] bots;

        /// <summary>
        /// Ширина мира в клетках
        /// </summary>
        int WorldWidth = 180;

        /// <summary>
        /// Высота мира в клектах
        /// </summary>
        int WorldHeight = 96;


        public int[,] cells;
        CBot currentBot;

        /// <summary>
        /// Максимальное количество ботов
        /// </summary>
        int MAX_BOTS_COUNT {
            get {
                return WorldWidth * WorldHeight;
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="width">ширина мира в клетках</param>
        /// <param name="height">высота мира в клетках</param>
        public CWorld(int width = 180, int height=96)
        {
            WorldWidth = width;
            WorldHeight = height;
            cells = new int[WorldWidth, WorldHeight];
            for(int w = 0; w < WorldWidth; w++)
            {
                for (int h = 0; h < WorldHeight; h++)
                {
                    cells[w, h] = W_EMPTY;
                }
            }
            bots = new CBot[MAX_BOTS_COUNT];
            GenerateAdam();
        }

        public void OrganicDown(int botIndex)
        {
          var bot = bots[botIndex];

            var xCoord = bot.XCoord;
            var yCoord = bot.YCoord;

            // если мы достигли дна или под нами что-то есть
            if (yCoord+1 >= WorldHeight || cells[xCoord, yCoord+1] != W_EMPTY)
            {
                //превращаемся в статическую органику
                bot.Type = BotType.LV_ORGANIC_HOLD;
                return;
            }
            cells[xCoord, yCoord + 1] = botIndex;
            cells[xCoord, yCoord] = W_EMPTY;
            bot.YCoord = yCoord + 1;
        }

        /// <summary>
        /// Обработка шага бота
        /// </summary>
        /// <remarks>
        ///  Выполнение логики за игровой тик
        /// </remarks>
        /// <param name="botIndex">Индекс бота</param>
        public void BotStep(int botIndex) {
           var bot = bots[botIndex];
           if (bot.Type == BotType.LV_ORGANIC_HOLD)
            {
                return;
            } 
           if (bot.Type == BotType.LV_ORGANIC_SINK)
            {
                OrganicDown(botIndex);
                return;
            }
            int commandCount = 0;

            while(commandCount <= MAX_COMMANDS)
            {

                if (ExecCommand(botIndex)) break;
                commandCount++;
            }

        }

        private void KillBot(int botIndex)
        {
            var bot = bots[botIndex];
            bot.Type = BotType.LV_ORGANIC_SINK;

        }

        private void BotDouble(int botIndex)
        {
            var bot = bots[botIndex];
            bot.Health = bot.Health - 150;
            if (bot.Health <= 0)
            {

            }
        }

        private Boolean ExecCommand(int botIndex)
        {
            var bot = bots[botIndex];
            switch (bot.DNA[bot.CurrentCommand])
            {
                case DnaCommands.Photosynthesis:
                    bot.EatSun(CurrentSeason);
                    bot.NextCommand();
                    return true;
                case DnaCommands.ChangeDirectRel:
                    break;
                case DnaCommands.ChangeDirectAbs:
                    break;
                case DnaCommands.StepDirectRel:
                    break;
                case DnaCommands.StepDirectAbs:
                    break;
                case DnaCommands.EatDirectRel:
                    break;
                case DnaCommands.EatDirectAbs:
                    break;
                case DnaCommands.LookDirectRel:
                    break;
                case DnaCommands.LookDirectAbs:
                    break;
                case DnaCommands.DivDirectRel:

                    break;
                case DnaCommands.DivDirectAbs:
                    break;
                case DnaCommands.AligDirectRel:
                    break;
                case DnaCommands.AligDirectAbs:
                    break;
                case DnaCommands.QLevel:
                    break;
                case DnaCommands.QHealth:
                    break;
                case DnaCommands.QMinerals:
                    break;
                case DnaCommands.Div:
                    BotDouble(botIndex);
                    break;
                case DnaCommands.QSurrounded:
                    break;
                case DnaCommands.QAddEnergy:
                    break;
                case DnaCommands.QAddMinerals:
                    break;
                case DnaCommands.MineralsToE:
                    break;
                case DnaCommands.Mutation:
                    break;
                case DnaCommands.DnaAttac:
                    break;
            }
            return true;
        }

        /// <summary>
        /// Выполнение игрового цикла
        /// </summary>
        public void Start()
        {
            while (!stop)
            {
                for (int botIndex = 0; botIndex < MAX_BOTS_COUNT; botIndex++)
                {
                    var bot = bots[botIndex];
                    if (bot == null) continue;
                    BotStep(botIndex);
                }
                
            }
        }

        /// <summary>
        /// Остановка игрового цикла
        /// </summary>
        public void Stop()
        {
            stop = true;
        }


        /// <summary>
        /// Генерация первого бота
        /// </summary>
        private void GenerateAdam()
        {
            var adam = new CBot
            {
                CRed = 170,
                CBlue = 170,
                CGreen = 170,
                Health = 990,
                Minerals = 0,
                Type = BotType.LV_ALIVE,
                Direct = BotDirect.Bottom,
                XCoord = 90,
                YCoord = 48
            };
            bots[0] = adam;
            cells[90, 48] = 0;
        }
    }
}
