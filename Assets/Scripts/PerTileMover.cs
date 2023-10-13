using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerTileMover : MonoBehaviour
{
     private bool isMoving = false;
     private Vector3 originalPosition, targetPosition;
     private float timeToMove = 0.2f;
     public Animator animatorChar;
    // Update is called once per frame
    void Update()
        {
            if(Input.GetKey(KeyCode.W)&&!isMoving)
                StartCoroutine(MovePlayer(Vector3.up));
                WalkAnimation("WFront", true);

            if(Input.GetKey(KeyCode.A)&&!isMoving)
                StartCoroutine(MovePlayer(Vector3.left));
                WalkAnimation("WLeft", true);

            if(Input.GetKey(KeyCode.S)&&!isMoving)
                StartCoroutine(MovePlayer(Vector3.down));
                WalkAnimation("WBack", true);
            
            if(Input.GetKey(KeyCode.D)&&!isMoving)
                StartCoroutine(MovePlayer(Vector3.right));
                WalkAnimation("WRight", true);
        }

    private void WalkAnimation(string var, bool x)
        {
            animatorChar.SetBool(var, x);
        }

    private IEnumerator MovePlayer(Vector3 direction)
        {
            isMoving = true;
            float elapsedTime=0;

            originalPosition=transform.position;
            targetPosition=originalPosition+direction;

            while(elapsedTime<timeToMove)
            {
                transform.position= Vector3.Lerp(originalPosition,targetPosition,(elapsedTime/timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position=targetPosition;
            isMoving = false;
        }

}
