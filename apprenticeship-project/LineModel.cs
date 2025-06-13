namespace apprenticeship_project;

public class LineModel
{
    private string _group = "";
    private DateTime _date = new();
    private double _quantity = 0;
    private double _value = 0;

    public string Group => _group;
    public DateTime Date => _date;
    public double Quantity => _quantity;
    public double Value => _value;


    //LineMethod constructor - have to be invoke to the end of counter that will have to count each line where group = written group by user 
//CHANGE '.' TO ',' BECAUSE DOUBLE WON'T WORK!!!!!!!!!!!!!!!!!!
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
            else if (counter == 4)
            {
                group = item;
            }
            else if (counter == 5)
            {
                value = item;
            }

            counter++;
        }
        
        _group = group;
        _date = DateTime.Parse(date);
        _quantity = double.Parse(quantity);
        _value = double.Parse(value);
    }
}