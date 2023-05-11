using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [SerializeField] private GameObject Balloon;
    [SerializeField] private Text text;
    [SerializeField] private Image image;

    private AnimalData animalData;

    public void SetAnimalData(AnimalData _animalData)
    {
        if(_animalData == null)
        {
            Debug.LogError("AnimalData is null");
            return;
        }
        
        animalData = _animalData;
        
        gameObject.name = animalData.name;
        image.sprite = animalData.image;

        SetListeners();
    }

    /// <summary>
    /// Set listeners for events that this animal can respond to
    /// </summary>
    private void SetListeners()
    {
        GameManager.Instance.OnSayHello += SayHello;
        
        if (animalData.canDoTrick)
        {
            GameManager.Instance.OnPerformTrick += PerformTrick;
        }
        
        if(animalData.creatureType == CreatureType.Carnivore || animalData.creatureType == CreatureType.Omnivore)
        {
            GameManager.Instance.OnGiveMeat += Eat;
        }
        if(animalData.creatureType == CreatureType.Herbivore || animalData.creatureType == CreatureType.Omnivore)
        {
            GameManager.Instance.OnGiveLeaves += Eat;
        }
    }
    
    private void Eat()
    {
        text.text = animalData.eatingText;
        Balloon.SetActive(true);
    }
    
    private void SayHello(string _name)
    {
        if (_name == name || string.IsNullOrEmpty(_name))
        {
            text.text = animalData.helloText;
            Balloon.SetActive(true);
        }
    }
    
    private void PerformTrick()
    {
        StartCoroutine(DoTrick());
    }
    
    IEnumerator DoTrick()
    {
        for (int i = 0; i < 360; i++)
        {
            transform.localRotation = Quaternion.Euler(i, 0, 0);
            yield return new WaitForEndOfFrame();
        }
    }
    
    private void OnDisable()
    {
        GameManager.Instance.OnSayHello -= SayHello;
        
        if(animalData.canDoTrick)
        {
            GameManager.Instance.OnPerformTrick -= PerformTrick;
        }
        
        if(animalData.creatureType == CreatureType.Carnivore || animalData.creatureType == CreatureType.Omnivore)
        {
            GameManager.Instance.OnGiveMeat -= Eat;
        }
        if(animalData.creatureType == CreatureType.Herbivore || animalData.creatureType == CreatureType.Omnivore)
        {
            GameManager.Instance.OnGiveLeaves -= Eat;
        }
    }
}