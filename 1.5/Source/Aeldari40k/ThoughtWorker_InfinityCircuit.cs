﻿using RimWorld;
using Verse;

namespace Aeldari40k
{
    public class ThoughtWorker_InfinityCircuit : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            Map playerHome = Find.AnyPlayerHomeMap;
            if (playerHome.listerBuildings.ColonistsHaveBuilding(Aeldari40kDefOf.BEWH_InfinityCircuit))
            {
                return ThoughtState.ActiveAtStage(1);
            }
            return ThoughtState.ActiveAtStage(0);
        }

        public override float MoodMultiplier(Pawn p)
        {
            Map playerHome = Find.AnyPlayerHomeMap;
            float mult = -1;
            if (playerHome.listerBuildings.ColonistsHaveBuilding(Aeldari40kDefOf.BEWH_InfinityCircuit))
            {
                foreach (Building building in playerHome.listerBuildings.AllBuildingsColonistOfDef(Aeldari40kDefOf.BEWH_InfinityCircuit))
                {
                    if (building is InfinityCircuitBuilding infBuild)
                    {
                        mult = infBuild.SoulAmount.Count;
                    }
                }
            }
                return mult;
        }

    }
}