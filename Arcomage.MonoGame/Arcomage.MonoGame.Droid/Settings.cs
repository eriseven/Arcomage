using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.MonoGame.Droid
{
    public class Settings
    {
        public string FirstPlayer { get; set; } = "PlayerA";

        public string SecondPlayer { get; set; } = "PlayerB";

        public DeckMode DeckMode { get; set; } = DeckMode.Classic;

        public RuleMode RuleMode { get; set; } = RuleMode.EmpireCaptital;
    }

    public enum DeckMode
    {
        Classic,

        Infinity,
    }

    public enum RuleMode
    {
        BearMountain,

        CrystalGarden,

        DragonsCaves,

        EaglesNest,

        EastRiver,
        
        EmpireCaptital,

        FairyTrees,

        FishingVillage,

        GreenWood,

        KingdomCapital,

        KingdomCastle,

        LizardsLowland,

        MagmaMines,

        MythrilCoast,

        PeacefulCamp,

        PortCity,

        PortalsRuins,

        RoguesWood,

        ShiningSpring,

        SublimeArbor,

        SunnyCity,

        TigersLake,

        TitansValley,

        WolfsDale,
    }
}