using System;

namespace Park
{
    class ParkRozvah
    {
        public delegate void VisitorAction(Visitor visitor);

        public event VisitorAction AllFunctionalityEvent;

        public void RideAmericanRollerCoaster(Visitor visitor)
        {
            visitor.RodeAmericanRollerCoaster = true;
            AllFunctionalityEvent?.Invoke(visitor);
        }

        public void ShootAtShootingRange(Visitor visitor)
        {
            visitor.ShotAtShootingRange = true;
            AllFunctionalityEvent?.Invoke(visitor);
        }

        public void VisitHouseOfFear(Visitor visitor)
        {
            visitor.VisitedHouseOfFear = true;
            AllFunctionalityEvent?.Invoke(visitor);
        }

        public void VisitHallOfMirrors(Visitor visitor)
        {
            visitor.VisitedHallOfMirrors = true;
            AllFunctionalityEvent?.Invoke(visitor);
        }

        public void EatPopcorn(Visitor visitor)
        {
            visitor.AtePopcorn = true;
            AllFunctionalityEvent?.Invoke(visitor);
        }

        public void RideFerrisWheel(Visitor visitor)
        {
            visitor.RodeFerrisWheel = true;
            AllFunctionalityEvent?.Invoke(visitor);
        }
    }

    class Visitor
    {
        public bool RodeAmericanRollerCoaster { get; set; }
        public bool ShotAtShootingRange { get; set; }
        public bool VisitedHouseOfFear { get; set; }
        public bool VisitedHallOfMirrors { get; set; }
        public bool AtePopcorn { get; set; }
        public bool RodeFerrisWheel { get; set; }
    }

    class Program
    {
        static void Main()
        {
            ParkRozvah park = new ParkRozvah();
            Visitor visitor = new Visitor();

            park.AllFunctionalityEvent += DisplayPropertyValues;

            park.RideAmericanRollerCoaster(visitor);
            park.ShootAtShootingRange(visitor);
            park.VisitHouseOfFear(visitor);
            park.VisitHallOfMirrors(visitor);
            park.EatPopcorn(visitor);
            park.RideFerrisWheel(visitor);
        }

        static void DisplayPropertyValues(Visitor visitor)
        {
            Console.WriteLine("Property Name -- Value");
            Console.WriteLine("RodeAmericanRollerCoaster -- " + visitor.RodeAmericanRollerCoaster);
            Console.WriteLine("ShotAtShootingRange -- " + visitor.ShotAtShootingRange);
            Console.WriteLine("VisitedHouseOfFear -- " + visitor.VisitedHouseOfFear);
            Console.WriteLine("VisitedHallOfMirrors -- " + visitor.VisitedHallOfMirrors);
            Console.WriteLine("AtePopcorn -- " + visitor.AtePopcorn);
            Console.WriteLine("RodeFerrisWheel -- " + visitor.RodeFerrisWheel);
        }
    }
}
