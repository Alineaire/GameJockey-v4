using UnityEngine;

namespace GameJockey_v4
{
    [System.Serializable]
    public class InputType : ScriptableObject { }

    public class InputTypeOne : InputType
    {
        public virtual void Done() { }
    }

    public class InputTypeWhile : InputType
    {
        public virtual void WhileDone() { }
    }

    public class InputTypeCharge : InputType
    {
        public virtual void AtFirst() { }
        public virtual void Then() { }
    }
}