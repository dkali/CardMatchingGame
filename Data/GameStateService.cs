namespace CardMatchingGame.Data;

public class GameStateService
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    public List<int> ImageIds = new List<int>();
    public int UniqueImageNum;

    public void InitGame(int rowSize, int columnsSize)
    {
        Rows = rowSize;
        Columns = columnsSize;
        ImageIds.Clear();

        //generate unique image IDs
        int imageNum = (Rows * Columns) / 2;
        UniqueImageNum = imageNum;
        Random rand = new Random();
        while (imageNum > 0)
        {
            int id = rand.Next(1001);
            if (!ImageIds.Contains(id))
            {
                ImageIds.Add(rand.Next(1001));
                imageNum--;
            }
        }
        // duplicate IDs
        ImageIds.AddRange(ImageIds);

        // shuffle elements
        for (int i = ImageIds.Count - 1; i >= 1; i--)
        {
            int j = rand.Next(i + 1);
            // swap _imageIds[j] and _imageIds[i]
            var temp = ImageIds[j];
            ImageIds[j] = ImageIds[i];
            ImageIds[i] = temp;
        }
    }
}