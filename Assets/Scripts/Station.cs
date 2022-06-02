using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Station : MonoBehaviour
{
    [SerializeField] public _Color stationColor;
    [Tooltip("The number of trains that must match with the stations colors in the scene in order to progress to the next level")]
    [SerializeField] private int numberOfCorrectEntryNecessary = 2;

    private int currentCorrectEntry = 0;
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        if (other.TryGetComponent<Train>(out Train train))
        {
            if (stationColor == train.TrainColor)
            {
                if (currentCorrectEntry == numberOfCorrectEntryNecessary)
                {
                    Debug.Log("entry numbers satisfied");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                if (currentCorrectEntry < numberOfCorrectEntryNecessary)
                {
                    Debug.Log("entry + 1");
                    currentCorrectEntry += 1;
                }

                if (SceneManager.sceneCount > 4)
                    SceneManager.LoadScene(0);

                // Increment Points by 1
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                // Decrease Points by 1
            }
        }
    }
}
