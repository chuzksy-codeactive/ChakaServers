using System.Collections.Generic;

namespace ChakaServers
{
    #region ServerLogic
    public class ServerLogic : IServerLogic
    {
        private void AddUpdatedStateToQueue(List<List<int>> grid, Queue<Server> server, int i, int j, int dayUpdated)
        {
            // This is the updated state in the mesh
            grid[i][j] = 1;

            // Adding the updatedState to the server
            Server s = new Server
            {
                i = i,
                j = j,
                dayUpdated = dayUpdated
            };

            server.Enqueue(s);
        }

        private void UpdateAdjacentServer(List<List<int>> grid, Queue<Server> server, int i, int j, int dayUpdated)
        {
            // Tranverse the adjacent cells of an updated state (1) Up, Down, Left, Right
            // If there's a non updated state (0), convert it to an updated state


            // Up
            if (i - 1 >= 0 && grid[i - 1][j] == 0)
            {
                AddUpdatedStateToQueue(grid, server, i - 1, j, dayUpdated);
            }

            // Down
            if (i + 1 < grid.Count && grid[i + 1][j] == 0)
            {
                AddUpdatedStateToQueue(grid, server, i + 1, j, dayUpdated);
            }

            // Left
            if (j - 1 >= 0 && grid[i][j - 1] == 0)
            {
                AddUpdatedStateToQueue(grid, server, i, j - 1, dayUpdated);
            }

            // Right
            if (j + 1 < grid[i].Count && grid[i][j + 1] == 0)
            {
                AddUpdatedStateToQueue(grid, server, i, j + 1, dayUpdated);
            }
        }

        public int UpdateServer(List<List<int>> grid)
        {
            int noOfDays = 0;

            // Create a queue that holds the updated states.
            Queue<Server> s = new Queue<Server>();

            // Iterate the servers in the grid to add the initial updated state to the queue.
            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid[i].Count; j++)
                {
                    // If the cell is updated
                    if (grid[i][j] == 1)
                    {
                        AddUpdatedStateToQueue(grid, s, i, j, 0);
                    }
                }
            }

            // Process each updated state in the queue by updated any cell adjacent to it
            while (s.Count > 0)
            {
                Server svr = s.Peek();
                s.Dequeue();

                // Update the number of days variable 
                noOfDays = svr.dayUpdated;

                // Update the state of the adjacent cell
                UpdateAdjacentServer(grid, s, svr.i, svr.j, svr.dayUpdated + 1);
            }

            return noOfDays;
        }
    }
    #endregion
}
