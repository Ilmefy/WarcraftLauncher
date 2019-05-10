using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Addons
{
    public class AddonCategories
    {
        [Flags]
        public enum Categories : UInt64
        {
            Achievements = 0x1,
            ActionBars = 0x2,
            Alchemy = 0x4,
            Archeology = 0x8,
            Arena = 0x10,
            Artwork = 0x20,
            AuctionEconomy = 0x40,
            Audio_Video = 0x80,
            Bags_Inventory = 0x100,
            Battle_Pets = 0x200,
            Battleground = 0x400,
            Blacksmithing = 0x800,
            Boss_Encounters = 0x1000,
            Buffs_Debuffs = 0x2000,
            Caster = 0x4000,
            Chat_Communication = 0x8000,
            Class = 0x10000,
            Combat = 0x20000,
            Companions = 0x40000,
            Cooking = 0x80000,
            Damage_Dealer = 0x100000,
            Data_Broker = 0x200000,
            Data_Export = 0x400000,
            Death_Knight = 0x800000,
            Demon_Hunters = 0x1000000,
            Development_Tools = 0x2000000,
            Druid = 0x4000000,
            Enchanting = 0x8000000,
            Engineering = 0x10000000,
            First_Aid = 0x2000000,
            Fishing = 0x4000000,
            FuBar = 0x8000000,
            Garrison = 0x10000000,
            Guild = 0x20000000,
            Healer = 0x40000000,
            Herbalism = 0x80000000,
            Huds = 0x100000000,
            HuntersMage = 0x200000000,
            Inscription = 0x400000000,
            Jewelcrafting = 0x800000000,
            Leatherworking = 0x1000000000,
            Libraries = 0x2000000000,
            Mail = 0x4000000000,
            Map_Minimap = 0x8000000000,
            Minigames = 0x10000000000,
            Mining = 0x20000000000,
            Miscellaneous = 0x40000000000,
            Monk = 0x80000000000,
            Paladin = 0x100000000000,
            Plugins = 0x200000000000,
            Priest = 0x400000000000,
            Professions = 0x800000000000,
            PvP = 0x1000000000000,
            Quests_Leveling = 0x2000000000000,
            Raid_Frames = 0x4000000000000,
            Rogue = 0x8000000000000,
            Roleplay = 0x10000000000000,
            Shaman = 0x20000000000000,
            Skinning = 0x40000000000000,
            Tailoring = 0x80000000000000,
            Tank = 0x100000000000000,
            Titan_Panel = 0x200000000000000,
            Tooltip = 0x400000000000000,
            Transmogrification = 0x800000000000000,
            Twitch_Integration = 0x1000000000000000,
            Unit_Frames = 0x1000000000000000,
            Warlock = 0x2000000000000000,
            Warrior = 0x4000000000000000,
        }
    }
}
