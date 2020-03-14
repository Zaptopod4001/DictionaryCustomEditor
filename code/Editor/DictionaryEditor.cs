using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Eses.Dict
{
    // Copyright Sami S.

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.
    
    [CustomEditor(typeof(DictionaryTest))]
    public class DictTestEditor : Editor
    {
        // local variables
        Dictionary<string, int> dict;
        DictionaryTest t;


        void OnEnable()
        {
            // store references
            t = (DictionaryTest)target;
            dict = t.dictionary;
        }


        public override void OnInspectorGUI()
        {
            var col = GUI.color;

            // get keys of dictionary
            List<string> keys = new List<string>(dict.Keys);

            // heading
            EditorGUILayout.LabelField("Serializable Dictionary", EditorStyles.boldLabel);

            using (var vert = new EditorGUILayout.VerticalScope("box"))
            {

                for (int i = 0; i < keys.Count; i++)
                {

                    // line of items
                    using (var line = new EditorGUILayout.HorizontalScope())
                    {
                        // label for key
                        EditorGUILayout.LabelField(keys[i]);

                        // edit field for value
                        dict[keys[i]] = EditorGUILayout.IntField(dict[keys[i]]);

                        // delete button 
                        GUI.color = Color.red;

                        if (GUILayout.Button("x"))
                        {
                            Undo.RecordObject(t, "Delete dictionary item");
                            t.dictionary.Remove(keys[i]);
                        }

                        // restore color
                        GUI.color = col;
                    }
                }
            }


            // Button to add new dictionary key/value pairs

            if (GUILayout.Button("Add item", GUILayout.Height(30)))
            {
                Undo.RecordObject(t, "Add dictionary item");
                t.AddItem();
            }

            if (GUILayout.Button("Clear all", GUILayout.Height(20)))
            {
                if (EditorUtility.DisplayDialog("Warning", "Clear the dictionary?", "YES", "NO"))
                {
                    Undo.RecordObject(t, "Clear dictionary");
                    dict.Clear();
                }
            }
        }

    }

}
