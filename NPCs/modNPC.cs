using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;

namespace modNPC.NPCs
{
  public class modNPC : GlobalNPC
  {

    public override bool InstancePerEntity
		{
			get
			{
				return false; //Changed from True.
			}
		}

    //Safe Mob list
    static List<int> safe_mobList = new List<int>();
    //Mob List
    static List<int> mobID = new List<int>();



    static List<int> safemobListMethod()
    {
      if (safe_mobList.Count == 0)
      {
        //Pre-Hardmode Mobs
        safe_mobList.Add(7); //Devourer
        safe_mobList.Add(8); //-
        safe_mobList.Add(9); //-
        safe_mobList.Add(10); //Giant-Worm
        safe_mobList.Add(11); //-
        safe_mobList.Add(12); //-
        safe_mobList.Add(13); //EoW
        safe_mobList.Add(14); //-
        safe_mobList.Add(15); //-
        safe_mobList.Add(35); //Skeletron
        safe_mobList.Add(36); //-
        safe_mobList.Add(39); //Bone Searpent
        safe_mobList.Add(40); //-
        safe_mobList.Add(41); //-
        safe_mobList.Add(68); //Dungeon Guardian
        safe_mobList.Add(87); //Wyvern
        safe_mobList.Add(88); //-
        safe_mobList.Add(89); //-
        safe_mobList.Add(90); //-
        safe_mobList.Add(91); //-
        safe_mobList.Add(92); //-
        safe_mobList.Add(98); //-Seeker
        safe_mobList.Add(99); //-
        safe_mobList.Add(100); //-
        safe_mobList.Add(112); //WoF
        safe_mobList.Add(113); //-
        safe_mobList.Add(114); //-
        safe_mobList.Add(115); //-
        safe_mobList.Add(116); //-
        safe_mobList.Add(117); //-
        safe_mobList.Add(118); //-
        safe_mobList.Add(119); //-

        //Hardmode Mobs
        safe_mobList.Add(95); //Digger
        safe_mobList.Add(96); //-
        safe_mobList.Add(97); //-
        safe_mobList.Add(473); //Corrupt Mimic
        safe_mobList.Add(474); //Crimson Mimic
        safe_mobList.Add(475); //Hallowed Mimic

        //Misc
        safe_mobList.Add(25); //Burning Sphere
        safe_mobList.Add(30); //Chaos Ball
        safe_mobList.Add(112); //Vile Spit
        safe_mobList.Add(115); //The Hungry


        string amt_mob = (safe_mobList.Count).ToString();
        //Main.NewText("Safe List: " + amt_mob, 255, 240, 20, false);
      }
      return safe_mobList;
    }


    static List<int> mobListMethod()
    {
      if (mobID.Count == 0)
      {
        //Pre-Hardmode Mobs - 21
        mobID.Add(6); //Eater of Souls
        mobID.Add(23); //Meteor Head
        mobID.Add(24); //Fire Imp
        mobID.Add(32); //Dark Caster
        mobID.Add(34); //Cursed Skull
        mobID.Add(42); //Hornet
        mobID.Add(45); //Tim
        mobID.Add(48); //Harpy
        mobID.Add(49); //Cave Bat
        mobID.Add(59); //Lava Slime
        mobID.Add(60); //Hell Bat
        mobID.Add(61); //Vulture
        mobID.Add(62);  //Demon
        mobID.Add(63);  //Blue Jelly-Fish
        mobID.Add(64);  //Pink Jelly-Fish
        mobID.Add(65);  //Shark
        mobID.Add(66); //Voodoo Demon
        mobID.Add(69); //Antlion
        mobID.Add(70); //Spike Ball
        mobID.Add(71); //Dungeon Slime
        mobID.Add(72); //Blazing Wheel*/
        mobID.Add(95); //Digger

        //Hardmode Mobs - 12
        mobID.Add(116); //TheHungery II
        mobID.Add(122); //Gastropod
        mobID.Add(244); //Rainbow Slime
        mobID.Add(527); //Dreamer Ghoul
        mobID.Add(513); //Tomb Crawler

        mobID.Add(75); //Pixie
        mobID.Add(84); //Enchanted Sword
        mobID.Add(85); //Mimic
        mobID.Add(87); //Wyvern
        mobID.Add(94); //Corruptor
        mobID.Add(156); //Red Devil
        mobID.Add(177); //Derpling
        mobID.Add(268); //IchorSticker
        mobID.Add(285); //Diabolist
        mobID.Add(288); //Dungeon Spirit
        mobID.Add(290); //Paladin
        mobID.Add(380); //Cultist Archer
        mobID.Add(476); //Jungle Mimic*/

        string amt_mob = (mobID.Count).ToString();
        //Main.NewText("Mob List: " + amt_mob, 255, 240, 20, false);
      }
      return mobID;
    }

    //Mobs Alive
    static List<int> mobsSpawned = new List<int>();

    static List<int> mobsSpawnedMethod()
    {
      return mobsSpawned;
    }

    //Set Defaults
    public override void SetDefaults(NPC npc)
    {
      if (Main.netMode != 1)
      {
        int ranChance = Main.rand.Next(2);
        List<int> mobs_spawned = mobsSpawnedMethod();

        if (ranChance == 1 && npc.townNPC == false && npc.lifeMax < 1000 && !mobs_spawned.Contains(npc.type))
        {
          List<int> safeList = safemobListMethod();

          if (!safeList.Contains(npc.type))
          {
            List<int> mobList = mobListMethod();

            //Get Random Mob ID from the list.
            //int ranID = 65;
            int ranID = mobList[Main.rand.Next(mobList.Count)];

            //If it is pre-hardmode
            if (Main.hardMode == false)
            {
              int hardChance = Main.rand.Next(0,3);

              //If it is a hardmode mob but it cannot spawn.
              if (ranID >= 75 && hardChance != 1)
              {
                ranID = mobList[Main.rand.Next(mobList.Count)];
              } else
              {
                //Main.NewText("Hardmode Creature Spawned.", 255, 240, 20, false);
              }
            }

            //If the ID selected is not in the list.
            if (npc.type != ranID)
            {
              int xx = (int)npc.Center.X;
              int yy = (int)npc.Center.Y;

              //Create the mob selected.
              NPC.NewNPC(xx, yy, ranID);

              //ensure mob does not get despawned
              mobs_spawned.Add(ranID);

              //Main.NewText("Creature Spawned", 255, 240, 20, false);
              //Main.NewText("Mob Spawned: "+ranID.ToString(), 255, 240, 20, false);

              //Kill the NPC
              npc.life = 0;

              if (mobs_spawned.Count > 3)
              {
                mobs_spawned.Clear();
              }
            }
          }
        }
      }
    }

    public virtual void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
    {
      if (Main.netMode != NetmodeID.SinglePlayer)
      {
        npc.netUpdate = true;
      }
    }

    public virtual void OnHitByItem(NPC npc, Player player, int damage, float knockback, bool crit )
    {
      if (Main.netMode != NetmodeID.SinglePlayer)
      {
        npc.netUpdate = true;
      }
    }

    public virtual void OnHitByProjectile(NPC npc, Player player, int damage, float knockback, bool crit )
    {
      if (Main.netMode != NetmodeID.SinglePlayer)
      {
        npc.netUpdate = true;
      }
    }
  }
}
