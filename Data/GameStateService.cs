namespace CardMatchingGame.Data;

public class GameStateService
{
    private int _rows;
    private int _columns;
    private List<int> _imageIds = new List<int>();

    public void InitGame(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;

        //generate unique image IDs
        int imageNum = (_rows * _columns) / 2;
        Random rand = new Random();
        for (int i = 0; i < imageNum; i++)
        {
            _imageIds.Add(rand.Next(1001));
        }
        // duplicate IDs
        _imageIds.AddRange(_imageIds);

        // shuffle elements
        for (int i = _imageIds.Count - 1; i >= 1; i--)
        {
            int j = rand.Next(i + 1);
            // swap _imageIds[j] and _imageIds[i]
            var temp = _imageIds[j];
            _imageIds[j] = _imageIds[i];
            _imageIds[i] = temp;
        }
    }
}