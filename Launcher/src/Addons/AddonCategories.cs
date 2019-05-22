using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Addons
{
    public class AddonCategories
    {
       
        public enum Categories : UInt64
        {
            All=0,
            Achievements = 0x1,
            ActionBars = 0x2,
            Alchemy = 0x4,
            Archeology = 0x8,
            Arena = 0x10,
            Artwork = 0x20,
            AuctionEconomy = 0x40,
            Bags_Inventory = 0x80,
            Battle_Pets = 0x100,
            Battleground = 0x200,
            Blacksmithing = 0x400,
            Boss_Encounters = 0x800,
            Buffs_Debuffs = 0x1000,
            Caster = 0x2000,
            Chat_Communication = 0x4000,
            Class = 0x8000,
            Combat = 0x10000,
            Companions = 0x20000,
            Cooking = 0x40000,
            Damage_Dealer = 0x80000,                      
            Death_Knight = 0x100000,
            Demon_Hunters = 0x200000,            
            Druid = 0x400000,
            Enchanting = 0x800000,
            Engineering = 0x1000000,
            First_Aid = 0x2000000,
            Fishing = 0x4000000,
            FuBar = 0x8000000,
            Garrison = 0x10000000,
            Guild = 0x20000000,
            Healer = 0x40000000,
            Herbalism = 1L << 31,
            Huds = 1L<<32,
            Hunter = 1L << 33,
            Inscription = 1L << 34,
            Jewelcrafting = 1L << 35,
            Leatherworking = 1L << 36,
            Libraries = 1L << 37,
            Mail = 1L << 38,
            Map_Minimap = 1L << 39,
            Mining = 1L << 40,
            Miscellaneous = 1L << 41,
            Monk = 1L << 42,
            Paladin = 1L << 43,
            Plugins = 1L << 44,
            Priest = 1L << 45,
            Professions = 1L << 46,
            PvP = 1L << 47,
            Quests_Leveling = 1L << 48,
            Raid_Frames = 1L << 49,
            Rogue = 1L << 50,
            Shaman = 1L << 51,
            Skinning = 1L << 52,
            Tailoring = 1L << 53,
            Tank = 1L << 54,
            Titan_Panel = 1L << 55,
            Tooltip = 1L << 56,
            Transmogrification = 1L << 57,
            Unit_Frames = 1L << 58,
            Warlock = 1L << 59,
            Warrior = 1L << 60,
        }
        public static Categories GetCategoryByCategoryIcon(string IconSource)
        {
            string CategoryName = System.Text.RegularExpressions.Regex.Replace(IconSource, "pack://application:,,,/View/Icons/CategoryList/Icons/", string.Empty);
            CategoryName = System.Text.RegularExpressions.Regex.Replace(CategoryName, ".jpg", string.Empty);
            CategoryName = System.Text.RegularExpressions.Regex.Replace(CategoryName, ".png", string.Empty);
            return (Categories)Enum.Parse(typeof(Categories), CategoryName);
        }
    }
}
