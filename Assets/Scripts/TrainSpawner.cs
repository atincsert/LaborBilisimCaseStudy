using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpawner : MonoBehaviour
{
    [SerializeField] Train[] trains;
    [SerializeField] int numberOfTrains;
    [SerializeField] float newTrainWaitTime = 5f;
    private List<_Color> stationTypesInScene;
    private int currentTrainIndex = 0;
    private Train currentTrain;

    private void Awake()
    {
        currentTrain = FindObjectOfType<Train>();
    }
    private void Start()
    {
        StartCoroutine(SpawnTrain());
        foreach (Station station in FindObjectsOfType<Station>())
        {
            stationTypesInScene.Add(station.stationColor);
        }
    }

    IEnumerator SpawnTrain()
    {
        foreach (Train train in trains)
        {
            Instantiate(train, transform.position, Quaternion.Euler(0, 180, 0));
            if (currentTrainIndex < trains.Length)
            {
                currentTrainIndex += 1;
                currentTrain = trains[currentTrainIndex];
            }
            yield return new WaitForSeconds(5f);
        }
        //for (int i = 0; i < numberOfTrains; i++)
        //{
        //    var trainInstance = Instantiate<Train>(trains[0], transform.position, Quaternion.identity);

        //    _Color randomColor = stationTypesInScene[Random.Range(0, stationTypesInScene.Count)];

        //    trainInstance.Init(randomColor);
        //}
    }
}
