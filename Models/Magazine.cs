public class Magazine : IReadingMaterials, IThings
{
    public int MagId { get; set; }
    public string Name { get; set; }
    public int IssuerNo { get; set; }

    public BookGenre? Genre { get; set; }

}