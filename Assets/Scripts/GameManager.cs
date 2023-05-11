using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private const string AnimalLocation = "Animals/";

    [SerializeField] private Animal animalPrefab;
    [SerializeField] private InputField inputField;
    
    public event Action OnGiveLeaves;
    public event Action OnGiveMeat;
    public event Action OnPerformTrick;
    public event Action<string> OnSayHello;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnAnimals();
    }

    private void SpawnAnimals()
    {
        foreach (AnimalData animalData in GetAnimalDatas())
        {
            Animal animal = Instantiate(animalPrefab, transform);
            animal.SetAnimalData(animalData);
        }
    }
    
    /// <summary>
    /// Gets all AnimalData from the Resources folder
    /// </summary>
    /// <returns>Array containing each animal data in resources folder</returns>
    private AnimalData[] GetAnimalDatas()
    {
        AnimalData[] animalDatas = Resources.LoadAll<AnimalData>(AnimalLocation);
        return animalDatas;
    }
    
    public void OnSayHelloClicked()
    {
        SayHello(inputField.text);
    }
    
    public void GiveLeaves()
    {
        OnGiveLeaves?.Invoke();
    }
    
    public void GiveMeat()
    {
        OnGiveMeat?.Invoke();
    }
    
    public void PerformTrick()
    {
        OnPerformTrick?.Invoke();
    }
    
    public void SayHello(string _name)
    {
        OnSayHello?.Invoke(_name);
    }
}