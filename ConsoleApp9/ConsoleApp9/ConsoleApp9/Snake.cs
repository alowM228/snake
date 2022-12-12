using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp9
{

     public class Snake
     {
        
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'w';
        char dir = 'u';

        public List<Position> snakeBody { get; set; }

        public int x { get; set; }
        public int y { get; set; }
        public int score { get; set; }




        public Snake()
        {
            x = 20;
            y = 20;
            score = 0;

            snakeBody = new List<Position>();
            snakeBody.Add(new Position(x, y));
        }
        



        public void drawSnake()
        {
            foreach(Position pos in snakeBody)
            { 

            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write("0");

            }
        }

        public void Input()
        {
            if(Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }

        private void direction ()
        {
            if (key == 'w' && dir != 'd')
            {
                dir = 'u';
            }
            else if (key == 's' && dir != 'u')
            {
                dir = 'd';
            }
            else if (key == 'd' && dir != 'l')
            {
                dir = 'r';
            }
            else if (key == 'a' && dir != 'r')
            {
                dir = 'l';
            }

        }

        public void moveSnake()
        {
            direction();
            if (dir == 'u')
            {
                y--;
            }
            else if (dir == 'd')
            {
                y++;
            }
            else if (dir == 'r')
            {
                x++;
            }
            else if (dir == 'l')
            {
                x--;
            }
            snakeBody.Add(new Position(x, y));
            snakeBody.RemoveAt(0);
            Thread.Sleep(100);
        }


        public void Eat (Position food, Food f)
        {

            Position head = snakeBody[snakeBody.Count - 1];

            if(head.x == food.x && head.y == food.y)
            {

                snakeBody.Add(new Position(x, y));
                f.foodNewLocation();
                score++;

            }
        }

        public void hitWall (Canvas canvas)
         {

            Position head = snakeBody[snakeBody.Count - 1];
            if (head.x >= canvas.Width || head.x <= 0 || head.y >= canvas.Height || head.y <=0 )
            {

                throw new SnakeException("ВЫ ПРОИГРАЛИ");
            }

         }




     }

}
