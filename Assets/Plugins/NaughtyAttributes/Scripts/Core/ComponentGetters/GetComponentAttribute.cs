using UnityEngine;
using System;

namespace NaughtyAttributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class GetComponentAttribute : ValidatorAttribute
    {
        public GetComponentScope Scope { get; private set; }

        public GetComponentAttribute(GetComponentScope scope = GetComponentScope.Self)
        {
            Scope = scope;
        }
    }
}
