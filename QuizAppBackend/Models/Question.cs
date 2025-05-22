public class Question
{
    public int Id { get; set; }               // Primärschlüssel
    public string Text { get; set; } = string.Empty;   // Die Frage selbst

    // 4 Antwortmöglichkeiten
    public string Option1 { get; set; } = string.Empty;
    public string Option2 { get; set; } = string.Empty;
    public string Option3 { get; set; } = string.Empty;
    public string Option4 { get; set; } = string.Empty;

    // Richtige Antwort (z.B. 1,2,3 oder 4)
    public int CorrectOption { get; set; }
}
