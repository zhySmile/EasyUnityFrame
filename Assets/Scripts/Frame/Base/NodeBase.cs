using System.Collections.Generic;

namespace U3DEventFrame
{
    public class NodeBase
    {
        public NodeBase Next;

        public NodeBase()
        {
            this.Next = null;
        }

        public NodeBase(NodeBase tmpNext)
        {
            this.Next = tmpNext;
        }

        public virtual void Dispose()
        {
            this.Next = null;
        }
    }

    public class NodeManagerBase
    {
        public Dictionary<string, NodeBase> Manager = null;

        public NodeManagerBase()
        {
            Manager = new Dictionary<string, NodeBase>();
        }

        public bool ContainsKey(string name)
        {
            return Manager.ContainsKey(name);
        }

        public void AddNode(string nodeKey, NodeBase values)
        {
            if (ContainsKey(nodeKey))
            {
                NodeBase topNode = Manager[nodeKey];

                while (topNode.Next != null)
                {
                    topNode = topNode.Next;
                }

                topNode.Next = values;
            }
            else
            {
                Manager.Add(nodeKey, values);
            }
        }

        public void ReleaseNode(string nodeKey)
        {
            if (ContainsKey(nodeKey))
            {
                NodeBase topNode = Manager[nodeKey];

                while (topNode.Next != null)
                {
                    NodeBase curNode = topNode;
                    topNode = topNode.Next;
                    curNode.Dispose();
                }
                
                topNode.Dispose();

                Manager.Remove(nodeKey);
            }
        }

        public void ReleaseNode(string nodeKey, NodeBase node)
        {
            if (!ContainsKey(nodeKey))
            {
                return;
            }
            else
            {
                NodeBase tmp = Manager[nodeKey];

                if (tmp == node)
                {
                    NodeBase header = tmp;

                    if (header.Next != null)
                    {
                        Manager[nodeKey] = tmp.Next;
                        header.Next = null;
                    }
                    else
                    {
                        Manager.Remove(nodeKey);
                    }
                }
                else
                {
                    while (tmp.Next != null && tmp.Next != node)
                    {
                        tmp = tmp.Next;
                    }

                    if (tmp.Next.Next != null)
                    {
                        NodeBase curNode = tmp.Next;
                        tmp.Next = curNode.Next;

                        curNode.Next = null;
                    }
                    else
                    {
                        tmp.Next = null;
                    }
                }
            }
        }

        public virtual void VisitorListNodes(string nodeKey)
        {
            if (ContainsKey(nodeKey))
            {
                NodeBase topNode = Manager[nodeKey];

                do
                {
                    topNode = topNode.Next;
                } while (topNode != null);
            }
        }

        public void Dispose()
        {
            Manager.Clear();
        }
    }

    public class EventNode
    {
        public MonoBase data;

        public EventNode Next;

        public EventNode(MonoBase tmp)
        {
            this.data = tmp;
            this.Next = null;
        }
    }
}
