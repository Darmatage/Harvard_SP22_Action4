using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class backgroundLoopSimple : MonoBehaviour {
      public Transform centerBG;
      public float offset = 33f;       //this value is the width of the image

      void Update(){
            if (transform.position.x >= centerBG.position.x + offset){
                  centerBG.position = new Vector2(transform.position.x + offset, centerBG.position.y);
            }
            else if (transform.position.x <= centerBG.position.x - offset){
                  centerBG.position = new Vector2(transform.position.x - offset, centerBG.position.y);
            }
      }
}
