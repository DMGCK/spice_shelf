namespace spice_shelf.Models
{
  public class Recipe
  {
    public int id { get; set; }
    public string picture { get; set; }
    public string title { get; set; }
    public string subtitle { get; set; }
    public string category { get; set; }
    public string creatorId { get; set; }

    public Profile Creator { get; set; }
  }
}