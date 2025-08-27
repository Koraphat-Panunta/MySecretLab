using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncapsulationSceneManager : MonoBehaviour
{

    [SerializeField] public ChildAbs subject;
    [SerializeField] public ParentEncap subject2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BeginTest());
    }
    private IEnumerator BeginTest()
    {
        yield return new WaitUntil(() => subject.isActiveAndEnabled);
        subject = subject2;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
