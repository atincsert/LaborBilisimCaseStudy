using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMover : MonoBehaviour
{
    [SerializeField] float cruiseSpeed = 1f;

    private void Update()
    {
        Forward();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<Rails>()) return;
        else
        {
            var rail = other.gameObject;
            transform.forward = rail.transform.forward;
        }
    }

    private void Forward()
    {
        transform.Translate(Vector3.forward * cruiseSpeed * Time.deltaTime);
    }

    //private void SetTrainColor(Trains color)
    //{
    //    currentTrainColor = Trains.white;
    //}

    //private Trains GetTrainColor()
    //{
    //    return currentTrainColor;
    //}

    //[SerializeField] List<Rails> moveableRails = new List<Rails>();
    //[SerializeField] float cruiseSpeed = 1f;
    //[SerializeField] GameObject[] trains;

    //private Vector3 startPos;
    //private StationTypes types;


    //private void Start()
    //{
    //    LookForNewRail();
    //    ReturnToStart();

    //    startPos = transform.position;
    //    StartCoroutine(FollowRail());
    //}

    //IEnumerator FollowRail()
    //{
    //    foreach (Rails rail in moveableRails)
    //    {
    //        startPos = transform.position;
    //        Vector3 endPos = new Vector3(rail.transform.position.x, transform.position.y, rail.transform.position.z);
    //        float moveFactor = 0f;
    //        transform.LookAt(endPos);

    //        while (moveFactor < 1f)
    //        {                
    //            moveFactor += Time.deltaTime * cruiseSpeed;
    //            if (endPos == null) LookForNewRail();
    //            transform.position = Vector3.Lerp(startPos, endPos, moveFactor);
    //            yield return new WaitForEndOfFrame();
    //        }           
    //    }
    //}

    //private void ReturnToStart()
    //{
    //    transform.position = moveableRails[0].transform.position;
    //}

    //private void OnTriggerEnter(Collider other)
    //{        
    //    transform.position = startPos;        
    //}

    //private void LookForNewRail()
    //{
    //    moveableRails.Clear();

    //    // Looking for children of the rail parent and adding them to the list of moveableRails
    //    GameObject rail = GameObject.FindGameObjectWithTag("Rail");

    //    foreach (Transform rails in rail.transform)
    //    {
    //        moveableRails.Add(rails.GetComponent<Rails>());
    //    }

    //}
}
