using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectoutofarena : MonoBehaviour
{
    public static void outofarena(GameObject project)
    {
        if (project.transform.position.x >= 3.2f || project.transform.position.x <= -3.2f || project.transform.position.y >= 6.2f * wavescript.screenSizePere || project.transform.position.y <= -6.2f * wavescript.screenSizePere)
        {
            Destroy(project);
        }
    }
}
