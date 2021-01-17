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
        // BecauseOfReasons

        public static Arrayx<int> BecauseOfReasonsIds = new Arrayx<int>();
        public static Arrayx<BecauseOfReasons> BecauseOfReasonss = new Arrayx<BecauseOfReasons>();

        public static void AddBecauseOfReasons(BecauseOfReasons component)
        {
            // Setup

            if (BecauseOfReasonsIds.Elements == null)
            {
                BecauseOfReasonsIds.Size = 8;
                BecauseOfReasonsIds.Elements = new int[BecauseOfReasonsIds.Size];
            }

            if (BecauseOfReasonss.Elements == null)
            {
                BecauseOfReasonss.Size = 8;
                BecauseOfReasonss.Elements = new BecauseOfReasons[BecauseOfReasonss.Size];
            }

            // Add

            BecauseOfReasonsIds.Elements[BecauseOfReasonsIds.Length++] = component.gameObject.GetInstanceID();
            BecauseOfReasonss.Elements[BecauseOfReasonss.Length++] = component;

            // Resize check

            if (BecauseOfReasonsIds.Length >= BecauseOfReasonsIds.Size)
            {
                BecauseOfReasonsIds.Size *= 2;
                Array.Resize(ref BecauseOfReasonsIds.Elements, BecauseOfReasonsIds.Size);

                BecauseOfReasonss.Size *= 2;
                Array.Resize(ref BecauseOfReasonss.Elements, BecauseOfReasonss.Size);
            }
        }

        public static void RemoveBecauseOfReasons(BecauseOfReasons component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < BecauseOfReasonsIds.Length; i++)
            {
                if (BecauseOfReasonsIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                BecauseOfReasonsIds.Elements, indexToRemove + 1,
                BecauseOfReasonsIds.Elements, indexToRemove,
                BecauseOfReasonsIds.Length - indexToRemove - 1);
            BecauseOfReasonsIds.Length--;

            Array.Copy(
                BecauseOfReasonss.Elements, indexToRemove + 1,
                BecauseOfReasonss.Elements, indexToRemove,
                BecauseOfReasonss.Length - indexToRemove - 1);
            BecauseOfReasonss.Length--;

            // Cache clean up

            BecauseOfReasonsIdCache.Clear();
        }

        public static Arrayx<BecauseOfReasons> GetBecauseOfReasons(params Arrayx<int>[] ids)
        {
            // BecauseOfReasonsIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] BecauseOfReasonsPlusIds = new Arrayx<int>[ids.Length + 1];
            BecauseOfReasonsPlusIds[0] = BecauseOfReasonsIds;
            Array.Copy(ids, 0, BecauseOfReasonsPlusIds, 1, ids.Length);

            return Gigas.Get<BecauseOfReasons>(BecauseOfReasonsPlusIds, EntitySet.BecauseOfReasonss);
        }

        public static BecauseOfReasons GetBecauseOfReasons(MonoBehaviour component)
        {
            return GetBecauseOfReasons(component.gameObject.GetInstanceID());
        }

        public static BecauseOfReasons GetBecauseOfReasons(GameObject gameobject)
        {
            return GetBecauseOfReasons(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> BecauseOfReasonsIdCache = new Dictionary<int, int>();
        public static BecauseOfReasons GetBecauseOfReasons(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (BecauseOfReasonsIdCache.ContainsKey(id))
                return BecauseOfReasonss.Elements[BecauseOfReasonsIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < BecauseOfReasonsIds.Length; i++)
            {
                if (BecauseOfReasonsIds.Elements[i] == id)
                {
                    index = i;
                    BecauseOfReasonsIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return BecauseOfReasonss.Elements[index];
        }

        // BecauseThisReason

        public static Arrayx<int> BecauseThisReasonIds = new Arrayx<int>();
        public static Arrayx<BecauseThisReason> BecauseThisReasons = new Arrayx<BecauseThisReason>();

        public static void AddBecauseThisReason(BecauseThisReason component)
        {
            // Setup

            if (BecauseThisReasonIds.Elements == null)
            {
                BecauseThisReasonIds.Size = 8;
                BecauseThisReasonIds.Elements = new int[BecauseThisReasonIds.Size];
            }

            if (BecauseThisReasons.Elements == null)
            {
                BecauseThisReasons.Size = 8;
                BecauseThisReasons.Elements = new BecauseThisReason[BecauseThisReasons.Size];
            }

            // Add

            BecauseThisReasonIds.Elements[BecauseThisReasonIds.Length++] = component.gameObject.GetInstanceID();
            BecauseThisReasons.Elements[BecauseThisReasons.Length++] = component;

            // Resize check

            if (BecauseThisReasonIds.Length >= BecauseThisReasonIds.Size)
            {
                BecauseThisReasonIds.Size *= 2;
                Array.Resize(ref BecauseThisReasonIds.Elements, BecauseThisReasonIds.Size);

                BecauseThisReasons.Size *= 2;
                Array.Resize(ref BecauseThisReasons.Elements, BecauseThisReasons.Size);
            }
        }

        public static void RemoveBecauseThisReason(BecauseThisReason component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < BecauseThisReasonIds.Length; i++)
            {
                if (BecauseThisReasonIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                BecauseThisReasonIds.Elements, indexToRemove + 1,
                BecauseThisReasonIds.Elements, indexToRemove,
                BecauseThisReasonIds.Length - indexToRemove - 1);
            BecauseThisReasonIds.Length--;

            Array.Copy(
                BecauseThisReasons.Elements, indexToRemove + 1,
                BecauseThisReasons.Elements, indexToRemove,
                BecauseThisReasons.Length - indexToRemove - 1);
            BecauseThisReasons.Length--;

            // Cache clean up

            BecauseThisReasonIdCache.Clear();
        }

        public static Arrayx<BecauseThisReason> GetBecauseThisReason(params Arrayx<int>[] ids)
        {
            // BecauseThisReasonIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] BecauseThisReasonPlusIds = new Arrayx<int>[ids.Length + 1];
            BecauseThisReasonPlusIds[0] = BecauseThisReasonIds;
            Array.Copy(ids, 0, BecauseThisReasonPlusIds, 1, ids.Length);

            return Gigas.Get<BecauseThisReason>(BecauseThisReasonPlusIds, EntitySet.BecauseThisReasons);
        }

        public static BecauseThisReason GetBecauseThisReason(MonoBehaviour component)
        {
            return GetBecauseThisReason(component.gameObject.GetInstanceID());
        }

        public static BecauseThisReason GetBecauseThisReason(GameObject gameobject)
        {
            return GetBecauseThisReason(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> BecauseThisReasonIdCache = new Dictionary<int, int>();
        public static BecauseThisReason GetBecauseThisReason(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (BecauseThisReasonIdCache.ContainsKey(id))
                return BecauseThisReasons.Elements[BecauseThisReasonIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < BecauseThisReasonIds.Length; i++)
            {
                if (BecauseThisReasonIds.Elements[i] == id)
                {
                    index = i;
                    BecauseThisReasonIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return BecauseThisReasons.Elements[index];
        }

        // Cattleya

        public static Arrayx<int> CattleyaIds = new Arrayx<int>();
        public static Arrayx<Cattleya> Cattleyas = new Arrayx<Cattleya>();

        public static void AddCattleya(Cattleya component)
        {
            // Setup

            if (CattleyaIds.Elements == null)
            {
                CattleyaIds.Size = 8;
                CattleyaIds.Elements = new int[CattleyaIds.Size];
            }

            if (Cattleyas.Elements == null)
            {
                Cattleyas.Size = 8;
                Cattleyas.Elements = new Cattleya[Cattleyas.Size];
            }

            // Add

            CattleyaIds.Elements[CattleyaIds.Length++] = component.gameObject.GetInstanceID();
            Cattleyas.Elements[Cattleyas.Length++] = component;

            // Resize check

            if (CattleyaIds.Length >= CattleyaIds.Size)
            {
                CattleyaIds.Size *= 2;
                Array.Resize(ref CattleyaIds.Elements, CattleyaIds.Size);

                Cattleyas.Size *= 2;
                Array.Resize(ref Cattleyas.Elements, Cattleyas.Size);
            }
        }

        public static void RemoveCattleya(Cattleya component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < CattleyaIds.Length; i++)
            {
                if (CattleyaIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                CattleyaIds.Elements, indexToRemove + 1,
                CattleyaIds.Elements, indexToRemove,
                CattleyaIds.Length - indexToRemove - 1);
            CattleyaIds.Length--;

            Array.Copy(
                Cattleyas.Elements, indexToRemove + 1,
                Cattleyas.Elements, indexToRemove,
                Cattleyas.Length - indexToRemove - 1);
            Cattleyas.Length--;

            // Cache clean up

            CattleyaIdCache.Clear();
        }

        public static Arrayx<Cattleya> GetCattleya(params Arrayx<int>[] ids)
        {
            // CattleyaIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] CattleyaPlusIds = new Arrayx<int>[ids.Length + 1];
            CattleyaPlusIds[0] = CattleyaIds;
            Array.Copy(ids, 0, CattleyaPlusIds, 1, ids.Length);

            return Gigas.Get<Cattleya>(CattleyaPlusIds, EntitySet.Cattleyas);
        }

        public static Cattleya GetCattleya(MonoBehaviour component)
        {
            return GetCattleya(component.gameObject.GetInstanceID());
        }

        public static Cattleya GetCattleya(GameObject gameobject)
        {
            return GetCattleya(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> CattleyaIdCache = new Dictionary<int, int>();
        public static Cattleya GetCattleya(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (CattleyaIdCache.ContainsKey(id))
                return Cattleyas.Elements[CattleyaIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < CattleyaIds.Length; i++)
            {
                if (CattleyaIds.Elements[i] == id)
                {
                    index = i;
                    CattleyaIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return Cattleyas.Elements[index];
        }

        // Conversation

        public static Arrayx<int> ConversationIds = new Arrayx<int>();
        public static Arrayx<Conversation> Conversations = new Arrayx<Conversation>();

        public static void AddConversation(Conversation component)
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
        }

        public static void RemoveConversation(Conversation component)
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

        // DemonInvitation

        public static Arrayx<int> DemonInvitationIds = new Arrayx<int>();
        public static Arrayx<DemonInvitation> DemonInvitations = new Arrayx<DemonInvitation>();

        public static void AddDemonInvitation(DemonInvitation component)
        {
            // Setup

            if (DemonInvitationIds.Elements == null)
            {
                DemonInvitationIds.Size = 8;
                DemonInvitationIds.Elements = new int[DemonInvitationIds.Size];
            }

            if (DemonInvitations.Elements == null)
            {
                DemonInvitations.Size = 8;
                DemonInvitations.Elements = new DemonInvitation[DemonInvitations.Size];
            }

            // Add

            DemonInvitationIds.Elements[DemonInvitationIds.Length++] = component.gameObject.GetInstanceID();
            DemonInvitations.Elements[DemonInvitations.Length++] = component;

            // Resize check

            if (DemonInvitationIds.Length >= DemonInvitationIds.Size)
            {
                DemonInvitationIds.Size *= 2;
                Array.Resize(ref DemonInvitationIds.Elements, DemonInvitationIds.Size);

                DemonInvitations.Size *= 2;
                Array.Resize(ref DemonInvitations.Elements, DemonInvitations.Size);
            }
        }

        public static void RemoveDemonInvitation(DemonInvitation component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < DemonInvitationIds.Length; i++)
            {
                if (DemonInvitationIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                DemonInvitationIds.Elements, indexToRemove + 1,
                DemonInvitationIds.Elements, indexToRemove,
                DemonInvitationIds.Length - indexToRemove - 1);
            DemonInvitationIds.Length--;

            Array.Copy(
                DemonInvitations.Elements, indexToRemove + 1,
                DemonInvitations.Elements, indexToRemove,
                DemonInvitations.Length - indexToRemove - 1);
            DemonInvitations.Length--;

            // Cache clean up

            DemonInvitationIdCache.Clear();
        }

        public static Arrayx<DemonInvitation> GetDemonInvitation(params Arrayx<int>[] ids)
        {
            // DemonInvitationIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] DemonInvitationPlusIds = new Arrayx<int>[ids.Length + 1];
            DemonInvitationPlusIds[0] = DemonInvitationIds;
            Array.Copy(ids, 0, DemonInvitationPlusIds, 1, ids.Length);

            return Gigas.Get<DemonInvitation>(DemonInvitationPlusIds, EntitySet.DemonInvitations);
        }

        public static DemonInvitation GetDemonInvitation(MonoBehaviour component)
        {
            return GetDemonInvitation(component.gameObject.GetInstanceID());
        }

        public static DemonInvitation GetDemonInvitation(GameObject gameobject)
        {
            return GetDemonInvitation(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> DemonInvitationIdCache = new Dictionary<int, int>();
        public static DemonInvitation GetDemonInvitation(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (DemonInvitationIdCache.ContainsKey(id))
                return DemonInvitations.Elements[DemonInvitationIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < DemonInvitationIds.Length; i++)
            {
                if (DemonInvitationIds.Elements[i] == id)
                {
                    index = i;
                    DemonInvitationIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return DemonInvitations.Elements[index];
        }

        // DemonOf

        public static Arrayx<int> DemonOfIds = new Arrayx<int>();
        public static Arrayx<DemonOf> DemonOfs = new Arrayx<DemonOf>();

        public static void AddDemonOf(DemonOf component)
        {
            // Setup

            if (DemonOfIds.Elements == null)
            {
                DemonOfIds.Size = 8;
                DemonOfIds.Elements = new int[DemonOfIds.Size];
            }

            if (DemonOfs.Elements == null)
            {
                DemonOfs.Size = 8;
                DemonOfs.Elements = new DemonOf[DemonOfs.Size];
            }

            // Add

            DemonOfIds.Elements[DemonOfIds.Length++] = component.gameObject.GetInstanceID();
            DemonOfs.Elements[DemonOfs.Length++] = component;

            // Resize check

            if (DemonOfIds.Length >= DemonOfIds.Size)
            {
                DemonOfIds.Size *= 2;
                Array.Resize(ref DemonOfIds.Elements, DemonOfIds.Size);

                DemonOfs.Size *= 2;
                Array.Resize(ref DemonOfs.Elements, DemonOfs.Size);
            }
        }

        public static void RemoveDemonOf(DemonOf component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < DemonOfIds.Length; i++)
            {
                if (DemonOfIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                DemonOfIds.Elements, indexToRemove + 1,
                DemonOfIds.Elements, indexToRemove,
                DemonOfIds.Length - indexToRemove - 1);
            DemonOfIds.Length--;

            Array.Copy(
                DemonOfs.Elements, indexToRemove + 1,
                DemonOfs.Elements, indexToRemove,
                DemonOfs.Length - indexToRemove - 1);
            DemonOfs.Length--;

            // Cache clean up

            DemonOfIdCache.Clear();
        }

        public static Arrayx<DemonOf> GetDemonOf(params Arrayx<int>[] ids)
        {
            // DemonOfIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] DemonOfPlusIds = new Arrayx<int>[ids.Length + 1];
            DemonOfPlusIds[0] = DemonOfIds;
            Array.Copy(ids, 0, DemonOfPlusIds, 1, ids.Length);

            return Gigas.Get<DemonOf>(DemonOfPlusIds, EntitySet.DemonOfs);
        }

        public static DemonOf GetDemonOf(MonoBehaviour component)
        {
            return GetDemonOf(component.gameObject.GetInstanceID());
        }

        public static DemonOf GetDemonOf(GameObject gameobject)
        {
            return GetDemonOf(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> DemonOfIdCache = new Dictionary<int, int>();
        public static DemonOf GetDemonOf(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (DemonOfIdCache.ContainsKey(id))
                return DemonOfs.Elements[DemonOfIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < DemonOfIds.Length; i++)
            {
                if (DemonOfIds.Elements[i] == id)
                {
                    index = i;
                    DemonOfIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return DemonOfs.Elements[index];
        }

        // EyeOfCreator

        public static Arrayx<int> EyeOfCreatorIds = new Arrayx<int>();
        public static Arrayx<EyeOfCreator> EyeOfCreators = new Arrayx<EyeOfCreator>();

        public static void AddEyeOfCreator(EyeOfCreator component)
        {
            // Setup

            if (EyeOfCreatorIds.Elements == null)
            {
                EyeOfCreatorIds.Size = 8;
                EyeOfCreatorIds.Elements = new int[EyeOfCreatorIds.Size];
            }

            if (EyeOfCreators.Elements == null)
            {
                EyeOfCreators.Size = 8;
                EyeOfCreators.Elements = new EyeOfCreator[EyeOfCreators.Size];
            }

            // Add

            EyeOfCreatorIds.Elements[EyeOfCreatorIds.Length++] = component.gameObject.GetInstanceID();
            EyeOfCreators.Elements[EyeOfCreators.Length++] = component;

            // Resize check

            if (EyeOfCreatorIds.Length >= EyeOfCreatorIds.Size)
            {
                EyeOfCreatorIds.Size *= 2;
                Array.Resize(ref EyeOfCreatorIds.Elements, EyeOfCreatorIds.Size);

                EyeOfCreators.Size *= 2;
                Array.Resize(ref EyeOfCreators.Elements, EyeOfCreators.Size);
            }
        }

        public static void RemoveEyeOfCreator(EyeOfCreator component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < EyeOfCreatorIds.Length; i++)
            {
                if (EyeOfCreatorIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                EyeOfCreatorIds.Elements, indexToRemove + 1,
                EyeOfCreatorIds.Elements, indexToRemove,
                EyeOfCreatorIds.Length - indexToRemove - 1);
            EyeOfCreatorIds.Length--;

            Array.Copy(
                EyeOfCreators.Elements, indexToRemove + 1,
                EyeOfCreators.Elements, indexToRemove,
                EyeOfCreators.Length - indexToRemove - 1);
            EyeOfCreators.Length--;

            // Cache clean up

            EyeOfCreatorIdCache.Clear();
        }

        public static Arrayx<EyeOfCreator> GetEyeOfCreator(params Arrayx<int>[] ids)
        {
            // EyeOfCreatorIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] EyeOfCreatorPlusIds = new Arrayx<int>[ids.Length + 1];
            EyeOfCreatorPlusIds[0] = EyeOfCreatorIds;
            Array.Copy(ids, 0, EyeOfCreatorPlusIds, 1, ids.Length);

            return Gigas.Get<EyeOfCreator>(EyeOfCreatorPlusIds, EntitySet.EyeOfCreators);
        }

        public static EyeOfCreator GetEyeOfCreator(MonoBehaviour component)
        {
            return GetEyeOfCreator(component.gameObject.GetInstanceID());
        }

        public static EyeOfCreator GetEyeOfCreator(GameObject gameobject)
        {
            return GetEyeOfCreator(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> EyeOfCreatorIdCache = new Dictionary<int, int>();
        public static EyeOfCreator GetEyeOfCreator(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (EyeOfCreatorIdCache.ContainsKey(id))
                return EyeOfCreators.Elements[EyeOfCreatorIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < EyeOfCreatorIds.Length; i++)
            {
                if (EyeOfCreatorIds.Elements[i] == id)
                {
                    index = i;
                    EyeOfCreatorIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return EyeOfCreators.Elements[index];
        }

        // EyeOfMind

        public static Arrayx<int> EyeOfMindIds = new Arrayx<int>();
        public static Arrayx<EyeOfMind> EyeOfMinds = new Arrayx<EyeOfMind>();

        public static void AddEyeOfMind(EyeOfMind component)
        {
            // Setup

            if (EyeOfMindIds.Elements == null)
            {
                EyeOfMindIds.Size = 8;
                EyeOfMindIds.Elements = new int[EyeOfMindIds.Size];
            }

            if (EyeOfMinds.Elements == null)
            {
                EyeOfMinds.Size = 8;
                EyeOfMinds.Elements = new EyeOfMind[EyeOfMinds.Size];
            }

            // Add

            EyeOfMindIds.Elements[EyeOfMindIds.Length++] = component.gameObject.GetInstanceID();
            EyeOfMinds.Elements[EyeOfMinds.Length++] = component;

            // Resize check

            if (EyeOfMindIds.Length >= EyeOfMindIds.Size)
            {
                EyeOfMindIds.Size *= 2;
                Array.Resize(ref EyeOfMindIds.Elements, EyeOfMindIds.Size);

                EyeOfMinds.Size *= 2;
                Array.Resize(ref EyeOfMinds.Elements, EyeOfMinds.Size);
            }
        }

        public static void RemoveEyeOfMind(EyeOfMind component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < EyeOfMindIds.Length; i++)
            {
                if (EyeOfMindIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                EyeOfMindIds.Elements, indexToRemove + 1,
                EyeOfMindIds.Elements, indexToRemove,
                EyeOfMindIds.Length - indexToRemove - 1);
            EyeOfMindIds.Length--;

            Array.Copy(
                EyeOfMinds.Elements, indexToRemove + 1,
                EyeOfMinds.Elements, indexToRemove,
                EyeOfMinds.Length - indexToRemove - 1);
            EyeOfMinds.Length--;

            // Cache clean up

            EyeOfMindIdCache.Clear();
        }

        public static Arrayx<EyeOfMind> GetEyeOfMind(params Arrayx<int>[] ids)
        {
            // EyeOfMindIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] EyeOfMindPlusIds = new Arrayx<int>[ids.Length + 1];
            EyeOfMindPlusIds[0] = EyeOfMindIds;
            Array.Copy(ids, 0, EyeOfMindPlusIds, 1, ids.Length);

            return Gigas.Get<EyeOfMind>(EyeOfMindPlusIds, EntitySet.EyeOfMinds);
        }

        public static EyeOfMind GetEyeOfMind(MonoBehaviour component)
        {
            return GetEyeOfMind(component.gameObject.GetInstanceID());
        }

        public static EyeOfMind GetEyeOfMind(GameObject gameobject)
        {
            return GetEyeOfMind(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> EyeOfMindIdCache = new Dictionary<int, int>();
        public static EyeOfMind GetEyeOfMind(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (EyeOfMindIdCache.ContainsKey(id))
                return EyeOfMinds.Elements[EyeOfMindIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < EyeOfMindIds.Length; i++)
            {
                if (EyeOfMindIds.Elements[i] == id)
                {
                    index = i;
                    EyeOfMindIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return EyeOfMinds.Elements[index];
        }

        // HideOnEye

        public static Arrayx<int> HideOnEyeIds = new Arrayx<int>();
        public static Arrayx<HideOnEye> HideOnEyes = new Arrayx<HideOnEye>();

        public static void AddHideOnEye(HideOnEye component)
        {
            // Setup

            if (HideOnEyeIds.Elements == null)
            {
                HideOnEyeIds.Size = 8;
                HideOnEyeIds.Elements = new int[HideOnEyeIds.Size];
            }

            if (HideOnEyes.Elements == null)
            {
                HideOnEyes.Size = 8;
                HideOnEyes.Elements = new HideOnEye[HideOnEyes.Size];
            }

            // Add

            HideOnEyeIds.Elements[HideOnEyeIds.Length++] = component.gameObject.GetInstanceID();
            HideOnEyes.Elements[HideOnEyes.Length++] = component;

            // Resize check

            if (HideOnEyeIds.Length >= HideOnEyeIds.Size)
            {
                HideOnEyeIds.Size *= 2;
                Array.Resize(ref HideOnEyeIds.Elements, HideOnEyeIds.Size);

                HideOnEyes.Size *= 2;
                Array.Resize(ref HideOnEyes.Elements, HideOnEyes.Size);
            }
        }

        public static void RemoveHideOnEye(HideOnEye component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < HideOnEyeIds.Length; i++)
            {
                if (HideOnEyeIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                HideOnEyeIds.Elements, indexToRemove + 1,
                HideOnEyeIds.Elements, indexToRemove,
                HideOnEyeIds.Length - indexToRemove - 1);
            HideOnEyeIds.Length--;

            Array.Copy(
                HideOnEyes.Elements, indexToRemove + 1,
                HideOnEyes.Elements, indexToRemove,
                HideOnEyes.Length - indexToRemove - 1);
            HideOnEyes.Length--;

            // Cache clean up

            HideOnEyeIdCache.Clear();
        }

        public static Arrayx<HideOnEye> GetHideOnEye(params Arrayx<int>[] ids)
        {
            // HideOnEyeIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] HideOnEyePlusIds = new Arrayx<int>[ids.Length + 1];
            HideOnEyePlusIds[0] = HideOnEyeIds;
            Array.Copy(ids, 0, HideOnEyePlusIds, 1, ids.Length);

            return Gigas.Get<HideOnEye>(HideOnEyePlusIds, EntitySet.HideOnEyes);
        }

        public static HideOnEye GetHideOnEye(MonoBehaviour component)
        {
            return GetHideOnEye(component.gameObject.GetInstanceID());
        }

        public static HideOnEye GetHideOnEye(GameObject gameobject)
        {
            return GetHideOnEye(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> HideOnEyeIdCache = new Dictionary<int, int>();
        public static HideOnEye GetHideOnEye(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (HideOnEyeIdCache.ContainsKey(id))
                return HideOnEyes.Elements[HideOnEyeIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < HideOnEyeIds.Length; i++)
            {
                if (HideOnEyeIds.Elements[i] == id)
                {
                    index = i;
                    HideOnEyeIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return HideOnEyes.Elements[index];
        }

        // Interact

        public static Arrayx<int> InteractIds = new Arrayx<int>();
        public static Arrayx<Interact> Interacts = new Arrayx<Interact>();

        public static void AddInteract(Interact component)
        {
            // Setup

            if (InteractIds.Elements == null)
            {
                InteractIds.Size = 8;
                InteractIds.Elements = new int[InteractIds.Size];
            }

            if (Interacts.Elements == null)
            {
                Interacts.Size = 8;
                Interacts.Elements = new Interact[Interacts.Size];
            }

            // Add

            InteractIds.Elements[InteractIds.Length++] = component.gameObject.GetInstanceID();
            Interacts.Elements[Interacts.Length++] = component;

            // Resize check

            if (InteractIds.Length >= InteractIds.Size)
            {
                InteractIds.Size *= 2;
                Array.Resize(ref InteractIds.Elements, InteractIds.Size);

                Interacts.Size *= 2;
                Array.Resize(ref Interacts.Elements, Interacts.Size);
            }
        }

        public static void RemoveInteract(Interact component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < InteractIds.Length; i++)
            {
                if (InteractIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                InteractIds.Elements, indexToRemove + 1,
                InteractIds.Elements, indexToRemove,
                InteractIds.Length - indexToRemove - 1);
            InteractIds.Length--;

            Array.Copy(
                Interacts.Elements, indexToRemove + 1,
                Interacts.Elements, indexToRemove,
                Interacts.Length - indexToRemove - 1);
            Interacts.Length--;

            // Cache clean up

            InteractIdCache.Clear();
        }

        public static Arrayx<Interact> GetInteract(params Arrayx<int>[] ids)
        {
            // InteractIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] InteractPlusIds = new Arrayx<int>[ids.Length + 1];
            InteractPlusIds[0] = InteractIds;
            Array.Copy(ids, 0, InteractPlusIds, 1, ids.Length);

            return Gigas.Get<Interact>(InteractPlusIds, EntitySet.Interacts);
        }

        public static Interact GetInteract(MonoBehaviour component)
        {
            return GetInteract(component.gameObject.GetInstanceID());
        }

        public static Interact GetInteract(GameObject gameobject)
        {
            return GetInteract(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> InteractIdCache = new Dictionary<int, int>();
        public static Interact GetInteract(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (InteractIdCache.ContainsKey(id))
                return Interacts.Elements[InteractIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < InteractIds.Length; i++)
            {
                if (InteractIds.Elements[i] == id)
                {
                    index = i;
                    InteractIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return Interacts.Elements[index];
        }

        // InteractPoint

        public static Arrayx<int> InteractPointIds = new Arrayx<int>();
        public static Arrayx<InteractPoint> InteractPoints = new Arrayx<InteractPoint>();

        public static void AddInteractPoint(InteractPoint component)
        {
            // Setup

            if (InteractPointIds.Elements == null)
            {
                InteractPointIds.Size = 8;
                InteractPointIds.Elements = new int[InteractPointIds.Size];
            }

            if (InteractPoints.Elements == null)
            {
                InteractPoints.Size = 8;
                InteractPoints.Elements = new InteractPoint[InteractPoints.Size];
            }

            // Add

            InteractPointIds.Elements[InteractPointIds.Length++] = component.gameObject.GetInstanceID();
            InteractPoints.Elements[InteractPoints.Length++] = component;

            // Resize check

            if (InteractPointIds.Length >= InteractPointIds.Size)
            {
                InteractPointIds.Size *= 2;
                Array.Resize(ref InteractPointIds.Elements, InteractPointIds.Size);

                InteractPoints.Size *= 2;
                Array.Resize(ref InteractPoints.Elements, InteractPoints.Size);
            }
        }

        public static void RemoveInteractPoint(InteractPoint component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < InteractPointIds.Length; i++)
            {
                if (InteractPointIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                InteractPointIds.Elements, indexToRemove + 1,
                InteractPointIds.Elements, indexToRemove,
                InteractPointIds.Length - indexToRemove - 1);
            InteractPointIds.Length--;

            Array.Copy(
                InteractPoints.Elements, indexToRemove + 1,
                InteractPoints.Elements, indexToRemove,
                InteractPoints.Length - indexToRemove - 1);
            InteractPoints.Length--;

            // Cache clean up

            InteractPointIdCache.Clear();
        }

        public static Arrayx<InteractPoint> GetInteractPoint(params Arrayx<int>[] ids)
        {
            // InteractPointIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] InteractPointPlusIds = new Arrayx<int>[ids.Length + 1];
            InteractPointPlusIds[0] = InteractPointIds;
            Array.Copy(ids, 0, InteractPointPlusIds, 1, ids.Length);

            return Gigas.Get<InteractPoint>(InteractPointPlusIds, EntitySet.InteractPoints);
        }

        public static InteractPoint GetInteractPoint(MonoBehaviour component)
        {
            return GetInteractPoint(component.gameObject.GetInstanceID());
        }

        public static InteractPoint GetInteractPoint(GameObject gameobject)
        {
            return GetInteractPoint(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> InteractPointIdCache = new Dictionary<int, int>();
        public static InteractPoint GetInteractPoint(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (InteractPointIdCache.ContainsKey(id))
                return InteractPoints.Elements[InteractPointIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < InteractPointIds.Length; i++)
            {
                if (InteractPointIds.Elements[i] == id)
                {
                    index = i;
                    InteractPointIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return InteractPoints.Elements[index];
        }

        // Izzy

        public static Arrayx<int> IzzyIds = new Arrayx<int>();
        public static Arrayx<Izzy> Izzys = new Arrayx<Izzy>();

        public static void AddIzzy(Izzy component)
        {
            // Setup

            if (IzzyIds.Elements == null)
            {
                IzzyIds.Size = 8;
                IzzyIds.Elements = new int[IzzyIds.Size];
            }

            if (Izzys.Elements == null)
            {
                Izzys.Size = 8;
                Izzys.Elements = new Izzy[Izzys.Size];
            }

            // Add

            IzzyIds.Elements[IzzyIds.Length++] = component.gameObject.GetInstanceID();
            Izzys.Elements[Izzys.Length++] = component;

            // Resize check

            if (IzzyIds.Length >= IzzyIds.Size)
            {
                IzzyIds.Size *= 2;
                Array.Resize(ref IzzyIds.Elements, IzzyIds.Size);

                Izzys.Size *= 2;
                Array.Resize(ref Izzys.Elements, Izzys.Size);
            }
        }

        public static void RemoveIzzy(Izzy component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < IzzyIds.Length; i++)
            {
                if (IzzyIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                IzzyIds.Elements, indexToRemove + 1,
                IzzyIds.Elements, indexToRemove,
                IzzyIds.Length - indexToRemove - 1);
            IzzyIds.Length--;

            Array.Copy(
                Izzys.Elements, indexToRemove + 1,
                Izzys.Elements, indexToRemove,
                Izzys.Length - indexToRemove - 1);
            Izzys.Length--;

            // Cache clean up

            IzzyIdCache.Clear();
        }

        public static Arrayx<Izzy> GetIzzy(params Arrayx<int>[] ids)
        {
            // IzzyIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] IzzyPlusIds = new Arrayx<int>[ids.Length + 1];
            IzzyPlusIds[0] = IzzyIds;
            Array.Copy(ids, 0, IzzyPlusIds, 1, ids.Length);

            return Gigas.Get<Izzy>(IzzyPlusIds, EntitySet.Izzys);
        }

        public static Izzy GetIzzy(MonoBehaviour component)
        {
            return GetIzzy(component.gameObject.GetInstanceID());
        }

        public static Izzy GetIzzy(GameObject gameobject)
        {
            return GetIzzy(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> IzzyIdCache = new Dictionary<int, int>();
        public static Izzy GetIzzy(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (IzzyIdCache.ContainsKey(id))
                return Izzys.Elements[IzzyIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < IzzyIds.Length; i++)
            {
                if (IzzyIds.Elements[i] == id)
                {
                    index = i;
                    IzzyIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return Izzys.Elements[index];
        }

        // LookAtVoidPlayer

        public static Arrayx<int> LookAtVoidPlayerIds = new Arrayx<int>();
        public static Arrayx<LookAtVoidPlayer> LookAtVoidPlayers = new Arrayx<LookAtVoidPlayer>();

        public static void AddLookAtVoidPlayer(LookAtVoidPlayer component)
        {
            // Setup

            if (LookAtVoidPlayerIds.Elements == null)
            {
                LookAtVoidPlayerIds.Size = 8;
                LookAtVoidPlayerIds.Elements = new int[LookAtVoidPlayerIds.Size];
            }

            if (LookAtVoidPlayers.Elements == null)
            {
                LookAtVoidPlayers.Size = 8;
                LookAtVoidPlayers.Elements = new LookAtVoidPlayer[LookAtVoidPlayers.Size];
            }

            // Add

            LookAtVoidPlayerIds.Elements[LookAtVoidPlayerIds.Length++] = component.gameObject.GetInstanceID();
            LookAtVoidPlayers.Elements[LookAtVoidPlayers.Length++] = component;

            // Resize check

            if (LookAtVoidPlayerIds.Length >= LookAtVoidPlayerIds.Size)
            {
                LookAtVoidPlayerIds.Size *= 2;
                Array.Resize(ref LookAtVoidPlayerIds.Elements, LookAtVoidPlayerIds.Size);

                LookAtVoidPlayers.Size *= 2;
                Array.Resize(ref LookAtVoidPlayers.Elements, LookAtVoidPlayers.Size);
            }
        }

        public static void RemoveLookAtVoidPlayer(LookAtVoidPlayer component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < LookAtVoidPlayerIds.Length; i++)
            {
                if (LookAtVoidPlayerIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                LookAtVoidPlayerIds.Elements, indexToRemove + 1,
                LookAtVoidPlayerIds.Elements, indexToRemove,
                LookAtVoidPlayerIds.Length - indexToRemove - 1);
            LookAtVoidPlayerIds.Length--;

            Array.Copy(
                LookAtVoidPlayers.Elements, indexToRemove + 1,
                LookAtVoidPlayers.Elements, indexToRemove,
                LookAtVoidPlayers.Length - indexToRemove - 1);
            LookAtVoidPlayers.Length--;

            // Cache clean up

            LookAtVoidPlayerIdCache.Clear();
        }

        public static Arrayx<LookAtVoidPlayer> GetLookAtVoidPlayer(params Arrayx<int>[] ids)
        {
            // LookAtVoidPlayerIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] LookAtVoidPlayerPlusIds = new Arrayx<int>[ids.Length + 1];
            LookAtVoidPlayerPlusIds[0] = LookAtVoidPlayerIds;
            Array.Copy(ids, 0, LookAtVoidPlayerPlusIds, 1, ids.Length);

            return Gigas.Get<LookAtVoidPlayer>(LookAtVoidPlayerPlusIds, EntitySet.LookAtVoidPlayers);
        }

        public static LookAtVoidPlayer GetLookAtVoidPlayer(MonoBehaviour component)
        {
            return GetLookAtVoidPlayer(component.gameObject.GetInstanceID());
        }

        public static LookAtVoidPlayer GetLookAtVoidPlayer(GameObject gameobject)
        {
            return GetLookAtVoidPlayer(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> LookAtVoidPlayerIdCache = new Dictionary<int, int>();
        public static LookAtVoidPlayer GetLookAtVoidPlayer(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (LookAtVoidPlayerIdCache.ContainsKey(id))
                return LookAtVoidPlayers.Elements[LookAtVoidPlayerIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < LookAtVoidPlayerIds.Length; i++)
            {
                if (LookAtVoidPlayerIds.Elements[i] == id)
                {
                    index = i;
                    LookAtVoidPlayerIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return LookAtVoidPlayers.Elements[index];
        }

        // MainMessage

        public static Arrayx<int> MainMessageIds = new Arrayx<int>();
        public static Arrayx<MainMessage> MainMessages = new Arrayx<MainMessage>();

        public static void AddMainMessage(MainMessage component)
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
        }

        public static void RemoveMainMessage(MainMessage component)
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

        // PartyHouse

        public static Arrayx<int> PartyHouseIds = new Arrayx<int>();
        public static Arrayx<PartyHouse> PartyHouses = new Arrayx<PartyHouse>();

        public static void AddPartyHouse(PartyHouse component)
        {
            // Setup

            if (PartyHouseIds.Elements == null)
            {
                PartyHouseIds.Size = 8;
                PartyHouseIds.Elements = new int[PartyHouseIds.Size];
            }

            if (PartyHouses.Elements == null)
            {
                PartyHouses.Size = 8;
                PartyHouses.Elements = new PartyHouse[PartyHouses.Size];
            }

            // Add

            PartyHouseIds.Elements[PartyHouseIds.Length++] = component.gameObject.GetInstanceID();
            PartyHouses.Elements[PartyHouses.Length++] = component;

            // Resize check

            if (PartyHouseIds.Length >= PartyHouseIds.Size)
            {
                PartyHouseIds.Size *= 2;
                Array.Resize(ref PartyHouseIds.Elements, PartyHouseIds.Size);

                PartyHouses.Size *= 2;
                Array.Resize(ref PartyHouses.Elements, PartyHouses.Size);
            }
        }

        public static void RemovePartyHouse(PartyHouse component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < PartyHouseIds.Length; i++)
            {
                if (PartyHouseIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                PartyHouseIds.Elements, indexToRemove + 1,
                PartyHouseIds.Elements, indexToRemove,
                PartyHouseIds.Length - indexToRemove - 1);
            PartyHouseIds.Length--;

            Array.Copy(
                PartyHouses.Elements, indexToRemove + 1,
                PartyHouses.Elements, indexToRemove,
                PartyHouses.Length - indexToRemove - 1);
            PartyHouses.Length--;

            // Cache clean up

            PartyHouseIdCache.Clear();
        }

        public static Arrayx<PartyHouse> GetPartyHouse(params Arrayx<int>[] ids)
        {
            // PartyHouseIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] PartyHousePlusIds = new Arrayx<int>[ids.Length + 1];
            PartyHousePlusIds[0] = PartyHouseIds;
            Array.Copy(ids, 0, PartyHousePlusIds, 1, ids.Length);

            return Gigas.Get<PartyHouse>(PartyHousePlusIds, EntitySet.PartyHouses);
        }

        public static PartyHouse GetPartyHouse(MonoBehaviour component)
        {
            return GetPartyHouse(component.gameObject.GetInstanceID());
        }

        public static PartyHouse GetPartyHouse(GameObject gameobject)
        {
            return GetPartyHouse(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> PartyHouseIdCache = new Dictionary<int, int>();
        public static PartyHouse GetPartyHouse(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (PartyHouseIdCache.ContainsKey(id))
                return PartyHouses.Elements[PartyHouseIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < PartyHouseIds.Length; i++)
            {
                if (PartyHouseIds.Elements[i] == id)
                {
                    index = i;
                    PartyHouseIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return PartyHouses.Elements[index];
        }

        // PartyHouseHide

        public static Arrayx<int> PartyHouseHideIds = new Arrayx<int>();
        public static Arrayx<PartyHouseHide> PartyHouseHides = new Arrayx<PartyHouseHide>();

        public static void AddPartyHouseHide(PartyHouseHide component)
        {
            // Setup

            if (PartyHouseHideIds.Elements == null)
            {
                PartyHouseHideIds.Size = 8;
                PartyHouseHideIds.Elements = new int[PartyHouseHideIds.Size];
            }

            if (PartyHouseHides.Elements == null)
            {
                PartyHouseHides.Size = 8;
                PartyHouseHides.Elements = new PartyHouseHide[PartyHouseHides.Size];
            }

            // Add

            PartyHouseHideIds.Elements[PartyHouseHideIds.Length++] = component.gameObject.GetInstanceID();
            PartyHouseHides.Elements[PartyHouseHides.Length++] = component;

            // Resize check

            if (PartyHouseHideIds.Length >= PartyHouseHideIds.Size)
            {
                PartyHouseHideIds.Size *= 2;
                Array.Resize(ref PartyHouseHideIds.Elements, PartyHouseHideIds.Size);

                PartyHouseHides.Size *= 2;
                Array.Resize(ref PartyHouseHides.Elements, PartyHouseHides.Size);
            }
        }

        public static void RemovePartyHouseHide(PartyHouseHide component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < PartyHouseHideIds.Length; i++)
            {
                if (PartyHouseHideIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                PartyHouseHideIds.Elements, indexToRemove + 1,
                PartyHouseHideIds.Elements, indexToRemove,
                PartyHouseHideIds.Length - indexToRemove - 1);
            PartyHouseHideIds.Length--;

            Array.Copy(
                PartyHouseHides.Elements, indexToRemove + 1,
                PartyHouseHides.Elements, indexToRemove,
                PartyHouseHides.Length - indexToRemove - 1);
            PartyHouseHides.Length--;

            // Cache clean up

            PartyHouseHideIdCache.Clear();
        }

        public static Arrayx<PartyHouseHide> GetPartyHouseHide(params Arrayx<int>[] ids)
        {
            // PartyHouseHideIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] PartyHouseHidePlusIds = new Arrayx<int>[ids.Length + 1];
            PartyHouseHidePlusIds[0] = PartyHouseHideIds;
            Array.Copy(ids, 0, PartyHouseHidePlusIds, 1, ids.Length);

            return Gigas.Get<PartyHouseHide>(PartyHouseHidePlusIds, EntitySet.PartyHouseHides);
        }

        public static PartyHouseHide GetPartyHouseHide(MonoBehaviour component)
        {
            return GetPartyHouseHide(component.gameObject.GetInstanceID());
        }

        public static PartyHouseHide GetPartyHouseHide(GameObject gameobject)
        {
            return GetPartyHouseHide(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> PartyHouseHideIdCache = new Dictionary<int, int>();
        public static PartyHouseHide GetPartyHouseHide(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (PartyHouseHideIdCache.ContainsKey(id))
                return PartyHouseHides.Elements[PartyHouseHideIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < PartyHouseHideIds.Length; i++)
            {
                if (PartyHouseHideIds.Elements[i] == id)
                {
                    index = i;
                    PartyHouseHideIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return PartyHouseHides.Elements[index];
        }

        // Rin

        public static Arrayx<int> RinIds = new Arrayx<int>();
        public static Arrayx<Rin> Rins = new Arrayx<Rin>();

        public static void AddRin(Rin component)
        {
            // Setup

            if (RinIds.Elements == null)
            {
                RinIds.Size = 8;
                RinIds.Elements = new int[RinIds.Size];
            }

            if (Rins.Elements == null)
            {
                Rins.Size = 8;
                Rins.Elements = new Rin[Rins.Size];
            }

            // Add

            RinIds.Elements[RinIds.Length++] = component.gameObject.GetInstanceID();
            Rins.Elements[Rins.Length++] = component;

            // Resize check

            if (RinIds.Length >= RinIds.Size)
            {
                RinIds.Size *= 2;
                Array.Resize(ref RinIds.Elements, RinIds.Size);

                Rins.Size *= 2;
                Array.Resize(ref Rins.Elements, Rins.Size);
            }
        }

        public static void RemoveRin(Rin component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < RinIds.Length; i++)
            {
                if (RinIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                RinIds.Elements, indexToRemove + 1,
                RinIds.Elements, indexToRemove,
                RinIds.Length - indexToRemove - 1);
            RinIds.Length--;

            Array.Copy(
                Rins.Elements, indexToRemove + 1,
                Rins.Elements, indexToRemove,
                Rins.Length - indexToRemove - 1);
            Rins.Length--;

            // Cache clean up

            RinIdCache.Clear();
        }

        public static Arrayx<Rin> GetRin(params Arrayx<int>[] ids)
        {
            // RinIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] RinPlusIds = new Arrayx<int>[ids.Length + 1];
            RinPlusIds[0] = RinIds;
            Array.Copy(ids, 0, RinPlusIds, 1, ids.Length);

            return Gigas.Get<Rin>(RinPlusIds, EntitySet.Rins);
        }

        public static Rin GetRin(MonoBehaviour component)
        {
            return GetRin(component.gameObject.GetInstanceID());
        }

        public static Rin GetRin(GameObject gameobject)
        {
            return GetRin(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> RinIdCache = new Dictionary<int, int>();
        public static Rin GetRin(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (RinIdCache.ContainsKey(id))
                return Rins.Elements[RinIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < RinIds.Length; i++)
            {
                if (RinIds.Elements[i] == id)
                {
                    index = i;
                    RinIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return Rins.Elements[index];
        }

        // SoundClip

        public static Arrayx<int> SoundClipIds = new Arrayx<int>();
        public static Arrayx<SoundClip> SoundClips = new Arrayx<SoundClip>();

        public static void AddSoundClip(SoundClip component)
        {
            // Setup

            if (SoundClipIds.Elements == null)
            {
                SoundClipIds.Size = 8;
                SoundClipIds.Elements = new int[SoundClipIds.Size];
            }

            if (SoundClips.Elements == null)
            {
                SoundClips.Size = 8;
                SoundClips.Elements = new SoundClip[SoundClips.Size];
            }

            // Add

            SoundClipIds.Elements[SoundClipIds.Length++] = component.gameObject.GetInstanceID();
            SoundClips.Elements[SoundClips.Length++] = component;

            // Resize check

            if (SoundClipIds.Length >= SoundClipIds.Size)
            {
                SoundClipIds.Size *= 2;
                Array.Resize(ref SoundClipIds.Elements, SoundClipIds.Size);

                SoundClips.Size *= 2;
                Array.Resize(ref SoundClips.Elements, SoundClips.Size);
            }
        }

        public static void RemoveSoundClip(SoundClip component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < SoundClipIds.Length; i++)
            {
                if (SoundClipIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                SoundClipIds.Elements, indexToRemove + 1,
                SoundClipIds.Elements, indexToRemove,
                SoundClipIds.Length - indexToRemove - 1);
            SoundClipIds.Length--;

            Array.Copy(
                SoundClips.Elements, indexToRemove + 1,
                SoundClips.Elements, indexToRemove,
                SoundClips.Length - indexToRemove - 1);
            SoundClips.Length--;

            // Cache clean up

            SoundClipIdCache.Clear();
        }

        public static Arrayx<SoundClip> GetSoundClip(params Arrayx<int>[] ids)
        {
            // SoundClipIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] SoundClipPlusIds = new Arrayx<int>[ids.Length + 1];
            SoundClipPlusIds[0] = SoundClipIds;
            Array.Copy(ids, 0, SoundClipPlusIds, 1, ids.Length);

            return Gigas.Get<SoundClip>(SoundClipPlusIds, EntitySet.SoundClips);
        }

        public static SoundClip GetSoundClip(MonoBehaviour component)
        {
            return GetSoundClip(component.gameObject.GetInstanceID());
        }

        public static SoundClip GetSoundClip(GameObject gameobject)
        {
            return GetSoundClip(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> SoundClipIdCache = new Dictionary<int, int>();
        public static SoundClip GetSoundClip(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (SoundClipIdCache.ContainsKey(id))
                return SoundClips.Elements[SoundClipIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < SoundClipIds.Length; i++)
            {
                if (SoundClipIds.Elements[i] == id)
                {
                    index = i;
                    SoundClipIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return SoundClips.Elements[index];
        }

        // Telepoint

        public static Arrayx<int> TelepointIds = new Arrayx<int>();
        public static Arrayx<Telepoint> Telepoints = new Arrayx<Telepoint>();

        public static void AddTelepoint(Telepoint component)
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
        }

        public static void RemoveTelepoint(Telepoint component)
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

        // TheGun

        public static Arrayx<int> TheGunIds = new Arrayx<int>();
        public static Arrayx<TheGun> TheGuns = new Arrayx<TheGun>();

        public static void AddTheGun(TheGun component)
        {
            // Setup

            if (TheGunIds.Elements == null)
            {
                TheGunIds.Size = 8;
                TheGunIds.Elements = new int[TheGunIds.Size];
            }

            if (TheGuns.Elements == null)
            {
                TheGuns.Size = 8;
                TheGuns.Elements = new TheGun[TheGuns.Size];
            }

            // Add

            TheGunIds.Elements[TheGunIds.Length++] = component.gameObject.GetInstanceID();
            TheGuns.Elements[TheGuns.Length++] = component;

            // Resize check

            if (TheGunIds.Length >= TheGunIds.Size)
            {
                TheGunIds.Size *= 2;
                Array.Resize(ref TheGunIds.Elements, TheGunIds.Size);

                TheGuns.Size *= 2;
                Array.Resize(ref TheGuns.Elements, TheGuns.Size);
            }
        }

        public static void RemoveTheGun(TheGun component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < TheGunIds.Length; i++)
            {
                if (TheGunIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                TheGunIds.Elements, indexToRemove + 1,
                TheGunIds.Elements, indexToRemove,
                TheGunIds.Length - indexToRemove - 1);
            TheGunIds.Length--;

            Array.Copy(
                TheGuns.Elements, indexToRemove + 1,
                TheGuns.Elements, indexToRemove,
                TheGuns.Length - indexToRemove - 1);
            TheGuns.Length--;

            // Cache clean up

            TheGunIdCache.Clear();
        }

        public static Arrayx<TheGun> GetTheGun(params Arrayx<int>[] ids)
        {
            // TheGunIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] TheGunPlusIds = new Arrayx<int>[ids.Length + 1];
            TheGunPlusIds[0] = TheGunIds;
            Array.Copy(ids, 0, TheGunPlusIds, 1, ids.Length);

            return Gigas.Get<TheGun>(TheGunPlusIds, EntitySet.TheGuns);
        }

        public static TheGun GetTheGun(MonoBehaviour component)
        {
            return GetTheGun(component.gameObject.GetInstanceID());
        }

        public static TheGun GetTheGun(GameObject gameobject)
        {
            return GetTheGun(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> TheGunIdCache = new Dictionary<int, int>();
        public static TheGun GetTheGun(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (TheGunIdCache.ContainsKey(id))
                return TheGuns.Elements[TheGunIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < TheGunIds.Length; i++)
            {
                if (TheGunIds.Elements[i] == id)
                {
                    index = i;
                    TheGunIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return TheGuns.Elements[index];
        }

        // VoidCam

        public static Arrayx<int> VoidCamIds = new Arrayx<int>();
        public static Arrayx<VoidCam> VoidCams = new Arrayx<VoidCam>();

        public static void AddVoidCam(VoidCam component)
        {
            // Setup

            if (VoidCamIds.Elements == null)
            {
                VoidCamIds.Size = 8;
                VoidCamIds.Elements = new int[VoidCamIds.Size];
            }

            if (VoidCams.Elements == null)
            {
                VoidCams.Size = 8;
                VoidCams.Elements = new VoidCam[VoidCams.Size];
            }

            // Add

            VoidCamIds.Elements[VoidCamIds.Length++] = component.gameObject.GetInstanceID();
            VoidCams.Elements[VoidCams.Length++] = component;

            // Resize check

            if (VoidCamIds.Length >= VoidCamIds.Size)
            {
                VoidCamIds.Size *= 2;
                Array.Resize(ref VoidCamIds.Elements, VoidCamIds.Size);

                VoidCams.Size *= 2;
                Array.Resize(ref VoidCams.Elements, VoidCams.Size);
            }
        }

        public static void RemoveVoidCam(VoidCam component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < VoidCamIds.Length; i++)
            {
                if (VoidCamIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                VoidCamIds.Elements, indexToRemove + 1,
                VoidCamIds.Elements, indexToRemove,
                VoidCamIds.Length - indexToRemove - 1);
            VoidCamIds.Length--;

            Array.Copy(
                VoidCams.Elements, indexToRemove + 1,
                VoidCams.Elements, indexToRemove,
                VoidCams.Length - indexToRemove - 1);
            VoidCams.Length--;

            // Cache clean up

            VoidCamIdCache.Clear();
        }

        public static Arrayx<VoidCam> GetVoidCam(params Arrayx<int>[] ids)
        {
            // VoidCamIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] VoidCamPlusIds = new Arrayx<int>[ids.Length + 1];
            VoidCamPlusIds[0] = VoidCamIds;
            Array.Copy(ids, 0, VoidCamPlusIds, 1, ids.Length);

            return Gigas.Get<VoidCam>(VoidCamPlusIds, EntitySet.VoidCams);
        }

        public static VoidCam GetVoidCam(MonoBehaviour component)
        {
            return GetVoidCam(component.gameObject.GetInstanceID());
        }

        public static VoidCam GetVoidCam(GameObject gameobject)
        {
            return GetVoidCam(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> VoidCamIdCache = new Dictionary<int, int>();
        public static VoidCam GetVoidCam(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (VoidCamIdCache.ContainsKey(id))
                return VoidCams.Elements[VoidCamIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < VoidCamIds.Length; i++)
            {
                if (VoidCamIds.Elements[i] == id)
                {
                    index = i;
                    VoidCamIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return VoidCams.Elements[index];
        }

        // VoidPlayer

        public static Arrayx<int> VoidPlayerIds = new Arrayx<int>();
        public static Arrayx<VoidPlayer> VoidPlayers = new Arrayx<VoidPlayer>();

        public static void AddVoidPlayer(VoidPlayer component)
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
        }

        public static void RemoveVoidPlayer(VoidPlayer component)
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

        // WatchingTheSea

        public static Arrayx<int> WatchingTheSeaIds = new Arrayx<int>();
        public static Arrayx<WatchingTheSea> WatchingTheSeas = new Arrayx<WatchingTheSea>();

        public static void AddWatchingTheSea(WatchingTheSea component)
        {
            // Setup

            if (WatchingTheSeaIds.Elements == null)
            {
                WatchingTheSeaIds.Size = 8;
                WatchingTheSeaIds.Elements = new int[WatchingTheSeaIds.Size];
            }

            if (WatchingTheSeas.Elements == null)
            {
                WatchingTheSeas.Size = 8;
                WatchingTheSeas.Elements = new WatchingTheSea[WatchingTheSeas.Size];
            }

            // Add

            WatchingTheSeaIds.Elements[WatchingTheSeaIds.Length++] = component.gameObject.GetInstanceID();
            WatchingTheSeas.Elements[WatchingTheSeas.Length++] = component;

            // Resize check

            if (WatchingTheSeaIds.Length >= WatchingTheSeaIds.Size)
            {
                WatchingTheSeaIds.Size *= 2;
                Array.Resize(ref WatchingTheSeaIds.Elements, WatchingTheSeaIds.Size);

                WatchingTheSeas.Size *= 2;
                Array.Resize(ref WatchingTheSeas.Elements, WatchingTheSeas.Size);
            }
        }

        public static void RemoveWatchingTheSea(WatchingTheSea component)
        {
            // Index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < WatchingTheSeaIds.Length; i++)
            {
                if (WatchingTheSeaIds.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                WatchingTheSeaIds.Elements, indexToRemove + 1,
                WatchingTheSeaIds.Elements, indexToRemove,
                WatchingTheSeaIds.Length - indexToRemove - 1);
            WatchingTheSeaIds.Length--;

            Array.Copy(
                WatchingTheSeas.Elements, indexToRemove + 1,
                WatchingTheSeas.Elements, indexToRemove,
                WatchingTheSeas.Length - indexToRemove - 1);
            WatchingTheSeas.Length--;

            // Cache clean up

            WatchingTheSeaIdCache.Clear();
        }

        public static Arrayx<WatchingTheSea> GetWatchingTheSea(params Arrayx<int>[] ids)
        {
            // WatchingTheSeaIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] WatchingTheSeaPlusIds = new Arrayx<int>[ids.Length + 1];
            WatchingTheSeaPlusIds[0] = WatchingTheSeaIds;
            Array.Copy(ids, 0, WatchingTheSeaPlusIds, 1, ids.Length);

            return Gigas.Get<WatchingTheSea>(WatchingTheSeaPlusIds, EntitySet.WatchingTheSeas);
        }

        public static WatchingTheSea GetWatchingTheSea(MonoBehaviour component)
        {
            return GetWatchingTheSea(component.gameObject.GetInstanceID());
        }

        public static WatchingTheSea GetWatchingTheSea(GameObject gameobject)
        {
            return GetWatchingTheSea(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> WatchingTheSeaIdCache = new Dictionary<int, int>();
        public static WatchingTheSea GetWatchingTheSea(int instanceID)
        {
            var id = instanceID;

            // Cache

            if (WatchingTheSeaIdCache.ContainsKey(id))
                return WatchingTheSeas.Elements[WatchingTheSeaIdCache[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < WatchingTheSeaIds.Length; i++)
            {
                if (WatchingTheSeaIds.Elements[i] == id)
                {
                    index = i;
                    WatchingTheSeaIdCache[id] = i; // Cache
                    break;
                }
            }

            // Value

            if (index < 0)
                return null;

            return WatchingTheSeas.Elements[index];
        }


        public static void Clear()
        {
            BecauseOfReasonsIds.Length = 0;
            BecauseOfReasonss.Length = 0;

            BecauseThisReasonIds.Length = 0;
            BecauseThisReasons.Length = 0;

            CattleyaIds.Length = 0;
            Cattleyas.Length = 0;

            ConversationIds.Length = 0;
            Conversations.Length = 0;

            DemonInvitationIds.Length = 0;
            DemonInvitations.Length = 0;

            DemonOfIds.Length = 0;
            DemonOfs.Length = 0;

            EyeOfCreatorIds.Length = 0;
            EyeOfCreators.Length = 0;

            EyeOfMindIds.Length = 0;
            EyeOfMinds.Length = 0;

            HideOnEyeIds.Length = 0;
            HideOnEyes.Length = 0;

            InteractIds.Length = 0;
            Interacts.Length = 0;

            InteractPointIds.Length = 0;
            InteractPoints.Length = 0;

            IzzyIds.Length = 0;
            Izzys.Length = 0;

            LookAtVoidPlayerIds.Length = 0;
            LookAtVoidPlayers.Length = 0;

            MainMessageIds.Length = 0;
            MainMessages.Length = 0;

            PartyHouseIds.Length = 0;
            PartyHouses.Length = 0;

            PartyHouseHideIds.Length = 0;
            PartyHouseHides.Length = 0;

            RinIds.Length = 0;
            Rins.Length = 0;

            SoundClipIds.Length = 0;
            SoundClips.Length = 0;

            TelepointIds.Length = 0;
            Telepoints.Length = 0;

            TheGunIds.Length = 0;
            TheGuns.Length = 0;

            VoidCamIds.Length = 0;
            VoidCams.Length = 0;

            VoidPlayerIds.Length = 0;
            VoidPlayers.Length = 0;

            WatchingTheSeaIds.Length = 0;
            WatchingTheSeas.Length = 0;
        }

        public static void ClearAlt()
        {
        }
    }
//  }
