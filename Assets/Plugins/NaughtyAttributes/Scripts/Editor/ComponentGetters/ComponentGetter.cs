using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEditor;
using System.Reflection;

namespace NaughtyAttributes.Editor
{
    [PropertyValidator(typeof(GetComponentAttribute))]
    public class ComponentGetter
    {
        private SerializedProperty property;
        private FieldInfo field;
        private GetComponentAttribute attribute;

        public void GetComponent(SerializedProperty property, FieldInfo field, GetComponentAttribute attribute)
        {
            this.property = property;
            this.field = field;
            this.attribute = attribute;

            if (IsComponentType())
                GetComponent();
            else
                DisplayWarning("GetComponentAttribute works only with Component types or interfaces");
        }

        private bool IsComponentType()
        {
            Type type = field.FieldType;
            return typeof(Component).IsAssignableFrom(type) || typeof(Component[]).IsAssignableFrom(type) || type.IsInterface;
        }

        private void GetComponent()
        {
            var monoBehaviour = PropertyUtility.GetTargetObject(property) as MonoBehaviour;

            if (property.isArray)
                GetComponents(monoBehaviour);
            else
                GetSingleComponent(monoBehaviour);

        }

        private void GetComponents(MonoBehaviour monoBehaviour)
        {
            property.ClearArray();

            Component[] components;
            Type type = field.FieldType.GetElementType();

            switch (attribute.Scope)
            {
                case GetComponentScope.Self:
                    components = monoBehaviour.GetComponents(type);
                    break;
                case GetComponentScope.Children:
                    components = monoBehaviour.GetComponentsInChildren(type);
                    break;
                default: //case GetComponentScope.Parent
                    components = monoBehaviour.GetComponentsInParent(type);
                    break;
            }

            property.arraySize = components.Length;
            for (int i = 0; i < components.Length; i++)
            {
                SerializedProperty component = property.GetArrayElementAtIndex(i);
                component.objectReferenceValue = components[i];
            }
        }

        private void GetSingleComponent(MonoBehaviour monoBehaviour)
        {
            if (property.objectReferenceValue != null)
                return;

            Type type = field.FieldType;

            switch (attribute.Scope)
            {
                case GetComponentScope.Self:
                    property.objectReferenceValue = monoBehaviour.GetComponent(type);
                    break;
                case GetComponentScope.Children:
                    property.objectReferenceValue = monoBehaviour.GetComponentInChildren(type);
                    break;
                case GetComponentScope.Parent:
                    property.objectReferenceValue = monoBehaviour.GetComponentInParent(type);
                    break;
            }
        }

        private void DisplayWarning(string message)
        {
            EditorDrawUtility.DrawHelpBox(message, MessageType.Error, logToConsole: true, context: PropertyUtility.GetTargetObject(property));
        }
    }
}
