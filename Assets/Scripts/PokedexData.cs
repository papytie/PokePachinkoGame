using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "NewData", menuName = "Data/NewData", order = 1)]
public class PokemonData : ScriptableObject
{
    public int pokedexNumber;
    public string pokedexName;
    public string firstType;
    public string secondType;
    public string currentForm;
    public string previousForm;
    public string nextForm;
    public string habitat;
    public int rarityLevel;
    public Sprite portrait;
    public Sprite icon;
    public AudioClip nameAnnounce;
    public AudioClip cry;
}

public class PokedexData : Singleton<PokedexData>
{
    public List<PokemonData> PokemonDataList => profilesList;
    public List<PokemonData> GrasslandList => grasslandList;
    public List<PokemonData> ForestList => forestList;
    public List<PokemonData> SeaList => seaList;
    public List<PokemonData> MountainList => mountainList;
    public List<PokemonData> UrbanList => urbanList;
    
    public Dictionary<int, PokemonData> globalLootTable = new();
    public Dictionary<int, PokemonData> grasslandLootTable = new();
    public Dictionary<int, PokemonData> forestLootTable = new();
    public Dictionary<int, PokemonData> watersEdgeLootTable = new();
    public Dictionary<int, PokemonData> seaLootTable = new();
    public Dictionary<int, PokemonData> caveLootTable = new();
    public Dictionary<int, PokemonData> mountainLootTable = new();
    public Dictionary<int, PokemonData> roughTerrainLootTable = new();
    public Dictionary<int, PokemonData> urbanLootTable = new();
    public Dictionary<int, PokemonData> rareLootTable = new();

    public List<PokemonData> profilesList = new();
    public List<PokemonData> grasslandList = new();
    public List<PokemonData> forestList = new();
    public List<PokemonData> seaList = new();
    public List<PokemonData> mountainList = new();
    public List<PokemonData> urbanList = new();
    //public List<List<PokemonData>> habitatList = new();
    public List<Sprite> portraitsList = new();
    public List<Sprite> iconsList = new();
    public List<AudioClip> announcerList = new();
    public List<AudioClip> criesList = new();

    [Header("RarityLevel Weight")]
    int rarity1 = 10;
    int rarity2 = 9;
    int rarity3 = 8;
    int rarity4 = 7;
    int rarity5 = 6;
    int rarity6 = 5;
    int rarity7 = 4;
    int rarity8 = 3;
    int rarity9 = 2;
    int rarity10 = 1;

    protected override void Awake()
    {
        base.Awake();
        portraitsList = new List<Sprite>(Resources.LoadAll<Sprite>(GameData.POKEMONS_PORTRAITS));
        iconsList = new List<Sprite>(Resources.LoadAll<Sprite>(GameData.POKEMONS_ICONS));
        announcerList = new List<AudioClip>(Resources.LoadAll<AudioClip>(GameData.POKEMONS_NAMES));
        criesList = new List<AudioClip>(Resources.LoadAll<AudioClip>(GameData.POKEMONS_CRIES));
    }

    public void InitPokedex()
    {
        LoadDataFromCSV();
        globalLootTable = CreateLootTable(profilesList);
        CreateHabitatLists();
        grasslandLootTable = CreateLootTable(grasslandList);
        forestLootTable = CreateLootTable(forestList);
        seaLootTable = CreateLootTable(seaList);
        mountainLootTable = CreateLootTable(mountainList);
        urbanLootTable = CreateLootTable(urbanList);

    }

    void LoadDataFromCSV()
    {
        if (File.Exists(GameData.POKEMONS_CSV))
        {
            string[] csvLines = File.ReadAllLines(GameData.POKEMONS_CSV);

            foreach (string line in csvLines)
            {
                string[] values = line.Split(',');

                if (values.Length >= 9)
                {
                    PokemonData dataObject = ScriptableObject.CreateInstance<PokemonData>(); //Create empty Scriptable Object PokemonData

                    int curentIndex = int.Parse(values[0])-1;

                    //Fill all fields with correct values from lists
                    //ALL THE LISTS MUST BE IN THE SAME ORDER AS THE .CSV FILE !
                    dataObject.pokedexNumber = int.Parse(values[0]);
                    dataObject.pokedexName = values[1];
                    dataObject.firstType = values[2];
                    dataObject.secondType = values[3];
                    dataObject.currentForm = values[4];
                    dataObject.previousForm = values[5];
                    dataObject.nextForm = values[6];
                    dataObject.habitat = values[7];
                    dataObject.rarityLevel = int.Parse(values[8]);
                    dataObject.portrait = portraitsList[curentIndex];
                    dataObject.icon = iconsList[curentIndex];
                    dataObject.nameAnnounce = announcerList[curentIndex];
                    dataObject.cry = criesList[curentIndex];
                    profilesList.Add(dataObject);
                }
            }
        }
        else
        {
            Debug.LogWarning("Current path do not find a valid .csv file!");
        }
    }

    public PokemonData GetRandomRaw()
    {
        return PokemonDataList[Random.Range(0, PokemonDataList.Count)];
    }

    public PokemonData GetRandomInTable(Dictionary<int, PokemonData> lootTable)
    {
        return lootTable[Random.Range(0, lootTable.Count)];
    }

    public PokemonData GetTarget(string targetName)
    {
        foreach (PokemonData dataProfile in PokemonDataList)
        {
            if (dataProfile.pokedexName == targetName)
                return dataProfile;
        }
        Debug.Log("No data profile found with this name");
        return null;
    }

    void CreateHabitatLists()
    {
        foreach(PokemonData dataProfile in PokemonDataList)
        {
            switch(dataProfile.habitat)
            {
                case "Grassland" :
                    grasslandList.Add(dataProfile);
                    break;
                case "Forest" :
                    forestList.Add(dataProfile);
                    break;
                case "Sea":
                    seaList.Add(dataProfile);
                    break;
                case "Mountain":
                    mountainList.Add(dataProfile);
                    break;
                case "Urban":
                    urbanList.Add(dataProfile);
                    break;
            }
        }
    }

    Dictionary<int, PokemonData> CreateLootTable(List<PokemonData> list)
    {
        Dictionary<int, PokemonData> newLootTable = new();
        int currentIndex = 0;
        foreach (PokemonData dataProfile in list)
        {
            for (int i = 0; i < GetRarityWeight(dataProfile.rarityLevel); i++)
            {
                newLootTable.Add(currentIndex, dataProfile);
                currentIndex++;
            }
        }
        return newLootTable;
    }

    int GetRarityWeight(int rarityLevel)
    {
        return (rarityLevel) switch
        {
            1 => rarity1,
            2 => rarity2,
            3 => rarity3,
            4 => rarity4,
            5 => rarity5,
            6 => rarity6,
            7 => rarity7,
            8 => rarity8,
            9 => rarity9,
            10 => rarity10,
            _ => 0,
        };
    }
}

public enum HabitatType
{
    Grassland = 0,
    Forest = 1,
    Sea = 2,
    Mountain = 3,
    Urban = 4,
}