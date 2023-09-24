using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING{
    public class TestFiles : MonoBehaviour
    {
        //private string fileName = "testFile";
        [SerializeField] private TextAsset fileName;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Run());
        }

        IEnumerator Run()
        {
            //List<string> lines = FileManager.ReadTextFile(fileName, false);
            List<string> lines = FileManager.ReadTextAsset(fileName, false);

            foreach (string line in lines)
                Debug.Log(line);

            yield return null;
        }
    }
}
