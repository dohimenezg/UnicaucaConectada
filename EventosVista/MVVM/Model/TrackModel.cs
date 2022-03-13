namespace EventosVista.MVVM.Model
{
    public partial class TrackModel
    {
        public Albums Albums { get; set; }
    }

    public partial class Albums
    {
        public Item[] Items { get; set; }

        public long Limit { get; set; }
    }

    public partial class Item
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
