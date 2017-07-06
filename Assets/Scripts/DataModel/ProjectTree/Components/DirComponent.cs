﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webservice.Response.ComponentTree;

namespace DataModel.ProjectTree.Components
{
    class DirComponent : TreeComponent
    {
        public readonly List<TreeComponent> components = new List<TreeComponent>();

        public DirComponent(Component component)
        {
            ID = component.id;
            Key = component.key;
            Name = component.name.Split('/').Last();
            Path = component.path;
            Qualifier = QualifierForString(component.qualifier);
            // TODO ADDYI  this.Metrics = component.measures;
        }

        private DirComponent(string dirName)
        {
            Name = dirName;
        }

        public override TreeComponent InsertComponentAt(string[] path, TreeComponent component)
        {
            if (component == null || path == null || path.Length < 0)
                return null;

            if (path.Length == 0)
                return UpdateComponent(component);

            TreeComponent tc = FindSubComponentInNode(path[0]);

            if (tc != null)
                return tc.InsertComponentAt(SubArray(path, 1, path.Length - 1), component);

            if (path.Length == 1)
            {
                components.Add(component);
                //TODO ADDYI components.Sort();
                return component;
            }

            tc = new DirComponent(path[0]);
            components.Add(tc);
            //TODO ADDYI components.Sort();
            return tc.InsertComponentAt(SubArray(path, 1, path.Length - 1), component);


        }

        public TreeComponent FindSubComponentInNode(string componentName)
        {
            foreach (TreeComponent c in components)
            {
                if (c.Name == componentName)
                    return c;
            }
            return null;
        }

        public override TreeComponent UpdateComponent(TreeComponent component)
        {
            if (component is DirComponent && this.Name == component.Name)
            {
                DirComponent d = (DirComponent)component;
                ID = d.ID;
                Key = d.Key;
                Name = d.Name.Split('/').Last();
                Path = d.Path;
                Qualifier = d.Qualifier;
                // TODO ADDYI  this.Metrics = d.Metrics;
                return this;
            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(base.ToString());
            foreach (TreeComponent tc in components)
            {
                s.Append("\n" + tc.ToString());
            }
            return s.ToString();
        }

    }
}
