using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hackathon001.Dijkstra
{
          
    public class Node
    {
        private string iD ;
        private List<Edge> edgeList ;//Edge的集合－－出边表

        public Node(string id )
        {
            this.iD = id ;
            this.edgeList = new  List<Edge>() ;
        }

       #region property
        
        public string ID
        {
            get
          {
                return this.iD ;
            }
        }

        public List<Edge>  EdgeList
        {
            get
            {
                return this.edgeList ;
            }
        }
        #endregion
    }
}
