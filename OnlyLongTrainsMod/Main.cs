using System;
using System.Collections;
using System.Reflection;
using UnityModManagerNet;
using Harmony12;
using UnityEngine;

namespace OnlyLongTrainsMod
{
    public class Main
    {
        static bool Load(UnityModManager.ModEntry modEntry)
        {
            var harmony = HarmonyInstance.Create(modEntry.Info.Id);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            // Something
            return true; // If false the mod will show an error.
        }
    }

    [HarmonyPatch(typeof(StationsJobLicenseUpdater), "SetStationRulesetLimits")]
    class StationsJobLicenseUpdater_SetStationRulesetLimits_Patch
    {
        static void Postfix(StationProceduralJobsRuleset[] ___stationsRuleset, bool maxCarsLicenseAcquired)
        {
            if (!maxCarsLicenseAcquired)
            {
                return;
            }

            for (int index = 0; index < ___stationsRuleset.Length; ++index)
            {
                ___stationsRuleset[index].minNumberOfCarsPerJob = 6;
                ___stationsRuleset[index].maxNumberOfCarsPerJob = 10;
            }
        }
    }
}