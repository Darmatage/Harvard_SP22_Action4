using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class backgroundLoopSimple : MonoBehaviour {
      public Transform centerBG;
      private Transform PlayerPos;
      private Transform CamPos;
      private float offset = 33f;
	  public float yMod = 1f;
	  public float xMod = 1f;
	  private float chunks = 0f;
	  
	  void Awake() {
			PlayerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
			CamPos = transform;
	  }

      void Update(){
            if (PlayerPos.position.x >= centerBG.position.x + offset){
                  chunks = chunks + 1f;
            }
            else if (PlayerPos.position.x <= centerBG.position.x - offset){
                  chunks = chunks - 1f;
            }
			centerBG.position = new Vector2(CamPos.position.x/xMod + chunks * offset, CamPos.position.y/yMod);
      }
}
