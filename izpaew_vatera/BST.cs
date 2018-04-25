using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace izpaew_vatera
{
    public enum Bejarastipus
    {
        PreOrder, InOrder, PostOrder
    }


    class BST<K, T> where K : IComparable
    {
        private TreeNode root;

        public BST()
        {
            root = null;
        }
        class TreeNode
        {
            public K key;
            public T Value;
#pragma warning disable 0649
            // warning a variable never use-ra mivel az insert p-ként hivatkozik rá nem Left vagy Right-ként
            public TreeNode Left;
            public TreeNode Right;
#pragma warning restore 0649



            public TreeNode(K key, T value)
            {
                this.key = key;
                this.Value = value;
            }
            public override string ToString()
            {
                return $"{key} {Value}";
            }

            
        }

        public void Insert(K key, T value)
        {
            Insert(root, key, value);
        }

        private void Insert(TreeNode p, K key, T value)
        {
            if (p == null)
                p = new TreeNode(key, value);
            else if (p.key.CompareTo(key) < 0)
                Insert( p.Right, key, value);
            else if (p.key.CompareTo(key) > 0)
                Insert( p.Left, key, value);
            else
                throw new KeyCollisionException("kulcs ütközés");
        }
    }
    class BST<T>
    {
        TreeNode root;

        public BST()
        {
            root = null;//üres fa
        }

        public List<T> Bejaras(Bejarastipus tipus)
        {
            List<T> output = new List<T>();
            if (tipus == Bejarastipus.PreOrder)
            {
                PreOrder(root,ref output);
            }
            else if (tipus == Bejarastipus.InOrder)
            {
                InOrder(root,ref output);
            }
            else
            {
                PostOrder(root,ref output);
            }
            return output;
        }

        private void PreOrder(TreeNode p,ref List<T> ts)
        {
            if (p != null)
            {
                ts.Add(p.Value);
                PreOrder(p.Left,ref ts);
                PreOrder(p.Right,ref ts);
            }
        }

        private void InOrder(TreeNode p, ref List<T> ts)
        {
            if (p != null)
            {
                InOrder(p.Left,ref ts);
                ts.Add(p.Value);
                InOrder(p.Right,ref ts);
            }
        }

        private void PostOrder(TreeNode p, ref List<T> ts)
        {
            if (p != null)
            {
                PostOrder(p.Left,ref ts);
                PostOrder(p.Right,ref ts);
                ts.Add(p.Value);
            }
        }

        public T FindItemByKey(int key)
        {
            if (root != null)
                return FindItemByKey(key, root);
            else
                return default(T);
        }

        private T FindItemByKey(int key, TreeNode p)
        {
            if (key == p.key)
                return p.Value;
            if (key < p.key)
            {
                if (p.Left != null)
                    return FindItemByKey(key, p.Left);
                else
                    return default(T);

            }
            else
            {
                if (p.Right != null)
                    return FindItemByKey(key, p.Right);
                else
                    return default(T);
            }
        }
        public void Insert(int key, T value)
        {

            Insert(ref root, key, value);
        }

        private void Insert(ref TreeNode p, int key, T value)
        {
            if (p == null)
                p = new TreeNode(key, value);
            else if (p.key < key)
                Insert(ref p.Right, key, value);
            else if (p.key > key)
                Insert(ref p.Left, key, value);
            else
                throw new KeyCollisionException("kulcs ütközés");
        }
        class TreeNode
        {
            public int key;
            public T Value;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(int key, T value)
            {
                this.key = key;
                this.Value = value;
            }

            public override string ToString()
            {
                return $"{this.key}  {this.Value}";
            }
        }

    }




    class BSTTester
    {
        static void Test()
        {
            BST<string> bst = new BST<string>();
            bst.Insert(10, "Ironman");
            bst.Insert(20, "Hulk");
            bst.Insert(7, "Vision");
            bst.Insert(30, "Black Panther");

            Console.WriteLine("pre");
            bst.Bejaras(Bejarastipus.PreOrder);
            Console.WriteLine("in");
            bst.Bejaras(Bejarastipus.InOrder);
            Console.WriteLine("post");
            bst.Bejaras(Bejarastipus.PostOrder);
        }
    }
}
