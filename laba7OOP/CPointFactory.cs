using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7OOP {
    class CPointFactory { 
        virtual public CPoint createPoint (string classname) {
            return null;
        }

        virtual public CPoint createPoint(string classname, int x, int y) {
            return null;
        }
    }

    class CMyPointFactory: CPointFactory {
        public CMyPointFactory() { }

        override public CPoint createPoint (string classname) {
            switch (classname) {
                case "Circle":
                    return new CCircle();
                case "Rectangle":
                    return new CRectangle();
                case "Triangle":
                    return new CTriangle();
                case "Segment":
                    return new CSegment();
                case "Group":
                    return new CGroup();
            }
            return null;
        }

        override public CPoint createPoint(string classname, int x, int y) {
            switch (classname) {
                case "Circle":
                    return new CCircle(x, y);
                case "Rectangle":
                    return new CRectangle(x, y);
                case "Triangle":
                    return new CTriangle(x, y);
                case "Segment":
                    return new CSegment(x, y);
                case "Group":
                    return new CGroup();
            }
            return null;
        }
    }
}


