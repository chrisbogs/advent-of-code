using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Models
{
    public class DirectoryNode<T>
    {
        private T directoryName;
        private List<Tuple<string, int>> files; // name and size
        private List<DirectoryNode<T>> children = new();
        public DirectoryNode<T> Parent { get; private set; }

        public int Size => files.Sum(f => f.Item2) + children.Sum(x => x.Size);

        public DirectoryNode(T data, List<Tuple<string, int>> files, DirectoryNode<T> parent)
        {
            this.directoryName = data;
            this.files = files;
            this.Parent = parent;
            children = new List<DirectoryNode<T>>();
        }

        /// <summary>
        /// If the directory already exists, return it, otherwise return the newly added directory.
        /// </summary>
        public DirectoryNode<T> AddChild<W>(T directoryName, List<Tuple<string, int>> files)
        {
            var existing = children.FirstOrDefault(x => 
                x.directoryName.Equals(directoryName));
            if (existing == null)
            {
                var newNode = new DirectoryNode<T>(directoryName, files, this);
                children.Add(newNode);
                return newNode;
            }

            return existing;
        }

        public void AddFile(Tuple<string, int> file)
        {
            if (!files.Any(x => x.Item1 == file.Item1))
            {
                files.Add(file);
            }
        }

        internal DirectoryNode<T> FindChild(string param)
        {
            return children.FirstOrDefault(x=>x.directoryName.Equals(param.Trim().ToLower()));
        }

        public override string ToString()
        {
            return string.Join(", ", files.Select(x => $"{x.Item1}({x.Item2})"))
                + Environment.NewLine + "  "
                + string.Join(", ", children.Select(x => x.ToString()));
        }

        internal List<DirectoryNode<T>> FindAllChildrenLessThan(int size)
        {
            var directoryList = new List<DirectoryNode<T>>();
            if (Size <= size)
            {
                directoryList.Add(this);
            }
            foreach (var child in children)
            {
                directoryList.AddRange(child.FindAllChildrenLessThan(size));
            }
            return directoryList;
        }
        internal List<DirectoryNode<T>> FindAllChildrenGreaterThan(int size)
        {
            var directoryList = new List<DirectoryNode<T>>();
            if (Size >= size)
            {
                directoryList.Add(this);
            }
            foreach (var child in children)
            {
                directoryList.AddRange(child.FindAllChildrenGreaterThan(size));
            }
            return directoryList;
        }

    }
}