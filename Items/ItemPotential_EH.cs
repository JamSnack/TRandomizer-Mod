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
	public class ItemPotential_EH : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fizzling Finite Potential");
			Tooltip.SetDefault("A physical mass of energy with unknown potential. Right-click to generate an item from early hardmode.");

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
				//Cobalt Armor
				itemList.Add(371); //Cobalt Hat
				itemList.Add(372); //Cobalt Helmet
				itemList.Add(373);//Cobalt Mask
				itemList.Add(374); //Cobalt Breastplate
				itemList.Add(375); //Cobalt Leggings

				//Cobalt equipment
				itemList.Add(383); //Cobalt Chainsaw
				itemList.Add(385); //Cobalt Drill
				itemList.Add(435); //Cobalt Repeater
				itemList.Add(483); //Cobalt Sword
				itemList.Add(537); //Cobalt Naginata
				itemList.Add(776); //Cobalt Pickaxe
				itemList.Add(991); //Cobalt Waraxe

				//Accessories
				itemList.Add(156); //Cobalt Shield
				itemList.Add(3334); //YoYo Glove

				//Other equipmet
				itemList.Add(426); //Breaker Blade
				itemList.Add(434); //Clockwork Assault Rifle
				itemList.Add(514); //Laser Rifle
				itemList.Add(2366); //Queen Spider Staff
				itemList.Add(2511); //Spider Staff
				itemList.Add(3052); //ShadowFlame Bow
				itemList.Add(3053); //ShadowFlame HexDoll
				itemList.Add(3054); //ShadowFlame Knife
				itemList.Add(3209); //Crystal Searpent
				itemList.Add(3788); //Onyx Blaster
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
