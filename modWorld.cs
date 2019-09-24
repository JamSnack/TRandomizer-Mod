using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

// --------- Chest Tasks --------------
//Buried Chests
//Surface Chests
//Jungle Chests Placement
//Water Chests


namespace modWorld
{
  public class modWorld : ModWorld
  {
    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
    {
        int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Surface Chests"));
        tasks.Insert(genIndex + 1, new PassLegacy("Ran SurfaceC", delegate (GenerationProgress progress)
        {
             WorldGen.PlaceChest(Main.spawnTileX, Main.spawnTileY, 21, false, 1);
        }));
    }

    //Item Pool
    static List<int> surfList = new List<int>();
    static List<int> underList = new List<int>();
    static List<int> dunList = new List<int>();
    static List<int> rareList = new List<int>();

    static List<int> itemList = new List<int>();
    static List<int> barList = new List<int>();
    static List<int> potList = new List<int>();

    static List<int> surfMethod()
    {
      if (surfList.Count == 0)
      {
        //Surface List
        surfList.Add(280); //Spear
        surfList.Add(284); //Wooden Boomerang
        surfList.Add(281); //Blowpipe
        surfList.Add(285); //Aglet
        surfList.Add(953); //Climbing Clawns
        surfList.Add(946); //Umbrella
        surfList.Add(3084); //Radar
        surfList.Add(3068);//Cordage Guide
        surfList.Add(3069); //Wand of Sparking

        //Ice Chests
        surfList.Add(670); //Ice Boomerang
        surfList.Add(724); //Ice Blade
        surfList.Add(950); //IceSkates
        surfList.Add(1319); //SnowballCannon
        surfList.Add(987); //BlizzardInaBottle
        surfList.Add(1579); //Flurryboots

        //Living Wood Chest
        surfList.Add(832); //LivingWoodWand
        surfList.Add(933); //LeafWand
        surfList.Add(2196); //LivingLoom
        surfList.Add(55); //EnchantedBoomerang
        surfList.Add(1991); //Bugnet
        surfList.Add(111); //BandofStarpower
      }
      return surfList;
    }

    static List<int> underMethod()
    {
      if (underList.Count == 0)
      {
        //Underground/Cavern List
        underList.Add(43); //SusEye
        underList.Add(49); //BandofRegen
        underList.Add(50); //MagicMirror
        underList.Add(53); //Cloud in a Bottle
        underList.Add(54); //HermesBoots
        underList.Add(55); //Enchanted Boomerang
        underList.Add(906); //Lava Charm
        underList.Add(930); //Flare Gun
        underList.Add(975); //ShoeSpikes
        underList.Add(997); //Extractinator

        //Jungle Chest List
        underList.Add(212); //AnkletoftheWind
        underList.Add(211); //FeralClaws
        underList.Add(213); //StaffofRegrowth
        underList.Add(964); //Boomstick
        underList.Add(212); //AnkletoftheWind
        underList.Add(753); //SeaWeed
        underList.Add(212); //AnkletoftheWind
        underList.Add(3360); //LivingMahoganyWand
        underList.Add(3361); //LivingMahoganyLeafWand
        underList.Add(2204); //HoneyDispenser

        //WaterChests
        underList.Add(277); //Trident
        underList.Add(186); //BreathingReed
        underList.Add(187); //Flipper

        //SpiderChest
        underList.Add(939); //WebSlinger
      }
      return underList;
    }



    static List<int> dunMethod()
    {
      if (dunList.Count == 0)
      {
        //Dungeon/Obsidian Item List
        //GoldDungeonChests
        dunList.Add(164); //HandGun
        dunList.Add(157); //AquaScepter
        dunList.Add(113); //MagicMissle
        dunList.Add(163); //BlueMoon
        dunList.Add(156); //CobaltShield
        dunList.Add(155); //Muramasa
        dunList.Add(329); //ShadowKey
        dunList.Add(3317); //Valor
        dunList.Add(2192); //BoneWelder

        //ObsidianChests
        dunList.Add(274); //DarkLance
        dunList.Add(218); //Flamelash
        dunList.Add(112); //FlowerofFire
        dunList.Add(220); //Sunfury
        dunList.Add(3019); //HellwingBow
        dunList.Add(579); //Drax
      }
      return dunList;
    }

    static List<int> rareMethod()
    {
      if (rareList.Count == 0)
      {
        //Speacial (Rare) Item List
        //BiomeChests
        rareList.Add(1156); //PiranhaGun
        rareList.Add(1571); //ScourgeOfTheCorruptor
        rareList.Add(1569); //VampireKnives
        rareList.Add(1260); //RainbowGun
        rareList.Add(1572); //StaffoftheFrostHydra

        //IceChests
        rareList.Add(2198); //IceMachine
        rareList.Add(3199); //IceMirror
        rareList.Add(669); //Fish (Pet Summon)

        //JungleChests
        rareList.Add(2292); //FiberglassFishingpole
        rareList.Add(3017); //Flowerboots

        //LizhardChests
        rareList.Add(1293); //LihzhardPowerCell
        rareList.Add(2195); //LihzhardFurnace
        rareList.Add(2767); //SolarTablet

        //SkywareChests
        rareList.Add(159); //ShinyRedBalloon
        rareList.Add(65); //StarFury
        rareList.Add(158); //Lucky Horseshoe
        rareList.Add(2197); //Skymill

        //WaterChests
        rareList.Add(863); //WaterwalkingBoots
      }
      return rareList;
    }

    static List<int> itemMethod()
    {
      if (itemList.Count == 0)
      {
        //Item List
        itemList.Add(8); //Torch
        itemList.Add(31); //Bottle
        itemList.Add(40); //Wooden Arrow
        itemList.Add(41); //Flaming Arrow
        itemList.Add(42); //Shuriken
        itemList.Add(51); //Jester'sArrows
        itemList.Add(72); //Silver Coin
        itemList.Add(73); //Gold Coin
        itemList.Add(166); //Bomb
        itemList.Add(167); //Dynamite
        itemList.Add(168); //Grenade
        itemList.Add(265); //HellFire Arrow
        itemList.Add(278); //Silver Bullet
        itemList.Add(931); //Flare
        itemList.Add(965); //Rope
        itemList.Add(2766); //SolarTablet Fragment
        itemList.Add(3093); //HerbBag
      }
      return itemList;
    }

    static List<int> barMethod()
    {
      if (barList.Count == 0)
      {
        //Bar List
        barList.Add(19); //Gold Bar
        barList.Add(20); //Copper
        barList.Add(21); //Silver Bar
        barList.Add(22); //Iron
        barList.Add(117); //Meteorite Bar
        barList.Add(704); //Lead Bar
        barList.Add(705); //Tungsten Bar
        barList.Add(706); //Platinum Bar
      }
      return barList;
    }

    static List<int> potMethod()
    {
      if (potList.Count == 0)
      {
        //Potion List
        potList.Add(28); //Lesser Healing Potion
        potList.Add(188); //HealingPotion
        potList.Add(226); //Lesser Restoration Potion
        potList.Add(227); //Restoration Potion
        potList.Add(288); //Obsidian Skin Potion
        potList.Add(289); //Regen Potion
        potList.Add(290); //Swiftness Potion
        potList.Add(291); //Gills Potion
        potList.Add(293); //ManaRegen Potion
        potList.Add(294); //MagicPower Potion
        potList.Add(295); //Featherfall Potion
        potList.Add(296); //Spelunker Potion
        potList.Add(297); //Invisibility Potion
        potList.Add(298); //Shine Potion
        potList.Add(299); //Nightowl Potion
        potList.Add(300); //Battle Potion
        potList.Add(301); //Thorns Potion
        potList.Add(302); //Waterwalking Potion
        potList.Add(303); //Archery Potion
        potList.Add(304); //Hunter Potion
        potList.Add(305); //Gravitation Potion
        potList.Add(2322); //Mining Potion
        potList.Add(2323); //Heartreach Potion
        potList.Add(2325); //Building Potion
        potList.Add(2329); //Dangersense Potion
        potList.Add(2345); //Lifeforce Potion
        potList.Add(2348); //Inferno Potion
        potList.Add(2350); //Recall Potion
        potList.Add(2351); //Teleportation Potion
      }
      return potList;
    }

//--------------------------------------------------------------------------------
//Pick a random list
  static List<int> ranListMethod()
  {
    var listID = Main.rand.Next(0,6);
    if (listID == 0 || listID == 3)
    {
      return surfMethod();
    } else if (listID == 1 || listID == 4)
    {
      return underMethod();
    } else if (listID == 2)
    {
      return dunMethod();
    }

    //Only occurs if the random list is a "5"
    return rareMethod();
  }


//------------------------------------------------------------------------------------
    public override void PostWorldGen()
    {
      // Place some items in Chests
      Random random = new Random();

      List<int> itemLootList = itemMethod();
      List<int> potLootList = potMethod();
      List<int> barLootList = barMethod();

      int itemsToPlaceInIceChestsChoice = 0;
      int chestMax = random.Next(4,10); //Max amount of items in a chest

      for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
      {
        Chest chest = Main.chest[chestIndex];
        // If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding.
        if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers)
        {
          for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
          {
            if (chest.item[inventoryIndex].type == 0)
            {
              for (int a = 0; a < chestMax; a++)
              {
                //Choose item or loot
                int itemPick = random.Next(0,4);
                List<int> surfaceLootList = ranListMethod();

                if (itemPick == 0) //Loot
                {
                  chest.item[a].SetDefaults(surfaceLootList[random.Next(surfaceLootList.Count)]);
                }
                else if (itemPick == 1) //Items
                {
                  var itemAmt = random.Next(1,66);
                  chest.item[a].SetDefaults(itemLootList[random.Next(itemLootList.Count)]);
                  chest.item[a].stack = itemAmt;
                }
                else if (itemPick == 2) //Bars
                {
                  var itemAmt = random.Next(3,11);
                  chest.item[a].SetDefaults(barLootList[random.Next(barLootList.Count)]);
                  chest.item[a].stack = itemAmt;
                }
                else if (itemPick == 3) //Potions
                {
                  var itemAmt = random.Next(1,6);
                  chest.item[a].SetDefaults(potLootList[random.Next(potLootList.Count)]);
                  chest.item[a].stack = itemAmt;
                }
              }
              chestMax = random.Next(3,9);
              break;
            } else {
              //Clear the chest
              chest.item[inventoryIndex].SetDefaults();
            }
          }
        }
      }
    }
  }
}
