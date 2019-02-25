using System;
using System.Collections.Generic;

namespace NaughtyAttributes.Editor
{
    public class ComponentGetterDatabase
    {
        private static Dictionary<Type, ComponentGetter> gettersByAttributeType;

        static ComponentGetterDatabase()
        {
            gettersByAttributeType = new Dictionary<Type, ComponentGetter>();
            gettersByAttributeType[typeof(GetComponentAttribute)] = new ComponentGetter();
        }

        public static ComponentGetter GetComponentGetterForAttribute(Type attributeType)
        {
            ComponentGetter getter;
            if (gettersByAttributeType.TryGetValue(attributeType, out getter))
            {
                return getter;
            }
            else
            {
                return null;
            }
        }
    }
}
