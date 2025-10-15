using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace impossible_game
{
    public class Snake
    {
        private List<(int x, int y)> body = new List<(int, int)>();
        private bool alive = true;
        private bool shouldGrow = false;

        public Snake(int startX, int startY) =>
            body.Add((startX, startY));

        public (int x, int y) Head => body[0];
        public bool IsAlive => alive;

        public void Move(int dx, int dy)
        {
            if (!alive) return;
            var head = body[0];
            var newHead = (head.x + dx, head.y + dy);

            // Check self-collision
            alive = !body.Contains(newHead);

            // Add new head
            body.Insert(0, newHead);

            // Remove tail unless growing
            if (shouldGrow)
                shouldGrow = false;
            else
                body.RemoveAt(body.Count - 1);
        }

        public void Grow() => shouldGrow = true;
        public void Die() => alive = false;
        public bool IsAt(int x, int y) => body.Contains((x, y));
    }
}
