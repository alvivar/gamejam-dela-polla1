// This file is auto-generated. Modifications won't be saved, be cool.

// EntitySet is a static database of GameObjects (Entities) and MonoBehaviour
// classes (Components). Check out 'Femto.cs' for more information about the
// code generated.

// Refresh with the menu item 'Tools/Gigas/Generate EntitySet.cs'

using System;
using System.Collections.Generic;
using UnityEngine;

//  namespace Gigas
//  {
    public static class EntitySet
    {
        // MainMessage

        public static Arrayx<int> MainMessageIds = new Arrayx<int>();
        public static Arrayx<MainMessage> MainMessages = new Arrayx<MainMessage>();

        public static void AddMainMessage(MainMessage component, bool componentEnabled = true)
        {
            // Setup

            if (MainMessageIds.Elements == null)
            {
                MainMessageIds.Size = 8;
                MainMessageIds.Elements = new int[MainMessageIds.Size];
            }

            if (MainMessages.Elements == null)
            {
                MainMessages.Size = 8;
                MainMessages.Elements = new MainMessage[MainMessages.Size];
            }

            // Add

            MainMessageIds.Elements[MainMessageIds.Length++] = component.gameObject.GetInstanceID();
            MainMessages.Elements[MainMessages.Length++] = component;

            // Resize check

            if (MainMessageIds.Length >= MainMessageIds.Size)
            {
                MainMessageIds.Size *= 2;
                Array.Resize(ref MainMessageIds.Elements, MainMessageIds.Size);

                MainMessages.Size *= 2;
                Array.Resize(ref MainMessages.Elements, MainMessages.Size);
            }

            // Enable

            component.enabled = componentEnabled;
        }

        public static void RemoveMainMessage(MainMessage component, bool componentEnabled = false)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < MainMessageIds.Length; i++)
            {
                if (MainMessageIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                MainMessageIds.Elements, indexToRemove + 1,
                MainMessageIds.Elements, indexToRemove,
                MainMessageIds.Length - indexToRemove - 1);
            MainMessageIds.Length--;

            Array.Copy(
                MainMessages.Elements, indexToRemove + 1,
                MainMessages.Elements, indexToRemove,
                MainMessages.Length - indexToRemove - 1);
            MainMessages.Length--;

            // Cache clean up

            MainMessageIdCache.Clear();

            // Disable

            component.enabled = componentEnabled;
        }

        public static Arrayx<MainMessage> GetMainMessage(params Arrayx<int>[] ids)
        {
            // MainMessageIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] MainMessagePlusIds = new Arrayx<int>[ids.Length + 1];
            MainMessagePlusIds[0] = MainMessageIds;
            Array.Copy(ids, 0, MainMessagePlusIds, 1, ids.Length);

            return Gigas.Get<MainMessage>(MainMessagePlusIds, EntitySet.MainMessages);
        }

        public static MainMessage GetMainMessage(MonoBehaviour component)
        {
            return GetMainMessage(component.gameObject.GetInstanceID());
        }

        public static MainMessage GetMainMessage(GameObject gameobject)
        {
            return GetMainMessage(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> MainMessageIdCache = new Dictionary<int, int>();
        public static MainMessage GetMainMessage(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (MainMessageIdCache.ContainsKey(id))
                return MainMessages.Elements[MainMessageIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < MainMessageIds.Length; i++)
            {
                if (MainMessageIds.Elements[i] == id)
                {
                    index = i;
                    MainMessageIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return MainMessages.Elements[index];
        }


        public static void Clear()
        {
            MainMessageIds.Length = 0;
            MainMessages.Length = 0;
        }

        public static void ClearAlt()
        {
        }
    }
//  }
