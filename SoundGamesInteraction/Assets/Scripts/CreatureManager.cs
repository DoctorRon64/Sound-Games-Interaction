using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatureManager : MonoBehaviour
{
    [Header("Earth")]
    [SerializeField] private GameObject earth;
    [SerializeField] private float radius;
    [SerializeField] private float scaleFactor;
    [SerializeField] private float minDistanceBetweenObjects;

    [Header("CreaturePrefabs")]
    [SerializeField] private Transform animalParent;
    [SerializeField] private Transform imposterParent;
    [SerializeField] private List<GameObject> animalPrefabs;
    [SerializeField] private List<GameObject> imposterPrefabs;

    [SerializeField] private AudioSource AlmostThere;

    private List<GameObject> currentAnimals;
    private List<GameObject> currentImposters;

    public int capturedAnimals = 0;

    void Start()
    {
        currentAnimals = new List<GameObject>();
        currentImposters = new List<GameObject>();

        SpawnAnimals();
        SpawnImposters();
    }

    private void Update()
    {
        
    }

    private void SpawnAnimals()
    {
        foreach (var _animalPrefab in animalPrefabs)
        {
            Vector3 _randomPosition;
            do
            {
                _randomPosition = earth.transform.position + Random.onUnitSphere * radius;
            } while (IsPositionTooClose(_randomPosition, currentAnimals, minDistanceBetweenObjects));

            Quaternion _rotation = Quaternion.LookRotation(_randomPosition - earth.transform.position, Vector3.up);
            GameObject _newAnimal = Instantiate(_animalPrefab, _randomPosition, _rotation, animalParent);
            Animal _animalScript = _newAnimal.GetComponent<Animal>();
            _animalScript.Setup(this);

            currentAnimals.Add(_newAnimal);
        }
    }

    private void SpawnImposters()
    {
        foreach (var _imposterPrefab in imposterPrefabs)
        {
            Vector3 _randomPosition;
            do
            {
                _randomPosition = earth.transform.position + Random.onUnitSphere * radius;
            } while (IsPositionTooClose(_randomPosition, currentImposters, minDistanceBetweenObjects));

            Quaternion _rotation = Quaternion.LookRotation(_randomPosition - earth.transform.position, Vector3.up);
            
            GameObject _newImposter = Instantiate(_imposterPrefab, _randomPosition, _rotation, imposterParent);
            Imposter _imposterScript = _newImposter.GetComponent<Imposter>();
            _imposterScript.Setup(this);
            currentImposters.Add(_newImposter);
        }
    }

    public void AnimalCaptured()
    {
        capturedAnimals++;

        float vectorFactor = capturedAnimals * scaleFactor;
        earth.transform.localScale -= new Vector3(vectorFactor, vectorFactor, vectorFactor);


        if (capturedAnimals == animalPrefabs.Count - 1)
        {
            AlmostThere.Play();
        } 
        else if (capturedAnimals == animalPrefabs.Count)
        {
            SceneManager.LoadScene("Outro");
        }
    }

    private bool IsPositionTooClose(Vector3 position, List<GameObject> objects, float minDistance)
    {
        foreach (var obj in objects)
        {
            if (Vector3.Distance(position, obj.transform.position) < minDistance)
            {
                return true;
            }
        }
        return false;
    }
}
