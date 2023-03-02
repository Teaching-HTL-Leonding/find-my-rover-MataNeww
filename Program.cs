#region Variables
const char NORTH = '^', EAST = '>', SOUTH = 'v', WEST = '<';
const int BASE_STATION = 0;
string input;
int east = 0, south = 0, north = 0, west = 0, position = 0, manhattan_distance = 0, number_of_movement = 0;
double linear_distance = 0;
#endregion

Console.Write("Enter your input: ");
input = Console.ReadLine()!.ToLower();

/*while (!(input.Contains('<')) && !(input.Contains('>')) && !(input.Contains('^')) && !(input.Contains('v')))
{
    Console.Write("Please enter a valid input: ");
    input = Console.ReadLine()!.ToLower();
}*/

var result = CalculateAndPrintResult(input);
Console.WriteLine(result);

Console.WriteLine();
var result_of_linearDistance = CalculateLinearDistance(north, east, south, west);
Console.WriteLine(result_of_linearDistance);

Console.WriteLine();

var result_of_manhattanDistance = CalculateManhattanDistance(north, east, south, west);
Console.WriteLine(result_of_manhattanDistance);


string CalculateAndPrintResult(string input)
{
    for (int i = 0; i < input.Length; i++)
    {
        char coordination = input[i];

        switch (coordination)
        {
            case NORTH:
                north++;
                south--;
                position++;
                break;

            case EAST:
                east++;
                west--;
                position++;
                break;

            case SOUTH:
                south++;
                north--;
                position--;
                break;

            case WEST:
                west++;
                east--;
                position--;
                break;

            default:
                TurnIntoInt(coordination, input[i - 1]);
                break;
        }
    }

    if (position == BASE_STATION) { Console.WriteLine("The rover is in the base station."); }

     if (east > 0 && west < 0) { west = 0; }
     if (north > 0 && south < 0) { south = 0; }
    if (south > 0 && north < 0) { north = 0; }
    if (west > 0 && east < 0) { east = 0; }

    return $"The rover is {east}m to the East, {north}m to the North, {south}m to the South, {west}m to the West.";
}

string CalculateManhattanDistance(int north, int east, int south, int west)
{
    manhattan_distance = (north - south) + (east - west);
    return $"Manhattan Distance: {manhattan_distance}";
}

string CalculateLinearDistance(double north, double east, double south, double west)
{
    linear_distance = Math.Sqrt((Math.Pow(north - south, 2)) + (Math.Pow(east - west, 2)));
    return $"Linear distance: {linear_distance:F2}";
}

int TurnIntoInt(char digit, char direction)
{
    string number = digit.ToString();
    number_of_movement = int.Parse(number);

    number_of_movement -= 1;

    if (direction == NORTH) { south -= number_of_movement;position += number_of_movement; return north += number_of_movement; }
    else if (direction == EAST) { west -= number_of_movement;position += number_of_movement;  return east += number_of_movement;  }
    else if (direction == SOUTH) { north -= number_of_movement;position += number_of_movement;  return south += number_of_movement; }
    else { east -= number_of_movement;position += number_of_movement; return west += number_of_movement; }
}