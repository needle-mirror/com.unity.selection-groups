﻿using System.Collections;
using System.Collections.Generic;
using Unity.SelectionGroups;
using Unity.SelectionGroups.Runtime;
using UnityEditor;
using UnityEngine;

namespace Unity.SelectionGroupsEditor
{
    public partial class SelectionGroup
    {
        /// <summary>
        /// Number of objects in this group that are available to be referenced. (Ie. they exist in a loaded scene)
        /// </summary>
        public int Count => PersistentReferenceCollection.LoadedObjectCount;

        public bool ShowMembers { get; set; }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Query
        {
            get => query;
            set => query = value;
        }

        public Color Color
        {
            get => color;
            set => color = value;
        }

        public HashSet<string> EnabledTools
        {
            get => enabledTools;
            set => enabledTools = value;
        }

        public SelectionGroupScope Scope
        {
            get => scope;
            set => scope = value;
        }

        public int GroupId
        {
            get => groupId;
            set => groupId = value;
        }
        
        public void OnDelete(ISelectionGroup group)
        {
            
        }

        public void Add(IList<Object> objectReferences)
        {
            foreach(var i in objectReferences) {
                var go = i as GameObject;
                if(go != null && string.IsNullOrEmpty(go.scene.path)) {
                    //GameObject is not saved into a scene, therefore it cannot be stored in a editor selection group.
                    throw new SelectionGroupException("Cannot add an Object from an unsaved scene.");
                } 
                PersistentReferenceCollection.Add(i);    
            }
        }

        public void Remove(IList<Object> objectReferences)
        {
            PersistentReferenceCollection.Remove(objectReferences);
        }

        public void Clear()
        {
            PersistentReferenceCollection.Clear();
        }

        /// <summary>
        /// Enumerator for all members of this group.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Object> GetEnumerator()
        {
            PersistentReferenceCollection.LoadObjects();
            return PersistentReferenceCollection.GetEnumerator();
        }
        /// <summary>
        /// Enumerable for all members of this group.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            PersistentReferenceCollection.LoadObjects();
            return PersistentReferenceCollection.GetEnumerator();
        }
    }
}