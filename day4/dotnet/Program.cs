
var lines = File.ReadLines("input.txt");
var rowLen = lines.Count();
var colLen = lines.First().Length;

var grid = new int[][] { };

Array.Resize(ref grid, colLen);

for (int i = 0; i < colLen; i++)
{
    Array.Resize(ref grid[i], rowLen);
}
int row = 0;
foreach (var line in lines)
{
    for (int col = 0; col < line.Length; col++)
    {
        grid[col][row] = line[col];
    }
    row++;
}

//Part1(grid);
Part2(grid);

void Part2(int[][] grid)
{
    int total = 0;

    for (int i = 0; i <= grid.Length; i++)
    {
        for (int j = 0; j <= grid[0].Length; j++)
        {
            var instances = 0;
            
            if (CheckXHasMLowerLeft(grid, i, j)) instances++;
            if (CheckXHasMLowerRight(grid, i, j)) instances++;
            if (CheckXHasMUpperLeft(grid, i, j)) instances++;
            if (CheckXHasMUpperRight(grid, i, j)) instances++;
            
            if (instances >= 2) total++;
        }
    }

    Console.WriteLine(total);
}


void Part1(int[][] grid)
{

    int total = 0;

    for (int i = 0; i <= grid.Length; i++)
    {
        for (int j = 0; j <= grid[0].Length; j++)
        {
            if (CheckLeft(grid, i, j)) total++;
            if (CheckRight(grid, i, j)) total++;
            if (CheckUp(grid, i, j)) total++;
            if (CheckDown(grid, i, j)) total++;
            if (CheckUpperRight(grid, i, j)) total++;
            if (CheckUpperLeft(grid, i, j)) total++;
            if (CheckLowerRight(grid, i, j)) total++;
            if (CheckLowerLeft(grid, i, j)) total++;
        }
    }

    Console.WriteLine(total);

}


bool Validate(int[][] grid, int row, int col, char letter)
{
    return letter == grid[col][row];
}


bool CheckXHasMLowerRight(int[][] grid, int row, int col) {
    var (mrow, mcol) = (row + 1, col + 1);
    var (arow, acol) = (row , col );
    var (srow, scol) = (row - 1, col - 1);

    var oob = OutOfBounds(grid, mrow, mcol)|| OutOfBounds(grid, arow, acol)  || OutOfBounds(grid, srow, scol);
    if (oob) return false;
    return Validate(grid, mrow, mcol, 'M')  && Validate(grid, arow, acol, 'A')  && Validate(grid, srow, scol, 'S');
    
}
bool CheckXHasMLowerLeft(int[][] grid, int row, int col) {
    var (mrow, mcol) = (row + 1, col - 1);
    var (arow, acol) = (row , col );
    var (srow, scol) = (row - 1, col + 1);

    var oob = OutOfBounds(grid, mrow, mcol)|| OutOfBounds(grid, arow, acol)  || OutOfBounds(grid, srow, scol);
    if (oob) return false;
    return Validate(grid, mrow, mcol, 'M')  && Validate(grid, arow, acol, 'A')  && Validate(grid, srow, scol, 'S');

}

bool CheckXHasMUpperRight(int[][] grid, int row, int col) {
    var (mrow, mcol) = (row - 1, col + 1);
    var (arow, acol) = (row , col );
    var (srow, scol) = (row + 1, col - 1);

    var oob = OutOfBounds(grid, mrow, mcol)|| OutOfBounds(grid, arow, acol)  || OutOfBounds(grid, srow, scol);
    if (oob) return false;
    return Validate(grid, mrow, mcol, 'M')  && Validate(grid, arow, acol, 'A')  && Validate(grid, srow, scol, 'S');
}
bool CheckXHasMUpperLeft(int[][] grid, int row, int col) {
    var (mrow, mcol) = (row - 1, col - 1);
    var (arow, acol) = (row , col );
    var (srow, scol) = (row + 1, col + 1);

    var oob = OutOfBounds(grid, mrow, mcol)|| OutOfBounds(grid, arow, acol)  || OutOfBounds(grid, srow, scol);
    if (oob) return false;
    return Validate(grid, mrow, mcol, 'M')  && Validate(grid, arow, acol, 'A')  && Validate(grid, srow, scol, 'S');
}


bool CheckLeft(int[][] grid, int row, int col)
{
    var (xrow, xcol) = (row, col - 0);
    var (mrow, mcol) = (row, col - 1);
    var (arow, acol) = (row, col - 2);
    var (srow, scol) = (row, col - 3);

    var oob = OutOfBounds(grid, xrow, xcol) || OutOfBounds(grid, mrow, mcol) || OutOfBounds(grid, arow, acol) || OutOfBounds(grid, srow, scol);
    if (oob) return false;
    return Validate(grid, xrow, xcol, 'X') && Validate(grid, mrow, mcol, 'M') && Validate(grid, arow, acol, 'A') && Validate(grid, srow, scol, 'S');
}
bool CheckRight(int[][] grid, int row, int col)
{
    var (xrow, xcol) = (row, col + 0);
    var (mrow, mcol) = (row, col + 1);
    var (arow, acol) = (row, col + 2);
    var (srow, scol) = (row, col + 3);
    var oob = OutOfBounds(grid, xrow, xcol) || OutOfBounds(grid, mrow, mcol) || OutOfBounds(grid, arow, acol) || OutOfBounds(grid, srow, scol);
    if (oob) return false;
    return Validate(grid, xrow, xcol, 'X') && Validate(grid, mrow, mcol, 'M') && Validate(grid, arow, acol, 'A') && Validate(grid, srow, scol, 'S');
}
bool CheckUp(int[][] grid, int row, int col)
{
    var (xrow, xcol) = (row, col);
    var (mrow, mcol) = (row - 1, col);
    var (arow, acol) = (row - 2, col);
    var (srow, scol) = (row - 3, col);
    var oob = OutOfBounds(grid, xrow, xcol) || OutOfBounds(grid, mrow, mcol) || OutOfBounds(grid, arow, acol) || OutOfBounds(grid, srow, scol);
    if (oob) return false;
    return Validate(grid, xrow, xcol, 'X') && Validate(grid, mrow, mcol, 'M') && Validate(grid, arow, acol, 'A') && Validate(grid, srow, scol, 'S');
}
bool CheckDown(int[][] grid, int row, int col)
{
    var (xrow, xcol) = (row, col);
    var (mrow, mcol) = (row + 1, col);
    var (arow, acol) = (row + 2, col);
    var (srow, scol) = (row + 3, col);
    var oob = OutOfBounds(grid, xrow, xcol) || OutOfBounds(grid, mrow, mcol) || OutOfBounds(grid, arow, acol) || OutOfBounds(grid, srow, scol);
    if (oob) return false;
    return Validate(grid, xrow, xcol, 'X') && Validate(grid, mrow, mcol, 'M') && Validate(grid, arow, acol, 'A') && Validate(grid, srow, scol, 'S');
}
bool CheckUpperRight(int[][] grid, int row, int col)
{
    var (xrow, xcol) = (row, col);
    var (mrow, mcol) = (row - 1, col + 1);
    var (arow, acol) = (row - 2, col + 2);
    var (srow, scol) = (row - 3, col + 3);
    var oob = OutOfBounds(grid, xrow, xcol) || OutOfBounds(grid, mrow, mcol) || OutOfBounds(grid, arow, acol) || OutOfBounds(grid, srow, scol);
    if (oob) return false;
    return Validate(grid, xrow, xcol, 'X') && Validate(grid, mrow, mcol, 'M') && Validate(grid, arow, acol, 'A') && Validate(grid, srow, scol, 'S');
}
bool CheckUpperLeft(int[][] grid, int row, int col)
{
    var (xrow, xcol) = (row, col);
    var (mrow, mcol) = (row - 1, col - 1);
    var (arow, acol) = (row - 2, col - 2);
    var (srow, scol) = (row - 3, col - 3);
    var oob = OutOfBounds(grid, xrow, xcol) || OutOfBounds(grid, mrow, mcol) || OutOfBounds(grid, arow, acol) || OutOfBounds(grid, srow, scol);
    if (oob) return false;
    return Validate(grid, xrow, xcol, 'X') && Validate(grid, mrow, mcol, 'M') && Validate(grid, arow, acol, 'A') && Validate(grid, srow, scol, 'S');
}
bool CheckLowerRight(int[][] grid, int row, int col)
{
    var (xrow, xcol) = (row, col);
    var (mrow, mcol) = (row + 1, col + 1);
    var (arow, acol) = (row + 2, col + 2);
    var (srow, scol) = (row + 3, col + 3);
    var oob = OutOfBounds(grid, xrow, xcol) || OutOfBounds(grid, mrow, mcol) || OutOfBounds(grid, arow, acol) || OutOfBounds(grid, srow, scol);
    if (oob) return false;
    return Validate(grid, xrow, xcol, 'X') && Validate(grid, mrow, mcol, 'M') && Validate(grid, arow, acol, 'A') && Validate(grid, srow, scol, 'S');
}
bool CheckLowerLeft(int[][] grid, int row, int col)
{
    var (xrow, xcol) = (row, col);
    var (mrow, mcol) = (row + 1, col - 1);
    var (arow, acol) = (row + 2, col - 2);
    var (srow, scol) = (row + 3, col - 3);
    var oob = OutOfBounds(grid, xrow, xcol) || OutOfBounds(grid, mrow, mcol) || OutOfBounds(grid, arow, acol) || OutOfBounds(grid, srow, scol);
    if (oob) return false;
    return Validate(grid, xrow, xcol, 'X') && Validate(grid, mrow, mcol, 'M') && Validate(grid, arow, acol, 'A') && Validate(grid, srow, scol, 'S');
}

bool OutOfBounds(int[][] grid, int row, int col)
{
    return row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length;
}

/*
ABCDEFG
HIJKLMN     ---->  
QRSTUVW
*/