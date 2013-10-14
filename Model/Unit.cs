using System;
using System.Collections.Generic;
using System.Linq;

namespace recursive_aggregation_linq.Model
{
    class Unit
    {
        private Unit parentUnit;

        public Unit()
        {
            childUnits = new List<Unit>();
            assignments = new List<Assignment>();
        }
        public Unit(Unit parent)
        {
            childUnits = new List<Unit>();
            assignments = new List<Assignment>();
            parentUnit = parent;
            parent.addUnit(this);
        }

        private List<Unit> childUnits;
        public IEnumerable<Unit> ChildUnits { get { return childUnits.AsReadOnly(); } }
        public void addUnit(Unit u)
        {
            childUnits.Add(u);
        }

        private List<Assignment> assignments;
        public IEnumerable<Assignment> Assignments { get { return assignments.AsReadOnly(); } }
        public void addAssignment(Assignment a)
        {
            assignments.Add(a);
        }
    }
}
