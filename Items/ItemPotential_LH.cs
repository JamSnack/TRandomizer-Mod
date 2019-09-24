using Terraria;
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Randomizer.Items
{
	public class ItemPotential_LH : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Finite Potential");
			Tooltip.SetDefault("A physical mass of energy with unknown potential. Right-click to generate an item from late hardmode.");

			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(3,6));
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 1000;
			item.rare = 4;
			item.consumable = true;
			item.maxStack = 99;
			ItemID.Sets.ItemNoGravity[item.type] = true;  //this make that the item will float in air
		}


	   /*public override void AddRecipes()
		{
			if (WorldGen.crimson == false) //Check for corruption.
				{
					ModRecipe recipe = new ModRecipe(mod);
					recipe.AddIngredient(ItemID.Gel, 25);
					recipe.AddIngredient(ItemID.DemoniteOre, 50);
					recipe.AddIngredient(ItemID.ShadowScale, 20);
					recipe.AddIngredient(ItemID.BeeWax, 20);
					recipe.AddTile(TileID.DemonAltar);
					recipe.SetResult(this);
					recipe.AddRecipe();
			} else //Check for crimson
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.Gel, 25);
				recipe.AddIngredient(ItemID.CrimtaneOre, 50);
				recipe.AddIngredient(ItemID.TissueSample, 20);
				recipe.AddIngredient(ItemID.BeeWax, 20);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}*/

		public override bool CanRightClick()
		{
			return true;
		}

		//-----------------Initialize item list.
		//Item List
		static List<int> itemList = new List<int>();

		static List<int> itemListMethod()
		{
			if (itemList.Count == 0)
			{
				//Chlorophyte Armor
				itemList.Add(1001); //Chlorophyte Mask
				itemList.Add(1002); ////Chlorophyte Helmet
				itemList.Add(1003);////Chlorophyte Headgear
				itemList.Add(1004); ////Chlorophyte Platemail
				itemList.Add(1005); ////Chlorophyte Greeves

				//Chlorophyte equipment
				itemList.Add(1226); //Chlorophyte Claymore
				itemList.Add(1227); //Chlorophyte Saber
				itemList.Add(1228); //Chlorophyte Partisan
				itemList.Add(1229); //Chlorophyte Shotbow
				itemList.Add(1230); //Chlorophyte Pickaxe
				itemList.Add(1231); //Chlorophyte Drill
				itemList.Add(1232); //Chlorophyte Chainsaw
				itemList.Add(1233); //Chlorophyte Greataxe
				itemList.Add(1234); //Chlorophyte Warhammer

				//Accessories
				itemList.Add(885); //AdhesiveBandage
				itemList.Add(886); //ArmorPolish
				itemList.Add(899); //SunStone
				itemList.Add(1248); //Eye of the Golem
				itemList.Add(938); //Paladin'sShield

				//Misc
				itemList.Add(1183); //WispinaBottle

				//Other equipmet
				itemList.Add(671); //Keybrand
				itemList.Add(679); //TacticalShotgun
				itemList.Add(758); //GrenadeLauncher
				itemList.Add(759); //RocketLauncher
				itemList.Add(788); //NettleBurst
				itemList.Add(1122); //PossessedHatchet
				itemList.Add(1155); //WaspGun
				itemList.Add(1157); //PygmyStaff
				itemList.Add(1178); //LeafBlower
				itemList.Add(1182); //Seedling
				itemList.Add(1254); //SniperRifle
				itemList.Add(1255); //VenusMagnum
				itemList.Add(1266); //MagnetSphere
				itemList.Add(1259); //FlowerPow
				itemList.Add(1294); //Picksaw
				itemList.Add(1295); //HeatRay
				itemList.Add(1296); //StaffofEarth
				itemList.Add(1297); //GolemFist
				itemList.Add(1305); //The Axe
				itemList.Add(1444); //ShadowbeamStaff
				itemList.Add(1445); //InfernoFork
				itemList.Add(1446); //SpectreStaff
				itemList.Add(1513); //Paladin'sHammer
				itemList.Add(2366); //Queen Spider Staff
				itemList.Add(2621); //TempestStaff
				itemList.Add(2622); //RazorbladeTyphoon
				itemList.Add(2623); //BubbleGun
				itemList.Add(2624); //Tsunami
				itemList.Add(3291); //Kraken
			}
			return itemList;
		}



		public override void OnConsumeItem(Player player)
		{
			Random random = new Random();
			List<int> lootList = itemListMethod();
			int ranID = lootList[Main.rand.Next(lootList.Count)];

			player.QuickSpawnItem(ranID, 1);
		}
	}
}
