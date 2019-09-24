using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;

namespace Randomizer.Items
{
	public class RandomSeed : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Finite Potential");
			Tooltip.SetDefault("A physical mass of energy with unknown potential.");
		}
		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.value = 10000;
			item.rare = 2;
			item.consumable = true;
			item.maxStack = 99;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OnConsumeItem(Player player)
		{
			Random random = new Random();

			//player.QuickSpawnItem(random.Next(1,3930), 1);
			NPC.NewNPC((int)player.Center.X, (int)player.Center.Y-15, 87);
		}
	}
}
