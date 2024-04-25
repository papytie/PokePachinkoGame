using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

[CreateAssetMenu(fileName = "NewData", menuName = "Data/NewData", order = 1)]
public class PokemonData : ScriptableObject
{
    public int pokedexNumber;
    public string pokedexName;
    public string firstType;
    public string secondType;
    public Sprite portrait;
    public Sprite icon;
    public AudioClip nameAnnounce;
    public AudioClip cry;
}

public class PokedexData : MonoBehaviour
{
    public static List<PokemonData> profilesList = new();
    List<Sprite> portraitsList = new();
    List<Sprite> iconsList = new();
    List<AudioClip> announcerList = new();
    List<AudioClip> criesList = new();

    private void Awake()
    {
        portraitsList = new List<Sprite>(Resources.LoadAll<Sprite>(GameData.POKEMONS_PORTRAITS));
        iconsList = new List<Sprite>(Resources.LoadAll<Sprite>(GameData.POKEMONS_ICONS));
        announcerList = new List<AudioClip>(Resources.LoadAll<AudioClip>(GameData.POKEMONS_NAMES));
        criesList = new List<AudioClip>(Resources.LoadAll<AudioClip>(GameData.POKEMONS_CRIES));
    }

    void Start()
    {
        LoadDataFromCSV();
    }

    void LoadDataFromCSV()
    {
        if (File.Exists(GameData.POKEMONS_CSV))
        {
            string[] csvLines = File.ReadAllLines(GameData.POKEMONS_CSV);

            foreach (string line in csvLines)
            {
                string[] values = line.Split(',');

                if (values.Length >= 4) // Vérifie si la ligne contient au moins 2 valeurs (variable1 et variable2)
                {
                    PokemonData dataObject = ScriptableObject.CreateInstance<PokemonData>();
                    dataObject.pokedexNumber = int.Parse(values[0]);
                    dataObject.pokedexName = values[1];
                    dataObject.firstType = values[2];
                    dataObject.secondType = values[3];
                    dataObject.portrait = portraitsList[int.Parse(values[0])-1];
                    dataObject.icon = iconsList[int.Parse(values[0])-1];
                    dataObject.nameAnnounce = announcerList[int.Parse(values[0]) - 1];
                    dataObject.cry = criesList[int.Parse(values[0]) - 1];
                    profilesList.Add(dataObject);
                }
            }
        }
        else
        {
            Debug.LogError("Le fichier CSV n'existe pas !");
        }
    }
}
