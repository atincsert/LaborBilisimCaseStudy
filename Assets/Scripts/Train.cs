using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private _Color trainColor;

    public _Color TrainColor
    {
        get
        {
            return trainColor;
        }

        set
        {
            trainColor = value;
        }
    }

    public void Init(_Color stationType)
    {
        this.trainColor = stationType;
    }
}
