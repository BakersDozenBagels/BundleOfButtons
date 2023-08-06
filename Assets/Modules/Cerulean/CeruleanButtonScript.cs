using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using BlueButtonLib;
using System.Collections;

public class CeruleanButtonScript : MonoBehaviour
{
    private int _id = ++_idc;
    private static int _idc;

    public void Start()
    {
        int seed = UnityEngine.Random.Range(0, int.MaxValue);
        Debug.LogFormat("[The Cerulean Button #{0}] Using seed {1}.", _id, seed);
        CeruleanButtonPuzzle c = CeruleanButtonPuzzle.GeneratePuzzle(seed,
            s =>
            {
                Debug.LogFormat("[The Cerulean Button #{0}] {1}", _id, s);
            },
#if UNITY_EDITOR
            s =>
            {
                //Debug.LogFormat("<The Cerulean Button #{0}> {1}", _id, s);
            }
#else
            s => { }
#endif
        );
        Debug.LogFormat("[The Cerulean Button #{0}] Answer: {1}, Constraints: {2}, Left Cube: {3}, Right Cube: {4}", _id, c.Answer, c.Constraints.Select(evc => evc.Direction.ToString() + evc.Index + (char)(evc.Letter + 'A' - 1)).Join(" "), c.LeftCube, c.RightCube);
    }

    [MenuItem("DoStuff/DoStuff")]
    public static void Stuff()
    {
        FindObjectOfType<TestHarness>().StartCoroutine(DoStuff());
    }
    public static IEnumerator DoStuff()
    {
        const string TABLE = "OSMGNYDIPUTHFELR";
        //for(int table = 0; table < 1000; table++)
        //{
        //string t = TABLE.OrderBy(_ => UnityEngine.Random.value).Join("");
        string t = TABLE;
        List<string> puzzles = new List<string>();
        for (int _id = 0; _id < 1000; ++_id)
        {
            int seed = UnityEngine.Random.Range(0, int.MaxValue);
            //Debug.LogFormat("[The Cerulean Button #{0}] Using seed {1}.", _id, seed);
            CeruleanButtonPuzzle c = CeruleanButtonPuzzle.GeneratePuzzle(seed,
                s =>
                {
                    //Debug.LogFormat("[The Cerulean Button #{0}] {1}", _id, s);
                },
                s => { },
                t
            );
            if (c != null)
                puzzles.Add(c.Answer);
            else
                puzzles.Add("NO_SOLUTION");
            if (_id % 100 == 0)
                Debug.Log(_id);
            yield return null;
            //Debug.LogFormat("[The Cerulean Button #{0}] Answer: {1}, Constraints: {2}, Left Cube: {3}, Right Cube: {4}", _id, c.Answer, c.Constraints.Select(evc => evc.Direction.ToString() + evc.Index + (char)(evc.Letter + 'A' - 1)).Join(" "), c.LeftCube, c.RightCube);
        }
        //Debug.LogFormat("[The Cerulean Button] Using table {0}: {1}", t, puzzles.Count);
        //}
        Debug.Log(puzzles.OrderBy(s => s).Join(","));
    }
}
