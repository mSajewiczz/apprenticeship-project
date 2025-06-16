namespace apprenticeship_project.Model;

public class LineModel
{
    private DateTime _date;
    private double _quantity;
    private double _value;
    public DateTime Date => _date;
    public double Quantity => _quantity;
    public double Value => _value;

    public LineModel(string line)
    {
        var group = "";
        var date = "";
        var quantity = "";
        var value = "";
        var splitedLine = line.Split(';');
        var counter = 0;

        foreach (var item in splitedLine)
        {
            if (counter == 2)
            {
                quantity = item;
            }
            else if (counter == 3)
            {
                date = item;
            }
            else if (counter == 5)
            {
                var correctItem = item.Replace('.', ',');
                value = correctItem;
            }

            counter++;
        }

        _date = DateTime.Parse(date);
        _quantity = double.Parse(quantity);
        _value = double.Parse(value);
    }
}