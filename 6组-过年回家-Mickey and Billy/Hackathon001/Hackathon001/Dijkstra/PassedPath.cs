using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Hackathon001.Dijkstra
{
    /// <summary>
    /// PassedPath 用于缓存计算过程中的到达某个节点的权值最小的路径
    /// </summary>
    public class PassedPath
    {
        private string curNodeID;
        private bool beProcessed;   //是否已被处理
        private double weight;        //累积的权值
        private ArrayList passedIDList; //路径

        public PassedPath(string ID)
        {
            this.curNodeID = ID;
            this.weight = double.MaxValue;
            this.passedIDList = new ArrayList();
            this.beProcessed = false;
        }

        #region property
        public bool BeProcessed
        {
            get
            {
                return this.beProcessed;
            }
            set
            {
                this.beProcessed = value;
            }
        }

        public string CurNodeID
        {
            get
            {
                return this.curNodeID;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }

        public ArrayList PassedIDList
        {
            get
            {
                return this.passedIDList;
            }
        }
        #endregion
    }
}
