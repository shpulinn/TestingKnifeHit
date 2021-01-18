using UnityEngine;

// scriptable int value for storage of score value

namespace Game {
    [CreateAssetMenu(fileName = "ScriptableIntValue", menuName = "ScriptableObjects/ScriptableIntValue")]
    public class ScriptableIntValue : ScriptableObject {

        public int value;
    }
}
