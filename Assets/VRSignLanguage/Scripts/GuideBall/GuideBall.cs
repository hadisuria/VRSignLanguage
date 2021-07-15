using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideBall : MonoBehaviour
{
    /*
     * --REPRESENTATION OF GUIDEBALL DATA--
     * {
	 *	word: "hello",
	 *	leftHandPath: [Vector3, Vector3, Vector3,],
	 *	rightHandPath: [ Vector3 ],
     * }
     */

     private class GuideBallPath {
     }

    private string word;
    private List<Vector3> leftHandPath = new List<Vector3>();
    private List<Vector3> rightHandPath = new List<Vector3>();

    public GuideBall(string word, List<Vector3> leftHandPath, List<Vector3> rightHandPath ){
        this.word = word;
        this.leftHandPath = leftHandPath;
        this.rightHandPath = rightHandPath;
    }

    
}
