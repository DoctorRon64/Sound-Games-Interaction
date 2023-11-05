using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private List<FauxCreatuerBody> creatuerBodies;
    private List<GameObject> currentAnimals;
    private List<GameObject> currentImposters;

    public int capturedAnimals = 0;

    [SerializeField] private float batchAttractionDistance = 10.0f;

    void Start()
    {
        currentAnimals = new List<GameObject>();
        currentImposters = new List<GameObject>();
        creatuerBodies = new List<FauxCreatuerBody>();

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

            GameObject _newAnimal = Instantiate(_animalPrefab, _randomPosition, Quaternion.identity, animalParent);
            Animal _animalScript = _newAnimal.GetComponent<Animal>();
            FauxCreatuerBody _animalGravityScript = _newAnimal.GetComponent<FauxCreatuerBody>();
            creatuerBodies.Add(_animalGravityScript);

            _animalGravityScript.GetAttractor(earth.GetComponent<FauxGravityAttractor>());
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

            GameObject _newImposter = Instantiate(_imposterPrefab, _randomPosition, Quaternion.identity, imposterParent);
            Imposter _imposterScript = _newImposter.GetComponent<Imposter>();
            FauxCreatuerBody _imposterGravityScript = _newImposter.GetComponent<FauxCreatuerBody>();
            creatuerBodies.Add(_imposterGravityScript);

            _imposterGravityScript.GetAttractor(earth.GetComponent<FauxGravityAttractor>());
            _imposterScript.Setup(this);
            currentImposters.Add(_newImposter);
        }
    }

    public void AnimalCaptured()
    {
        capturedAnimals++;

        float vectorFactor = capturedAnimals * scaleFactor;
        earth.transform.localScale -= new Vector3(vectorFactor, vectorFactor, vectorFactor);

        AttractCreaturesBatched();
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

    private void AttractCreaturesBatched()
    {
        foreach (var creatureBody in creatuerBodies)
        {
            if (Vector3.Distance(creatureBody.transform.position, earth.transform.position) < batchAttractionDistance)
            {
                creatureBody.Attract();
            }
        }
    }
}
