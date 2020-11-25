using System;
using System.Collections.Generic;
using System.Text;

namespace Incubator
{
    public enum BotType
    {
        LV_ORGANIC_HOLD,
        LV_ORGANIC_SINK,
        LV_ALIVE
    }
    // 0-вверх-лево 1-вверх    2-верх-право   3-право
    // 4 право-низ  5-низ 6-лево-низ 7-лево
    public enum DnaCommands
    {
        Photosynthesis,
        ChangeDirectRel,
        ChangeDirectAbs,
        StepDirectRel,
        StepDirectAbs,
        EatDirectRel,
        EatDirectAbs,
        LookDirectRel,
        LookDirectAbs,
        DivDirectRel,
        DivDirectAbs,
        AligDirectRel,
        AligDirectAbs,
        QLevel,
        QHealth,
        QMinerals,
        Div,
        QSurrounded,
        QAddEnergy,
        QAddMinerals,
        MineralsToE,
        Mutation,
        DnaAttac

    }
    public enum BotDirect
    {
        TopLeft,
        Top,
        TopRight,
        Right,
        RigthBottom,
        Bottom,
        LeftBottom,
        Left
    }

    public enum Seasons: int
    {
          Summer = 11,
          Spring = 10,
          Winter = 9
    }
}
