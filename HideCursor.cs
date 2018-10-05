using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideCursor : MonoBehaviour {

    [SerializeField]
    GameObject textbox, relationshipstats, pausemenu, stats, objectivesB,objectives, inventory, ending;

	
	void Update () {
		
        if (pausemenu.activeSelf
            || relationshipstats.activeSelf
            || stats.activeSelf
            || inventory.activeSelf
            || ending.activeSelf
            || (objectives.activeSelf && objectivesB.activeSelf)
            || textbox.GetComponent<Image>().isActiveAndEnabled)
        {
            Cursor.visible = true;
            Screen.lockCursor = false;
        }

        else
        {
            Cursor.visible = false;
            Screen.lockCursor = true;
        }

	}
}
