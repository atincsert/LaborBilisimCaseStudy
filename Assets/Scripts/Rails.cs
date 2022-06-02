using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rails : MonoBehaviour
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    [SerializeField] private Direction[] directions;

    private int currentDirectionIndex = 0;
    private Direction currentDirection;
    private TrainMover trainMover;
    private void Awake()
    {
        trainMover = FindObjectOfType<TrainMover>();
    }
    private void Start()
    {
        currentDirection = directions[currentDirectionIndex];
        SetDirection();
    }

    private void OnMouseDown()
    {
        if (currentDirectionIndex + 1 < directions.Length)
            currentDirectionIndex += 1;
        else
            currentDirectionIndex = 0;

        currentDirection = directions[currentDirectionIndex];
        SetDirection();
    }

    private void SetDirection()
    {
        switch (currentDirection)
        {
            case Direction.North:
                transform.forward = Vector3.forward;
                break;
            case Direction.East:
                transform.forward = Vector3.right;
                trainMover.transform.forward = transform.forward;
                break;
            case Direction.South:
                transform.forward = Vector3.forward * -1;
                trainMover.transform.forward = transform.forward;
                break;
            case Direction.West:
                transform.forward = Vector3.right * -1;
                trainMover.transform.forward = transform.forward;
                break;
        }
    }
}
