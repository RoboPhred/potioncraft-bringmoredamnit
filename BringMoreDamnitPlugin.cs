using System;
using System.Linq;
using BepInEx;
using HarmonyLib;
using Npc.MonoBehaviourScripts;
using Npc.Parts;
using Npc.Parts.Settings;
using ObjectBased.RecipeMap;
using UnityEngine;

namespace RoboPhredDev.PotionCraft.BringMoreDamnit
{

    [BepInPlugin("net.robophreddev.PotionCraft.BringMoreDamnit", "Bring more ingredients!", "1.0.0.0")]
    public class BringMoreDamnitPlugin : BaseUnityPlugin
    {
        public static string AssemblyDirectory
        {
            get
            {
                var assemblyLocation = typeof(BringMoreDamnitPlugin).Assembly.Location;
                return System.IO.Path.GetDirectoryName(assemblyLocation);
            }
        }

        void Awake()
        {
            UnityEngine.Debug.Log($"[BringMoreDamnit]: Loaded");

            this.ApplyPatches();

            // Delay ingredient load until the ingredients we base ours on have loaded.
            RecipeMapObjectAwakeEvent.OnRecipeMapObjectAwake += (sender, args) => IncreaseTraderInventory();
        }

        private void IncreaseTraderInventory()
        {
            var count = 0;
            foreach (var template in NpcTemplate.allNpcTemplates)
            {
                NpcTemplate.UsedSubTemplatesOnGetParts.Clear();

                var parts = template.GetListOfPartsToApply();

                foreach (var traderSettings in parts.Item1.OfType<TraderSettings>())
                {
                    count += IncreaseTraderInventory(traderSettings);
                }
            }

            Debug.Log($"[BringMoreDamnit]: Processed {count} deliveries.");
        }

        private int IncreaseTraderInventory(TraderSettings traderSettings)
        {
            var count = 0;
            foreach (var category in traderSettings.deliveriesCategories)
            {
                foreach (var delivery in category.deliveries)
                {
                    delivery.minCount *= 10;
                    delivery.maxCount *= 10;
                    delivery.appearingChance = Math.Max(delivery.appearingChance + (delivery.appearingChance * .5f), 1f);
                    count++;
                }
            }
            return count;
        }

        private void ApplyPatches()
        {
            var harmony = new Harmony("net.robophreddev.PotionCraft.BringMoreDamnit");
            harmony.PatchAll();
        }
    }
}