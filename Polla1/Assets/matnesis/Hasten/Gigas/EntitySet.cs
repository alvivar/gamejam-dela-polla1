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
        // Conversation

        public static Arrayx<int> ConversationIds = new Arrayx<int>();
        public static Arrayx<Conversation> Conversations = new Arrayx<Conversation>();

        public static void AddConversation(Conversation component, bool componentEnabled = true)
        {
            // Setup

            if (ConversationIds.Elements == null)
            {
                ConversationIds.Size = 8;
                ConversationIds.Elements = new int[ConversationIds.Size];
            }

            if (Conversations.Elements == null)
            {
                Conversations.Size = 8;
                Conversations.Elements = new Conversation[Conversations.Size];
            }

            // Add

            ConversationIds.Elements[ConversationIds.Length++] = component.gameObject.GetInstanceID();
            Conversations.Elements[Conversations.Length++] = component;

            // Resize check

            if (ConversationIds.Length >= ConversationIds.Size)
            {
                ConversationIds.Size *= 2;
                Array.Resize(ref ConversationIds.Elements, ConversationIds.Size);

                Conversations.Size *= 2;
                Array.Resize(ref Conversations.Elements, Conversations.Size);
            }

            // Enable

            component.enabled = componentEnabled;
        }

        public static void RemoveConversation(Conversation component, bool componentEnabled = false)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < ConversationIds.Length; i++)
            {
                if (ConversationIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                ConversationIds.Elements, indexToRemove + 1,
                ConversationIds.Elements, indexToRemove,
                ConversationIds.Length - indexToRemove - 1);
            ConversationIds.Length--;

            Array.Copy(
                Conversations.Elements, indexToRemove + 1,
                Conversations.Elements, indexToRemove,
                Conversations.Length - indexToRemove - 1);
            Conversations.Length--;

            // Cache clean up

            ConversationIdCache.Clear();

            // Disable

            component.enabled = componentEnabled;
        }

        public static Arrayx<Conversation> GetConversation(params Arrayx<int>[] ids)
        {
            // ConversationIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] ConversationPlusIds = new Arrayx<int>[ids.Length + 1];
            ConversationPlusIds[0] = ConversationIds;
            Array.Copy(ids, 0, ConversationPlusIds, 1, ids.Length);

            return Gigas.Get<Conversation>(ConversationPlusIds, EntitySet.Conversations);
        }

        public static Conversation GetConversation(MonoBehaviour component)
        {
            return GetConversation(component.gameObject.GetInstanceID());
        }

        public static Conversation GetConversation(GameObject gameobject)
        {
            return GetConversation(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> ConversationIdCache = new Dictionary<int, int>();
        public static Conversation GetConversation(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (ConversationIdCache.ContainsKey(id))
                return Conversations.Elements[ConversationIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < ConversationIds.Length; i++)
            {
                if (ConversationIds.Elements[i] == id)
                {
                    index = i;
                    ConversationIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return Conversations.Elements[index];
        }

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

        // Telepoint

        public static Arrayx<int> TelepointIds = new Arrayx<int>();
        public static Arrayx<Telepoint> Telepoints = new Arrayx<Telepoint>();

        public static void AddTelepoint(Telepoint component, bool componentEnabled = true)
        {
            // Setup

            if (TelepointIds.Elements == null)
            {
                TelepointIds.Size = 8;
                TelepointIds.Elements = new int[TelepointIds.Size];
            }

            if (Telepoints.Elements == null)
            {
                Telepoints.Size = 8;
                Telepoints.Elements = new Telepoint[Telepoints.Size];
            }

            // Add

            TelepointIds.Elements[TelepointIds.Length++] = component.gameObject.GetInstanceID();
            Telepoints.Elements[Telepoints.Length++] = component;

            // Resize check

            if (TelepointIds.Length >= TelepointIds.Size)
            {
                TelepointIds.Size *= 2;
                Array.Resize(ref TelepointIds.Elements, TelepointIds.Size);

                Telepoints.Size *= 2;
                Array.Resize(ref Telepoints.Elements, Telepoints.Size);
            }

            // Enable

            component.enabled = componentEnabled;
        }

        public static void RemoveTelepoint(Telepoint component, bool componentEnabled = false)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < TelepointIds.Length; i++)
            {
                if (TelepointIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                TelepointIds.Elements, indexToRemove + 1,
                TelepointIds.Elements, indexToRemove,
                TelepointIds.Length - indexToRemove - 1);
            TelepointIds.Length--;

            Array.Copy(
                Telepoints.Elements, indexToRemove + 1,
                Telepoints.Elements, indexToRemove,
                Telepoints.Length - indexToRemove - 1);
            Telepoints.Length--;

            // Cache clean up

            TelepointIdCache.Clear();

            // Disable

            component.enabled = componentEnabled;
        }

        public static Arrayx<Telepoint> GetTelepoint(params Arrayx<int>[] ids)
        {
            // TelepointIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] TelepointPlusIds = new Arrayx<int>[ids.Length + 1];
            TelepointPlusIds[0] = TelepointIds;
            Array.Copy(ids, 0, TelepointPlusIds, 1, ids.Length);

            return Gigas.Get<Telepoint>(TelepointPlusIds, EntitySet.Telepoints);
        }

        public static Telepoint GetTelepoint(MonoBehaviour component)
        {
            return GetTelepoint(component.gameObject.GetInstanceID());
        }

        public static Telepoint GetTelepoint(GameObject gameobject)
        {
            return GetTelepoint(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> TelepointIdCache = new Dictionary<int, int>();
        public static Telepoint GetTelepoint(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (TelepointIdCache.ContainsKey(id))
                return Telepoints.Elements[TelepointIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < TelepointIds.Length; i++)
            {
                if (TelepointIds.Elements[i] == id)
                {
                    index = i;
                    TelepointIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return Telepoints.Elements[index];
        }

        // VoidPlayer

        public static Arrayx<int> VoidPlayerIds = new Arrayx<int>();
        public static Arrayx<VoidPlayer> VoidPlayers = new Arrayx<VoidPlayer>();

        public static void AddVoidPlayer(VoidPlayer component, bool componentEnabled = true)
        {
            // Setup

            if (VoidPlayerIds.Elements == null)
            {
                VoidPlayerIds.Size = 8;
                VoidPlayerIds.Elements = new int[VoidPlayerIds.Size];
            }

            if (VoidPlayers.Elements == null)
            {
                VoidPlayers.Size = 8;
                VoidPlayers.Elements = new VoidPlayer[VoidPlayers.Size];
            }

            // Add

            VoidPlayerIds.Elements[VoidPlayerIds.Length++] = component.gameObject.GetInstanceID();
            VoidPlayers.Elements[VoidPlayers.Length++] = component;

            // Resize check

            if (VoidPlayerIds.Length >= VoidPlayerIds.Size)
            {
                VoidPlayerIds.Size *= 2;
                Array.Resize(ref VoidPlayerIds.Elements, VoidPlayerIds.Size);

                VoidPlayers.Size *= 2;
                Array.Resize(ref VoidPlayers.Elements, VoidPlayers.Size);
            }

            // Enable

            component.enabled = componentEnabled;
        }

        public static void RemoveVoidPlayer(VoidPlayer component, bool componentEnabled = false)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < VoidPlayerIds.Length; i++)
            {
                if (VoidPlayerIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                VoidPlayerIds.Elements, indexToRemove + 1,
                VoidPlayerIds.Elements, indexToRemove,
                VoidPlayerIds.Length - indexToRemove - 1);
            VoidPlayerIds.Length--;

            Array.Copy(
                VoidPlayers.Elements, indexToRemove + 1,
                VoidPlayers.Elements, indexToRemove,
                VoidPlayers.Length - indexToRemove - 1);
            VoidPlayers.Length--;

            // Cache clean up

            VoidPlayerIdCache.Clear();

            // Disable

            component.enabled = componentEnabled;
        }

        public static Arrayx<VoidPlayer> GetVoidPlayer(params Arrayx<int>[] ids)
        {
            // VoidPlayerIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] VoidPlayerPlusIds = new Arrayx<int>[ids.Length + 1];
            VoidPlayerPlusIds[0] = VoidPlayerIds;
            Array.Copy(ids, 0, VoidPlayerPlusIds, 1, ids.Length);

            return Gigas.Get<VoidPlayer>(VoidPlayerPlusIds, EntitySet.VoidPlayers);
        }

        public static VoidPlayer GetVoidPlayer(MonoBehaviour component)
        {
            return GetVoidPlayer(component.gameObject.GetInstanceID());
        }

        public static VoidPlayer GetVoidPlayer(GameObject gameobject)
        {
            return GetVoidPlayer(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> VoidPlayerIdCache = new Dictionary<int, int>();
        public static VoidPlayer GetVoidPlayer(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (VoidPlayerIdCache.ContainsKey(id))
                return VoidPlayers.Elements[VoidPlayerIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < VoidPlayerIds.Length; i++)
            {
                if (VoidPlayerIds.Elements[i] == id)
                {
                    index = i;
                    VoidPlayerIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return VoidPlayers.Elements[index];
        }


        public static void Clear()
        {
            ConversationIds.Length = 0;
            Conversations.Length = 0;

            MainMessageIds.Length = 0;
            MainMessages.Length = 0;

            TelepointIds.Length = 0;
            Telepoints.Length = 0;

            VoidPlayerIds.Length = 0;
            VoidPlayers.Length = 0;
        }

        public static void ClearAlt()
        {
        }
    }
//  }
