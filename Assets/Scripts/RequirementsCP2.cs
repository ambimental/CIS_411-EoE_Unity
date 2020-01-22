using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementsCP2 : MonoBehaviour
{

    public delegate void Del();

    // Use this for initialization
    void Start()
    {
    }

    public bool requirementCheck(Card card)
    {
        bool works = false;

        List<string> reqs = new List<string>();
        foreach (string x in card.ReqID)
        {
            string reqID = x;
            reqs.Add(reqID);
        }

        foreach (string x in reqs)
        {
            Type type = typeof(ReqsCP2);
            ReqsCP2 ClassObject = new ReqsCP2();
            MethodInfo method = type.GetMethod(x);
            method.Invoke(ClassObject, null);

            if (method.Invoke(ClassObject, null).ToString() == "False")
            {
                works = false;
                break;
            }
            else works = true;
        }

        if (works == true) //returns true or false based on the reqs
            return works;
        else return works;
    }
}

public class ReqsCP2
{
    public bool r001() //5 forest cards, grassland, arid, or Sub-Zero region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2SubZeroCount;

        if (count >= 5)
            return true;
        else return false;
    }

    public bool r002() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r003() //3 plants type cards must be placed
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 3)
            return true;
        else return false;
    }
    public bool r004() //2 invertebrate type cards must be placed
    {
        if (GameManager.Instance.InvertebratePlacementCP2.Count >= 2)
            return true;
        else return false;
    }
    public bool r005() //2 animal type cards must be placed
    {
        if (GameManager.Instance.AnimalPlacementCP2.Count >= 2)
            return true;
        else return false;
    }
    public bool r006() //any 1 region card must be placed
    {
        if (GameManager.Instance.RegionPlacementCP2.Count >= 1)
            return true;
        else if (GameManager.Instance.SpecialRegionPlacementCP2.Count > 0)
            return true;
        else return false;
    }
    public bool r007() //1 species in play or in the discard pile
    {
        if (GameManager.Instance.AnimalPlacementCP2.Count > 0 || GameManager.Instance.PlantPlacementCP2.Count > 0 || GameManager.Instance.InvertebratePlacementCP2.Count > 0 || GameManager.Instance.HumanPlacementCP2.Count > 0)
            return true;

        for (int i = 0; i < GameManager.Instance.DiscardPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.DiscardPlacementCP2[i].CardType == "Human" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Animal" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Plant" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Invertebrate")
                return true;
        }

        return false;
    }
    public bool r008() //2 of any region
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r009() //2 of any plants
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 2)
            return true;
        else return false;
    }
    public bool r010() //1 invertebrate or animal card
    {
        if (GameManager.Instance.InvertebratePlacementCP2.Count >= 1 || GameManager.Instance.AnimalPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r011() //1 forest or grassland region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r012() //1 canopy or understory plant from the division of Coniferophyta or the magnophy one
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if ((GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy" || GameManager.Instance.PlantPlacementCP2[i].PlantType == "Understory") && (GameManager.Instance.PlantPlacementCP2[i].Division == "Magnoliophyta" || GameManager.Instance.PlantPlacementCP2[i].Division == "Coniferophyta"))
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r013() //3 forest regions
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 3)
            return true;
        else return false;
    }
    public bool r014() //1 canopy plant
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r015() //1 tiny or small invertebrate
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r016() //2 tiny or small animals
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.AnimalPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r017() //1 forest or grassland region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r018() //1 canopy or understory plant from the division of Co
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if ((GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy" || GameManager.Instance.PlantPlacementCP2[i].PlantType == "Understory") && (GameManager.Instance.PlantPlacementCP2[i].Division == "Magnoliophyta" || GameManager.Instance.PlantPlacementCP2[i].Division == "Coniferophyta"))
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r019() //1 forest region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r020() //3 of any region EXCEPT salt water region
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 3)
            return true;
        else return false;
    }
    public bool r021() //1 tiny or small invertebrate
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r022() //2 tiny or small animals
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.AnimalPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r023() //1 forest region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r024() //1 canopy or understory plant from the division of Co
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if ((GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy" || GameManager.Instance.PlantPlacementCP2[i].PlantType == "Understory") && (GameManager.Instance.PlantPlacementCP2[i].Division == "Magnoliophyta" || GameManager.Instance.PlantPlacementCP2[i].Division == "Coniferophyta"))
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r025() //1 forest or arid region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2AridCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r026() //1 Canopy plant
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++) //goes through regions
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r027() //1 invertebrate
    {
        if (GameManager.Instance.InvertebratePlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r028() //1 tiny or small animal
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.AnimalPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r029() //1 forest or grassland region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r030() //1 canopy or understory plant from the divison of Co
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if ((GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy" || GameManager.Instance.PlantPlacementCP2[i].PlantType == "Understory") && (GameManager.Instance.PlantPlacementCP2[i].Division == "Magnoliophyta" || GameManager.Instance.PlantPlacementCP2[i].Division == "Coniferophyta"))
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r031() //1 forest, arid, sub-zero or grassland region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2SubZeroCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r032() //1 any species in play or the discard pile
    {
        if (GameManager.Instance.AnimalPlacementCP2.Count > 0 || GameManager.Instance.PlantPlacementCP2.Count > 0 || GameManager.Instance.InvertebratePlacementCP2.Count > 0 || GameManager.Instance.HumanPlacementCP2.Count > 0)
            return true;

        for (int i = 0; i < GameManager.Instance.DiscardPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.DiscardPlacementCP2[i].CardType == "Human" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Animal" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Plant" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Invertebrate")
                return true;
        }

        return false;
    }
    public bool r033() //2 of any forest or grassland regions
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r034() //3 plants
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 3)
            return true;
        else return false;
    }
    public bool r035() //2 of any forest or grassland regions
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r036() //3 plants
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 3)
            return true;
        else return false;
    }
    public bool r037() //5 any regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 5)
            return true;
        else return false;
    }
    public bool r038() //1 forest region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r039() //1 canopy or under story plant from the division
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if ((GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy" || GameManager.Instance.PlantPlacementCP2[i].PlantType == "Understory") && (GameManager.Instance.PlantPlacementCP2[i].Division == "Magnoliophyta"))
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r040() //1 forest region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r041() //1 canopy plant
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++) //goes through regions
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r042() //1 any region except salt water regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r043() //1 plant in division Magnoliophyla - Flowering Plants
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.PlantPlacementCP2[i].Division == "Magnoliophyta")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r044() //1 any region except sub-zero and salt water regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r045() //1 plant
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r046() //1 any region
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r047() //1 species in play or in the discard pile
    {
        if (GameManager.Instance.AnimalPlacementCP2.Count > 0 || GameManager.Instance.PlantPlacementCP2.Count > 0 || GameManager.Instance.InvertebratePlacementCP2.Count > 0 || GameManager.Instance.HumanPlacementCP2.Count > 0)
            return true;

        for (int i = 0; i < GameManager.Instance.DiscardPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.DiscardPlacementCP2[i].CardType == "Human" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Animal" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Plant" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Invertebrate")
                return true;
        }

        return false;
    }
    public bool r048() //1 any region except sub zero regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r049() //1 plant in the division magnoliophyta - flower plants
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.PlantPlacementCP2[i].Division == "Magnoliophyta")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r050() //1 any region except sub zerio regions 
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r051() //1 plant in the division magnoliophyta - flowering pl
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.PlantPlacementCP2[i].Division == "Magnoliophyta")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r052() //1 forest region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r053() //1 canopy or understory plant
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++) //goes through regions
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy" || GameManager.Instance.PlantPlacementCP2[i].PlantType == "Understory")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r054() //1 any region excet sub zero and salt ater regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r055() //1 plant in the deivison magnoliophyta
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.PlantPlacementCP2[i].Division == "Magnoliophyta")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r056() //1 forest region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r057() //2 forest regions
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r058() //1 canopy plant
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++) //goes through regions
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r059() //1 groundcover plant
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++) //goes through regions
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "Groundcover")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r060() //1 mountain range
    {
        int count = 0;

        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r061() //1 forest region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r062() //1 forest region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r063() //1 canopy plant
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++) //goes through regions
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r064() //1 mountain range
    {
        int count = 0;

        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r065() //1 any region
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r066() //2 forest regions
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r067() //2 canopy plants
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++) //goes through regions
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy")
                count++;
        }

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r068() //1 mycorrhizal fungus
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].CardName.Contains("Mycorrhizal"))
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r069() //1 forest region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r070() //1 mountain range
    {
        int count = 0;

        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r071() //1 forest region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r072() //1 canopy plant
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++) //goes through regions
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r073() //1 mountain range
    {
        int count = 0;

        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r074() //1 forest region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r075() //1 canopy plant
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++) //goes through regions
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r076() //1 forest region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r077() //1 canopy plant
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++) //goes through regions
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r078() //2 groundcover plants
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++) //goes through regions
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "Groundcover")
                count++;
        }

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r079() //1 mycorrhizal fungus
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].CardName.Contains("Mycorrhizal"))
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r080() //1 forest region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r081() //1 forest or grassland or sub-zero region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2SubZeroCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r082() //1 forest region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r083() //1 forest region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r084() //1 canopy plant
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++) //goes through regions
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r085() //3 any regions except saltwater and sub zero
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 3)
            return true;
        else return false;
    }
    public bool r086() //2 invertebrates
    {
        if (GameManager.Instance.InvertebratePlacementCP2.Count >= 2)
            return true;
        else return false;
    }
    public bool r087() //2 tiny or small animals
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r088() //1 any region
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r089() //1 human
    {
        if (GameManager.Instance.HumanPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r090() //1 any region
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r091() //1 human
    {
        if (GameManager.Instance.HumanPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r092() //1 plant
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r093() //1 invertebrate
    {
        if (GameManager.Instance.InvertebratePlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r094() //1 any region
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r095() //1 human
    {
        if (GameManager.Instance.HumanPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r096() //1 forest or grassland region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;

        if (count >= 1)
            return true;
        else return false;
    }

    public bool r097() //1 groundcover plant
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++) //goes through regions
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "GroundCover")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r098() //1 forest or grassland region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r099() //2 tiny or small animals
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.AnimalPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r100() //5 land regions (forest, grassland, arid, sub zero)
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2SubZeroCount;

        if (count >= 5)
            return true;
        else return false;
    }
    public bool r101() //2 water regions
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r102() //1 invertebrate
    {
        if (GameManager.Instance.InvertebratePlacementCP2.Count >= 1)
            return true;
        return false;
    }
    public bool r103() //2 tiny, small, or medium animals
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.AnimalPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Small" || GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Medium")
                count++;
        }

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r104() //1 cliff or canyon
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.ConditionPlacementCP2.Count; i++) //goes through regions
        {
            if (GameManager.Instance.ConditionPlacementCP2[i].CardName.Contains("Cliff"))
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r105() //1 grassland region
    {
        int count = 0;

        count += GameManager.Instance.cp2GrasslandsCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r106() //2 groundcover plants
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++) //goes through regions
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "Groundcover")
                count++;
        }

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r107() //1 grassland region
    {
        int count = 0;

        count += GameManager.Instance.cp2GrasslandsCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r108() //2 any regions except salt water regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r109() //1 tiny, small, or medium invertebrate
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Small" || GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Medium")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r110() //1 tiny or small animal
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.AnimalPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r111() //2 forest, arid, sub-zero or grassland regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2SubZeroCount;

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r112() //1 plant
    {

        if (GameManager.Instance.PlantPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r113() //1 invertebrate
    {
        if (GameManager.Instance.InvertebratePlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r114() //1 tiny or small animal
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.AnimalPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r115() //5 regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 5)
            return true;
        else return false;
    }
    public bool r116() //1 any region except salt water or sub zero regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r117() //1 plant
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r118() //1 any region
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r119() //1 species in play or in the discard pile
    {
        if (GameManager.Instance.AnimalPlacementCP2.Count > 0 || GameManager.Instance.PlantPlacementCP2.Count > 0 || GameManager.Instance.InvertebratePlacementCP2.Count > 0 || GameManager.Instance.HumanPlacementCP2.Count > 0)
            return true;

        for (int i = 0; i < GameManager.Instance.DiscardPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.DiscardPlacementCP2[i].CardType == "Human" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Animal" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Plant" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Invertebrate")
                return true;
        }

        return false;
    }
    public bool r120() // 1 any region except sub zero regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r121() //1 divison magnoliophyta - flowering plants
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.PlantPlacementCP2[i].Division == "Magnoliophyta")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r122() //1 any region
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r123() //1 plant
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r124() //1 forest or grassland region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r125() //1 plant in the diviosn magnioliophytta - flowering plants
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.PlantPlacementCP2[i].Division == "Magnoliophyta")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r126() //1 grassland region
    {
        int count = 0;

        count += GameManager.Instance.cp2GrasslandsCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r127() //1 forest region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r128() //1 any region except salt water and sub zero regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r129() //1 grassland region
    {
        int count = 0;

        count += GameManager.Instance.cp2GrasslandsCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r130() //1 human
    {
        if (GameManager.Instance.HumanPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r131() //1 grassland region
    {
        int count = 0;

        count += GameManager.Instance.cp2GrasslandsCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r132() //1 human
    {
        if (GameManager.Instance.HumanPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r133() //1 grassland region
    {
        int count = 0;

        count += GameManager.Instance.cp2GrasslandsCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r134() //1 human
    {
        if (GameManager.Instance.HumanPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r135() //1 region
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 0)
            return true;
        else return false;
    }
    public bool r136() //1 grassaland region
    {
        int count = 0;

        count += GameManager.Instance.cp2GrasslandsCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r137() //5 running or Standing-Water regions
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 5)
            return true;
        else return false;
    }
    public bool r138() //2 canopy plants
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "Canopy")
                count++;
        }

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r139() //3 animals
    {
        if (GameManager.Instance.AnimalPlacementCP2.Count >= 3)
            return true;
        else return false;
    }
    public bool r140() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r141() //1 plant
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r142() //1 tiny or small invertebrate
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r143() //1 running ro Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r144() //1 any species in play or the discard pile
    {
        if (GameManager.Instance.AnimalPlacementCP2.Count > 0 || GameManager.Instance.PlantPlacementCP2.Count > 0 || GameManager.Instance.InvertebratePlacementCP2.Count > 0 || GameManager.Instance.HumanPlacementCP2.Count > 0)
            return true;

        for (int i = 0; i < GameManager.Instance.DiscardPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.DiscardPlacementCP2[i].CardType == "Human" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Animal" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Plant" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Invertebrate")
                return true;
        }

        return false;
    }
    public bool r145() //1 Running-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r146() //1 plant
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r147() //1 tiny or small aquatic invertebrate
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if ((GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Small") && GameManager.Instance.InvertebratePlacementCP2[i].AnimalEnvironment == "Aquatic")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r148() //1 tiny or small aquatic animal
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.AnimalPlacementCP2.Count; i++)
        {
            if ((GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Small") && GameManager.Instance.AnimalPlacementCP2[i].AnimalEnvironment == "Aquatic")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r149() //1 mountain range
    {
        int count = 0;

        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r150() //1 running or stnading water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r151() // 3 any regions except salt water regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 3)
            return true;
        else return false;
    }
    public bool r152() //1 tiny or small invertebrate
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r153() //1 tiny, small, or medium animal
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.AnimalPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Small" || GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Medium")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r154() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r155() //1 species in play or the discard pile
    {
        if (GameManager.Instance.AnimalPlacementCP2.Count > 0 || GameManager.Instance.PlantPlacementCP2.Count > 0 || GameManager.Instance.InvertebratePlacementCP2.Count > 0 || GameManager.Instance.HumanPlacementCP2.Count > 0)
            return true;

        for (int i = 0; i < GameManager.Instance.DiscardPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.DiscardPlacementCP2[i].CardType == "Human" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Animal" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Plant" || GameManager.Instance.DiscardPlacementCP2[i].CardType == "Invertebrate")
                return true;
        }

        return false;
    }
    public bool r156() //3 running or Standing-Water regions
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 3)
            return true;
        else return false;
    }
    public bool r157() //1 plant
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r158() //2 tiny or small invertebrates
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r159() //1 mountain rainge
    {
        int count = 0;

        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r160() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r161() //2 invertebrates
    {
        if (GameManager.Instance.InvertebratePlacementCP2.Count >= 2)
            return true;
        else return false;
    }
    public bool r162() //1 tiny or small aquatic animals
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.AnimalPlacementCP2.Count; i++)
        {
            if ((GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Small") && GameManager.Instance.AnimalPlacementCP2[i].AnimalEnvironment == "Aquatic")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r163() //5 running or Standing-Water regions
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 5)
            return true;
        else return false;
    }
    public bool r164() //1 aquatic plant
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.PlantPlacementCP2[i].AnimalEnvironment == "Aquatic")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r165() //2 invertebrates
    {
        if (GameManager.Instance.InvertebratePlacementCP2.Count >= 2)
            return true;
        else return false;
    }
    public bool r166() // 3 animals that require a running or Standing-Water Region
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.AnimalPlacementCP2.Count; i++)
        {
            int id = GameManager.Instance.AnimalPlacementCP2[i].ReqID.Count;

            for (int j = 0; j < id; j++) //goes through and checks the requirements of the animals to see if they need running or standing water
            {
                if (GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r002" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r137" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r140" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r143"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r150" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r154" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r156" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r160"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r163" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r166" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r167" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r170"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r172"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r173" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r174" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r176" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r180"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r188" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r189" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r190" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r191"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r192" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r194" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r198" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r199"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r202" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r207" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r235" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r145"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r211"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r218" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r222" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r225" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r229"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r231" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r235")
                {
                    count++;
                    break;
                }
            }
        }

        if (count >= 3)
            return true;
        else return false;
    }
    public bool r167() //3 running or Standing-Water regions
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 3)
            return true;
        else return false;
    }
    public bool r168() //2 invertebrates
    {
        if (GameManager.Instance.InvertebratePlacementCP2.Count >= 2)
            return true;
        else return false;
    }
    public bool r169() //1 tiny or small animal
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.AnimalPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r170() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r171() //1 tiny or small invertebrate
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r172() //3 running or Standing-Water regions
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 3)
            return true;
        else return false;
    }
    public bool r173() //3 species that require running or Standing-Water
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.AnimalPlacementCP2.Count; i++) // I KNOW THIS IS AWFULL TO LOOK AT AND NOT A GOOD WAY TO DO IT AT ALL I JUST HAD TO GET THIS DONE
        {
            int id = GameManager.Instance.AnimalPlacementCP2[i].ReqID.Count;

            for (int j = 0; j < id; j++)
            {
                if (GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r002" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r137" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r140" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r143"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r150" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r154" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r156" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r160"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r163" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r166" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r167" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r170"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r172"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r173" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r174" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r176" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r180"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r188" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r189" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r190" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r191"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r192" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r194" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r198" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r199"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r202" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r207" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r235" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r145"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r211"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r218" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r222" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r225" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r229"
                    || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r231" || GameManager.Instance.AnimalPlacementCP2[i].ReqID[j] == "r235")
                {
                    count++;
                    break;
                }
            }
        }
        for (int i = 0; i < GameManager.Instance.HumanPlacementCP2.Count; i++)
        {
            int id = GameManager.Instance.HumanPlacementCP2[i].ReqID.Count;

            for (int j = 0; j < id; j++)
            {
                if (GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r002" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r137" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r140" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r143"
                    || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r150" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r154" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r156" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r160"
                    || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r163" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r166" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r167" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r170"
                    || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r172"
                    || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r173" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r174" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r176" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r180"
                    || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r188" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r189" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r190" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r191"
                    || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r192" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r194" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r198" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r199"
                    || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r202" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r207" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r235" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r145"
                    || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r211"
                    || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r218" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r222" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r225" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r229"
                    || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r231" || GameManager.Instance.HumanPlacementCP2[i].ReqID[j] == "r235")
                {
                    count++;
                    break;
                }
            }
        }
        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            int id = GameManager.Instance.PlantPlacementCP2[i].ReqID.Count;

            for (int j = 0; j < id; j++)
            {
                if (GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r002" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r137" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r140" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r143"
                    || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r150" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r154" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r156" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r160"
                    || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r163" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r166" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r167" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r170"
                    || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r172"
                    || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r173" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r174" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r176" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r180"
                    || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r188" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r189" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r190" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r191"
                    || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r192" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r194" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r198" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r199"
                    || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r202" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r207" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r235" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r145"
                    || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r211"
                    || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r218" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r222" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r225" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r229"
                    || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r231" || GameManager.Instance.PlantPlacementCP2[i].ReqID[j] == "r235")
                {
                    count++;
                    break;
                }
            }
        }
        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            int id = GameManager.Instance.InvertebratePlacementCP2[i].ReqID.Count;

            for (int j = 0; j < id; j++)
            {
                if (GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r002" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r137" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r140" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r143"
                    || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r150" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r154" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r156" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r160"
                    || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r163" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r166" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r167" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r170"
                    || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r172"
                    || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r173" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r174" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r176" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r180"
                    || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r188" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r189" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r190" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r191"
                    || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r192" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r194" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r198" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r199"
                    || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r202" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r207" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r235" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r145"
                    || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r211"
                    || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r218" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r222" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r225" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r229"
                    || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r231" || GameManager.Instance.InvertebratePlacementCP2[i].ReqID[j] == "r235")
                {
                    count++;
                    break;
                }
            }
        }

        if (count >= 3)
            return true;
        else return false;
    }
    public bool r174() //1 running ro Standing-Water regions
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r175() //1 plant
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r176() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r177() //1 tiny invertebrate
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Tiny")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r178() //1 any region except sub-zero and salt water regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r179() //1 plant
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r180() //1 standing or Running-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r181() //1 plant
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r182() //2 tiny or small invertebrates
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r183() //1 any region
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r184() //1 plant
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r185() //2 tiny or small invertebrates
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r186() //1 any region except sub-zero and salt water regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r187() //1 groundcover plant
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.PlantPlacementCP2[i].PlantType == "Groundcover")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r188() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r189() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r190() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r191() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r192() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r193() //1 any region except salt water regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r194() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r195() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r196() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r197() //1 forest or grassland or sub-zero region
    {
        int count = 0;

        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2SubZeroCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r198() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r199() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r200() //1 human
    {
        if (GameManager.Instance.HumanPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r201() //1 region
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r202() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r203() //1 plant
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r204() //2 tiny or small invertebrates
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r205() //1 grassland region
    {
        int count = 0;

        count += GameManager.Instance.cp2GrasslandsCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r206() //2 tiny or small animals
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.AnimalPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Tiny" || GameManager.Instance.AnimalPlacementCP2[i].AnimalSize == "Small")
                count++;
        }

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r207() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r208() //1 tiny invertebrate
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Tiny")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r209() //1 caves and caverns
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.ConditionPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.ConditionPlacementCP2[i].CardName.Contains("Cave") || GameManager.Instance.RegionPlacementCP2[i].CardName.Contains("Cavern"))
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r210() //5 any regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 5)
            return true;
        else return false;
    }
    public bool r211() //1 Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r212() //4 any additional regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 4)
            return true;
        else return false;
    }
    public bool r213() //1 any region except sub-zero
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r214() //1 plant
    {
        if (GameManager.Instance.PlantPlacementCP2.Count >= 1)
            return true;
        else return false;
    }
    public bool r215() //1 invertebrate in the family: aphididae
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].Family == "Aphididae")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r216() //1 any region except sub-zero regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r217() //1 plant from the family asclepiadaceae?milkweed family
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.PlantPlacementCP2[i].Family == "Asclepiadaceae - Milkweed family")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r218() //1 Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r219() //1 any region
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return true;
    }
    public bool r220() //1 any region
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r221() //1 any region except salt water or sub-zero regions
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r222() //1 Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r223() //1 any region
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r224() //1 tiny invertebrate or microbe
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Tiny")
                count++;
        }
        for (int i = 0; i < GameManager.Instance.MicrobePlacement.Count; i++)
        {
            if (GameManager.Instance.MicrobePlacement[i].AnimalSize == "Tiny")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r225() //2 Standing-Water regions
    {
        int count = 0;

        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r226() //1 spagnum
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.PlantPlacementCP2[i].Genus.Contains("Sphagnum"))
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r227() //1 tiny invertebrate
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Tiny")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r228() //1 peat bog
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.ConditionPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.ConditionPlacementCP2[i].CardName.Contains("Peat-Bog"))
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r229() //1 Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r230() //1 any region
    {
        int count = 0;

        count += GameManager.Instance.cp2AridCount;
        count += GameManager.Instance.cp2ForestCount;
        count += GameManager.Instance.cp2GrasslandsCount;
        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2SaltWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;
        count += GameManager.Instance.cp2SubZeroCount;
        count += GameManager.Instance.cp2MountainRange;

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r231() //2 Standing-Water regions
    {
        int count = 0;

        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 2)
            return true;
        else return false;
    }
    public bool r232() //1 spahgnum
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.PlantPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.PlantPlacementCP2[i].Genus.Contains("Sphagnum"))
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r233() //1 tiny invertebrate
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.InvertebratePlacementCP2.Count; i++)
        {
            if (GameManager.Instance.InvertebratePlacementCP2[i].AnimalSize == "Tiny")
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r234() //1 peat bog
    {
        int count = 0;

        for (int i = 0; i < GameManager.Instance.ConditionPlacementCP2.Count; i++)
        {
            if (GameManager.Instance.ConditionPlacementCP2[i].CardName.Contains("Peat-Bog"))
                count++;
        }

        if (count >= 1)
            return true;
        else return false;
    }
    public bool r235() //1 running or Standing-Water region
    {
        int count = 0;

        count += GameManager.Instance.cp2RunningWaterCount;
        count += GameManager.Instance.cp2StandingWaterCount;

        if (count >= 1)
            return true;
        else return false;
    }

    //REQUIREMENTS R236 - R245 ARE FOR THE MULTIPLAYER CARDS

    public bool r236() //acidic waters
    {
        return false;
    }

    public bool r237() //children at play
    {
        return false;
    }

    public bool r238() //extinction
    {
        return true;
    }

    public bool r239() //isolated ecosystems
    {
        return false;
    }

    public bool r240() //temperature drop
    {
        return false;
    }

    public bool r241() //ideal conditions
    {
        return false;
    }

    public bool r242() //invasive invertebrate species
    {
        return false;
    }

    public bool r243() //web of life
    {
        return false;
    }

    public bool r244() //relocate species
    {
        return false;
    }

    public bool r245() //forest fire
    {
        return false;
    }
}
