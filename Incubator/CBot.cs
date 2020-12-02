using System;
using System.Collections.Generic;
using System.Text;

namespace Incubator
{
    class CBot
    {

        public const int MAX_DNA_SIZE = 64;
        public BotType Type;
        public List<DnaCommands> DNA;
        public int CurrentCommand;
        public int XCoord;
        public int YCoord;
        public int Health;
        public int Minerals;
        public int CRed;
        public int CGreen;
        public int CBlue;
        public BotDirect Direct;
    
        public CBot()
        {
            this.Type = BotType.LV_ALIVE;
            this.DNA = new List<DnaCommands>();
            this.Direct = BotDirect.Right;

            for(int i=0; i < MAX_DNA_SIZE; i++)
            {
                DNA.Add(DnaCommands.Photosynthesis);
            }

        }

        public void EatSun(Seasons currentSeason)
        {
            var t = 0;
            if (Minerals < 100)
            {
                t = 0;
            }
            else
            {
                if (Minerals < 400) t = 1;
                else t = 2;
            }

            int hlt = (int)currentSeason - ((YCoord - 1) / 6) + t;

            if (hlt > 0)
            {
                Health += hlt;
                goGreen(Minerals);

            }
        }
        public void MineraltoEnergy()
        {
        if (Minerals > 100) 
            {
                Minerals = Minerals - 100;
                Minerals = Health + 400;
                goBlue();
            }
            else
            {
                goBlue();
                Health = Health + 4 * Minerals;
                Minerals = 0;
            }

        }

        public void NextCommand()
        {
            if (CurrentCommand == MAX_DNA_SIZE - 1)
            {
                CurrentCommand = 0;
                return;
            }
            CurrentCommand++;
        }
        public void ExecuteCommnad()
        {
            switch (DNA[CurrentCommand])
            {
                case DnaCommands.Photosynthesis:
                    break;
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
        }
        public int xFromVektorR(int n,CWorld World)
        {
            int xt = XCoord;
            n = n + Direct;
            if (n >= 8)
            {
                n = n - 8;
            }
            if (n == 0 || n == 6 || n == 7)
            {
                xt = xt - 1;
                if (xt == -1)
                {
                    xt = World.WorldWidth - 1;
                }
            }
            else if (n == 2 || n == 3 || n == 4)
            {
                xt = xt + 1;
                if (xt == World.WorldWidth)
                {
                    xt = 0;
                }
            }
            return xt;
        }

        //жжжжжжжжжжжжжжжжжжжхжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжж
        // -- получение Х-координаты рядом        ---------
        //  с био по абсолютному направлению     ----------
        // in - номер био, направление       --------------
        // out - X -  координата             --------------
        public int xFromVektorA(Bot bot, int n)
        {
            int xt = bot.x;
            if (n == 0 || n == 6 || n == 7)
            {
                xt = xt - 1;
                if (xt == -1)
                {
                    xt = World.simulation.width - 1;
                }
            }
            else if (n == 2 || n == 3 || n == 4)
            {
                xt = xt + 1;
                if (xt == World.simulation.width)
                {
                    xt = 0;
                }
            }
            return xt;
        }

        //жжжжжжжжжжжжхжжжжжхжжжжжжхжхжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжж
        // ------ получение Y-координаты рядом              ---------
        // ---- Y координата по относительному направлению  ----------
        // ---  in - номер бота, направление              ------------
        // ---  out - Y -  координата                    -------------
        public int yFromVektorR(Bot bot, int n)
        {
            int yt = bot.y;
            n = n + bot.direction;
            if (n >= 8)
            {
                n = n - 8;
            }
            if (n == 0 || n == 1 || n == 2)
            {
                yt = yt - 1;
            }
            else if (n == 4 || n == 5 || n == 6)
            {
                yt = yt + 1;
            }
            return yt;
        }

        //жжжжжжжжжжжжхжжжжжхжжжжжжхжхжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжжж
        // ------ получение Y-координаты рядом              ---------
        // ---- Y координата по абсолютному направлению     ----------
        // ---  in - номер бота, направление              ------------
        // ---  out - Y -  координата                    -------------
        public int yFromVektorA(Bot bot, int n)
        {
            int yt = bot.y;
            if (n == 0 || n == 1 || n == 2)
            {
                yt = yt - 1;
            }
            else if (n == 4 || n == 5 || n == 6)
            {
                yt = yt + 1;
            }
            return yt;
        }

        public int botEat(int direction, int ra)
        { // на входе ссылка на бота, направлелие и флажок(относительное или абсолютное направление)
          // на выходе пусто - 2  стена - 3  органик - 4  бот - 5
            Health = Health - 4; // бот теряет на этом 4 энергии в независимости от результата
            int xt;
            int yt;
            if (ra == 0)
            {  // вычисляем координату клетки, с которой хочет скушать бот (относительное направление)
                xt = xFromVektorR(bot, direction);
                yt = yFromVektorR(bot, direction);
            }
            else
            {        // вычисляем координату клетки, с которой хочет скушать бот (абсолютное направление)
                xt = xFromVektorA(bot, direction);
                yt = yFromVektorA(bot, direction);
            }
            if ((yt < 0) || (yt >= World.simulation.height))
            {  // если там стена возвращаем 3
                return 3;
            }
            if (World.simulation.matrix[xt][yt] == null)
            {  // если клетка пустая возвращаем 2
                return 2;
            }
            // осталось 2 варианта: ограника или бот
            else if (World.simulation.matrix[xt][yt].alive <= LV_ORGANIC_SINK)
            {   // если там оказалась органика
                deleteBot(World.simulation.matrix[xt][yt]);                           // то удаляем её из списков
                bot.health = bot.health + 100; //здоровье увеличилось на 100
                goRed(this, 100);                                     // бот покраснел
                return 4;                                               // возвращаем 4
            }
            //--------- дошли до сюда, значит впереди живой бот -------------------
            int min0 = bot.mineral;  // определим количество минералов у бота
            int min1 = World.simulation.matrix[xt][yt].mineral;  // определим количество минералов у потенциального обеда
            int hl = World.simulation.matrix[xt][yt].health;  // определим энергию у потенциального обеда
                                                              // если у бота минералов больше
            if (min0 >= min1)
            {
                bot.mineral = min0 - min1; // количество минералов у бота уменьшается на количество минералов у жертвы
                                           // типа, стесал свои зубы о панцирь жертвы
                deleteBot(World.simulation.matrix[xt][yt]);          // удаляем жертву из списков
                int cl = 100 + (hl / 2);           // количество энергии у бота прибавляется на 100+(половина от энергии жертвы)
                bot.health = bot.health + cl;
                goRed(this, cl);                    // бот краснеет
                return 5;                              // возвращаем 5
            }
            //если у жертвы минералов больше ----------------------
            bot.mineral = 0; // то бот израсходовал все свои минералы на преодоление защиты
            min1 = min1 - min0;       // у жертвы количество минералов тоже уменьшилось
            World.simulation.matrix[xt][yt].mineral = min1 - min0;       // перезаписали минералы жертве =========================ЗАПЛАТКА!!!!!!!!!!!!
                                                                         //------ если здоровья в 2 раза больше, чем минералов у жертвы  ------
                                                                         //------ то здоровьем проламываем минералы ---------------------------
            if (bot.health >= 2 * min1)
            {
                deleteBot(World.simulation.matrix[xt][yt]);         // удаляем жертву из списков
                int cl = 100 + (hl / 2) - 2 * min1; // вычисляем, сколько энергии смог получить бот
                bot.health = bot.health + cl;
                if (cl < 0) { cl = 0; } //========================================================================================ЗАПЛАТКА!!!!!!!!!!! - энергия не должна быть отрицательной

                goRed(this, cl);                   // бот краснеет
                return 5;                             // возвращаем 5
            }
            //--- если здоровья меньше, чем (минералов у жертвы)*2, то бот погибает от жертвы
            World.simulation.matrix[xt][yt].mineral = min1 - (bot.health / 2);  // у жертвы минералы истраченны
            bot.health = 0;  // здоровье уходит в ноль
            return 5;                       // возвращаем 5
        }
        public void deleteBot()
        {
            Bot pbot = bot.mprev;
            Bot nbot = bot.mnext;
            if (pbot != null) { pbot.mnext = null; } // удаление бота из многоклеточной цепочки
            if (nbot != null) { nbot.mprev = null; }
            bot.mprev = null;
            bot.mnext = null;
            World.simulation.matrix[bot.x][bot.y] = null; // удаление бота с карты
        }
        public void goBlue(int num)//Функция посоинения
        {
            CBlue = CBlue + num;
            if (CBlue >255)
            {
                CBlue = 255;
            }
            int nm = num / 2;
            CGreen = CGreen - nm;
            if(CGreen < 0)
            {
                CRed = CRed + CGreen;
            }
            CRed = CRed - nm;
            if (CRed < 0)
            {
                CGreen = CGreen + CRed;
            }
            if (CRed < 0)
            {
                CRed = 0;
            }
            if (CGreen < 0)
            {
                CGreen = 0;
            }
        }
        public void goGreen(int num)//Функция позеленения
        {
            CGreen = CGreen + num;
            if (CGreen > 255)
            {
                CGreen = 255;
            }
            int nm = num / 2;
            CRed = CRed - nm;
            if (CRed < 0)
            {
                CBlue = CBlue + CRed;
            }
            CBlue = CBlue - nm;
            if (CBlue < 0)
            {
                CRed = CRed + CBlue;
            }
            if (CRed < 0)
            {
                CRed = 0;
            }
            if (CBlue < 0)
            {
                CBlue = 0;
            }
        }
        public void goRed(int num)//Функция покраснения
        {
            CRed = CRed + num;
            if (CRed > 255)
            {
                CRed = 255;
            }
            int nm = num / 2;
            CGreen = CGreen - nm;
            if (CGreen < 0)
            {
                CBlue = CBlue + CGreen;
            }
            CBlue = CBlue - nm;
            if (CBlue < 0)
            {
                CGreen = CGreen + CBlue;
            }
            if (CBlue < 0)
            {
                CBlue = 0;
            }
            if (CGreen < 0)
            {
                CGreen = 0;
            }
        }
    }
}
