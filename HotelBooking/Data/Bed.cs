public class Bed
{
    public int BedId { get; set; }
    public SizeOfBed BedSize { get; set; }
    
    public enum SizeOfBed
    {
        Single,
        Double
    };

}