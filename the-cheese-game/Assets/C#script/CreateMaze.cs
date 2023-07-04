using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMaze : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject WallPrefab;
    GameObject wall;

    void makeMaze()
    {
        List<List<int>> maze = new List<List<int>>();
        for(int row=0; row<height; row++)
        {
            maze.Add(new List<int>());
            for (int column = 0; column < width; column++)
                maze[row].Add(0);
        }

        List<List<int>> chessboard = new List<List<int>>();
        for (int row = 0; row < 2*height+1; row++)
        {
            chessboard.Add(new List<int>());
            for (int column = 0; column < 2*width+1; column++)
                chessboard[row].Add(0);
        }

        int start_row = Random.Range(0, width);
        int start_column = Random.Range(0, height);

        makeRoute(start_row, start_column);

        for (int row = 0; row < 2*height+1; row++)
        {
            for (int column = 0; column < 2*width+1; column++)
                if (chessboard[row][column] == 0)
                {
                    wall = Instantiate(WallPrefab);
                    wall.transform.SetParent(this.transform);
                    wall.transform.localPosition = new Vector3(((float)row/(float)(2*width+1))-0.477f, ((float)column/(float)(2*height+1))-0.477f, 0);
                    wall.transform.localScale = new Vector3((0.25f/(float)(2 * width + 1)), (0.25f/(float)(2 * height + 1)), 0);
                }
        }

        void makeRoute(int row, int column)
        {
            maze[row][column] = 1;
            chessboard[2 * row + 1][2 * column + 1] = 1;
            where_to_visit(row, column);
        }

        void where_to_visit(int row, int column)
        {
            List<string> direction = new List<string>() { "up", "down", "left", "right" };

            while (direction.Count > 0)
            {
                string visit = direction[Random.Range(0, direction.Count)];
                direction.Remove(visit);

                switch (visit)
                {
                    case "up":
                        if (column > 0 && maze[row][column - 1] == 0)
                        {
                            chessboard[2 * row + 1][2 * column] = 1;
                            makeRoute(row, column - 1);
                        }
                        break;
                    case "down":
                        if (column < height - 1 && maze[row][column + 1] == 0)
                        {
                            chessboard[2 * row + 1][2 * column + 2] = 1;
                            makeRoute(row, column + 1);
                        }
                        break;
                    case "left":
                        if (row > 0 && maze[row - 1][column] == 0)
                        {
                            chessboard[2 * row][2 * column + 1] = 1;
                            makeRoute(row - 1, column);
                        }
                        break;
                    case "right":
                        if (row < width - 1 && maze[row + 1][column] == 0)
                        {
                            chessboard[2 * row + 2][2 * column + 1] = 1;
                            makeRoute(row + 1, column);
                        }
                        break;
                }
            }
        }


    }

    void Start()
    {
        transform.localScale = new Vector3(5 * width, 5 * height);
        makeMaze();
    }
}
