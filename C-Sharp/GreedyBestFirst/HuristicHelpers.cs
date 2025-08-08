using System;

namespace GreedyBestFirst;

public static class HuristicHelpers
{
    public static int GetHuristic(this Node current, Node goal) => Math.Abs(current.X - goal.X) + Math.Abs(current.Y - goal.Y);
}
