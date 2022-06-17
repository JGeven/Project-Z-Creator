using Project_Z_Interface.DTO;

namespace Project_Z_Logic
{
    public class Occupations
    {
        public int ID { get; }   
        public string? Name { get; }
        public int Cost { get; }

        public Occupations(OccupationDto occupation)
        {
            ID = occupation.OccupationID;
            Name = occupation.Name;
            Cost = occupation.Cost;
        }
    }
}
