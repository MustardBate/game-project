using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AbstractMapGenerator), true)]
public class RandomMapGenerationEditor : Editor
{ 
    AbstractMapGenerator generator;

    private void Awake()
    {
        generator = (AbstractMapGenerator)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Generate Map"))
        {
            generator.GenerateMap();
        }
    }
}