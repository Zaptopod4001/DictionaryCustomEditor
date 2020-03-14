using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Eses.Dict
{

    [CreateAssetMenu()]
    public class DictionaryTest : ScriptableObject, ISerializationCallbackReceiver
    {
        // Temporary lists
        [SerializeField] List<string> keys = new List<string>();
        [SerializeField] List<int> values = new List<int>();

        // Runtime dictionary
        public Dictionary<string, int> dictionary = new Dictionary<string, int>();


        // Add new items from Inspector Context menu
        [ContextMenu("Add test item")]
        public void AddItem()
        {
            dictionary.Add("key" + UnityEngine.Random.Range(0, 9999), UnityEngine.Random.Range(0, 10));
        }


        // Dictionary can't be serialized by default
        // Store keys and values into serializable types
        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();

            foreach (var kvp in dictionary)
            {
                keys.Add(kvp.Key);
                values.Add(kvp.Value);
            }
        }

        // When/before UI gets updated, fill the dictionary
        // with data from serialized key and value lists
        public void OnAfterDeserialize()
        {
            dictionary = new Dictionary<string, int>();

            for (int i = 0; i != Math.Min(keys.Count, values.Count); i++)
            {
                dictionary.Add(keys[i], values[i]);
            }
        }

    }

}